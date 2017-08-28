using System;
using System.Collections.Generic;
using System.Text;
using Geode.Attributes;
using Geode.Geometries;

namespace Geode.Tests.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Geometry(GeoType.Polyline)]
        public IEnumerable<IEnumerable<int>> FlightPath { get; set; }
    }
}
