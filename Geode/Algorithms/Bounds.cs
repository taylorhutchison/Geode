using System;
using System.Collections.Generic;
using System.Text;
using Geode;
using Geode.Geometry;

namespace Geode.Algorithms
{
    public class Bounds: IEquatable<Bounds>
    {
        public double XMin { get; set; }
        public double XMax { get; set; }
        public double YMin { get; set; }
        public double YMax { get; set; }
        public double ZMin { get; set; }
        public double ZMax { get; set; }
        public bool Equals(Bounds other)
        {
            throw new NotImplementedException();
        }
    }
    public static class BoundsExtensions
    {
        public static Bounds CalculateBounds(this IGeometry geom)
        {
            return new Bounds();
        }
    }
}
