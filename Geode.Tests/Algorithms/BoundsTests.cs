using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Geode;
using Geode.Geometry;
using Geode.Algorithms;

namespace Geode.Tests.Algorithms
{
    public class BoundsTests
    {
        [Fact]
        public void Test1()
        {
            var lineString = new List<double[]>
            {
                new double[]{ -1, -5 },
                new double[]{ 1, 22 }
            }.ToLineString();
            var bounds = lineString.GetBounds();
            Assert.Equal(-1, bounds.XMin);
            Assert.Equal(1, bounds.XMax);
            Assert.Equal(-5, bounds.YMin);
            Assert.Equal(22, bounds.YMax);
            Assert.Equal(0, bounds.ZMin);
            Assert.Equal(0, bounds.ZMax);
        }

        [Fact]
        public void Test2()
        {
            var c1 = new List<double[]>
            {
                new double[]{ -1, -6 },
                new double[]{ 1, 22 }
            }.ToLineString();
            var c2 = new List<double[]>
            {
                new double[]{ -3, -5 },
                new double[]{ 8, 7 }
            }.ToLineString();
            var lines = new List<LineString> {
                c1, c2
            };
            var bounds = lines.GetBounds();
            Assert.Equal(-3, bounds.XMin);
            Assert.Equal(8, bounds.XMax);
            Assert.Equal(-6, bounds.YMin);
            Assert.Equal(22, bounds.YMax);
            Assert.Equal(0, bounds.ZMin);
            Assert.Equal(0, bounds.ZMax);
        }
    }
}
