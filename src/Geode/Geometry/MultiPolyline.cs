using System.Collections.Generic;
using System.Collections;

namespace Geode;
public class MultiPolyline : IGeometry<IEnumerable<IEnumerable<IPosition>>>
{
    public GeometryType Type => GeometryType.MultiPolyline;
    object IGeometry.Coordinates => Coordinates;
    public IEnumerable<IEnumerable<IPosition>> Coordinates { get; private set; }
    public Bounds Bounds { get; set; }
    public MultiPolyline(IEnumerable<IEnumerable<IPosition>> coordinates)
    {
        Coordinates = coordinates;
    }
    public MultiPolyline() { }
    public IEnumerable Geometry => Coordinates;
    public bool Equals(IGeometry other)
    {
        return Type == other.Type;
    }
}
