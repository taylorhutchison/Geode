using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;
using System.Linq;

namespace Geode.Services
{
    internal static class GeometryService
    {
        
    }

    public static class GeometryExtensions
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
            return new Point()
            {
                Coordinates = coordinates
            };
        }
    }
}
