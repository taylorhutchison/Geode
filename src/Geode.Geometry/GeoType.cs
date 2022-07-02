using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Geode
{
    /// <summary>
    /// The classification of a geometry (e.g. Point, LineString, Polygon, etc.).
    /// </summary>
    public enum GeoType
    {
        Point,
        MultiPoint,
        LineString,
        MultiLineString,
        Polygon,
        MultiPolygon,
        GeometryCollection
    }
}
