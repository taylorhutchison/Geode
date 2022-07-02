using System;
using System.Collections.Generic;
using System.Text;
using Geode;
using Geode.Geometry;

namespace Geode.Serializers
{
    public class WktSerializer
    {
        public static string ToWKT(IPosition position)
        {
            if(position == null)
            {
                return string.Empty;
            }
            return $"POINT ({position.X} {position.Y})";
        }
    }
}
