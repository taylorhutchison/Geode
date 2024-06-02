using System.Collections.Generic;

namespace Geode.Tests.FeatureTests.Models;
public class Pipe
{
    public int Id { get; set; }
    public IEnumerable<double[]> Location { get; set; }
}
