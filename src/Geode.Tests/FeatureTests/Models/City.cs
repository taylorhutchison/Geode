using System;
using System.Collections.Generic;

namespace Geode.Tests.FeatureTests.Models;
public class City : IFeatureConvertible
{
    public string Name { get; set; }
    public IEnumerable<IEnumerable<double>> Boundary { get; set; }

    public IFeature ToFeature()
    {
        throw new NotImplementedException();
    }
}
