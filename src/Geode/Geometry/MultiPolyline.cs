using System.Collections.Generic;
using System.Collections;

namespace Geode;
public record MultiPolyline : IMultiPolyline
{
    public GeometryType Type => GeometryType.MultiPolyline;
    object? IGeometry.Geometry => Geometry;
    public IEnumerable<IPolyline>? Geometry { get; private set; }
    public MultiPolyline(IEnumerable<IPolyline> polylines)
    {
        Geometry = polylines;
    }
    public MultiPolyline() { }
}
