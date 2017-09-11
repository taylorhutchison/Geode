using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.Models
{
    [Feature]
    public class Event: IFeatureConvertible<IGeoType>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Geometry(GeoType.Point)]
        public IGeoType Coordinates { get; set; }
        public IFeature<IGeoType> ToFeature()
        {
            return new Feature<IGeoType>
            {
                Properties = new Dictionary<string, object>()
                {
                    {nameof(Name), Name },
                    {nameof(Description), Description }
                },
                Geometry = Coordinates
            };
        }
    }
}
