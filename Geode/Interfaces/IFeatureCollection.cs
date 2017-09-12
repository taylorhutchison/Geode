using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IFeatureCollection 
    {
        string Type { get; }
        IEnumerable<IFeature> Features { get; set; }
    }
}
