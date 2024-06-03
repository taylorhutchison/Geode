using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Geode.Tests.GeometryTests;
public class PolylineTests
{
    [Fact]
    public void CanCreatePolylineFromListOfPoints()
    {
        var points = new List<Point> {
            new Point(1, 2),
            new Point(3, 4),
            new Point(5, 6)
        };
        var polyline = new Polyline(points);
        Assert.Equal(3, polyline.Coordinates.Count());
    }
}
