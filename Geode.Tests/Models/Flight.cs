﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Geometry(GeoType.LineString)]
        public IEnumerable<IEnumerable<double>> FlightPath { get; set; }
    }
}
