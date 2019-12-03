using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using Geode.Readers;
using System.IO;
using Geode.Readers;

namespace Geode.Tests
{
    public class ShapefileReaderTests
    {
        [Fact]
        public void ReadShapefile()
        {
            var path = @"./Data/Shapefiles/places.shp";
            var features = new ShapefileReader().Read(path);
            Assert.Equal(243, features.Features.Count());
        }
    }
}
