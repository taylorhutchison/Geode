using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Geode.Geometry;

namespace Geode.Serializers
{
    public static class GeoJsonSerializer
    {
        public static string ToGeoJson(this IFeature<IGeoType> feature, bool indented = false)
        {
            var formatting = indented ? Formatting.Indented : Formatting.None;
            return JsonConvert.SerializeObject(feature, formatting);
        }

        public static string ToGeoJson(this IFeatureCollection<IFeature<IGeoType>> featureCollection, bool indented = false)
        {
            var formatting = indented ? Formatting.Indented : Formatting.None;
            return JsonConvert.SerializeObject(featureCollection, formatting);
        }
    }
}
