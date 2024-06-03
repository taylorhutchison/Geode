using System.Collections.Generic;
using System.Collections;

namespace Geode;
/// <summary>
/// A Polyline is a geometry type, sometimes refered to as a Polyline, that is represented by an array of positions.
/// </summary>
public class Polyline : IPolyline
{
    public GeometryType Type => GeometryType.Polyline;
    object IGeometry.Coordinates => Coordinates;
    public IEnumerable<IPoint> Coordinates { get; private set; }
    public IEnumerable<IPoint> Positions => Coordinates;
    public Polyline(IEnumerable<IPoint> coordinates)
    {
        Coordinates = coordinates;
    }

}
