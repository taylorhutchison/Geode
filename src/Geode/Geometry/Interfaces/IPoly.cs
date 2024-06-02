using System.Collections.Generic;

namespace Geode;
public interface IPoly
{
    Bounds Bounds { get; }
    IEnumerable<IPosition> Positions { get; }
}
