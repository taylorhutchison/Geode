using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.Models
{
    public class Line
    {
        public IEnumerable<LatLng> Points { get; set; }
        public Line() { }
        public Line(IEnumerable<LatLng> points)
        {
            Points = points;
        }
    }
}
