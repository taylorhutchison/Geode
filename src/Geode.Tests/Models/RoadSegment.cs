using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.Models
{
    public class RoadSegment
    {
        public int Id { get; set; }

        public LatLng MidPoint { get; set; }

        public IEnumerable<LatLng> Line { get; set; }

        public IEnumerable<LatLng> Bounds { get; set; }
    }
}
