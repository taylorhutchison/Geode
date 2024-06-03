﻿using System.Collections.Generic;
using Xunit;

namespace Geode.Tests;
public class GeometryServiceTests
{
    [Fact]
    public void GetCentroidOfListOfPositions()
    {
        IEnumerable<IPoint> points = new List<IPoint>
            {
                new Point(0,0,0),
                new Point(1,1,10)
            };
        var centroid = points.Centroid();
        Assert.Equal(0.5, centroid.Position[0]);
        Assert.Equal(0.5, centroid.Position[1]);
        Assert.Equal(5, centroid.Position[2]);
    }
}
