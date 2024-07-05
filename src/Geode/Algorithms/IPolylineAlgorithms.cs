using System;
using System.Collections.Generic;
using System.Linq;

namespace Geode;

public static class IPolyAlgorithms
{
    public static Point? GetMidPoint(this IPolyline polyline)
    {
        if (polyline?.Geometry != null && polyline.Geometry.Count() > 1)
        {
            var segments = GetLineSegments(polyline)?.ToArray();
            if(segments == null) return default;
            var segmentDistances = segments.Select(s => s.SegmentLength).ToArray();
            var halfwayLength = segmentDistances.Sum(d => d) / 2d; 

            return GetMidPoint(segments, segmentDistances, halfwayLength);
        }
        var firstPosition = polyline?.Geometry?.First();
        if (firstPosition == null) return null;
        var (x, y, z) = (firstPosition.X, firstPosition.Y, firstPosition.Z);
        return new Point(x, y, z);
    }

    public static decimal GetDistance(this IPolyline polyline) {
        if(polyline?.Geometry == null) return 0;
        if(polyline.Geometry.Count() == 1) return 0m;
        var distance = 0m;
        var verticies = polyline.Geometry.ToArray();
        for(var i = 0; i < verticies.Length - 1; i++) {
            var a = verticies[i];
            var b = verticies[i + 1];
            distance += Convert.ToDecimal(Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.Z - b.Z, 2)));
        }
        return distance;
    }

    private static IEnumerable<LineSegment>? GetLineSegments(IPolyline polyline)
    {
        if(polyline.Geometry == null) return default;
        var polylineVertices = polyline.Geometry.ToArray();
        var segments = new List<LineSegment>();
        for (var i = 0; i < polylineVertices.Length - 1; i++)
        {
            var a = polylineVertices[i];
            var b = polylineVertices[i + 1];
            var segment = new LineSegment(a, b);
            segments.Add(segment);
        }
        return segments;
    }
    private static Point? GetMidPoint(LineSegment[] segments, double[] segmentDistances, double halfwayLength)
    {
        var cumulativeDistance = 0d;
        for (var i = 0; i < segmentDistances.Length; i++)
        {
            cumulativeDistance += segmentDistances[i];
            if (cumulativeDistance >= halfwayLength)
            {
                var distance = halfwayLength - (cumulativeDistance - segmentDistances[i]);
                var midPoint = segments[i].PositionAtDistance(distance);
                if (midPoint != null)
                {
                    var (x, y, z) = (midPoint.X, midPoint.Y, midPoint.Z);
                    return new Point(x, y, z);
                }
            }
        }
        return default;
    }
}
