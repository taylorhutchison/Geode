using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Geode.Geometry
{
    public static class PolylineExtensions
    {
        public static Polyline ToPolyline(this IEnumerable<double[]> positions)
        {
            var posArray = positions.Select((p, i) =>
            {
                var x = p.Length > 0 ? p[0] : default(double);
                var y = p.Length > 1 ? p[1] : default(double);
                var z = p.Length > 2 ? p[2] : default(double);
                return new Position(x, y, z) as IPosition;
            });
            return new Polyline(posArray);
        }
    }
}
