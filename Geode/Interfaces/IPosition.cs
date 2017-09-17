using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IPosition: IEquatable<IPosition>
    {
        IReadOnlyList<double> Position { get; }
    }

}
