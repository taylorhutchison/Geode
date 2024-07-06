using Geode;
using Xunit;

namespace Geode.Tests.Algorithms;

public class IPointAlgorithmsTests {

    [Fact]
    public void DistanceCalculatedBetweenTwoPoints() {
        var point1 = new Point(0, 0, 0);
        var point2 = new Point(10, 10, 10);
        var distance = point1.DistanceTo(point2);
        Assert.Equal(17.320508075688775, distance, 1e-6);
    }


}