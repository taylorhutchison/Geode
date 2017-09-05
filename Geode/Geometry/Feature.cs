﻿using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;
using Geode.Services;

namespace Geode
{
    public class Feature<T>: IFeature<T> where T : IGeoType
    {
        public string Type => "Feature";
        public T Geometry { get; set; }
        public IDictionary<string, object> Properties { get; set; }
    }

    public static class Feature
    {
        public static IFeature<IGeoType> CreateFeature(Object obj) => FeatureService.CreateFeature(obj);

        public static IFeature<IGeoType> CreateFeature<U>(Object obj) => FeatureService.CreateFeature<U>(obj);

        public static IFeature<IGeoType> CreateFeature(IFeatureConvertible feature)
        {
            return feature.ConvertToFeature();
        }
    }
}
