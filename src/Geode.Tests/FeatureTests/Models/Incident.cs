using System.Collections.Generic;

namespace Geode.Tests.FeatureTests.Models;
public class Incident
{
    public string Description { get; set; }
    public IEnumerable<Point2D> Route { get; set; }
}
