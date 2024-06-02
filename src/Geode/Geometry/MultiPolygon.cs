using System;
using System.Collections;
using System.Collections.Generic;

namespace Geode;
public class MultiPolygon : IGeometry
{
    public GeometryType Type => GeometryType.MultiPolyline;
    public IEnumerable Coordinates { get; private set; }
    public MultiPolygon(IEnumerable<IEnumerable<IPosition>> coordinates)
    {
        Coordinates = coordinates;
    }
    public MultiPolygon() { }
    public Bounds Bounds { get; set; }
    public IEnumerable Geometry => Coordinates;
    public bool Equals(IGeometry other)
    {
        throw new NotImplementedException();
    }
}
