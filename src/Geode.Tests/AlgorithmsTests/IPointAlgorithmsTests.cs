using Xunit;

namespace Geode.Tests.Algorithms;
using TestData = AlgorithmsTestData;

public class IPointAlgorithmsTests {

    [Theory]
    [MemberData(nameof(TestData.PointDistanceTestData), MemberType = typeof(TestData))]
    public void DistanceCalculatedBetweenTwoPoints(IPoint point1, IPoint point2, double expectedDistance) {
        var distance = point1.DistanceTo(point2);
        Assert.Equal(expectedDistance, distance, 1e-12);
    }
}