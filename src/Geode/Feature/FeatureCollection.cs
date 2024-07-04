using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Geode;
/// <summary>
/// A FeatureCollection is a collection of Features.
/// </summary>
public class FeatureCollection : IEnumerable<IFeature>
{
    public IEnumerable<IFeature> Features { get; set; }
    public IEnumerator<IFeature> GetEnumerator()
    {
        return Features.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return Features.GetEnumerator();
    }

    public FeatureCollection() {
        Features = Enumerable.Empty<IFeature>();
    }
}