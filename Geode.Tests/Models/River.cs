using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.Models
{
    [Feature]
    public class River
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Geometry(GeoType.LineString,"Lng","Lat")]
        public IEnumerable<LatLng> Location { get; set; }
    }
}
