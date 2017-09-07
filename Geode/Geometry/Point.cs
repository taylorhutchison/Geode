using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Geode.Geometry
{
    public class Point<T> : IGeoType
    {
        public GeoType Type => GeoType.Point;
        public T[] Coordinates { get; set; }
        public Point(T x, T y)
        {
            Coordinates = new T[] { x, y };
        }
        public IEnumerable Geometry => Coordinates;
    }

    public class Point : IGeoType
    {
        public GeoType Type => GeoType.Point;
        public double[] Coordinates { get; set; }
        public Point(double x, double y)
        {
            Coordinates = new double[] { x, y };
        }
        public IEnumerable Geometry => Coordinates;
    }
}
