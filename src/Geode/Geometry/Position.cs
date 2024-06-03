using System;

namespace Geode;
public struct Position : IPoint
{
    private double[] _position;
    public double X => _position[0];
    public double Y => _position[1];
    public double Z => _position[2];
    public Position(double x, double y)
    {
        _position = new double[] { x, y, default(double) };
    }

    public Position(double x, double y, double z)
    {
        _position = new double[] { x, y, z };
    }

    double[] IPoint.Position => _position;

    public bool Equals(IPoint other)
    {
        throw new NotImplementedException();
    }
}
