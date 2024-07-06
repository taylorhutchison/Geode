using System;

namespace Geode;
public record Bounds(double XMin, double XMax, double YMin, double YMax, double ZMin = 0, double ZMax = 0) : IEquatable<Bounds>
{
    public double Width => XMax - XMin;
    public double Height => YMax - YMin;
    public double Depth => ZMax - ZMin;
    public virtual bool Equals(Bounds? other)
    {
        return other != null && XMin == other.XMin && XMax == other.XMax &&
               YMin == other.YMin && YMax == other.YMin &&
               ZMin == other.ZMin && ZMax == other.ZMax;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(XMin, XMax, YMin, YMax, ZMin, ZMax);
    }
}
