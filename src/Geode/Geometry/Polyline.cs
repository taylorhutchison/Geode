using System.Collections.Generic;
using System.Collections;

namespace Geode;
/// <summary>
/// A Polyline is a geometry type, sometimes refered to as a Polyline, that is represented by an array of positions.
/// </summary>
public class Polyline : IGeometry<IEnumerable<IPoint>>, IPoly
{
    private IEnumerable<IPoint> _coordinates;
    public GeometryType Type => GeometryType.Polyline;
    object IGeometry.Coordinates => Coordinates;
    public IEnumerable<IPoint> Coordinates => _coordinates;
    public Bounds Bounds { get; set; }
    public IEnumerable<IPoint> Positions => _coordinates;
    public Polyline(IEnumerable<IPoint> coordinates)
    {
        _coordinates = coordinates;
    }

}
