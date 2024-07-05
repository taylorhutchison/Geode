using System.Collections.Generic;

namespace Geode.Tests.FeatureTests.Models;
public class Flight
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<IEnumerable<double>> FlightPath { get; set; }
}
