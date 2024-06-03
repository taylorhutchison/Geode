using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public class GeoJsonFeature
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
            Geometry.Add("Coordinates", feature?.Geometry?.Coordinates);
        }
    }
    public string Type => "Feature";
    public IDictionary<string, object> Properties { get; private set; }
    public IDictionary<string, object> Geometry { get; private set; }
}

public class GeoJsonFeatureCollection
{
    public GeoJsonFeatureCollection(FeatureCollection featureCollection)
    {
        Features = featureCollection.Features.Select(f => new GeoJsonFeature(f));
    }
    public string Type => "FeatureCollection";
    public IEnumerable<GeoJsonFeature> Features { get; private set; }
}

public class GeoJsonGeometry
{
    public string Type { get; private set; }
    public object Coordinates { get; private set; }
    public GeoJsonGeometry(IGeometry geometry)
    {
        Type = geometry?.Type.ToString();
        Coordinates = geometry?.Coordinates;
    }
}
