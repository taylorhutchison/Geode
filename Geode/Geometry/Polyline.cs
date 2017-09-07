using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Geode.Geometry
{
    public class Polyline<T> : IGeoType
    {
        public GeoType Type => GeoType.LineString;
        public IEnumerable<IEnumerable<T>> Coordinates { get; set; }
        public Polyline(IEnumerable<IEnumerable<T>> coordinates)
        {
            Coordinates = coordinates;
        }
        public IEnumerable Geometry => Coordinates;
    }

    public class Polyline : IGeoType
    {
        public GeoType Type => GeoType.LineString;
        public IEnumerable<IEnumerable<double>> Coordinates { get; set; }
        public Polyline(IEnumerable<IEnumerable<double>> coordinates)
        {
            Coordinates = coordinates;
        }
        public IEnumerable Geometry => Coordinates;
    }
}
