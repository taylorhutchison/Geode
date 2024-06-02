using System;
using System.Collections;

namespace Geode;
public interface IGeometry
{
    GeometryType Type { get; }
    IEnumerable Coordinates { get; }
}
