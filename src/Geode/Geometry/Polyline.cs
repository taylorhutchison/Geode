using System.Collections.Generic;
using System.Collections;

namespace Geode;
/// <summary>
/// A Polyline is a geometry type, sometimes refered to as a Polyline, that is represented by an array of positions.
/// </summary>
public class Polyline : IPolyline
{
    public GeometryType Type => GeometryType.Polyline;
    object IGeometry.Geometry => Geometry;
    public IEnumerable<IPoint> Geometry { get; private set; }
    public IEnumerable<IPoint> Positions => Geometry;
    public Polyline(IEnumerable<IPoint> coordinates)
    {
        Geometry = coordinates;
    }
}