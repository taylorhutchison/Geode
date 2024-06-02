using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geode;

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
            A = new Position(a[0], a[1]);
            B = new Position(b[0], b[1]);
        }
        public double SegmentLength => Math.Sqrt(Math.Pow(A.Position[0] - B.Position[0], 2) + Math.Pow(A.Position[1] - B.Position[1], 2));

        public IPosition PositionAtDistance(double distance)
        {
            var cx = B.Position[0] - A.Position[0];
            var cy = B.Position[1] - A.Position[1];
            var c = new Point(cx, cy);
            var length = Math.Sqrt(Math.Pow(c.Position[0], 2) + Math.Pow(c.Position[1], 2));
            var dx = c.Position[0] / length * distance;
            var dy = c.Position[0] / length * distance;
            return new Point(dx + A.Position[0], dy + A.Position[1]);
        }
    }
