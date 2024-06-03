using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;

public static class IPolyAlgorithms
{
    public static Point GetMidPoint(this IPolyline Polyline)
    {
        if (Polyline.Coordinates.Count() > 1)
        {
            var segments = GetLineSegments(Polyline).ToArray();
            var segmentDistances = segments.Select(s => s.SegmentLength).ToArray();
            var halfwayLength = segmentDistances.Sum(d => d) / 2d;

            return GetMidPoint(segments, segmentDistances, halfwayLength);
        }
        var firstPosition = Polyline.Coordinates.First();
        return new Point(firstPosition);
    }

    private static IEnumerable<LineSegment> GetLineSegments(IPolyline Polyline)
    {
        var line = Polyline.Coordinates.ToArray();
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
        return default;
    }
}
