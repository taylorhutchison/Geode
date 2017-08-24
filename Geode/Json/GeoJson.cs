using System;
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
        private static IGeoType GetPointGeometry(GeometryAttribute attribute, Object obj, Object value)
        {
            var xMap = attribute.Map != null ? attribute.Map.XMap : "X";
            var yMap = attribute.Map != null ? attribute.Map.YMap : "Y";
            object x = value.GetType().GetProperty(xMap).GetValue(value, null);
            object y = value.GetType().GetProperty(yMap).GetValue(value, null);
            return new Point((double)x, (double)y);
        }

        private static IGeoType GetPolylineGeometry(GeometryAttribute attribute, Object obj, Object value)
        {
            object x;
            object y;
            x = value.GetType().GetProperty("X").GetValue(value, null);
            y = value.GetType().GetProperty("Y").GetValue(value, null);
            return new Point((double)x, (double)y);
        }


        public static Feature<IGeoType> CreateFeature(Object obj)
        {
            var properties = obj.GetType().GetRuntimeProperties();
            var geometryPropertyFound = false;
            var isCollectionType = false;

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
                    if(geometryPropertyFound && !isCollectionType)
                    {
                        throw new MultipleGeometriesException();
                    }
                    geometryPropertyFound = true;
                    if (geoAttribute.Type == GeoType.Point)
                    {
                        geometry = GetPointGeometry(geoAttribute, obj, propVal);
                    }
                    else if (geoAttribute.Type == GeoType.Polyline)
                    {
                        geometry = GetPolylineGeometry(geoAttribute, obj, propVal);
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
    }
}
