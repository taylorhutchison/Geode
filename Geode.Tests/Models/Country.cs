using System;
using System.Collections.Generic;
using System.Text;
using Geode;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    [Feature]
    public class Country: IFeatureConvertible
    {
        public string Name { get; set; }
        [Geometry(GeoType.Polygon)]
        public IEnumerable<IEnumerable<int>> Boundary { get; set; }

        public IFeature ConvertToFeature()
        {
            throw new NotImplementedException();
        }

    }
}
