using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geode;
using Geode.Geometry;

namespace Geode.Algorithms
{
    internal class LineSegment
    {
        public IPosition A { get; set; }
        public IPosition B { get; set; }
        public LineSegment(IPosition a, IPosition b)
        {
            A = a;
            B = b;
        }
        public double SegmentLength => Math.Sqrt(Math.Pow(A.Position[0] - B.Position[0], 2) + Math.Pow(A.Position[1] - B.Position[1], 2));

        public IPosition DistanceAlong(double distance)
        {
            var cx = B.Position[0] - A.Position[0];
            var cy = B.Position[1] - A.Position[1];
            var c = new Point(cx, cy);
            var length = Math.Sqrt(Math.Pow(c.Position[0], 2) + Math.Pow(c.Position[1], 2));
            var dx = (c.Position[0] / length) * distance;
            var dy = (c.Position[0] / length) * distance;
            return new Point(dx + A.Position[0], dy + A.Position[1]);
        }
    }

    public static class Midpoint
    {
        private static IEnumerable<LineSegment> GetLineSegments(IEnumerable<IEnumerable<double>> lineString)
        {
            var segments = new List<LineSegment>();
            lineString.Aggregate((a, b) =>
            {
                var ax = a.ToArray()[0];
                var ay = a.ToArray()[1];
                var bx = b.ToArray()[0];
                var by = b.ToArray()[1];
                var pa = new Position(ax, ay);
                var pb = new Position(bx, by);
                var segment = new LineSegment(pa, pb);
                segments.Add(segment);
                return a;
            });
            return segments;
        }
    public static Point GetMidPoint(this IEnumerable<IEnumerable<double>> lineString)
        {
            var segments = GetLineSegments(lineString).ToArray();
            var segmentDistances = segments.Select(s => s.SegmentLength).ToArray();
            var totalLength = segmentDistances.Sum(d => d);
            var halfwayLength = totalLength / 2d;
            var cumulativeDistance = 0d;
            IPosition midPoint = null;
            for (var i = 0; i < segmentDistances.Count(); i++)
            {
                cumulativeDistance += segmentDistances[i];
                if (cumulativeDistance >= halfwayLength)
                {
                    midPoint = segments[i].DistanceAlong(halfwayLength - (cumulativeDistance - segmentDistances[i]));
                }
            }
            return new Point(midPoint);
        }
    }
}
