using System;
using System.Collections;

namespace Geode;
public interface IGeometry : IGeoType, IEquatable<IGeometry>
{
    Bounds Bounds { get; }
    IEnumerable Coordinates { get; }
}
