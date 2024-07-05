using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Geode;
public static class BoundsExtensions
{
    public static Bounds GetBounds(IEnumerable<IPoint> points)
    {
        var bounds = new Bounds();
        foreach (var point in points)
        {
            if (bounds.XMax < point.X) bounds.XMax = point.X;
            if (bounds.XMin > point.X) bounds.XMin = point.X;
            if (bounds.YMax < point.Y) bounds.YMax = point.Y;
            if (bounds.YMin > point.Y) bounds.YMin = point.Y;
            if (bounds.ZMax < point.Z) bounds.ZMax = point.Z;
            if (bounds.ZMin > point.Z) bounds.ZMin = point.Z;
        }
        return bounds;
    }

    public static Bounds? GetBounds(this IPolyline polyline)
    {
        var bounds = new Bounds();
        if (polyline?.Geometry != null)
        {
            foreach (var point in polyline.Geometry)
            {
                if (point != null)
                {
                    if (bounds.XMax < point.X) bounds.XMax = point.X;
                    if (bounds.XMin > point.X) bounds.XMin = point.X;
                    if (bounds.YMax < point.Y) bounds.YMax = point.Y;
                    if (bounds.YMin > point.Y) bounds.YMin = point.Y;
                    if (bounds.ZMax < point.Z) bounds.ZMax = point.Z;
                    if (bounds.ZMin > point.Z) bounds.ZMin = point.Z;
                }
            }
            return bounds;
        }
        return null;
    }
    public static Bounds GetBounds(this IEnumerable<Bounds> bounds)
    {
        return new Bounds
        {
            XMin = bounds.Min(b => b.XMin),
            XMax = bounds.Max(b => b.XMax),
            YMin = bounds.Min(b => b.YMin),
            YMax = bounds.Max(b => b.YMax),
            ZMin = bounds.Min(b => b.ZMin),
            ZMax = bounds.Min(b => b.ZMax)
        };
    }
}
