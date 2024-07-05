using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace Geode.Tests.Structures;
public class BoundsTests
{
    [Fact]
    public void BoundsOfPolyline()
    {
        var polyline = new List<double[]>
            {
                new double[]{ -1, -5 },
                new double[]{ 1, 22 }
            }.ToPolyline();
        var bounds = polyline.GetBounds();
        Assert.Equal(-1, bounds.XMin);
        Assert.Equal(1, bounds.XMax);
        Assert.Equal(-5, bounds.YMin);
        Assert.Equal(22, bounds.YMax);
        Assert.Equal(0, bounds.ZMin);
        Assert.Equal(0, bounds.ZMax);
    }

    [Fact]
    public void BoundsOfGenericPolyline()
    {
        var polyline = new List<Point> {
            new Point(-1, -5),
            new Point(1, 22)
        }.ToPolyline();

        var bounds = polyline.GetBounds();
        Assert.Equal(-1, bounds.XMin);
        Assert.Equal(1, bounds.XMax);
        Assert.Equal(-5, bounds.YMin);
        Assert.Equal(22, bounds.YMax);
        Assert.Equal(0, bounds.ZMin);
        Assert.Equal(0, bounds.ZMax);
    }

    [Fact]
    public void BoundsOfListofPolyline()
    {
        var c1 = new List<double[]>
            {
                new double[]{ -1, -6 },
                new double[]{ 1, 22 }
            }.ToPolyline();
        var c2 = new List<double[]>
            {
                new double[]{ -3, -5 },
                new double[]{ 8, 7 }
            }.ToPolyline();
        var lines = new List<Polyline> {
                c1, c2
            };
        var bounds = lines.Select(l => l.GetBounds()).GetBounds();
        Assert.Equal(-3, bounds.XMin);
        Assert.Equal(8, bounds.XMax);
        Assert.Equal(-6, bounds.YMin);
        Assert.Equal(22, bounds.YMax);
        Assert.Equal(0, bounds.ZMin);
        Assert.Equal(0, bounds.ZMax);
    }
}
