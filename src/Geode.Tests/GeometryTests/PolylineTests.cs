using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Geode.Tests.GeometryTests;
public class PolylineTests
{
    [Fact]
    public void CanCreatePolylineFromListOfPoints()
    {
        var points = new List<Point2D> {
            new Point2D(1, 2),
            new Point2D(3, 4),
            new Point2D(5, 6)
        };
        var polyline = new Polyline(points);
        Assert.Equal(3, polyline.Geometry.Count());
    }

    [Fact]
    public void CanCreatePolylineFromArray()
    {
        var points = new double[][] {
            [1, 2],
            [3, 4],
            [5, 6]
        };
        var polyline = points.ToPolyline();
        Assert.Equal(3, polyline.Geometry.Count());
    }

    [Fact]
    public void PolylineCreationFromArray_ThrowsException_IfAnyArrayElementsHaveLessThanTwoElements()
    {
        var points = new double[][] {
            [1, 2],
            [3, 4],
            [5],
            [6, 7]
        };
        Assert.Throws<GeodeGeometryException>(() => points.ToPolyline());
    }

    [Fact]
    public void PolylineCreationFromArray_ThrowsException_IfAllArrayElementsAreNotConsistentLength()
    {
        var points = new double[][] {
            [1, 2],
            [3, 4],
            [5, 6, 7],
            [8, 9]
        };
        Assert.Throws<GeodeGeometryException>(() => points.ToPolyline());
    }

    [Fact]
    public void PolylineCreationFromArray_ThrowsException_IfAnyArrayElementsHaveZeroLength() {
        var points = new double[][] {
            [0],
            [1, 2],
            [3, 4],
            [5, 6]
        };
        Assert.Throws<GeodeGeometryException>(() => points.ToPolyline());
    }

    [Fact]
    public void PolylineCreationFromArray_ThrowsException_IfArrayIsNull() {
        double[][] points = null;
        Assert.Throws<GeodeGeometryException>(() => points.ToPolyline());
    }
}
