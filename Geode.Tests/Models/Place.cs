using System;
using System.Collections.Generic;
using System.Text;
using Geode.Attributes;
using Geode.Geometries;

namespace Geode.Tests.Models
{
    [Feature]
    public class Place
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Geometry(GeoType.Point, "Lat", "Lng")]
        public LatLng Location { get; set; }
    }
}
