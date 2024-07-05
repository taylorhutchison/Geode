using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Geode.Tests.GeometryTests;
public class PolygonTests
{
    [Fact]
    public void CanCreatePolylineFromListOfPoints()
    {
        var boundary = new List<Point> {
                new Point(1, 2),
                new Point(3, 4),
                new Point(5, 6),
                new Point(1, 2)
        };
        var polygon = new Polygon(boundary);
        Assert.Equal(4, polygon.Geometry.Boundary.Count());
    }
}
