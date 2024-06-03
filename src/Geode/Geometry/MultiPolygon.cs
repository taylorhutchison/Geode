using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public class MultiPolygon : IMultiPolygon
{
    public GeometryType Type => GeometryType.MultiPolyline;
    object IGeometry.Coordinates => Coordinates;
    public IEnumerable<IEnumerable<IEnumerable<IPoint>>> Coordinates { get; private set; }
    public MultiPolygon(IEnumerable<Polygon> polygons)
    {
        Coordinates = polygons.Select(p => p.Coordinates);
    }
    public MultiPolygon() { }
    public Bounds Bounds { get; set; }
    public IEnumerable Geometry => Coordinates;
}
