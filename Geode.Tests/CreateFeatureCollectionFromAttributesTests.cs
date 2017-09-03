using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using Geode.Json;
using Geode.Tests.Models;

namespace Geode.Tests
{
    public class CreateFeatureCollectionFromAttributesTests
    {
        [Fact]
        [Trait("Category", "Unit")]
        [Trait("Category", "CreateFeatures")]
        public void CreateFeatures_ListOfTypeWithXYProperties_CreatesFeatures()
        {
            var eventList = new List<Event>
            {
                new Event{
                    Name = "Test Name 1",
                    Description = "Test Description 1",
                    Coordinates = new Point { X = 123.005, Y = 456.004 }
                },
                new Event{
                    Name = "Test Name 2",
                    Description = "Test Description 1",
                    Coordinates = new Point { X = 777.123, Y = 999.789 }
                }
            };
            var featureCollection = FeatureCollection.CreateFeatures(eventList);
            Assert.Equal("FeatureCollection", featureCollection.Type);
            Assert.Equal(2, featureCollection.Features.Count());
        }
    }
}
