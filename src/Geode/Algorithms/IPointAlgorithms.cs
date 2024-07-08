using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public static class IPointAlgorithms
{
    public static double DistanceTo(this IPoint position, IPoint other, bool includeZ = true)
    {
        return position.DistanceTo(other.X, other.Y, includeZ ? other.Z : 0);
    }

    public static double DistanceTo(this IPoint position, double x, double y, double? z = null)
    {
        var dx2 = Math.Pow(position.X - x, 2);
        var dy2 = Math.Pow(position.Y - y, 2);
        var dz2 = z == null ? 0 : Math.Pow(position.Z - z.Value, 2);
        return Math.Sqrt(dx2 + dy2 + dz2);
    }
}
