using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode
{
    public interface IFeatureConvertible<T> where T: IGeoType
    {
        Feature<T> ConvertToFeature();
    }

    public interface IGeoCollectionFeatureConvertible<T> where T: IGeoType
    {
        GeoCollectionFeature<T> ConvertToFeature();
    }

    public interface IGeoCollectionFeatureConvertible
    {
        GeoCollectionFeature<IGeoType> ConvertToFeature();
    }
}
