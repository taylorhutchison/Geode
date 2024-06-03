using System;
using System.Collections;
using System.Collections.Generic;

namespace Geode;
public class MultiPoint : IGeometry<IEnumerable<IPosition>>
{
    public GeometryType Type => GeometryType.MultiPoint;
    object IGeometry.Coordinates => Coordinates;
    public IEnumerable<IPosition> Coordinates { get; set; }
    public MultiPoint(IEnumerable<IPosition> coordinates)
    {
        Coordinates = coordinates;
    }
    public IEnumerable Geometry => Coordinates;
    public Bounds Bounds { get; set; }
}
