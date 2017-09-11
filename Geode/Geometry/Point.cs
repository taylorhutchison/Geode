using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace Geode.Geometry
{
    public class Point : IGeoType, IPosition, IEnumerable<double>
    {
        public GeoType Type => GeoType.Point;
        public IReadOnlyList<double> Coordinates { get; set; }
        public Point(double x, double y)
        {
            Coordinates = new double[] { x, y };
        }
        public Point(double x, double y, double z)
        {
            Coordinates = new double[] { x, y, z };
        }
        public Point(IPosition position)
        {
            Coordinates = position.Coordinates.ToArray();
        }
        public Point() { }
        public IEnumerable Geometry => Coordinates;

        public IReadOnlyList<double> Position => Coordinates;

        public IEnumerator<double> GetEnumerator()
        {
            return Position.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Position.GetEnumerator();
        }

        public bool Equals(IGeoType other)
        {
            throw new NotImplementedException();
        }
        
    }

}
