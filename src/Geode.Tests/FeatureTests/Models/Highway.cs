using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.FeatureTests.Models
{
    public class Highway
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RoadSegment> Segments { get; set; }
    }
}
