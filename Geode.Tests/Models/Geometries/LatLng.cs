using System;
using System.Collections.Generic;
using System.Text;
using Geode.Attributes;
using Geode.Geometries;

namespace Geode.Tests.Models
{
    [Geometry(GeoType.Point, "Lng", "Lat")]
    public class LatLng
    {
        public LatLng() { }
        public LatLng(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
