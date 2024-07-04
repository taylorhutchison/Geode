using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public static class IPositionAlgorithms
{
    public static Point2D? Centroid(this IEnumerable<IPoint2D> pointList)
    {
        if (!pointList.Any()) return default;
        var xSum = 0.0;
        var ySum = 0.0;
        var count = 0;
        foreach (var point in pointList)
        {
            if (point != null)
            {
                xSum += point.X;
                ySum += point.Y;
                count++;
            }
        }
        if (count == 0) return default;
        return new Point2D(xSum / count, ySum / count);
    }

    public static Point3D? Centroid(this IEnumerable<IPoint3D> pointList)
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
        return new Point3D(xSum / count, ySum / count, zSum / count);
    }
}
