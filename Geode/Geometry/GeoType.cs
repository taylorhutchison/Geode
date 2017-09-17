using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Geode
{
    /// <summary>
    /// The classification of a geometry (e.g. Point, LineString, Polygon, etc.).
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
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
