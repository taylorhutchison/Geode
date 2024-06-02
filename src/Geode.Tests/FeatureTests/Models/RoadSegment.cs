using System.Collections.Generic;
using Geode.Tests.FeatureTests.Models.Geometries;

namespace Geode.Tests.FeatureTests.Models;
public class RoadSegment
{
    public int Id { get; set; }

    public LatLng MidPoint { get; set; }

    public IEnumerable<LatLng> Line { get; set; }

    public IEnumerable<LatLng> Bounds { get; set; }
}
