using Xunit;

namespace Geode.Tests.Algorithms;

public class DistanceTests
{
    [Fact]
    public void DistanceCalculatedAsZeroFor2DPolylineWithOnePosition()
    {
        var line = new Point2D[] {
                new(0, 10)
            }.ToPolyline();
        var distance = line.GetDistance();
        Assert.Equal(0, distance);
    }

    [Fact]
    public void DistanceCalculatedAsZeroFor3DPolylineWithOnePosition()
    {
        var line = new Point3D[] {
                new(0, 10, 20)
            }.ToPolyline();
        var distance = line.GetDistance();
        Assert.Equal(0, distance);
    }

    [Fact]
    public void DistanceCalculatedFor2DPolyline()
    {
        var line = new Point2D[] {
                new(0, 0),
                new(5, 5),
                new(10, 0),
                new(15, 5)
            }.ToPolyline();
        var distance = line.GetDistance();
        Assert.Equal(21.2132034355965m, distance, 12);
    }

    [Fact]
    public void DistanceCalculatedFor3DPolyline()
    {
        var line = new Point3D[] {
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
        var line = new Point3D[] {
                new(0, 0, 0),
                new(5, 5, 0),
                new(10, 0, 0),
                new(15, 5, 0)
            }.ToPolyline();
        var distance = line.GetDistance();
        Assert.Equal(21.2132034355965m, distance, 12);
    }
}