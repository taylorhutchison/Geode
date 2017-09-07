using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IGeometryCollectionFeature : IFeature<IGeoType>
    {
        IGeoCollectionType[] Geometries { get; set; }
    }
}
