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
                Islands = new List<IGeoType>
                {
                    new Polygon
                    {
                        Coordinates = new List<IEnumerable<double>>
                        {
                            new double[]{0,0},
                            new double[]{1,1},
                            new double[]{2,2},
                            new double[]{3,3}
                        }
                    },
                    new Polygon
                    {
                        Coordinates = new List<IEnumerable<double>>
                        {
                            new double[]{4,4},
                            new double[]{5,5},
                            new double[]{6,6},
                            new double[]{7,7}
                        }
                    },
                    new Point(1,2,3)
                },
                Name = "Test Archipelago"
            };
            var feature = archipelago.ToFeature().ToGeoJson(indented: true);
        }
    }
}
