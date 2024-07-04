using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;

public class Point3D : IGeometry<IPoint3D>, IPoint3D, IEquatable<Point3D>
{
    private double[] _position;
    public IReadOnlyList<double> Position => _position;
    public double X => _position[0];
    public double Y => _position[1];
    public double Z => _position[2];
    public GeometryType Type => GeometryType.Point3D;
    object IGeometry.Geometry => Geometry;
    public IPoint3D Geometry => this;
    public Point3D(double x, double y, double z)
    {
        _position = [x, y, z];
    }
    public bool Equals(Point3D? other)
    {
        return other != null && Equals((IPoint3D)other);
    }

    public bool Equals(IPoint3D? other)
    {
        return other != null && X == other.X && Y == other.Y && Z == other.Z;
    }
}