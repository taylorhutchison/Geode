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
            var line = new double[][] {
                [2, 3]
            }.ToLineString();
            var midPoint = line.GetMidPoint();
            Assert.Equal(2, midPoint.Position[0]);
            Assert.Equal(3, midPoint.Position[1]);
        }

        [Fact]
        public void LineStringWithTwoPositions()
        {
            var line = new double[][] {
                [ 0, 0 ],
                [ 1, 1 ]
            }.ToLineString();
            var midPoint = line.GetMidPoint();
            Assert.Equal(0.5, midPoint.Position[0]);
            Assert.Equal(0.5, midPoint.Position[1]);
        }

        [Fact]
        public void LineStringWithThreePositions()
        {
            var line = new double[][] {
                [0, 0],
                [1, 1],
                [5, 5]
            }.ToLineString();
            var midPoint = line.GetMidPoint();
            Assert.Equal(2.5, midPoint.Position[0]);
            Assert.Equal(2.5, midPoint.Position[1]);
        }
    }
}
