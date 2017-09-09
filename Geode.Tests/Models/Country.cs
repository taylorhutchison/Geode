using System;
using System.Collections.Generic;
using System.Text;
using Geode;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    [Feature]
    public class Country: IFeatureConvertible<IGeoType>
    {
        public string Name { get; set; }
        [Geometry(GeoType.Polygon)]
        public IEnumerable<IEnumerable<double>> Boundary { get; set; }

        public Feature<IGeoType> ToFeature()
        {
            throw new NotImplementedException();
        }
    }
}
