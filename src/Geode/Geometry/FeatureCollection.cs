using System.Collections;
using System.Collections.Generic;

namespace Geode;
/// <summary>
/// A FeatureCollection is a collection of Features.
/// </summary>
public class FeatureCollection : IEnumerable<IFeature>, IFeatureCollection
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
}
