using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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
        public Bounds(IPosition position)
        {
            XMin = position.Position[0];
            XMax = position.Position[0];
            YMin = position.Position[1];
            YMax = position.Position[1];
        }
        public Bounds() { }
        public bool Equals(Bounds other)
        {
            return XMin == other.XMin && XMax == other.XMax && YMin == other.YMin && YMax == other.YMin && ZMin == other.ZMin && ZMax == other.ZMax;
        }
    }
    public static class BoundsExtensions
    {
        private static Bounds GetBounds(IEnumerable<double[]> poly)
        {
            var bounds = new Bounds();
            foreach (var position in poly)
            {
                if (bounds.XMax < position[0]) bounds.XMax = position[0];
                if (bounds.XMin > position[0]) bounds.XMin = position[0];
                if (bounds.YMax < position[1]) bounds.YMax = position[1];
                if (bounds.YMin > position[1]) bounds.YMin = position[1];
                if (position.Length > 2)
                {
                    if (bounds.ZMax < position[2]) bounds.ZMax = position[2];
                    if (bounds.ZMin > position[2]) bounds.ZMin = position[2];
                }
            }
            return bounds;
        }
        public static Bounds GetBounds(this IPosition position)
        {
            return new Bounds(position);
        }
        public static Bounds GetBounds(this IPoly poly)
        {
            return GetBounds(poly.Positions);
        }
        public static Bounds GetBounds(this IEnumerable<IPosition> positions)
        {
            var bounds = positions.Select(p => p.GetBounds());
            return GetBounds(bounds);
        }
        public static Bounds GetBounds(this IEnumerable<IPoly> positions)
        {
            var bounds = positions.Select(p => p.GetBounds());
            return GetBounds(bounds);
        }
        public static Bounds GetBounds(this IEnumerable<Bounds> bounds)
        {
            return new Bounds
            {
                XMin = bounds.Min(b => b.XMin),
                XMax = bounds.Max(b => b.XMax),
                YMin = bounds.Min(b => b.YMin),
                YMax = bounds.Max(b => b.YMax),
                ZMin = bounds.Min(b => b.ZMin),
                ZMax = bounds.Min(b => b.ZMax)
            };
        }
    }
}
