using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geode.Geometry;
using Geode.Services;

namespace Geode
{
    /// <summary>
    /// A FeatureCollection is a collection of Features.
    /// </summary>
    public class FeatureCollection : IEnumerable<IFeature>, IFeatureCollection
    {
        public IEnumerable<IFeature> Features { get; set; }
        public IEnumerator<IFeature> GetEnumerator()
        {
            return Features.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Features.GetEnumerator();
        }
    }

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

}
