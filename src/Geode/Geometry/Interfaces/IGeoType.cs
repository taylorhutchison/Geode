using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Geode
{
    public interface IGeoType
    {
        GeoType Type { get; }
        IEnumerable Geometry { get; }
    }
}
