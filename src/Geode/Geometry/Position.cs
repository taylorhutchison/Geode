using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Geode
{
    public struct Position : IPosition
    {
        private double[] _position;
        public double X => _position[0];
        public double Y => _position[1];
        public double Z => _position[2];
        public Position(double x, double y)
        {
            _position = new double[] { x, y, default(double) };
        }

        public Position(double x, double y, double z)
        {
            _position = new double[] { x, y, z };
        }

        double[] IPosition.Position => _position;

        public bool Equals(IPosition other)
        {
            throw new NotImplementedException();
        }
    }
}
