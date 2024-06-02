using System.Collections.Generic;

namespace Geode;

public interface IFeature
{
    IDictionary<string, object> Properties { get; set; }
    IGeoType Geometry { get; set; }
}
