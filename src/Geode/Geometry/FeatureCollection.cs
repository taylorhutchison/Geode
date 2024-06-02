using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geode.Geometry;

namespace Geode
{
    /// <summary>
    /// A FeatureCollection is a collection of Features.
    /// </summary>
    public class FeatureCollection : IEnumerable<IFeature>, IFeatureCollection
    {
        public IEnumerable<IFeature> Features { get; set; }
        public IEnumerator<IFeature> GetEnumerator()
        {
            return Features.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Features.GetEnumerator();
        }
    }

}
