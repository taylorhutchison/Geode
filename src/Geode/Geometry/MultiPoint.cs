using System;
using System.Collections;
using System.Collections.Generic;

namespace Geode;
public class MultiPoint : IGeometry<IEnumerable<IPoint>>
{
    public GeometryType Type => GeometryType.MultiPoint;
    object IGeometry.Coordinates => Coordinates;
    public IEnumerable<IPoint> Coordinates { get; set; }
    public MultiPoint(IEnumerable<IPoint> coordinates)
    {
        Coordinates = coordinates;
    }
    public IEnumerable Geometry => Coordinates;
    public Bounds Bounds { get; set; }
}
