using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.Models
{
    public class River
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<LatLng> Location { get; set; }
    }
}
