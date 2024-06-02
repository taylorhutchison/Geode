using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.FeatureTests.Models
{
    public class Archipelago : IFeatureConvertible
    {
        public IEnumerable<IGeometry> Islands { get; set; }

        public string Name { get; set; }

        public IFeature ToFeature()
        {
            return new Feature
            {
                Properties = new Dictionary<string, object>
                {
                    { nameof(Name), Name }
                },
                Geometry = new GeometryCollection()
                {
                    Geometries = Islands
                }
            };
        }
    }
}
