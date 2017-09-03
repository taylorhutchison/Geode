using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.Models
{
    public class Highway
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Geometry(GeoType.GeometryCollection)]
        public ICollection<RoadSegment> Segments { get; set; }
    }
}
