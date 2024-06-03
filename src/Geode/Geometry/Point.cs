using System;

namespace Geode;
public sealed class Point : IGeometry<IPosition>, IPosition, IEquatable<Point>
{
    private double[] _position;
    public double X => _position[0];
    public double Y => _position[1];
    public double Z => _position[2];
    public GeometryType Type => GeometryType.Point;
    public double[] Position => _position;
    object IGeometry.Coordinates => Coordinates;
    public IPosition Coordinates => this;
    public Point(double x, double y)
    {
        _position = new double[] { x, y, 0 };
    }
    public Point(double x, double y, double z)
    {
        _position = new double[] { x, y, z };
    }
    public Point(IPosition position)
    {
        _position = position.Position;
    }
    public Point(double[] position)
    {
        _position = position;
    }

    public bool Equals(Point other)
    {
        return Equals((IPosition)other);
    }

    public bool Equals(IPosition other)
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
