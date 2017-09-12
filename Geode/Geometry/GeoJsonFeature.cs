using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Geode.Geometry
{
    internal class GeoJsonFeature
    {
        public GeoJsonFeature(IFeature feature)
        {
            Type = feature?.Type;
            Properties = feature?.Properties;
            Geometry = new Dictionary<string, object>(2)
            {
                {"Type", feature?.Geometry?.Type}
            };
            if(feature.Geometry.Type == GeoType.GeometryCollection)
            {
                Geometry.Add("Geometries", feature?.Geometry?.Geometry);
            }
            else
            {
                Geometry.Add("Coordinates", feature?.Geometry?.Geometry);
            }
        }
        public string Type { get; private set; }
        public IDictionary<string, object> Properties { get; private set; }
        public IDictionary<string, object> Geometry { get; private set; }
    }

    internal class GeoJsonFeatureCollection
    {
        public GeoJsonFeatureCollection(IFeatureCollection featureCollection)
        {
            Type = featureCollection.Type;
            Features = featureCollection.Features.Select(f => new GeoJsonFeature(f));
        }
        public string Type { get; private set; }
        public IEnumerable<GeoJsonFeature> Features { get; private set; }

    }
}
