using System;
using System.Collections.Generic;
using System.Linq;
using Geode;

namespace Geode
{
    public static class IPolyAlgorithms
    {
        private static IEnumerable<LineSegment> GetLineSegments(IPoly Polyline)
        {
            var line = Polyline.Positions.ToArray();
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
        public static Point GetMidPoint(this IPoly Polyline)
        {
            if (Polyline.Positions.Count() > 1)
            {
                var segments = GetLineSegments(Polyline).ToArray();
                var segmentDistances = segments.Select(s => s.SegmentLength).ToArray();
                var halfwayLength = segmentDistances.Sum(d => d) / 2d;

                return GetMidPoint(segments, segmentDistances, halfwayLength);
            }
            var firstPosition = Polyline.Positions.First();
            return new Point(firstPosition);
        }
    }
}
