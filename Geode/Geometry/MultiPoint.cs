using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public class MultiPoint<T> : IGeoType
    {
        public GeoType Type => GeoType.MultiPoint;
        public IEnumerable Coordinates { get; set; }
        public MultiPoint(IEnumerable<IEnumerable<T>> coordinates)
        {
            Coordinates = coordinates;
        }
        public IEnumerable Geometry => Coordinates;
    }

    public class MultiPoint : IGeoType
    {
        public GeoType Type => GeoType.MultiPoint;
        public IEnumerable Coordinates { get; set; }
        public MultiPoint(IEnumerable<IEnumerable<double>> coordinates)
        {
            Coordinates = coordinates;
        }
        public IEnumerable Geometry => Coordinates;
    }
}
