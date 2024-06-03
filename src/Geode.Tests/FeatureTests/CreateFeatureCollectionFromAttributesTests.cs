using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Geode.Tests.FeatureTests.Models;

namespace Geode.Tests.FeatureTests;
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
                    Location = new Point(123.005,456.004)
                },
                new Event{
                    Name = "Test Name 2",
                    Description = "Test Description 1",
                    Location = new Point(777.123,999.789)
                }
            };
        var featureCollection = eventList.ToFeatureCollection();
        Assert.Equal(2, featureCollection.Features.Count());
    }
}
