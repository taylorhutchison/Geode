using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geode.Geometry;
using Geode.Services;

namespace Geode
{
    public class FeatureCollection<T>: IEnumerable<T> where T : IFeature<IGeoType>
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
        public static FeatureCollection<IFeature<IGeoType>> CreateFeatures<T>(IEnumerable<Object> objList) => FeatureService.CreateFeatures<T>(objList);

        public static FeatureCollection<IFeature<IGeoType>> CreateFeatures(IEnumerable<IFeatureConvertible<IGeoType>> featureCollection) {
            var features = featureCollection.Select(fc => fc.ConvertToFeature());
            return new FeatureCollection<IFeature<IGeoType>>
            {
                Features = features
            };
        }

        public static IFeatureCollection CreateFeatures(IFeatureCollectionConvertible featureCollection) => featureCollection.ConvertToFeatureCollection();
    }
}
