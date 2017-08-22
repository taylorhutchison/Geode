using System;
using Xunit;
using Geode.Json;
using Geode.Tests.Models;

namespace Geode.Tests
{
    public class GeoJsonTests
    {
        [Fact]
        public void CreateFeature_TypeWithXYProperties_CreatesFeature()
        {
            var testEvent = new Event
            {
                Name = "Test Name",
                Description = "Test Description",
                Coordinates = new Point { X = 123.005, Y = 456.004 }
            };
            var feature = GeoJson.CreateFeature(testEvent);
            Assert.Equal("Feature", feature.Type);
            var geometry = feature.Geometry as Geometries.Point;
            Assert.Equal(123.005, geometry.Coordinates[0]);
            Assert.Equal(456.004, geometry.Coordinates[1]);
        }

        [Fact]
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

            var feature = GeoJson.CreateFeature(testPlace);
            var geometry = feature.Geometry as Geometries.Point;
            Assert.Equal(90, geometry.Coordinates[0]);
            Assert.Equal(180, geometry.Coordinates[1]);
        }
    }
}
