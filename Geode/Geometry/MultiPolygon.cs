using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public class MultiPolygon : IGeoType, IGeometry
    {
        public GeoType Type => GeoType.MultiLineString;
        public IEnumerable Coordinates { get; private set; }
        public MultiPolygon(IEnumerable<IEnumerable<IEnumerable<double>>> coordinates)
        {
            Coordinates = coordinates;
        }
        public MultiPolygon() { }
        public IEnumerable Geometry => Coordinates;
        public bool Equals(IGeoType other)
        {
            throw new NotImplementedException();
        }
    }
}
