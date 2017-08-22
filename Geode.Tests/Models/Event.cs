using System;
using System.Collections.Generic;
using System.Text;
using Geode.Attributes;
using Geode.Geometries;

namespace Geode.Tests.Models
{
    [Feature]
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Geometry(GeoType.Point)]
        public Point Coordinates { get; set; }
    }
}
