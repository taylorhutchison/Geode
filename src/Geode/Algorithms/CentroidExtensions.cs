using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;

public static class CentroidExtensions
{
    public static IPoint GetCentroid(this Polygon polygon)
    {
        throw new NotImplementedException();
    }

    public static IPoint GetCentroid(this Polygon polygon, bool inside)
    {
        throw new NotImplementedException();
    }

    public static IPoint? GetCentroid(this IEnumerable<IPoint> pointList)
    {
        if (!pointList.Any()) return default;
        var xSum = 0.0;
        var ySum = 0.0;
        var zSum = 0.0;
        var count = 0;
        foreach (var point in pointList)
        {
            if (point != null)
            {
                xSum += point.X;
                ySum += point.Y;
                zSum += point.Z;
                count++;
            }
        }
        if (count == 0) return default;
        return new Point(xSum / count, ySum / count, zSum / count);
    }

    public static IPoint GetCentroid(this Bounds bounds)
    {
        return new Point((bounds.XMin + bounds.XMax) / 2, (bounds.YMin + bounds.YMax) / 2, (bounds.ZMin + bounds.ZMax) / 2);
    }
}
