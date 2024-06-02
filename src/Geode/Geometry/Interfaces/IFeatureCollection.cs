using System.Collections.Generic;

namespace Geode;
public interface IFeatureCollection
{
    IEnumerable<IFeature> Features { get; set; }
}
