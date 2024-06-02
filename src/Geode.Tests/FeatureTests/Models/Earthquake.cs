using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.FeatureTests.Models
{
    public class Earthquake : IFeatureConvertible
    {
        public Polygon ImpactArea { get; set; }
        public Point Epicenter { get; set; }
        public double Magnitude { get; set; }
        public IFeature ToFeature()
        {
            var feature = new Feature
            {
                Geometry = new GeometryCollection
                {
                    Geometries = new List<IGeometry> {
                        ImpactArea,
                        Epicenter
                    }
                },
                Properties = new Dictionary<string, object>
                {
                    {nameof(Magnitude), Magnitude }
                }
            };
            return feature;
        }
    }
}
