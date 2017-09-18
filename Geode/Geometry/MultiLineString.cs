using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Geode.Structures;

namespace Geode.Geometry
{
    public class MultiLineString : IGeoType, IGeometry
    {
        public GeoType Type => GeoType.MultiLineString;
        public IEnumerable Coordinates { get; private set; }
        public Bounds Bounds { get; set; }
        public MultiLineString(IEnumerable<IEnumerable<IPosition>> coordinates)
        {
            Coordinates = coordinates;
        }
        public MultiLineString () { }
        public IEnumerable Geometry => Coordinates;
        public bool Equals(IGeometry other)
        {
            return Type == other.Type;
        }
    }
}
