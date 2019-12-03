using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Geode.Geometry
{

    /// <summary>
    /// A LineString is a geometry type, sometimes refered to as a Polyline, that is represented by an array of positions.
    /// </summary>
    public class LineString : IGeoType, IGeometry, IPoly
    {
        private IEnumerable<IPosition> _coordinates;
        public GeoType Type => GeoType.LineString;
        public IEnumerable Coordinates => _coordinates;
        public Bounds Bounds { get; set; }
        public IEnumerable<IPosition> Positions => _coordinates;
        public LineString(IEnumerable<IPosition> coordinates)
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
