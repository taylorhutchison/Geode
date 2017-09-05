using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public class Polygon: IGeoType
    {
        public string Type => "Polygon";
        public IEnumerable<IEnumerable<double>> Coordinates { get; set; }
        public Polygon(IEnumerable<IEnumerable<double>> coordinates)
        {
            Coordinates = coordinates;
        }
    }

    public class Polygon<T> : IGeoType
    {
        public string Type => "Polygon";
        public IEnumerable<IEnumerable<T>> Coordinates { get; set; }
        public Polygon(IEnumerable<IEnumerable<T>> coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
