using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IFeatureCollection<T> where T: IFeature<IGeoType>
    {
        string Type { get; }
        IEnumerable<T> Features { get; set; }
    }
}
