using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometries
{
    public class Polyline : IGeoType
    {
        public string Type => "LineString";
        public IEnumerable<IEnumerable<double>> Coordinates { get; set; }
        public Polyline(IEnumerable<IEnumerable<double>> coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
