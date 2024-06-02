using System;
using System.Collections.Generic;
using System.Text;
using Geode.Tests.FeatureTests.Models.Geometries;

namespace Geode.Tests.FeatureTests.Models
{
    public class Place
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public LatLng Location { get; set; }
    }
}
