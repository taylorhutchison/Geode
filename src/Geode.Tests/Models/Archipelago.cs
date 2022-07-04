using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    public class Archipelago: IFeatureConvertible<GeometryCollection>
    {
        public IEnumerable<IGeometry> Islands { get; set; }

        public string Name { get; set; }

        public IFeature<GeometryCollection> ToFeature()
        {
            return new Feature<GeometryCollection>
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
