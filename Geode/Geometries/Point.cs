using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometries
{
    public class Point<T> : IGeoType
    {
        public string Type => "Point";
        public T[] Coordinates { get; set; }
        public Point(T x, T y)
        {
            Coordinates = new T[] { x, y };
        }
    }
}
