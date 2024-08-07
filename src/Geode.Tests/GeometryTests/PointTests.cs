﻿using Xunit;

namespace Geode.Tests.GeometryTests;
public class PointTests
{
    [Fact]
    public void PointsAreEqual()
    {
        var p1 = new Point(1, 2);
        var p2 = new Point(1, 2);
        Assert.True(p1.Equals(p2));
        Assert.True(p2.Equals(p1));
    }

    [Fact]
    public void PointsAreNotEqual()
    {
        var p1 = new Point(2, 1);
        var p2 = new Point(1, 2);
        Assert.False(p1.Equals(p2));
        Assert.False(p2.Equals(p1));
    }

    [Fact]
    public void PointsOfDifferentDimensionsAreNotEqual()
    {
        var p1 = new Point(1, 2);
        var p2 = new Point(1, 2, 3);
        Assert.False(p1.Equals(p2));
        Assert.False(p2.Equals(p1));
    }
}
