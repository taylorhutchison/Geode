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
        public LineSegment(double[] a, double[] b)
        {
            A = new Position(a[0],a[1]);
            B = new Position(b[0],b[1]);
        }
        public double SegmentLength => Math.Sqrt(Math.Pow(A.Position[0] - B.Position[0], 2) + Math.Pow(A.Position[1] - B.Position[1], 2));

        public IPosition PositionAtDistance(double distance)
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
        private static IEnumerable<LineSegment> GetLineSegments(IPoly lineString)
        {
            var line = lineString.Positions.ToArray();
            var segments = new List<LineSegment>();
            for (var i = 0; i < line.Length - 1; i++)
            {
                var a = line[i];
                var b = line[i + 1];
                var segment = new LineSegment(a, b);
                segments.Add(segment);
            }
            return segments;
        }
        private static Point GetMidPoint(LineSegment[] segments, double[] segmentDistances, double halfwayLength)
        {
            var cumulativeDistance = 0d;
            for (var i = 0; i < segmentDistances.Count(); i++)
            {
                cumulativeDistance += segmentDistances[i];
                if (cumulativeDistance >= halfwayLength)
                {
                    var distance = halfwayLength - (cumulativeDistance - segmentDistances[i]);
                    var midPoint = segments[i].PositionAtDistance(distance);
                    return new Point(midPoint);
                }
            }
            return default(Point);
        }
        public static Point GetMidPoint(this IPoly lineString)
        {
            if (lineString.Positions.Count() > 1)
            {
                var segments = GetLineSegments(lineString).ToArray();
                var segmentDistances = segments.Select(s => s.SegmentLength).ToArray();
                var halfwayLength = segmentDistances.Sum(d => d) / 2d;

                return GetMidPoint(segments, segmentDistances, halfwayLength);
            }
            var firstPosition = lineString.Positions.First();
            return new Point(firstPosition);
        }
    }
}
