using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IGeometry: IGeoType
    {
        IEnumerable Coordinates { get; }
    }
}
