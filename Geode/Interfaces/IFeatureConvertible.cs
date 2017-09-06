using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode
{
    public interface IFeatureConvertible
    {
        IFeature ConvertToFeature();
    }
}
