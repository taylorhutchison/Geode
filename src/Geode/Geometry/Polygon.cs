using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Geode;
public class Polygon : IGeometry<IEnumerable<IEnumerable<IPoint>>>, IPoly
{
    private IEnumerable<IEnumerable<IPoint>> _coordinates;
    public GeometryType Type => GeometryType.Polygon;
    public Bounds Bounds { get; set; }
    object IGeometry.Coordinates => Coordinates;
    public IEnumerable<IEnumerable<IPoint>> Coordinates => _coordinates;
    public IEnumerable<IPoint> Positions => _coordinates.SelectMany(p => p);
    public Polygon(IEnumerable<IEnumerable<IPoint>> coordinates)
    {
        _coordinates = coordinates;
    }
    public bool Equals(IGeometry other)
    {
        throw new NotImplementedException();
    }

}
