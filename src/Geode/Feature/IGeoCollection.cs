using System.Collections.Generic;

namespace Geode;
public interface IGeoCollection
{
    IEnumerable<IGeometry>? Geometries { get; }
}
