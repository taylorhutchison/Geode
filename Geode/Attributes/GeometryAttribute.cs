using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode
{
    public class GeometryAttribute : Attribute
    {
        public GeoType Type { get; set; }
        public GeoTypeMap Map { get; set; }

        public GeometryAttribute(GeoType type)
        {
            Type = type;
        }

        public GeometryAttribute(GeoType type, GeoTypeMap map)
        {
            Type = type;
            Map = map;
        }

        public GeometryAttribute(GeoType type, string xMap, string yMap)
        {
            Type = type;
            Map = new GeoTypeMap(xMap, yMap);
        }
    }
}
