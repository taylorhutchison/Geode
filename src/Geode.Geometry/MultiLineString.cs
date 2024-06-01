﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Geode.Geometry
{
    public class MultiPolyline : IGeoType, IGeometry
    {
        public GeoType Type => GeoType.MultiPolyline;
        public IEnumerable Coordinates { get; private set; }
        public Bounds Bounds { get; set; }
        public MultiPolyline(IEnumerable<IEnumerable<IPosition>> coordinates)
        {
            Coordinates = coordinates;
        }
        public MultiPolyline () { }
        public IEnumerable Geometry => Coordinates;
        public bool Equals(IGeometry other)
        {
            return Type == other.Type;
        }
    }
}
