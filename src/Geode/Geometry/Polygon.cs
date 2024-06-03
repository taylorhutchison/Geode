using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Geode;
public class Polygon : IGeometry<IEnumerable<IEnumerable<IPosition>>>, IPoly, IGeometry
{
    private IEnumerable<IEnumerable<IPosition>> _coordinates;
    public GeometryType Type => GeometryType.Polygon;
    public Bounds Bounds { get; set; }
    public IEnumerable Coordinates => _coordinates;
    public IEnumerable<IEnumerable<IPosition>> TypedCoordinates => _coordinates;
    public IEnumerable<IPosition> Positions => _coordinates.SelectMany(p => p);
    public Polygon(IEnumerable<IEnumerable<IPosition>> coordinates)
    {
        _coordinates = coordinates;
    }
    public bool Equals(IGeometry other)
    {
        throw new NotImplementedException();
    }

}
