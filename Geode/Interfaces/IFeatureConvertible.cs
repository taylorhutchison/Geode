using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode
{
    public interface IFeatureConvertible<T> where T: IGeoType
    {
        IFeature<IGeoType> ToFeature();
    }

}
