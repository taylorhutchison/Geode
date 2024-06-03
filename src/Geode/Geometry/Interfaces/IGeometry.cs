using System;
using System.Collections;

namespace Geode;
public interface IGeometry
{
    GeometryType Type { get; }
    object Coordinates { get; }
}

public interface IGeometry<T> : IGeometry
{
    new T Coordinates { get; }
}