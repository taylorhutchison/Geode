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
}
