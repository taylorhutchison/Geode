using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Geode.Geometry;
using Geode.Tests.Models;

namespace Geode.Tests
{
    public class CreateFeatureFromAttributesTests
    {
        [Fact]
        [Trait("Category","Unit")]
        [Trait("Category", "FeatureCreation")]
        public void CreateFeature_TypeWithXYProperties_CreatesFeature()
        {
            var testEvent = new Event
            {
                Name = "Test Name",
                Description = "Test Description",
                Coordinates = new Geode.Tests.Models.Point { X = 123.005, Y = 456.004 }
            };
            var feature = (Feature)Feature.CreateFeature(testEvent);
            Assert.Equal("Feature", feature.Type);
            var geometry = feature.Geometry as Point<double>;
            Assert.Equal(123.005, geometry.Coordinates[0]);
            Assert.Equal(456.004, geometry.Coordinates[1]);
        }

        [Fact]
        [Trait("Category", "Unit")]
        [Trait("Category", "FeatureCreation")]
        public void CreateFeature_TypeWithMappedXYProperties_CreatesFeature()
        {
            var testPlace = new Place
            {
                Name = "Test Place",
                Description = "Test Description",
                Location = new LatLng
                {
                    Lat = 90,
                    Lng = 180
                }
            };

            var feature = (Feature)Feature.CreateFeature(testPlace);
            var geometry = feature.Geometry as Point<double>;
            Assert.Equal(90, geometry.Coordinates[0]);
            Assert.Equal(180, geometry.Coordinates[1]);
        }

        [Fact]
        [Trait("Category", "Unit")]
        [Trait("Category", "FeatureCreation")]
        public void CreateFeature_TypeOfPolylineGeometry_CreatesFeature()
        {
            var testIncident = new Incident
            {
                Description = "Test Description",
                Route = new List<Geode.Tests.Models.Point>
                {
                    new Geode.Tests.Models.Point { X = 1, Y = 4},
                    new Geode.Tests.Models.Point { X = 9, Y = 7}
                }
            };
            var feature = (Feature)Feature.CreateFeature(testIncident);
            var geometry = feature.Geometry as Polyline<double>;
            var coordinatePairs = geometry.Coordinates.Select(c => c.ToArray()).ToArray();
            Assert.Equal(1, coordinatePairs[0][0]);
            Assert.Equal(4, coordinatePairs[0][1]);
            Assert.Equal(9, coordinatePairs[1][0]);
            Assert.Equal(7, coordinatePairs[1][1]);
        }

        [Fact]
        [Trait("Category", "Unit")]
        [Trait("Category", "FeatureCreation")]
        public void CreateFeature_TypeOfPolylineGeometryWithMappedXYProperties_CreatesFeature()
        {
            var testRiver = new River
            {
                Name = "Test Name",
                Description = "Test Description",
                Location = new List<LatLng>
                {
                    new LatLng { Lat = 1, Lng = 1},
                    new LatLng { Lat = 2, Lng = 2}
                }
            };
            var feature = (Feature)Feature.CreateFeature(testRiver);
            var geometry = feature.Geometry as Polyline<double>;
            var coordinatePairs = geometry.Coordinates.Select(c => c.ToArray()).ToArray();
            Assert.Equal(1, coordinatePairs[0][0]);
            Assert.Equal(1, coordinatePairs[0][1]);
            Assert.Equal(2, coordinatePairs[1][0]);
            Assert.Equal(2, coordinatePairs[1][0]);
        }

        [Fact]
        [Trait("Category", "Unit")]
        [Trait("Category", "FeatureCreation")]
        public void CreateFeature_TypeOfPolylineGeometryAsArrayOfArrays_CreatesFeature()
        {
            var testPipe= new Pipe
            {
                Id = 1,
                Location = new List<double[]>
                {
                    new double[] {24, 35},
                    new double[] {56, 22}
                }
            };
            var feature = (Feature)Feature.CreateFeature(testPipe);
            var geometry = feature.Geometry as Polyline<double>;
            var coordinatePairs = geometry.Coordinates.Select(c => c.ToArray()).ToArray();
            Assert.Equal(24, coordinatePairs[0][0]);
            Assert.Equal(35, coordinatePairs[0][1]);
            Assert.Equal(56, coordinatePairs[1][0]);
            Assert.Equal(22, coordinatePairs[1][1]);
        }

        [Fact]
        [Trait("Category", "Unit")]
        [Trait("Category", "FeatureCreation")]
        public void CreateFeature_TypeOfPolylineGeometryAsArrayOfInts_CreatesFeature()
        {
            var testFlight = new Flight
            {
                Id = 1,
                Name = "Test Name",
                FlightPath = new List<int[]>
                {
                    new int[] {10, 20},
                    new int[] {30, 40}
                }
            };
            var feature = (Feature)Feature.CreateFeature<int>(testFlight);
            var geometry = feature.Geometry as Polyline<int>;
            var coordinatePairs = geometry.Coordinates.Select(c => c.ToArray()).ToArray();
            Assert.Equal(10, coordinatePairs[0][0]);
            Assert.Equal(20, coordinatePairs[0][1]);
            Assert.Equal(30, coordinatePairs[1][0]);
            Assert.Equal(40, coordinatePairs[1][1]);
        }

        [Fact]
        [Trait("Category", "Unit")]
        [Trait("Category", "FeatureCreation")]
        public void CreateFeature_TypeOfPolygonGeometry_CreatesFeature()
        {
            var testCountry = new Country
            {
                Name = "Test Name",
                Boundary = new List<int[]>
                {
                    new int[] {0, 0},
                    new int[] {10, 10},
                    new int[] {-10, 10},
                    new int[] {0, 0}
                }
            };
            var feature = (Feature)Feature.CreateFeature<int>(testCountry);
            var geometry = feature.Geometry as Polygon<int>;
            var coordinatePairs = geometry.Coordinates.Select(c => c.ToArray()).ToArray();
            Assert.Equal(0, coordinatePairs[0][0]);
            Assert.Equal(0, coordinatePairs[0][1]);
            Assert.Equal(10, coordinatePairs[1][0]);
            Assert.Equal(10, coordinatePairs[1][1]);
            Assert.Equal(-10, coordinatePairs[2][0]);
            Assert.Equal(10, coordinatePairs[2][1]);
            Assert.Equal(0, coordinatePairs[3][0]);
            Assert.Equal(0, coordinatePairs[3][1]);
        }
    }
}
