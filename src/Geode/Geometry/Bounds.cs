using System;

namespace Geode;
public class Bounds : IEquatable<Bounds>
{
    public double XMin { get; set; }
    public double XMax { get; set; }
    public double YMin { get; set; }
    public double YMax { get; set; }
    public double ZMin { get; set; }
    public double ZMax { get; set; }
    public Bounds(IPoint position)
    {
        XMin = position.Position[0];
        XMax = position.Position[0];
        YMin = position.Position[1];
        YMax = position.Position[1];
    }
    public Bounds() { }
    public bool Equals(Bounds other)
    {
        return XMin == other.XMin && XMax == other.XMax &&
               YMin == other.YMin && YMax == other.YMin &&
               ZMin == other.ZMin && ZMax == other.ZMax;
    }
}
