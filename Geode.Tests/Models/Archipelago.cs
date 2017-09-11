using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    public class Archipelago: IFeatureConvertible<GeometryCollection>
    {
        public IEnumerable<Polygon> Islands { get; set; }

        public string Name { get; set; }

        public IFeature<IGeoType> ToFeature()
        {
            return new Feature<IGeoType>
            {
                Properties = new Dictionary<string, object>
                {
                    { nameof(Name), Name }
                },
                Geometry = new GeometryCollection() {
                   Geometries = Islands
                }            
            };
        }
    }
}
