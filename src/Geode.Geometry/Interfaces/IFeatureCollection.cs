using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IFeatureCollection 
    {
        IEnumerable<IFeature> Features { get; set; }
    }
}
