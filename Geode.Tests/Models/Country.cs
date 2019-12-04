using System;
using System.Collections.Generic;
using System.Text;
using Geode;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    public class Country: IFeatureConvertible
    {
        public string Name { get; set; }
        public IEnumerable<IEnumerable<double>> Boundary { get; set; }

        public IFeature ToFeature()
        {
            throw new NotImplementedException();
        }
    }
}
