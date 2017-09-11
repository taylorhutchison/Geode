using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Geode.Tests.Models;
using Geode.Geometry;
using Geode.Serializers;

namespace Geode.Tests
{
    public class GeoJsonTests
    {
        [Fact]
        public void ConvertFeatureToGeoJson()
        {
            var testEvent = new Event()
            {
                Name = "Test Event",
                Description = "TestDescription",
                Coordinates = new Point(10, 10),
            };
            var feature = testEvent.ToFeature().ToGeoJson(indented: true);
        }

        [Fact]
        public void ConvertFeatureCollectionToGeoJson()
        {
            var eventList = new List<Event> {
                new Event()
                {
                    Name = "Test Event",
                    Description = "TestDescription",
                    Coordinates = new Point(10, 10),
                },
                new Event()
                {
                    Name = "Test Event",
                    Description = "TestDescription",
                    Coordinates = new Point(10, 10),
                }
            };
            var feature = eventList.ToFeatureCollection().ToGeoJson(indented: true);
        }

        [Fact]
        public void ConvertGeoCollectionFeatureToGeoJson()
        {
            var archipelago = new Archipelago
            {

            };
            var feature = archipelago.ToFeature().ToGeoJson(indented: true);
        }
    }
}
