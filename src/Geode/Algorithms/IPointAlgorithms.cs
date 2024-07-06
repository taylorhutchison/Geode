using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public static class IPointAlgorithms
{
    public static double DistanceTo(this IPoint position, IPoint other, bool includeZ = true)
    {
        var dx2 = Math.Pow(position.X - other.X, 2);
        var dy2 = Math.Pow(position.Y - other.Y, 2);
        var dz2 = includeZ ? Math.Pow(position.Z - other.Z, 2) : 0;
        return Math.Sqrt(dx2 + dy2 + dz2);
    }
}
