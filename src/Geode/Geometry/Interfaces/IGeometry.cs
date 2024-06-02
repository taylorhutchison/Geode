using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IGeometry: IGeoType, IEquatable<IGeometry>
    {
        Bounds Bounds { get; }
        IEnumerable Coordinates { get; }
    }
}
