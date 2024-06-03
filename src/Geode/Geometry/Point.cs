using System;

namespace Geode;
public sealed class Point : IGeometry<IPoint>, IPoint, IEquatable<Point>
{
    public double X => Position[0];
    public double Y => Position[1];
    public double Z => Position[2];
    public GeometryType Type => GeometryType.Point;
    public double[] Position { get; private set; }
    object IGeometry.Coordinates => Coordinates;
    public IPoint Coordinates => this;
    public Point(double x, double y)
    {
        Position = new double[] { x, y, 0 };
    }
    public Point(double x, double y, double z)
    {
        Position = new double[] { x, y, z };
    }
    public Point(IPoint position)
    {
        Position = position.Position;
    }
    public Point(double[] position)
    {
        Position = position;
    }

    public bool Equals(Point other)
    {
        return Equals((IPoint)other);
    }

    public bool Equals(IPoint other)
    {
        if (Position.Length != other.Position.Length)
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
