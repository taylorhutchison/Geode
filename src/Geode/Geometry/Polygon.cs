using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Diagnostics.Contracts;
using System.Dynamic;

namespace Geode;
public record Polygon : IPolygon
{
    public GeometryType Type => GeometryType.Polygon;
    object IGeometry.Geometry => Geometry;
    public (IEnumerable<IPoint> Boundary, IEnumerable<IEnumerable<IPoint>>? Holes) Geometry { get; private set; }
    public bool IsValid => throw new NotImplementedException();
    public Polygon()
    {

    }
    public Polygon(IEnumerable<IPoint> boundary, IEnumerable<IEnumerable<IPoint>>? holes = null)
    {
        Geometry = (boundary, holes);
    }

}
