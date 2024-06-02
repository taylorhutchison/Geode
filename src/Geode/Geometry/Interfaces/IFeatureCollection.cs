using System;
using System.Collections.Generic;
using System.Text;

namespace Geode
{
    public interface IFeatureCollection 
    {
        IEnumerable<IFeature> Features { get; set; }
    }
}
