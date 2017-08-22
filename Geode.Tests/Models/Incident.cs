using System;
using System.Collections.Generic;
using System.Text;
using Geode.Attributes;
using Geode.Geometries;

namespace Geode.Tests.Models
{
    [Feature]
    public class Incident
    {
        public string Description { get; set; }
        [Geometry(GeoType.Polyline)]
        public IEnumerable<Point> Route { get; set; }
    }
}
