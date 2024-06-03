using System.Collections.Generic;
using System.Collections;

namespace Geode;
public class MultiPolyline : IGeometry<IEnumerable<IEnumerable<IPoint>>>
{
    public GeometryType Type => GeometryType.MultiPolyline;
    object IGeometry.Coordinates => Coordinates;
    public IEnumerable<IEnumerable<IPoint>> Coordinates { get; private set; }
    public Bounds Bounds { get; set; }
    public MultiPolyline(IEnumerable<IEnumerable<IPoint>> coordinates)
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
