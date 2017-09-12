using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IGeoCollection
    {
        IEnumerable<IGeometry> Geometries { get; }
    }
}
