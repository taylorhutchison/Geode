using System;
using System.Collections.Generic;
using System.Text;

namespace Geode
{
    public interface IPoly
    {
        IEnumerable<IPosition> Positions { get; }
    }
}
