using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IGeometryCollectionFeature : IFeature<IGeoType>
    {
        IEnumerable<IGeoType> Geometries { get; set; }
    }
}
