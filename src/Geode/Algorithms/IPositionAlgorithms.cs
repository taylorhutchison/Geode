using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public static class IPositionAlgorithms
{
    public static IPosition Centroid(this IEnumerable<IPosition> pointList)
    {
        var coords = pointList.Select(p => p.Position);
        var dimensions = coords.FirstOrDefault().Count();
        var coordinates = new double[dimensions];
        for (var i = 0; i < dimensions; i++)
        {
            coordinates[i] = coords.Average(c => c[i]);
        }
        return new Point(coordinates);
    }
}
