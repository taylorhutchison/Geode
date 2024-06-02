using Xunit;

namespace Geode.Tests.Algorithms;

public class MidPointTests
{
    [Fact]
    public void PolylineWithOnePosition()
    {
        var line = new double[][] {
                [2, 3]
            }.ToPolyline();
        var midPoint = line.GetMidPoint();
        Assert.Equal(2, midPoint.Position[0]);
        Assert.Equal(3, midPoint.Position[1]);
    }

    [Fact]
    public void PolylineWithTwoPositions()
    {
        var line = new double[][] {
                [ 0, 0 ],
                [ 1, 1 ]
            }.ToPolyline();
        var midPoint = line.GetMidPoint();
        Assert.Equal(0.5, midPoint.Position[0]);
        Assert.Equal(0.5, midPoint.Position[1]);
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
        Assert.Equal(2.5, midPoint.Position[0]);
        Assert.Equal(2.5, midPoint.Position[1]);
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
        Assert.Equal(49.5, midPoint.Position[0], 1e-6);
        Assert.Equal(49.5, midPoint.Position[1], 1e-6);
    }
}
