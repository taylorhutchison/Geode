﻿using System;
using System.Collections.Generic;
using System.Text;
using Geode;

namespace Geode
{
    public static class CentroidExtensions
    {
        public static Point CalculateCentroid(this IGeometry geom)
        {
            return new Point(new double[2]);
        }

        public static Point CalculateCentroid(this IGeometry geom, bool inside)
        {
            return new Point(new double[2]);
        }
    }
}
