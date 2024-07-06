using System.Collections.Generic;
using Xunit;

namespace Geode.Tests;
public class GeometryServiceTests
{
    [Fact]
    public void GetCentroidOfListOfPositions()
    {
        var points = new List<IPoint>
            {
                new Point(0,0,0),
                new Point(1,1,10)
            };
        var centroid = points.GetCentroid();
        Assert.Equal(0.5, centroid.X);
        Assert.Equal(0.5, centroid.Y);
        Assert.Equal(5, centroid.Z);
    }
}
