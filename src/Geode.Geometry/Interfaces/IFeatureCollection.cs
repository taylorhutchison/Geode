using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public interface IFeatureCollection<T>
    {
        IEnumerable<IFeature<T>> Features { get; set; }
    }
}
