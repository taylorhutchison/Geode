using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public record QuadTree
{
    private readonly Bounds _bounds;
    private const int _capacity = 4;
    private List<IPoint> _points = new();
    private bool _divided = false;
    public bool Divided => _divided;
    public QuadTree? _northWest;
    public QuadTree? _northEast;
    public QuadTree? _southWest;
    public QuadTree? _southEast;
    public int Count = 0;
    public Bounds bounds => _bounds;
    public QuadTree(Bounds bounds)
    {
        _bounds = bounds;
    }
    public QuadTree(IEnumerable<IPoint> points)
    {
        _bounds = points.GetBounds();
        foreach (var point in points)
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
            if (!_divided)
            {
                Subdivide();
            }

            if (_northWest?.Insert(point) ?? false) { Count++; return true; }
            if (_northEast?.Insert(point) ?? false) { Count++; return true; }
            if (_southWest?.Insert(point) ?? false) { Count++; return true; }
            if (_southEast?.Insert(point) ?? false) { Count++; return true; }
        }

        return false;
    }

    public IPoint? FindNearest(IPoint target)
    {
        IPoint? nearest = null;
        double nearestDist = double.MaxValue;
        QuadTree? toSearch = this;

        while (toSearch != null)
        {
            var current = toSearch;

            foreach (var point in current._points)
            {
                var dist = point.DistanceTo(target, includeZ: false);
                if (dist < nearestDist)
                {
                    nearest = point;
                    nearestDist = dist;
                }
            }
            if (current.Contains(target))
            {
                if (current._divided)
                {
                    if (current._northWest!.Contains(target))
                    {
                        toSearch = current._northWest!;
                    }
                    else if (current._northEast!.Contains(target))
                    {
                        toSearch = current._northEast!;
                    }
                    else if (current._southWest!.Contains(target))
                    {
                        toSearch = current._southWest!;
                    }
                    else if (current._southEast!.Contains(target))
                    {
                        toSearch = current._southEast!;
                    }
                    else
                    {
                        toSearch = null;
                    }
                }
                else
                {
                    toSearch = null;
                }
            }
            else if (current._divided)
            {
                var nearestQuad = double.MaxValue;
                var northWestDist = current._northWest!._bounds.DistanceFromCentroid(target, false);
                var northEastDist = current._northEast!._bounds.DistanceFromCentroid(target, false);
                var southWestDist = current._southWest!._bounds.DistanceFromCentroid(target, false);
                var southEastDist = current._southEast!._bounds.DistanceFromCentroid(target, false);
                if (northWestDist < nearestQuad)
                {
                    nearestQuad = northWestDist;
                    toSearch = current._northWest;
                }
                if (northEastDist < nearestQuad)
                {
                    nearestQuad = northEastDist;
                    toSearch = current._northEast;
                }
                if (southWestDist < nearestQuad)
                {
                    nearestQuad = southWestDist;
                    toSearch = current._southWest;
                }
                if (southEastDist < nearestQuad)
                {
                    nearestQuad = southEastDist;
                    toSearch = current._southEast;
                }
            }
            else
            {
                toSearch = null;
            }
        }

        return nearest;
    }

    public bool Contains(IPoint point)
    {
        return _bounds.Contains(point, includeZ: false);
    }

    private void Subdivide()
    {
        _northWest = new QuadTree(new Bounds(_bounds.XMin, _bounds.XMax / 2, _bounds.YMax / 2, _bounds.YMax));
        _northEast = new QuadTree(new Bounds(_bounds.XMax / 2, _bounds.XMax, _bounds.YMax / 2, _bounds.YMax));
        _southWest = new QuadTree(new Bounds(_bounds.XMin, _bounds.XMax / 2, _bounds.YMin, _bounds.YMax / 2));
        _southEast = new QuadTree(new Bounds(_bounds.XMax / 2, _bounds.XMax, _bounds.YMin, _bounds.YMax / 2));
        _divided = true;
    }
}
