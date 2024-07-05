using System.Collections.Generic;
using System.Linq;

namespace Geode;
public static class PolygonExtensions
{
    public static Polygon ToPolygon(this IEnumerable<IEnumerable<double[]>> rings)
    {
        var posArray = rings.Select(ring => ring.Select((p, i) =>
        {
            var x = p.Length > 0 ? p[0] : default;
            var y = p.Length > 1 ? p[1] : default;
            return new Point(x, y) as IPoint;
        }));
        return new Polygon(posArray);
    }
}
