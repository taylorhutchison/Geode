using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;
using Geode.Services;

namespace Geode
{

    public static class Feature
    {
        public static Feature<IGeoType> CreateFeature(Object obj)
        {
            return FeatureService.CreateFeature<IGeoType>(obj);
        }

        public static Feature<IGeoType> CreateFeature<T>(Object obj)
        {
            return FeatureService.CreateFeature<T>(obj);
        }
    }

    public abstract class BaseFeature<T> : IFeature<IGeoType>
    {
        public string Type => "Feature";
        public IDictionary<string, object> Properties { get; set; }
    }

    public sealed class Feature<T>: BaseFeature<T>, IGeometryFeature where T: IGeoType
    {
        public IGeoType Geometry { get; set; }
    }

    public sealed class GeoCollectionFeature<T> : BaseFeature<T>, IGeometryCollectionFeature where T: IGeoType
    {
        public IEnumerable<IGeoType> Geometries { get; set; }

    }



}
