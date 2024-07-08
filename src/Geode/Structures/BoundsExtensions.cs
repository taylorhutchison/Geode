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

    public static bool Contains(this Bounds bounds, IPoint point, bool includeZ = true)
    {
        return point.X >= bounds.XMin && point.X <= bounds.XMax &&
               point.Y >= bounds.YMin && point.Y <= bounds.YMax &&
               (!includeZ || point.Z >= bounds.ZMin && point.Z <= bounds.ZMax);
    }

    public static double DistanceFromCentroid(this Bounds bounds, IPoint point, bool includeZ = true)
    {
        var boundsCentroid = bounds.GetCentroid();
        return boundsCentroid.DistanceTo(point);
    }

    public static double DistanceFromEdge(this Bounds bounds, IPoint point, bool includeZ = true)
    {
        var x = bounds.XMin > point.X || bounds.XMax < point.X ? Math.Min(Math.Abs(bounds.XMin - point.X), Math.Abs(bounds.XMax - point.X)) : 0;
        var y = bounds.YMin > point.Y || bounds.YMax < point.Y ? Math.Min(Math.Abs(bounds.YMin - point.Y), Math.Abs(bounds.YMax - point.Y)) : 0;
        var z = includeZ ? bounds.ZMin > point.Z || bounds.ZMax < point.Z ? Math.Min(Math.Abs(bounds.ZMin - point.Z), Math.Abs(bounds.ZMax - point.Z)) : 0 : 0;
        return Math.Sqrt(x * x + y * y + z * z);
    }
}
