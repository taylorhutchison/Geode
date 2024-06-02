using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
public static class FeatureCollectionExtensions
{
    public static IFeatureCollection ToFeatureCollection(this IEnumerable<IFeatureConvertible> features)
    {
        return new FeatureCollection()
        {
            Features = features.Select(f => f.ToFeature())
        };
    }
    public static IFeatureCollection ToFeatureCollection<T>(this IEnumerable<T> features, Func<T, IFeature> converter)
    {
        return new FeatureCollection()
        {
            Features = features.Select(f => converter(f))
        };
    }
}
