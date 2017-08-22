using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometries;

namespace Geode
{
    public class Feature<T> where T : IGeoType
    {
        public string Type => "Feature";
        public T Geometry { get; set; }
        public IDictionary<string, object> Properties { get; set; }

    }
}
