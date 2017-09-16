using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Geode.Readers;

namespace Geode.Tests
{
    public class ShapefileReaderTests
    {
        [Fact]
        public void ReadShapefile()
        {
            var reader = new ShapefileReader();
            var header = reader.GetShpHeader(@"./Data/Shapefiles/places.shp");
        }
    }
}
