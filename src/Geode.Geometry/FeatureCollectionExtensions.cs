using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Geode.Geometry
{
    public static class FeatureCollectionExtensions
    {
        public static IFeatureCollection<T> ToFeatureCollection<T>(this IEnumerable<IFeatureConvertible<T>> features)
        {
            return new FeatureCollection<T>()
            {
                Features = features.Select(f => f.ToFeature())
            };
        }
        public static IFeatureCollection<T> ToFeatureCollection<T>(this IEnumerable<T> features, Func<T, IFeature<T>> converter)
        {
            return new FeatureCollection<T>()
            {
                Features = features.Select(f => converter(f))
            };
        }
    }
}
