using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;
using Geode.Services;

namespace Geode
{
    public abstract class BaseFeature : IFeature<IGeoType>
    {
        public string Type => "Feature";
        public IDictionary<string, object> Properties { get; set; }
    }

    public sealed class Feature : BaseFeature, IFeature<IGeoType>
    {
        public IGeoType Geometry { get; set; }
        public static Feature CreateFeature(Object obj)
        {
            return CreateFeature<double>(obj);
        }
        public static Feature CreateFeature<T>(Object obj)
        {
            return FeatureService.CreateFeature<T>(obj);
        }
    }

    public abstract class BaseFeature<T> : IFeature<IGeoType>
    {
        public string Type => "Feature";
        public IDictionary<string, object> Properties { get; set; }
    }

    public sealed class Feature<T>: BaseFeature<T>, IFeature<T> where T: IGeoType
    {
        public T Geometry { get; set; }
        public static Feature<T> CreateFeature(IFeatureConvertible<T> feature)
        {
            return feature.ConvertToFeature();
        }
    }

    public sealed class GeoCollectionFeature<T> : BaseFeature<T>, IFeature<T> where T: IGeoType
    {
        public IEnumerable<IGeoType> Geometries { get; set; }
        public static GeoCollectionFeature<IGeoType> CreateFeature(IGeoCollectionFeatureConvertible feature)
        {
            return feature.ConvertToFeature();
        }
    }


}
