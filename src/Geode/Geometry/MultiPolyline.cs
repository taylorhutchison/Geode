using System.Collections.Generic;
using System.Collections;

namespace Geode;
public class MultiPolyline : IMultiPolyline
{
    public GeometryType Type => GeometryType.MultiPolyline;
    object? IGeometry.Geometry => Geometry;
    public IEnumerable<IEnumerable<IPoint>>? Geometry { get; private set; }
    public MultiPolyline(IEnumerable<IEnumerable<IPoint>> coordinates)
    {
        Geometry = coordinates;
    }
    public MultiPolyline() { }
}
