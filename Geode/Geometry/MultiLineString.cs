using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Geode.Geometry
{
    public class MultiLineString : IGeoType
    {
        public GeoType Type => GeoType.MultiLineString;
        public IEnumerable<IEnumerable<IEnumerable<double>>> Coordinates { get; set; }
        public MultiLineString(IEnumerable<IEnumerable<IEnumerable<double>>> coordinates)
        {
            Coordinates = coordinates;
        }
        public MultiLineString () { }
        public IEnumerable Geometry => Coordinates;
        public bool Equals(IGeoType other)
        {
            throw new NotImplementedException();
        }
    }
}
