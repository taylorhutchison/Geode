using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode
{
    public interface IFeatureCollectionConvertible
    {
        IFeatureCollection ConvertToFeatureCollection();
    }
}
