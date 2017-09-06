using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;
using Geode.Services;

namespace Geode
{
    public abstract class BaseFeature : IFeature
    {
        public string Type => "Feature";
        public IDictionary<string, object> Properties { get; set; }
    }

    public sealed class Feature: BaseFeature, IFeature
    {
        public IGeoType Geometry { get; set; }
        public static IFeature CreateFeature(Object obj)
        {
            return FeatureService.CreateFeature(obj);
        }
        public static IFeature CreateFeature<U>(Object obj)
        {
            return FeatureService.CreateFeature<U>(obj);
        }
        public static IFeature CreateFeature(IFeatureConvertible feature)
        {
            return feature.ConvertToFeature();
        }
    }

    public sealed class GeoCollectionFeature : BaseFeature, IFeature
    {
        public IEnumerable<IGeoType> Geometries { get; set; }
    }


}
