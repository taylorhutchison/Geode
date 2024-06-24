using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Diagnostics.Contracts;
using System.Dynamic;

namespace Geode;
public class Polygon : IPolygon
{
    public GeometryType Type => GeometryType.Polygon;
    object IGeometry.Geometry => Geometry;
    public IEnumerable<IEnumerable<IPoint>> Geometry { get; private set; }
    public IEnumerable<IPoint> Positions => Geometry.SelectMany(p => p);

    public void AddRing(IEnumerable<IPoint> ring)
    {
        Geometry = Geometry.Append(ring);
    }

    public Polygon()
    {
        Geometry = Enumerable.Empty<IPoint[]>().ToArray();
    }

    public Polygon(IEnumerable<IEnumerable<IPoint>> rings)
    {
        Geometry = rings;
    }

}
