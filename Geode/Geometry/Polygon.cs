using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Geode.Geometry
{
    public class Polygon : IGeoType, IGeometry, IPoly
    {
        private IEnumerable<IPosition> _coordinates;
        public GeoType Type => GeoType.Polygon;
        public IEnumerable Coordinates => _coordinates;
        public IEnumerable Geometry => _coordinates;
        public IEnumerable<IPosition> Positions => _coordinates;
        public Polygon(IEnumerable<IPosition> coordinates)
        {
            _coordinates = coordinates;
        }
        public bool Equals(IGeoType other)
        {
            throw new NotImplementedException();
        }

    }
}
