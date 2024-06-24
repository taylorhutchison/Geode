using System;
using System.Linq;

namespace Geode;

public class Point2D : IGeometry<IPoint2D>, IPoint2D, IEquatable<Point2D>
{
    public double[] Position { get; private set; }
    public double X => Position[0];
    public double Y => Position[1];
    public GeometryType Type => GeometryType.Point2D;
    object IGeometry.Geometry => Geometry;
    public IPoint2D Geometry => this;
    public Point2D(IPoint point)
    {
        Position = point.Position;
    }
    public Point2D(double x, double y)
    {
        Position = [x, y];
    }
    public Point2D(IPoint2D point)
    {
        Position = point.Position;
    }
    public Point2D(double[] position)
    {
        Position = position;
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

    public bool Equals(IPoint other)
    {
        if (other == null || Position.Length != other.Position.Length)
        {
            return false;
        }
        for (int i = 0; i < Position.Length; i++)
        {
            if (Position[i] != other.Position[i])
            {
                return false;
            }
        }
        return true;
    }

}

public class Point3D : IGeometry<IPoint3D>, IPoint3D, IEquatable<Point3D>
{
    public double[] Position { get; private set; }
    public double X => Position[0];
    public double Y => Position[1];
    public double Z => Position[2];
    public GeometryType Type => GeometryType.Point3D;
    object IGeometry.Geometry => Geometry;
    public IPoint3D Geometry => this;
    public Point3D(double x, double y, double z)
    {
        Position = [x, y, z];
    }
    public bool Equals(Point3D other)
    {
        return Equals((IPoint3D)other);
    }

    public bool Equals(IPoint3D other)
    {
        return X == other.X && Y == other.Y && Z == other.Z;
    }

    public bool Equals(IPoint other)
    {
        if (other == null || Position.Length != other.Position.Length)
        {
            return false;
        }
        for (int i = 0; i < Position.Length; i++)
        {
            if (Position[i] != other.Position[i])
            {
                return false;
            }
        }
        return true;
    }
}
