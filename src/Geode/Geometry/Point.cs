using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;

public class Point : IGeometry<IPoint>, IPoint, IEquatable<Point>
{
    private (double X, double Y, double Z) _coordinates;
    public (double X, double Y, double Z) Coordinates => _coordinates;
    public double X => _coordinates.X;
    public double Y => _coordinates.Y;
    public double Z => _coordinates.Z;
    public GeometryType Type => GeometryType.Point;
    object IGeometry.Geometry => Geometry;
    public IPoint Geometry => this;
    public Point(double x, double y, double z = 0)
    {
        _coordinates = new (x, y, z);
    }
    public bool Equals(Point? other)
    {
        return other != null && Equals((IPoint)other);
    }

    public bool Equals(IPoint? other)
    {
        return other != null && X == other.X && Y == other.Y && Z == other.Z;
    }
}