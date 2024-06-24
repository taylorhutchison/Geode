using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Geode.Tests.GeometryTests;
public class PolygonTests
{
    [Fact]
    public void CanCreatePolylineFromListOfPoints()
    {
        var ring = new List<List<Point2D>> {
            new List<Point2D> {
                new Point2D(1, 2),
                new Point2D(3, 4),
                new Point2D(5, 6),
                new Point2D(1, 2)
            }
        };
        var polygon = new Polygon(ring);
        Assert.Equal(4, polygon.Positions.Count());
    }
}
