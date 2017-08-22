using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometries
{
    public class Point : IGeoType
    {
        public string Type => "Point";
        public double[] Coordinates { get; set; }
        public Point(double x, double y)
        {
            Coordinates = new double[] { x, y };
        }
    }
}
