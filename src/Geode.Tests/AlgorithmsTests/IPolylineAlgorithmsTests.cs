using Xunit;

namespace Geode.Tests.Algorithms;

public class IPolylineAlgorithmsTests
{
    [Fact]
    public void DistanceCalculatedAsZeroFor2DPolylineWithOnePosition()
    {
        var line = new Point[] {
                new(0, 10)
            }.ToPolyline();
        var distance = line.GetDistance();
        Assert.Equal(0, distance);
    }

    [Fact]
    public void DistanceCalculatedAsZeroFor3DPolylineWithOnePosition()
    {
        var line = new Point[] {
                new(0, 10, 20)
            }.ToPolyline();
        var distance = line.GetDistance();
        Assert.Equal(0, distance);
    }

    [Fact]
    public void DistanceCalculatedFor2DPolyline()
    {
        var line = new Point[] {
                new(0, 0),
                new(5, 5),
                new(10, 0),
                new(15, 5)
            }.ToPolyline();
        var distance = line.GetDistance();
        Assert.Equal(21.2132034355965m, distance, 12);
    }

    [Fact]
    public void DistanceCalculatedFor2DPolylineExtendingIntoNegativeSpace()
    {
        var line = new Point[] {
                new(0, 0),
                new(-5, -5),
                new(-10, -0),
                new(-15, -5)
            }.ToPolyline();
        var distance = line.GetDistance();
        Assert.Equal(21.2132034355965m, distance, 12);
    }

    [Fact]
    public void DistanceCalculatedFor3DPolyline()
    {
        var line = new Point[] {
                new(0, 0, 0),
                new(5, 5, 5),
                new(10, 0, 10),
                new(15, 5, 15)
            }.ToPolyline();
        var distance = line.GetDistance();
        Assert.Equal(25.980762113533175m, distance, 12);
    }

    [Fact]
    public void DistanceCalculatedFor3DPolylineWithoutZAxisChange()
    {
        var line = new Point[] {
                new(0, 0, 0),
                new(5, 5, 0),
                new(10, 0, 0),
                new(15, 5, 0)
            }.ToPolyline();
        var distance = line.GetDistance();
        Assert.Equal(21.2132034355965m, distance, 12);
    }

    [Fact]
    public void PolylineWithOnePosition()
    {
        var line = new double[][] {
                [2, 3]
            }.ToPolyline();
        var midPoint = line.GetMidPoint();
        Assert.Equal(2, midPoint.X);
        Assert.Equal(3, midPoint.Y);
    }

    [Fact]
    public void PolylineWithTwoPositions()
    {
        var line = new double[][] {
                [ 0, 0 ],
                [ 1, 1 ]
            }.ToPolyline();
        var midPoint = line.GetMidPoint();
        Assert.Equal(0.5, midPoint.X);
        Assert.Equal(0.5, midPoint.Y);
    }

    [Fact]
    public void PolylineWithThreePositions()
    {
        var line = new double[][] {
                [0, 0],
                [1, 1],
                [5, 5]
            }.ToPolyline();
        var midPoint = line.GetMidPoint();
        Assert.Equal(2.5, midPoint.X);
        Assert.Equal(2.5, midPoint.Y);
    }

    [Fact]
    public void PolylineWithHundredsOfPositions()
    {
        var line = new double[100][];
        for (var i = 0; i < 100; i++)
        {
            line[i] = new double[] { i, i * 1 };
        }
        var midPoint = line.ToPolyline().GetMidPoint();
        Assert.Equal(49.5, midPoint.X, 1e-6);
        Assert.Equal(49.5, midPoint.Y, 1e-6);
    }
}