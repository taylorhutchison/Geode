using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.Models
{
    public class Point
    {
        public Point() { }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
