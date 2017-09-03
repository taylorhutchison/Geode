using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.Models
{
    [Feature]
    public class Pipe
    {
        public int Id { get; set; }
        [Geometry(GeoType.Polyline)]
        public IEnumerable<double[]> Location { get; set; }
    }
}
