using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Geode.Geometry
{
    public interface IGeoType
    {
        GeoType Type { get; }
        IEnumerable Geometry { get; }
    }
}
