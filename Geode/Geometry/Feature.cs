using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;
using Geode.Services;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Geode.Tests")]

namespace Geode
{

    public sealed class Feature : IFeature
    {
        public string Type => "Feature";
        public IDictionary<string, object> Properties { get; set; }
        public IGeoType Geometry { get; set; }

        internal static IFeature CreateFeature(Object obj)
        {
            return FeatureService.CreateFeature<IGeoType>(obj);
        }

        internal static IFeature CreateFeature<T>(Object obj)
        {
            return FeatureService.CreateFeature<T>(obj);
        }

    }

}
