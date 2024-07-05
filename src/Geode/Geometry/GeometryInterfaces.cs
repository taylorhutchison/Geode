﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Geode;
public interface IGeometry
{
    GeometryType Type { get; }
    object? Geometry { get; }
}

public interface IGeometry<T> : IGeometry
{
    new T? Geometry { get; }
}

public interface IPoint : IGeometry
{
    (double X, double Y, double Z) Coordinates { get; }
    double X { get; }
    double Y { get; }
    double Z { get; }
}

// public interface IPoint : IPoint, IEquatable<IPoint>
// {
//     double X { get; }
//     double Y { get; }
// }

// public interface IPoint : IPoint, IEquatable<IPoint>
// {
//     double X { get; }
//     double Y { get; }
//     double Z { get; }
// }

public interface IPolyline : IGeometry<IEnumerable<IPoint>>
{

}
public interface IMultiPolyline : IGeometry<IEnumerable<IPolyline>>
{

}

public interface IPolygon : IGeometry<IEnumerable<IEnumerable<IPoint>>>
{
    public bool IsValid { get; }
}

public interface IMultiPolygon : IGeometry<IEnumerable<IPolygon>>
{
    public bool IsValid { get; }
}