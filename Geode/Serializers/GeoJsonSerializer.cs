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
    internal class FeatureContractResolver : DefaultContractResolver
    {
        private IEnumerable<Type> _typeList {
            get {
                yield return typeof(IFeature);
            }
        }
        protected override IList<JsonProperty> CreateProperties(
            Type type,
            MemberSerialization memberSerialization)
        {
            foreach (var t in _typeList)
            {
                if (t.IsAssignableFrom(type))
                {
                    return base.CreateProperties(t, memberSerialization);
                }
            }
            return base.CreateProperties(type, memberSerialization);
        }
    }

    public static class GeoJsonSerializer
    {
        public static string ToGeoJson(this IFeature feature, bool indented = false)
        {
            var geoJsonFeature = new GeoJsonFeature(feature);
            var formatting = indented ? Formatting.Indented : Formatting.None;
            var settings = new JsonSerializerSettings
            {
                //ContractResolver = new FeatureContractResolver(),
                Formatting = formatting
            };
            return JsonConvert.SerializeObject(geoJsonFeature, settings);
        }

        public static string ToGeoJson(this IFeatureCollection featureCollection, bool indented = false)
        {
            var geoJsonFeatures = new GeoJsonFeatureCollection(featureCollection);
            var formatting = indented ? Formatting.Indented : Formatting.None;
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new FeatureContractResolver(),
                Formatting = formatting
            };
            return JsonConvert.SerializeObject(geoJsonFeatures, settings);
        }
    }
}
