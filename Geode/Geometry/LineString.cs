using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Geode.Geometry
{
    public static class LineStringExtensions
    {
        public static LineString ToLineString(this IEnumerable<double[]> positions)
        {
            var posArray = positions.Select((p, i) =>
            {
                var x = p.Length > 0 ? p[0] : default(double);
                var y = p.Length > 1 ? p[1] : default(double);
                var z = p.Length > 2 ? p[2] : default(double);
                return new Position(x,y,z) as IPosition;
            });
            return new LineString(posArray);
        }
    }
    /// <summary>
    /// A LineString is a geometry type, sometimes refered to as a Polyline, that is represented by an array of positions.
    /// </summary>
    public class LineString : IGeoType, IGeometry, IPoly
    {
        private IEnumerable<IPosition> _coordinates;
        public GeoType Type => GeoType.LineString;
        public IEnumerable Coordinates => _coordinates;
        public IEnumerable<IPosition> Positions => _coordinates;
        public LineString(IEnumerable<IPosition> coordinates)
        {
            _coordinates = coordinates;
        }
        public IEnumerable Geometry => _coordinates;
        
        public bool Equals(IGeoType other)
        {
            throw new NotImplementedException();
        }
    }
}
