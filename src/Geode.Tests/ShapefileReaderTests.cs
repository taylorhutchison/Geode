﻿using System;
using System.Linq;
using Xunit;
using Geode.Readers;

namespace Geode.Tests
{
    public class ShapefileReaderTests
    {
        [Fact]
        public void ReadShapefile()
        {
            var path = @"./TestData/Shapefiles/places.shp";
            var features = new ShapefileReader().Read(path);
            Assert.Equal(243, features.Features.Count());
        }
    }
}
