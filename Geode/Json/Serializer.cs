using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Geode.Json
{
    public static class Serializer
    {
        public static string Write(Object obj)
        {
            var geoObj = GeoJson.CreateFeature(obj);
            return JsonConvert.SerializeObject(geoObj, Formatting.Indented);
        }
    }
}
