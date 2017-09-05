using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Geode.Geometry;
using Geode.Tests.Models;


namespace Geode.Tests
{
    public class CreateFeatureAsIFeatureConvertibleTests
    {
        [Fact]
        [Trait("Category","Unit")]
        public void CreateFeatureWithGeometryAttributesFavorsInterfaceMethod()
        {
            var city = new City
            {
                Boundary = new List<double[]>
                {
                    new double[] {0,0},
                    new double[] {1,1}
                }
            };
            Assert.Throws<NotImplementedException>(() =>
            {
                Feature.CreateFeature(city);
            });
        }
    }
}
