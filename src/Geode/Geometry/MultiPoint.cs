using System;
using System.Collections;
using System.Collections.Generic;

namespace Geode;
public class MultiPoint : IGeometry<IEnumerable<IPoint>>
{
    public GeometryType Type => GeometryType.MultiPoint;
    object IGeometry.Geometry => Geometry;
    public IEnumerable<IPoint> Geometry { get; set; }
    public MultiPoint(IEnumerable<IPoint> coordinates)
    {
        Geometry = coordinates;
    }
}
