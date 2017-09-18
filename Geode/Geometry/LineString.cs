using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Geode.Geometry
{
    public static class LineStringExtensions
    {
        public static LineString ToLineString(this IEnumerable<IEnumerable<double>> lineString) {
            return new LineString(lineString);
        }
    }
    /// <summary>
    /// A LineString is a geometry type, sometimes refered to as a Polyline, that is represented by an array of positions.
    /// </summary>
    public class LineString : IGeoType, IGeometry, ILineString, IEnumerable<double[]>
    {
        private IEnumerable<double[]> _coordinates;
        public GeoType Type => GeoType.LineString;
        public IEnumerable Coordinates => _coordinates;
        public IEnumerable<double[]> LineArray => _coordinates;
        public LineString(IEnumerable<IEnumerable<double>> coordinates)
        {
            _coordinates = coordinates.Select(c => c.ToArray());
        }
        public LineString(IEnumerable<double[]> coordinates)
        {
            _coordinates = coordinates;
        }
        public LineString(double[][] coordinates)
        {
            _coordinates = coordinates;
        }
        public LineString(IEnumerable<IPosition> positions)
        {
            _coordinates = positions.Select(p => p.Position.ToArray());
        }

        public IEnumerable Geometry => _coordinates;
        
        public bool Equals(IGeoType other)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<double[]> GetEnumerator()
        {
            return _coordinates.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _coordinates.GetEnumerator();
        }
    }
}
