using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IFeature
    {
        IDictionary<string, object> Properties { get; set; }
        IGeoType Geometry { get; set; }
    }
}
