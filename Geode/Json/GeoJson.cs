using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Geode.Attributes;
using Geode.Geometries;
using Geode.Exceptions;

namespace Geode.Json
{
    public static class GeoJson
    {
        private static IGeoType GetPointGeometry<T>(GeometryAttribute attribute, Object point)
        {
            var xMap = attribute.Map != null ? attribute.Map.XMap : "X";
            var yMap = attribute.Map != null ? attribute.Map.YMap : "Y";
            object x = point.GetType().GetProperty(xMap).GetValue(point, null);
            object y = point.GetType().GetProperty(yMap).GetValue(point, null);
            return new Point<T>((T)x, (T)y);
        }

        private static IGeoType GetPolylineGeometry<T>(GeometryAttribute attribute, Object polyline)
        {
            if (IsEnumerable(polyline))
            {
                var xMap = attribute.Map != null ? attribute.Map.XMap : "X";
                var yMap = attribute.Map != null ? attribute.Map.YMap : "Y";
                var enumerable = polyline as IEnumerable;
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
                return new Polyline<T>(line);
            }
            return null;
        }

        private static bool IsEnumerable(Object obj)
        {
            return obj != null && (obj as IEnumerable) != null;
        }

        public static Feature<IGeoType> CreateFeature<T>(Object obj)
        {
            var properties = obj.GetType().GetRuntimeProperties();

            IGeoType geometry = null;
            var objProperties = new Dictionary<string, object>();
            foreach (var prop in properties)
            {
                var propAttributes = prop.GetCustomAttributes();
                var geoAttribute =
                    propAttributes.FirstOrDefault(at => at.GetType() == typeof(GeometryAttribute)) as GeometryAttribute;
                var propVal = prop.GetValue(obj, null);
                if (geoAttribute != null)
                {
                    if (geoAttribute.Type == GeoType.Point)
                    {
                        geometry = GetPointGeometry<T>(geoAttribute, propVal);
                    }
                    else if (geoAttribute.Type == GeoType.Polyline)
                    {
                        geometry = GetPolylineGeometry<T>(geoAttribute, propVal);
                    }
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


        public static Feature<IGeoType> CreateFeature(Object obj)
        {
            return CreateFeature<double>(obj);
        }
    }
}
