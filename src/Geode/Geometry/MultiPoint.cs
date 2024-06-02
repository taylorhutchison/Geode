using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Geode
{
    public class MultiPoint : IGeoType, IGeometry
    {
        public GeoType Type => GeoType.MultiPoint;
        public IEnumerable Coordinates { get; set; }
        public MultiPoint(IEnumerable<IPosition> coordinates)
        {
            Coordinates = coordinates;
        }
        public IEnumerable Geometry => Coordinates;
        public Bounds Bounds { get; set; }

        public bool Equals(IGeometry other)
        {
            throw new NotImplementedException();
        }
    }
}
