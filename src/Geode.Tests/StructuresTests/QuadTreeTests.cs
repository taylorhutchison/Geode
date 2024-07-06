using System;
using System.Collections.Generic;
using Xunit;

namespace Geode.Tests.Structures;

public class QuadTreeTests {

    [Fact]
    public void QuadTree_WithOnlyFourPoints_IsNotDivided() {
        var points = new List<IPoint> {
            new Point(1, 1),
            new Point(2, 2),
            new Point(3, 3),
            new Point(4, 4)
        };
        var quadTree = new QuadTree(points);
        Assert.False(quadTree.Divided);
    }

    [Fact]
    public void QuadTree_WithMoreThanFourPoints_IsNotDivided() {
        var points = new List<IPoint> {
            new Point(1, 1),
            new Point(2, 2),
            new Point(3, 3),
            new Point(4, 4),
            new Point(5, 5)
        };
        var quadTree = new QuadTree(points);
        Assert.True(quadTree.Divided);
    }

    [Fact]
    public void QuadTree_InsertOutsideBounds_ReturnsFalse() {
        var points = new List<IPoint> {
            new Point(1, 1),
            new Point(2, 2),
            new Point(3, 3),
            new Point(4, 4)
        };
        var quadTree = new QuadTree(points);
        var point = new Point(5, 5);
        Assert.False(quadTree.Insert(point));
    }

    [Fact]
    public void QuadTree_FindNearest_ReturnsNearestPoint() {
        var points = new List<IPoint>();
        for (var i = 0; i < 10; i++) {
            for(var j = 0; j < 10; j++) {
                points.Add(new Point(i, j));
            }
        }
        var quadTree = new QuadTree(points);
        var point = new Point(3.1, 3.1);
        var nearest = quadTree.FindNearest(point);

        Assert.Equal(3, nearest.X);
        Assert.Equal(3, nearest.Y);
    }


}