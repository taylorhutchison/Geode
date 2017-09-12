using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    [Feature]
    public class City : IFeatureConvertible
    {
        public string Name { get; set; }
        [Geometry(GeoType.Polygon)]
        public IEnumerable<IEnumerable<double>> Boundary { get; set; }

        public IFeature ToFeature()
        {
            throw new NotImplementedException();
        }
    }
}
