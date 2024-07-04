﻿using System;

namespace Geode;

internal class LineSegment
{
    public IPoint A { get; set; }
    public IPoint B { get; set; }
    public LineSegment(IPoint a, IPoint b)
    {
        A = a;
        B = b;
    }
    public LineSegment(double[] a, double[] b)
    {
        A = new Point2D(a[0], a[1]);
        B = new Point2D(b[0], b[1]);
    }

    public double SegmentLength => GetSegmentLength();
    private double GetSegmentLength() { 
        return Math.Sqrt(Math.Pow(A.Position[0] - B.Position[0], 2) + Math.Pow(A.Position[1] - B.Position[1], 2));
    }

    public Point2D PositionAtDistance(double distance)
    {
        var cx = B.Position[0] - A.Position[0];
        var cy = B.Position[1] - A.Position[1];
        var c = new Point2D(cx, cy);
        var length = Math.Sqrt(Math.Pow(c.Position[0], 2) + Math.Pow(c.Position[1], 2));
        var dx = c.Position[0] / length * distance;
        var dy = c.Position[0] / length * distance;
        return new Point2D(dx + A.Position[0], dy + A.Position[1]);
    }
}
