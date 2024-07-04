using System;
using System.Collections;
using System.Collections.Generic;

namespace Geode;
public interface IGeometry
{
    GeometryType Type { get; }
    object Geometry { get; }
}

public interface IGeometry<T> : IGeometry
{
    new T Geometry { get; }
}

public interface IPoint : IGeometry
{
    IReadOnlyList<double> Position { get; }
}

public interface IPoint2D : IPoint, IEquatable<IPoint2D>
{
    double X { get; }
    double Y { get; }
}

public interface IPoint3D : IPoint, IEquatable<IPoint3D>
{
    double X { get; }
    double Y { get; }
    double Z { get; }
}

public interface IPolyline : IGeometry<IEnumerable<IPoint>>
{

}

public interface IPolyline<T> : IGeometry<IEnumerable<T>> where T : IPoint
{

}

public interface IMultiPolyline : IGeometry<IEnumerable<IEnumerable<IPoint>>>
{

}

public interface IPolygon : IGeometry<IEnumerable<IEnumerable<IPoint>>>
{

}

public interface IPolygon<T> : IGeometry<IEnumerable<IEnumerable<T>>> where T : IPoint
{

}

public interface IMultiPolygon : IGeometry<IEnumerable<IEnumerable<IEnumerable<IPoint>>>>
{

}