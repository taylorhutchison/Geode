using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Geode;
using Geode.Geometries;

namespace Geode.Json
{
    public static class Serializer
    {
        public static string Write(Object obj)
        {
            var geoObj = Feature.CreateFeature(obj);
            return JsonConvert.SerializeObject(geoObj, Formatting.Indented);
        }
    }
}
