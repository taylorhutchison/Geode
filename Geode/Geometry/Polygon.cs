using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Geode.Geometry
{
    public class Polygon : IGeoType, IGeometry, IEnumerable<IEnumerable<double>>
    {
        private IEnumerable<IEnumerable<double>> _coordinates;
        public GeoType Type => GeoType.Polygon;
        public IEnumerable Coordinates => _coordinates;
        public IEnumerable Geometry => _coordinates;
        public Polygon(IEnumerable<IEnumerable<double>> coordinates)
        {
            _coordinates = coordinates;
        }
        public Polygon() { }
        public bool Equals(IGeoType other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IEnumerable<double>> GetEnumerator()
        {
            return _coordinates.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _coordinates.GetEnumerator();
        }
    }
}
