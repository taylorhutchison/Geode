using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public class Polyline<T> : IGeoType
    {
        public string Type => "LineString";
        public IEnumerable<IEnumerable<T>> Coordinates { get; set; }
        public Polyline(IEnumerable<IEnumerable<T>> coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
