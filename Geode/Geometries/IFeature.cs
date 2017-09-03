using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometries
{
    public interface IFeature<T>
    {
        string Type { get; }
        T Geometry { get; set; }
        IDictionary<string, object> Properties { get; set; }
    }
}
