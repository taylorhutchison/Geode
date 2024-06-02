using System;
using System.Collections.Generic;
using System.Text;

namespace Geode
{
    public interface IPosition: IEquatable<IPosition>
    {
        double[] Position { get; }
        double X { get;  }
        double Y { get;  }
        double Z { get;  }
    }

}
