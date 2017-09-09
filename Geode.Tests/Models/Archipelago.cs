using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    public class Archipelago: IGeoCollectionFeatureConvertible
    {
        public IEnumerable<Polygon> Islands { get; set; }

        public string Name { get; set; }

        public GeoCollectionFeature<IGeoType> ToFeature()
        {
            return new GeoCollectionFeature<IGeoType>
            {
                Properties = new Dictionary<string, object>
                {
                    { nameof(Name), Name }
                },
                Geometries = Islands                
            };
        }
    }
}
