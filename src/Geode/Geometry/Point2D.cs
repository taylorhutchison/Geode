using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;

public class Point2D : IGeometry<IPoint2D>, IPoint2D, IEquatable<Point2D>
{
    private readonly double[] _position;
    public IReadOnlyList<double>? Position => _position;
    public double X => _position[0];
    public double Y => _position[1];
    public GeometryType Type => GeometryType.Point2D;
    object IGeometry.Geometry => this;
    public IPoint2D Geometry => this;
    public Point2D(double x, double y)
    {
        _position = [x, y];
    }
    public bool Equals(Point2D other)
    {
        if (other == null || other is not Point2D)
        {
            return false;
        }
        return Equals((IPoint2D)other);
    }

    public bool Equals(IPoint2D other)
    {
        return X == other.X && Y == other.Y;
    }
}