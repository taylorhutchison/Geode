using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public static class PolylineExtensions
{
    public static Polyline ToPolyline(this IEnumerable<double[]> positions)
    {
        var posArray = positions.Select((p, i) =>
        {
            if (p.Length < 2)
            {
                throw new ArgumentException("Failed to creat a polyline. Each position must have at least 2 coordinates.");
            }
            else if (p.Length == 2)
            {
                var x = p.Length > 0 ? p[0] : default;
                var y = p.Length > 1 ? p[1] : default;
                return new Point2D(x, y) as IPoint;
            }
            else
            {
                var x = p.Length > 0 ? p[0] : default;
                var y = p.Length > 1 ? p[1] : default;
                var z = p.Length > 2 ? p[2] : default;
                return new Point3D(x, y, z) as IPoint;
            }
        });
        return new Polyline(posArray);
    }
}
