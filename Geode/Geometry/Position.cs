using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    internal struct Position : IPosition
    {
        private double[] _position;
        public double X => _position[0];
        public double Y => _position[1];
        public double Z => _position[2];
        public Position(double[] position)
        {
            _position = position;
        }
        public Position(double x, double y)
        {
            _position = new double[] { x, y };
        }
        public Position(double x, double y, double z)
        {
            _position = new double[] { x, y, z };
        }

        IReadOnlyList<double> IPosition.Position => _position;

        public bool Equals(IPosition other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<double> GetEnumerator()
        {
            return (IEnumerator<double>)_position.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _position.GetEnumerator();
        }
    }
}
