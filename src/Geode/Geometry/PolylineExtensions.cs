using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public static class PolylineExtensions
{
    public static Polyline ToPolyline(this IEnumerable<double[]> positions)
    {   
        var posArray = new List<IPoint>();
        int? pointLength = null;
        foreach(var position in positions){
            pointLength = pointLength ?? position.Length;
            if (pointLength != position.Length)
            {
                throw new GeodeGeometryException("Failed to create a polyline. All positions must have the same number of coordinates.");
            }
            else if (position.Length < 2)
            {
                throw new GeodeGeometryException("Failed to create a polyline. Each position must have at least 2 coordinates.");
            }
            else if (position.Length == 2)
            {
                var x = position.Length > 0 ? position[0] : default;
                var y = position.Length > 1 ? position[1] : default;
                posArray.Add(new Point2D(x, y));
            }
            else
            {
                var x = position.Length > 0 ? position[0] : default;
                var y = position.Length > 1 ? position[1] : default;
                var z = position.Length > 2 ? position[2] : default;
                posArray.Add(new Point3D(x, y, z));
            }
        };
        return new Polyline(posArray);
    }

    public static Polyline<IPoint2D> ToPolyline(this IEnumerable<IPoint2D> points)
    {
        return new Polyline<IPoint2D>(points);
    }

    public static Polyline<IPoint3D> ToPolyline(this IEnumerable<IPoint3D> points)
    {
        return new Polyline<IPoint3D>(points);
    }
}
