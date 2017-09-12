using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace Geode.Geometry
{
    public sealed class Point : IGeoType, IPosition, IGeometry, IEnumerable<double>
    {
        private double[] _position;
        public GeoType Type => GeoType.Point;
        public IReadOnlyList<double> Position => _position;
        public IEnumerable Coordinates => _position;
        public IEnumerable Geometry => Coordinates;
        public Point(double x, double y)
        {
            _position = new double[] { x, y };
        }
        public Point(double x, double y, double z)
        {
            _position = new double[] { x, y, z };
        }
        public Point(IPosition position)
        {
            _position = position.Position.ToArray();
        }
        public Point(double[] position)
        {
            _position = position;
        }
        public Point() { }

        public bool Equals(IGeoType other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<double> GetEnumerator()
        {
            return ((IEnumerable<double>)_position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_position).GetEnumerator();
        }
    }

}
