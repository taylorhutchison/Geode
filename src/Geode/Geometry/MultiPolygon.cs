using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public class MultiPolygon : IMultiPolygon
{
    public GeometryType Type => GeometryType.MultiPolyline;
    object IGeometry.Geometry => Geometry;
    public IEnumerable<IEnumerable<IEnumerable<IPoint>>> Geometry { get; private set; }
    public MultiPolygon(IEnumerable<Polygon> polygons)
    {
        Geometry = polygons.Select(p => p.Geometry);
    }
    public MultiPolygon() { }
}
