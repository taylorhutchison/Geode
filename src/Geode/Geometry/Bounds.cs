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
    public bool Equals(Bounds? other)
    {
        return other != null && XMin == other.XMin && XMax == other.XMax &&
               YMin == other.YMin && YMax == other.YMin &&
               ZMin == other.ZMin && ZMax == other.ZMax;
    }
}
