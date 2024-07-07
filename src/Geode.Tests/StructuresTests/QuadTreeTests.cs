using System;
using System.Collections.Generic;
using Xunit;

namespace Geode.Tests.Structures;
using TestData = StructuresTestData;

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
    public void QuadTree_WithMoreThanFourPoints_IsDivided() {
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

    [Theory]
    [MemberData(nameof(TestData.QuadTreeTestData), MemberType = typeof(TestData))]
    public void QuadTree_FindNearest_PointOutsideBounds(int gridSize, Point searchPoint, Point expected)
    {
        var points = new List<IPoint>();
        for (var i = 0; i <= gridSize; i++)
        {
            for (var j = 0; j <= gridSize; j++)
            {
                points.Add(new Point(i, j));
            }
        }
        var quadTree = new QuadTree(points);
        var nearest = quadTree.FindNearest(searchPoint);
        Assert.Equal(expected.X, nearest.X);
        Assert.Equal(expected.Y, nearest.Y);
    }

}
