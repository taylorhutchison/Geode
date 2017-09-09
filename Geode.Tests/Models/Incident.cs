using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    [Feature]
    public class Incident
    {
        public string Description { get; set; }
        [Geometry(GeoType.LineString)]
        public IEnumerable<Point> Route { get; set; }
    }
}
