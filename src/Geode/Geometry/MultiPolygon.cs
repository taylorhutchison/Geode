using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public class MultiPolygon : IGeometry<IEnumerable<IEnumerable<IEnumerable<IPosition>>>>
{
    public GeometryType Type => GeometryType.MultiPolyline;
    object IGeometry.Coordinates => Coordinates;
    public IEnumerable<IEnumerable<IEnumerable<IPosition>>> Coordinates { get; private set; }
    public MultiPolygon(IEnumerable<Polygon> polygons)
    {
        Coordinates = polygons.Select(p => p.Coordinates);
    }
    public MultiPolygon() { }
    public Bounds Bounds { get; set; }
    public IEnumerable Geometry => Coordinates;
    public bool Equals(IGeometry other)
    {
        throw new NotImplementedException();
    }
}
