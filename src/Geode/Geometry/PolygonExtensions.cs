using System.Collections.Generic;
using System.Linq;

namespace Geode;
public static class PolygonExtensions
{
    public static Polygon ToPolygon(this IEnumerable<double[]> boundary, IEnumerable<IEnumerable<double[]>>? holes = null)
    {
        var posArray = boundary.Select((p, i) =>
        {
            var x = p.Length > 0 ? p[0] : default;
            var y = p.Length > 1 ? p[1] : default;
            var z = p.Length > 2 ? p[2] : default;
            return new Point(x, y, z) as IPoint;
        });

        var holesArray = holes?.Select(ring => ring.Select((p, i) =>
        {
            var x = p.Length > 0 ? p[0] : default;
            var y = p.Length > 1 ? p[1] : default;
            var z = p.Length > 2 ? p[2] : default;
            return new Point(x, y, z) as IPoint;
        }));
        
        return new Polygon(posArray, holesArray);
    }
}
