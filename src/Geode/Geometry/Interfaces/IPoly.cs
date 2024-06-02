using System.Collections.Generic;

namespace Geode;
public interface IPoly
{
    IEnumerable<IPosition> Positions { get; }
}
