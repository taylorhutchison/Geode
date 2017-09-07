using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    public class Earthquake : IGeoCollectionFeatureConvertible
    {
        public Geode.Geometry.Polygon ImpactArea { get; set; }
        public Geode.Geometry.Point Epicenter { get; set; }
        public double Magnitude { get; set; }
        public GeoCollectionFeature<IGeoType> ConvertToFeature()
        {
            var feature = new GeoCollectionFeature<IGeoType>
            {
                Geometries = new List<IGeoType>
                {
                    ImpactArea,
                    Epicenter
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
