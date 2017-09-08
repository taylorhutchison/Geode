using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Geode.Geometry;

namespace Geode.Services
{
    internal static class FeatureService
    {
        private static IGeoType GetPointGeometry<T>(GeometryAttribute attribute, Object point)
        {
            var xMap = attribute.Map != null ? attribute.Map.XMap : "X";
            var yMap = attribute.Map != null ? attribute.Map.YMap : "Y";
            object x = point.GetType().GetProperty(xMap).GetValue(point, null);
            object y = point.GetType().GetProperty(yMap).GetValue(point, null);
            return new Point((double)x, (double)y);
        }

        private static IEnumerable<IEnumerable<T>> CreatePoly<T>(GeometryAttribute attribute, Object poly)
        {
            if (IsEnumerable(poly))
            {
                var xMap = attribute.Map != null ? attribute.Map.XMap : "X";
                var yMap = attribute.Map != null ? attribute.Map.YMap : "Y";
                var enumerable = poly as IEnumerable;
                var line = new List<IEnumerable<T>>();
                foreach (var point in enumerable)
                {
                    if (IsEnumerable(point))
                    {
                        line.Add(point as T[]);
                    }
                    else
                    {
                        object x = point.GetType().GetProperty(xMap).GetValue(point, null);
                        object y = point.GetType().GetProperty(yMap).GetValue(point, null);
                        var xy = new T[] { (T)x, (T)y };
                        line.Add(xy);
                    }
                }
                return line;
            }
            return null;
        }

        private static IGeoType GetPolylineGeometry<T>(GeometryAttribute attribute, Object polyline)
        {
            var line = CreatePoly<T>(attribute, polyline);
            return line != null ? new Polyline<T>(line) : null;
        }

        private static IGeoType GetPolygonGeometry<T>(GeometryAttribute attribute, Object polyline)
        {
            var line = CreatePoly<T>(attribute, polyline);
            return line != null ? new Polygon<T>(line) : null;
        }

        private static bool IsEnumerable(Object obj)
        {
            return obj != null && (obj as IEnumerable) != null;
        }

        private static IGeoType GetGeometry<T>(GeometryAttribute attribute, Object obj)
        {
            switch (attribute.Type)
            {
                case GeoType.Point:
                    return GetPointGeometry<T>(attribute, obj);
                case GeoType.LineString:
                    return GetPolylineGeometry<T>(attribute, obj);
                case GeoType.Polygon:
                    return GetPolygonGeometry<T>(attribute, obj);
                default:
                    throw new ArgumentException($"GeoType {attribute.Type} not handled.");
            }
        }

        private static GeometryAttribute GetGeometryAttribute(PropertyInfo prop)
        {
            var propAttributes = prop.GetCustomAttributes();
            return propAttributes.FirstOrDefault(at => at.GetType() == typeof(GeometryAttribute)) as GeometryAttribute;
        }

        public static Feature CreateFeature<T>(Object obj)
        {
            var properties = obj.GetType().GetRuntimeProperties();

            IGeoType geometry = null;
            var objProperties = new Dictionary<string, object>();
            foreach (var prop in properties)
            {
                var geoAttribute = GetGeometryAttribute(prop);
                var propVal = prop.GetValue(obj, null);
                if (geoAttribute != null)
                {
                    geometry = GetGeometry<T>(geoAttribute, propVal);
                }
                else
                {
                    objProperties.Add(prop.Name, propVal);
                }
            }

            var feature = new Feature
            {
                Geometry = geometry,
                Properties = objProperties
            };

            return feature;
        }

        public static FeatureCollection<IFeature<IGeoType>> CreateFeatures<T>(IEnumerable<Object> objList)
        {
            {
                var features = objList.Select(obj => CreateFeature<T>(obj));
                return new FeatureCollection<IFeature<IGeoType>>
                {
                    Features = features
                };
            }
        }

    }
}
