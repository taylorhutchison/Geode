using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.FeatureTests.Models.Geometries
{
    public class Location<IGeoType>
    {
        IGeoType Geometry { get; set; }
    }
}
