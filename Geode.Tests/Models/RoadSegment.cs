using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.Models
{
    public class RoadSegment
    {
        public int Id { get; set; }

        [Geometry(GeoType.Point)]
        public LatLng MidPoint { get; set; }

        [Geometry(GeoType.LineString)]
        public IEnumerable<LatLng> Line { get; set; }

        [Geometry(GeoType.Polygon)]
        public IEnumerable<LatLng> Bounds { get; set; }
    }
}
