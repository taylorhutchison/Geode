using System;
using System.Collections.Generic;

namespace Geode;
public record QuadTree
{
    private readonly Bounds _bounds;
    private const int _capacity = 4;
    private List<IPoint> _points = new();
    private bool divided = false;
    public bool Divided => divided;
    private QuadTree? northWest;
    private QuadTree? northEast;
    private QuadTree? southWest;
    private QuadTree? southEast;
    public int Count = 0;
    public QuadTree(Bounds bounds)
    {
        _bounds = bounds;
    }
    public QuadTree(IEnumerable<IPoint> points)
    {
        _bounds = points.GetBounds();
        foreach(var point in points)
        {
            Insert(point);
        }
    }
    public bool Insert(IPoint point)
    {
        if (!_bounds.Contains(point))
        {
            return false;
        }

        if (_points.Count < _capacity)
        {
            _points.Add(point);
            Count++;
            return true;
        }
        else
        {
            if (!divided)
            {
                Subdivide();
            }

            if (northWest?.Insert(point) ?? false) { Count++; return true; }
            if (northEast?.Insert(point) ?? false) { Count++; return true; }
            if (southWest?.Insert(point) ?? false) { Count++; return true; }
            if (southEast?.Insert(point) ?? false) { Count++; return true; }
        }

        return false;
    }

    public IPoint? FindNearest(IPoint target)
    {
        IPoint? nearest = null;
        double nearestDist = double.MaxValue;

        Queue<QuadTree> toSearch = new Queue<QuadTree>();
        toSearch.Enqueue(this);

        while (toSearch.Count > 0)
        {
            var current = toSearch.Dequeue();
            if (current._bounds.DistanceFromCentroid(target, false) < nearestDist)
            {
                foreach (var point in current._points)
                {
                    var dist = point.DistanceTo(target, includeZ: false);
                    if (dist < nearestDist)
                    {
                        nearest = point;
                        nearestDist = dist;
                    }
                }

                if (current.divided)
                {
                    toSearch.Enqueue(current.northWest!);
                    toSearch.Enqueue(current.northEast!);
                    toSearch.Enqueue(current.southWest!);
                    toSearch.Enqueue(current.southEast!);
                }
            }
        }

        return nearest;
    }

    private void Subdivide()
    {
        northWest = new QuadTree(new Bounds(_bounds.XMin, _bounds.XMax / 2, _bounds.YMin / 2, _bounds.YMax));
        northEast = new QuadTree(new Bounds(_bounds.XMin / 2, _bounds.XMax, _bounds.YMin / 2, _bounds.YMax));
        southWest = new QuadTree(new Bounds(_bounds.XMin, _bounds.XMax / 2, _bounds.YMin, _bounds.YMax / 2));
        southEast = new QuadTree(new Bounds(_bounds.XMin / 2, _bounds.XMax, _bounds.YMin, _bounds.YMax / 2));
        divided = true;
    }
}
