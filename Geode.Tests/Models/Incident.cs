﻿using System;
using System.Collections.Generic;
using System.Text;

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
