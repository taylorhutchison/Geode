using System;
using System.Collections;
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
            var p1 = new List<IEnumerable<double>>
                        {
                            new double[]{0,0},
                            new double[]{1,1},
                            new double[]{2,2},
                            new double[]{3,3}
                        };
            var p2 = new List<IEnumerable<double>>
                        {
                            new double[]{4,4},
                            new double[]{5,5},
                            new double[]{6,6},
                            new double[]{7,7}
                        };
            var archipelago = new Archipelago
            {
                Islands = new List<IGeometry>
                {
                    new Polygon(p1),
                    new Polygon(p2),
                    new Point(1,2,3)
                },
                Name = "Test Archipelago"
            };
            var feature = archipelago.ToFeature().ToGeoJson(indented: true, camelCase: false);
        }

        [Fact]
        public void ConvertFeatureCollectionWithGeoCollectionFeatureToGeoJson()
        {
            var p1 = new List<IEnumerable<double>>
                        {
                            new double[]{0,0},
                            new double[]{1,1},
                            new double[]{2,2},
                            new double[]{3,3}
                        };
            var p2 = new List<IEnumerable<double>>
                        {
                            new double[]{4,4},
                            new double[]{5,5},
                            new double[]{6,6},
                            new double[]{7,7}
                        };
            var archipelago = new Archipelago
            {
                Islands = new List<IGeometry>
                {
                    new Polygon(p1),
                    new Polygon(p2),
                    new Point(1,2,3)
                },
                Name = "Test Archipelago"
            };
            var testEvent = new Event
            {
                Coordinates = new Point(1, 2),
                Description = "Test Description",
                Name = "Test Name"
            };

            var features = new List<IFeatureConvertible>
            {
                archipelago,
                testEvent
            }.ToFeatureCollection();

            var geoJson = features.ToGeoJson(indented: true, camelCase: true);
        }
    }
}
