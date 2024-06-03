using System.Collections.Generic;
using System.Linq;

namespace Geode;
public static class BoundsExtensions
{
    private static Bounds GetBounds(IEnumerable<double[]> poly)
    {
        var bounds = new Bounds();
        foreach (var position in poly)
        {
            if (bounds.XMax < position[0]) bounds.XMax = position[0];
            if (bounds.XMin > position[0]) bounds.XMin = position[0];
            if (bounds.YMax < position[1]) bounds.YMax = position[1];
            if (bounds.YMin > position[1]) bounds.YMin = position[1];
            if (position.Length > 2)
            {
                if (bounds.ZMax < position[2]) bounds.ZMax = position[2];
                if (bounds.ZMin > position[2]) bounds.ZMin = position[2];
            }
        }
        return bounds;
    }
    public static Bounds GetBounds(this IPoint position)
    {
        return new Bounds(position);
    }
    public static Bounds GetBounds(this IPolyline poly)
    {
        return GetBounds(poly.Coordinates);
    }
    public static Bounds GetBounds(this IEnumerable<IPoint> positions)
    {
        var bounds = positions.Select(p => p.GetBounds());
        return GetBounds(bounds);
    }
    public static Bounds GetBounds(this IEnumerable<IPolyline> positions)
    {
        var bounds = positions.Select(p => p.GetBounds());
        return GetBounds(bounds);
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
