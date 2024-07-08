using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Geode;
public static class BoundsExtensions
{
    public static Bounds GetBounds(this IEnumerable<IPoint>? points)
    {
        var (xMin, xMax, yMin, yMax, zMin, zMax) = (0d, 0d, 0d, 0d, 0d, 0d);
        if (points != null)
        {
            foreach (var point in points)
            {
                if (xMin > point.X) xMin = point.X;
                if (xMax < point.X) xMax = point.X;
                if (yMin > point.Y) yMin = point.Y;
                if (yMax < point.Y) yMax = point.Y;
                if (zMin > point.Z) zMin = point.Z;
                if (zMax < point.Z) zMax = point.Z;
            }
        }
        return new Bounds(xMin, xMax, yMin, yMax, zMin, zMax);
    }

    public static Bounds? GetBounds(this IPolyline polyline)
    {
        return GetBounds(polyline?.Geometry);
    }
    public static Bounds GetBounds(this IEnumerable<Bounds> bounds)
    {
        var xMin = bounds.Min(b => b.XMin);
        var xMax = bounds.Max(b => b.XMax);
        var yMin = bounds.Min(b => b.YMin);
        var yMax = bounds.Max(b => b.YMax);
        var zMin = bounds.Min(b => b.ZMin);
        var zMax = bounds.Min(b => b.ZMax);
        return new Bounds(xMin, xMax, yMin, yMax, zMin, zMax);
    }

    public static Bounds GetBounds<T>(this IEnumerable<IFeature<T>> features) where T : IPoint
    {
        var locations = features.Where(f => f.Location != null).Select(f => f.Location! as IPoint);
        return GetBounds(locations);
    }

    public static bool Contains(this Bounds bounds, double x, double y) {
        return x >= bounds.XMin && x <= bounds.XMax &&
               y >= bounds.YMin && y <= bounds.YMax;
    }

    public static bool Contains(this Bounds bounds, double x, double y, double z) {
        return x >= bounds.XMin && x <= bounds.XMax &&
               y >= bounds.YMin && y <= bounds.YMax &&
               z >= bounds.ZMin && z <= bounds.ZMax;
    }

    public static bool Contains(this Bounds bounds, IPoint point, bool includeZ = true)
    {
        return includeZ ? Contains(bounds, point.X, point.Y, point.Z) : Contains(bounds, point.X, point.Y);
    }

    public static double DistanceFromCentroid(this Bounds bounds, double x, double y, double? z = null)
    {
        var boundsCentroid = bounds.GetCentroid();
        return boundsCentroid.DistanceTo(x, y, z);
    }

    public static double DistanceFromCentroid(this Bounds bounds, IPoint point, bool includeZ = true)
    {
        var boundsCentroid = bounds.GetCentroid();
        return boundsCentroid.DistanceTo(point, includeZ);
    }

    public static double DistanceFromEdge(this Bounds bounds, double x, double y, double z = 0)
    {
        var dx = bounds.XMin > x || bounds.XMax < x ? Math.Min(Math.Abs(bounds.XMin - x), Math.Abs(bounds.XMax - x)) : 0;
        var dy = bounds.YMin > y || bounds.YMax < y ? Math.Min(Math.Abs(bounds.YMin - y), Math.Abs(bounds.YMax - y)) : 0;
        var dz = z != 0 ? bounds.ZMin > z || bounds.ZMax < z ? Math.Min(Math.Abs(bounds.ZMin - z), Math.Abs(bounds.ZMax - z)) : 0 : 0;
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }

    public static double DistanceFromEdge(this Bounds bounds, IPoint point, bool includeZ = true)
    {
        return includeZ ? DistanceFromEdge(bounds, point.X, point.Y, point.Z) : DistanceFromEdge(bounds, point.X, point.Y);
    }
}
