using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;
using Geode.Services;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Geode.Tests")]

namespace Geode
{

    public static class Feature
    {
        internal static IFeature<IGeoType> CreateFeature(Object obj)
        {
            return FeatureService.CreateFeature<IGeoType>(obj);
        }

        internal static IFeature<IGeoType> CreateFeature<T>(Object obj)
        {
            return FeatureService.CreateFeature<T>(obj);
        }
    }

    public sealed class Feature<T>: IFeature<IGeoType>
    {
        public string Test => "Hello!";
        public string Type => "Feature";
        public IDictionary<string, object> Properties { get; set; }
        public IGeoType Geometry { get; set; }

    }

}
