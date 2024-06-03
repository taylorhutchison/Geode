using System.Collections.Generic;
using System.Collections;

namespace Geode;
/// <summary>
/// A Polyline is a geometry type, sometimes refered to as a Polyline, that is represented by an array of positions.
/// </summary>
public class Polyline : IGeometry<IEnumerable<IPosition>>, IPoly
{
    private IEnumerable<IPosition> _coordinates;
    public GeometryType Type => GeometryType.Polyline;
    object IGeometry.Coordinates => Coordinates;
    public IEnumerable<IPosition> Coordinates => _coordinates;
    public Bounds Bounds { get; set; }
    public IEnumerable<IPosition> Positions => _coordinates;
    public Polyline(IEnumerable<IPosition> coordinates)
    {
        _coordinates = coordinates;
    }

}
