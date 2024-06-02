using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.FeatureTests.Models
{
    public class Incident
    {
        public string Description { get; set; }
        public IEnumerable<Point> Route { get; set; }
    }
}
