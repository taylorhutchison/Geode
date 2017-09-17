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
        public void Test()
        {
            var line = new List<double[]>()
            {
                new double[]{0,0},
                new double[]{1,1}
            };
            var midPoint = line.GetMidPoint();
            Assert.Equal(0.5, midPoint.Position[0]);
            Assert.Equal(0.5, midPoint.Position[1]);
        }
    }
}
