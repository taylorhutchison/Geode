using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Geode
{

    /// <summary>
    /// A Polyline is a geometry type, sometimes refered to as a Polyline, that is represented by an array of positions.
    /// </summary>
    public class Polyline : IGeoType, IGeometry, IPoly
    {
        private IEnumerable<IPosition> _coordinates;
        public GeoType Type => GeoType.Polyline;
        public IEnumerable Coordinates => _coordinates;
        public Bounds Bounds { get; set; }
        public IEnumerable<IPosition> Positions => _coordinates;
        public Polyline(IEnumerable<IPosition> coordinates)
        {
            _coordinates = coordinates;
        }
        public IEnumerable Geometry => _coordinates;
        
        public bool Equals(IGeometry other)
        {
            return Type == other.Type;
        }
    }
}
