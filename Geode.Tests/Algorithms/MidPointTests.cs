using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Geode;
using Geode.Algorithms;
using Geode.Geometry;

namespace Geode.Tests.Algorithms
{
    public class MidPointTests
    {
        [Fact]
        public void LineStringWithOnePosition()
        {
            var line = new LineString(new double[][] {
                new double[] { 2, 3 }
            });
            var midPoint = line.GetMidPoint();
            Assert.Equal(2, midPoint.Position[0]);
            Assert.Equal(3, midPoint.Position[1]);
        }

        [Fact]
        public void LineStringWithTwoPositions()
        {
            var line = new LineString( new double[][] {
                new double[] { 0, 0 },
                new double[] { 1, 1 }
            });
            var midPoint = line.GetMidPoint();
            Assert.Equal(0.5, midPoint.Position[0]);
            Assert.Equal(0.5, midPoint.Position[1]);
        }

        [Fact]
        public void LineStringWithThreePositions()
        {
            var line = new LineString(new double[][] {
                new double[] { 0, 0 },
                new double[] { 1, 1 },
                new double[] { 5, 5 }
            });
            var midPoint = line.GetMidPoint();
            Assert.Equal(2.5, midPoint.Position[0]);
            Assert.Equal(2.5, midPoint.Position[1]);
        }
    }
}
