using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geode.Geometry;
using Geode.Services;

namespace Geode
{
    public class FeatureCollection<T> : IEnumerable<T>, IFeatureCollection<T> where T : IFeature<IGeoType>
    {
        public string Type => "FeatureCollection";
        public IEnumerable<T> Features { get; set; }
        public IEnumerator<T> GetEnumerator()
        {
            return Features.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Features.GetEnumerator();
        }
    }

    public static class FeatureCollection
    {
        public static IFeatureCollection<IFeature<IGeoType>> ToFeatureCollection(this IEnumerable<IFeatureConvertible<IGeoType>> features)
        {
            return new FeatureCollection<IFeature<IGeoType>>()
            {
                Features = features.Select(f => f.ToFeature())
            };
        }
        public static IFeatureCollection<IFeature<IGeoType>> ToFeatureCollection<T>(this IEnumerable<T> features, Func<T, IFeature<IGeoType>> converter)
        {
            return new FeatureCollection<IFeature<IGeoType>>()
            {
                Features = features.Select(f => converter(f))
            };
        }
    }
}
