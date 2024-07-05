using System;

namespace Geode;

internal record LineSegment
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
        A = new Point(a[0], a[1]);
        B = new Point(b[0], b[1]);
    }

    public double SegmentLength => GetSegmentLength();
    private double GetSegmentLength() { 
        return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2) + + Math.Pow(A.Z - B.Z, 2));
    }

    public Point PositionAtDistance(double distance)
    {
        var cx = B.X - A.X;
        var cy = B.Y - A.Y;
        var cz = B.Z - A.Z;
        var c = new Point(cx, cy, cz);
        var length = Math.Sqrt(Math.Pow(c.X, 2) + Math.Pow(c.Y, 2) + + Math.Pow(c.Z, 2));
        var dx = c.X / length * distance;
        var dy = c.Y / length * distance;
        var dz = c.Z / length * distance;
        return new Point(dx + A.X, dy + A.Y, dz + A.Z);
    }
}
