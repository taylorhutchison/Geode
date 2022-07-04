using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Geode.Geometry
{
    public class GeoJsonFeature<T> where T: IGeoType
    {
        public GeoJsonFeature(IFeature<T> feature)
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

    public class GeoJsonFeatureCollection<T> where T: IGeoType
    {
        public GeoJsonFeatureCollection(IFeatureCollection<T> featureCollection)
        {
            Features = featureCollection.Features.Select(f => new GeoJsonFeature<T>(f));
        }
        public string Type => "FeatureCollection";
        public IEnumerable<GeoJsonFeature<T>> Features { get; private set; }
    }

    public class GeoJsonGeometry
    {
        public string Type { get; private set; }
        public IEnumerable Coordinates { get; private set; }
        public GeoJsonGeometry(IGeoType geometry)
        {
            Type = geometry?.Type.ToString();
            Coordinates = geometry?.Geometry;
        }
    }
}
