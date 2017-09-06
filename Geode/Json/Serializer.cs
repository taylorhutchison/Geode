using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Geode.Geometry;

namespace Geode.Json
{
    public static class Serializer
    {
        public static string Write(Object obj)
        {
            var geoObj = Feature.CreateFeature(obj);
            return JsonConvert.SerializeObject(geoObj, Formatting.Indented);
        }

        public static string Write(IFeature feature)
        {
            return JsonConvert.SerializeObject(feature, Formatting.Indented);
        }

        public static string Write(IFeatureCollection featureCollection)
        {
            return JsonConvert.SerializeObject(featureCollection, Formatting.Indented);
        }
    }
}
