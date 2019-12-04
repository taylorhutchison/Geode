using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    public class Incident
    {
        public string Description { get; set; }
        public IEnumerable<Point> Route { get; set; }
    }
}
