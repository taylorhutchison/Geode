using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Geode.Structures;

namespace Geode.Geometry
{
    public class MultiPolygon : IGeoType, IGeometry
    {
        public GeoType Type => GeoType.MultiLineString;
        public IEnumerable Coordinates { get; private set; }
        public MultiPolygon(IEnumerable<IEnumerable<IPosition>> coordinates)
        {
            Coordinates = coordinates;
        }
        public MultiPolygon() { }
        public Bounds Bounds { get; set; }
        public IEnumerable Geometry => Coordinates;
        public bool Equals(IGeometry other)
        {
            throw new NotImplementedException();
        }
    }
}
