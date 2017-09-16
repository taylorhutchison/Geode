using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Geode.Geometry
{
    internal class GeoJsonFeature
    {
        public GeoJsonFeature(IFeature feature)
        {
            Properties = feature?.Properties;
            Geometry = new Dictionary<string, object>(2)
            {
                {"Type", feature?.Geometry?.Type}
            };
            if (typeof(IGeoCollection).IsAssignableFrom(feature.Geometry.GetType()))
            {
                var geometry = feature.Geometry as IGeoCollection;
                var geometries = geometry.Geometries.Select(g => new GeoJsonGeometry(g));
                Geometry.Add("Geometries", geometries);
            }
            else
            {
                Geometry.Add("Coordinates", feature?.Geometry?.Geometry);
            }
        }
        public string Type => "Feature";
        public IDictionary<string, object> Properties { get; private set; }
        public IDictionary<string, object> Geometry { get; private set; }
    }

    internal class GeoJsonFeatureCollection
    {
        public GeoJsonFeatureCollection(IFeatureCollection featureCollection)
        {
            Features = featureCollection.Features.Select(f => new GeoJsonFeature(f));
        }
        public string Type => "FeatureCollection";
        public IEnumerable<GeoJsonFeature> Features { get; private set; }
    }

    internal class GeoJsonGeometry
    {
        public string Type { get; private set; }
        public IEnumerable Coordinates { get; private set; }
        public GeoJsonGeometry(IGeometry geometry)
        {
            Type = geometry?.Type.ToString();
            Coordinates = geometry?.Coordinates;
        }
    }
}
