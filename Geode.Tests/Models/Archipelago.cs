using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    public class Archipelago: IFeatureConvertible
    {
        public IEnumerable<Polygon> Islands { get; set; }

        public string Name { get; set; }

        public IFeature ConvertToFeature()
        {
            return new GeoCollectionFeature
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
