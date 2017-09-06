using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IGeometryFeature : IFeature
    {
        IGeoType Geometry { get; set; }
    }
}
