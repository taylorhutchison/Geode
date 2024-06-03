using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Geode;
public class Polygon : IPolygon
{
    public GeometryType Type => GeometryType.Polygon;
    object IGeometry.Coordinates => Coordinates;
    public IEnumerable<IEnumerable<IPoint>> Coordinates { get; private set; }
    public IEnumerable<IPoint> Positions => Coordinates.SelectMany(p => p);
    public Polygon(IEnumerable<IEnumerable<IPoint>> coordinates)
    {
        Coordinates = coordinates;
    }

}
