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
        [Trait("Category", "Unit")]
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
                Feature<Polygon>.CreateFeature(city);
            });
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CreateFeature_GeoCollectionFeature_CreatesFeature()
        {
            var archipeligo = new Archipelago
            {
                Islands = new List<Polygon>()
                {
                    new Polygon()
                    {
                        Coordinates = new List<IEnumerable<double>> {
                         new double[]{0 ,0 },
                         new double[]{1 ,1 },
                         new double[]{2 ,2 }
                        }
                    },
                    new Polygon()
                    {
                        Coordinates = new List<IEnumerable<double>> {
                         new double[]{0 ,0 },
                         new double[]{1 ,1 },
                         new double[]{2 ,2 }
                        }
                    }
                },
                Name = "Test Name"
            };
            var feature = GeoCollectionFeature<Polygon>.CreateFeature(archipeligo);
            Assert.Equal(2, feature.Geometries.Count());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CreateFeature_GeoCollectionFeatureWithMultipleTypes_CreatesFeature()
        {
            var earthquake = new Earthquake
            {
                ImpactArea = new Polygon
                {
                    Coordinates = new List<IEnumerable<double>>
                    {
                        new double[]{0 ,0 },
                        new double[]{1 ,1 },
                        new double[]{2 ,2 }
                    }
                },
                Epicenter = new Geode.Geometry.Point(0, 0),
                Magnitude = 9.0
            };
            var feature = earthquake.ConvertToFeature();
        }
    }
}
