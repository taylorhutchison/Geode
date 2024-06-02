using System;
using System.Collections.Generic;
using System.Text;
using Geode.Tests.FeatureTests.Models.Geometries;

namespace Geode.Tests.FeatureTests.Models
{
    public class River
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<LatLng> Location { get; set; }
    }
}
