using System.Collections;

namespace Geode;
public interface IGeoType
{
    GeoType Type { get; }
    IEnumerable Geometry { get; }
}
