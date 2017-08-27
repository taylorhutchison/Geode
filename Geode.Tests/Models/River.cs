using System;
using System.Collections.Generic;
using System.Text;
using Geode.Attributes;
using Geode.Geometries;

namespace Geode.Tests.Models
{
    [Feature]
    public class River
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Geometry(GeoType.Polyline,"Lng","Lat")]
        public IEnumerable<LatLng> Location { get; set; }
    }
}
