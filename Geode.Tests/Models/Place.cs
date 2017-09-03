using System;
using System.Collections.Generic;
using System.Text;

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
