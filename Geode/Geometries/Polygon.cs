using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometries
{
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
