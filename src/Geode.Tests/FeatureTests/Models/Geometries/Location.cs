using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.FeatureTests.Models.Geometries
{
    public class Location<IGeoType>
    {
        IGeoType Geometry { get; set; }
    }
}
