using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Geode.Tests.FeatureTests.Models;

namespace Geode.Tests.FeatureTests;
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
            city.ToFeature();
        });
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void CreateFeature_GeoCollectionFeature_CreatesFeature()
    {
        var p1 = new List<double[]> {
                         new double[]{0 ,0 },
                         new double[]{1 ,1 },
                         new double[]{2 ,2 }
                        }.ToPolygon();
        var p2 = new List<double[]> {
                         new double[]{0 ,0 },
                         new double[]{1 ,1 },
                         new double[]{2 ,2 }
                        }.ToPolygon();
        var archipeligo = new Archipelago
        {
            Islands = new List<Polygon>()
                {
                    p1,
                    p2
                },
            Name = "Test Name"
        };
        var feature = archipeligo.ToFeature();
        var geometry = feature.Geometry as GeometryCollection;
        Assert.Equal(2, geometry.Count());
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void CreateFeature_GeoCollectionFeatureWithMultipleTypes_CreatesFeature()
    {
        var p1 = new List<double[]>
                    {
                        new double[]{0, 0 },
                        new double[]{1 ,1 },
                        new double[]{2 ,2 }
                    }.ToPolygon();
        var earthquake = new Earthquake
        {
            ImpactArea = p1,
            Epicenter = new Point(0, 0),
            Magnitude = 9.0
        };
        var feature = earthquake.ToFeature();
    }
}
