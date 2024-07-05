using System.Collections.Generic;

namespace Geode.Tests.FeatureTests.Models;
public class Highway
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<RoadSegment> Segments { get; set; }
}
