using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public record MultiPolygon : IMultiPolygon
{
    public GeometryType Type => GeometryType.MultiPolyline;
    object? IGeometry.Geometry => Geometry;
    public IEnumerable<IPolygon>? Geometry { get; private set; }
    public bool IsValid => throw new NotImplementedException();
    public MultiPolygon(IEnumerable<Polygon> polygons)
    {
        Geometry = polygons;
    }
    public MultiPolygon() { }
}
