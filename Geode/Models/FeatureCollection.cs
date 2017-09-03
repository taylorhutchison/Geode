using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometries;

namespace Geode
{
    public class FeatureCollection<T> where T : IFeature<IGeoType>
    {
        public string Type => "FeatureCollection";
        public IEnumerable<T> Features { get; set; }
    }
}
