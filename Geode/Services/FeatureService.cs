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
        private static IGeoType GetPointGeometry(GeometryAttribute attribute, Object point)
        {
            var xMap = attribute.Map != null ? attribute.Map.XMap : "X";
            var yMap = attribute.Map != null ? attribute.Map.YMap : "Y";
            object x = point.GetType().GetProperty(xMap).GetValue(point, null);
            object y = point.GetType().GetProperty(yMap).GetValue(point, null);
            return new Point((double)x, (double)y);
        }

        private static IEnumerable<IEnumerable<double>> CreatePoly(GeometryAttribute attribute, Object poly)
        {
            if (IsEnumerable(poly))
            {
                var xMap = attribute.Map != null ? attribute.Map.XMap : "X";
                var yMap = attribute.Map != null ? attribute.Map.YMap : "Y";
                var enumerable = poly as IEnumerable;
                var line = new List<IEnumerable<double>>();
                foreach (var point in enumerable)
                {
                    if (IsEnumerable(point))
                    {
                        line.Add(point as double[]);
                    }
                    else
                    {
                        object x = point.GetType().GetProperty(xMap).GetValue(point, null);
                        object y = point.GetType().GetProperty(yMap).GetValue(point, null);
                        var xy = new double[] { (double)x, (double)y };
                        line.Add(xy);
                    }
                }
                return line;
            }
            return null;
        }

        private static IGeoType GetPolylineGeometry(GeometryAttribute attribute, Object polyline)
        {
            var line = CreatePoly(attribute, polyline);
            return line != null ? new Polyline(line) : null;
        }

        private static IGeoType GetPolygonGeometry(GeometryAttribute attribute, Object polyline)
        {
            var line = CreatePoly(attribute, polyline);
            return line != null ? new Polygon(line) : null;
        }

        private static bool IsEnumerable(Object obj)
        {
            return obj != null && (obj as IEnumerable) != null;
        }

        private static IGeoType GetGeometry(GeometryAttribute attribute, Object obj)
        {
            switch (attribute.Type)
            {
                case GeoType.Point:
                    return GetPointGeometry(attribute, obj);
                case GeoType.LineString:
                    return GetPolylineGeometry(attribute, obj);
                case GeoType.Polygon:
                    return GetPolygonGeometry(attribute, obj);
                default:
                    throw new ArgumentException($"GeoType {attribute.Type} not handled.");
            }
        }

        private static GeometryAttribute GetGeometryAttribute(PropertyInfo prop)
        {
            var propAttributes = prop.GetCustomAttributes();
            return propAttributes.FirstOrDefault(at => at.GetType() == typeof(GeometryAttribute)) as GeometryAttribute;
        }

        public static Feature<IGeoType> CreateFeature<T>(Object obj)
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
                    geometry = GetGeometry(geoAttribute, propVal);
                }
                else
                {
                    objProperties.Add(prop.Name, propVal);
                }
            }

            var feature = new Feature<IGeoType>
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
