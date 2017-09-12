using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Geode.Geometry;
using Newtonsoft.Json.Serialization;

namespace Geode.Serializers
{
    public static class GeoJsonSerializer
    {
        public static string ToGeoJson(this IFeature feature, bool indented = false, bool camelCase = true)
        {
            var formatting = indented ? Formatting.Indented : Formatting.None;
            var contractResolver = camelCase ? new CamelCasePropertyNamesContractResolver() : null;
            var settings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = formatting
            };
            return feature.ToGeoJson(settings);
        }

        public static string ToGeoJson(this IFeature feature, JsonSerializerSettings settings)
        {
            var geoJsonFeature = new GeoJsonFeature(feature);
            return JsonConvert.SerializeObject(geoJsonFeature, settings);
        }

        public static string ToGeoJson(this IFeatureCollection featureCollection, bool indented = false, bool camelCase = true)
        {
            var geoJsonFeatures = new GeoJsonFeatureCollection(featureCollection);
            var formatting = indented ? Formatting.Indented : Formatting.None;
            var contractResolver = camelCase ? new CamelCasePropertyNamesContractResolver() : null;
            var settings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = formatting
            };
            return JsonConvert.SerializeObject(geoJsonFeatures, settings);
        }

        public static string ToGeoJson(this IFeatureCollection featureCollection, JsonSerializerSettings settings)
        {
            var geoJsonFeatures = new GeoJsonFeatureCollection(featureCollection);
            return JsonConvert.SerializeObject(geoJsonFeatures, settings);
        }
    }
}
