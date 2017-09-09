using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode
{
    public interface IFeatureConvertible<T> where T: IGeoType
    {
        Feature<T> ToFeature();
    }

    public interface IGeoCollectionFeatureConvertible
    {
        GeoCollectionFeature<IGeoType> ToFeature();
    }
}
