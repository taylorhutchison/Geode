using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    public class Archipelago: IFeatureConvertible
    {
        public IEnumerable<IGeoType> Islands { get; set; }

        public string Name { get; set; }

        public IFeature ToFeature()
        {
            return new Feature
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
