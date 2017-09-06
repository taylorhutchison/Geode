﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
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