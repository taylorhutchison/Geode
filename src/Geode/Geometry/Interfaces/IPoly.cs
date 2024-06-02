using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IPoly
    {
        IEnumerable<IPosition> Positions { get; }
    }
}
