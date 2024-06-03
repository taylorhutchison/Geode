using System;
using System.Collections;
using System.Collections.Generic;

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

public interface IPolyline : IGeometry<IEnumerable<IPoint>>
{

}

public interface IPolygon : IGeometry<IEnumerable<IEnumerable<IPoint>>>
{

}