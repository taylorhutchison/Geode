using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    public class City : IFeatureConvertible<IGeoType>
    {
        public string Name { get; set; }
        public IEnumerable<IEnumerable<double>> Boundary { get; set; }

        public IFeature<IGeoType> ToFeature()
        {
            throw new NotImplementedException();
        }
    }
}
