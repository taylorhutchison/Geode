using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IFeature<T>
    {
        IDictionary<string, object> Properties { get; set; }
        T Geometry { get; set; }
    }
}
