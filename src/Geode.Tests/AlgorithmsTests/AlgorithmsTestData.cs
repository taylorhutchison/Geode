using System.Collections.Generic;

namespace Geode.Tests.Algorithms;

public class AlgorithmsTestData
{
    public static IEnumerable<object[]> PointDistanceTestData()
    {
        yield return new object[] { new Point(0, 0), new Point(10, 10), 14.142135623730951 };
        yield return new object[] { new Point(0, 0, 0), new Point(10, 10, 10), 17.320508075688775 };
        yield return new object[] { new Point(0, 0, 0), new Point(0, 0, 0), 0 };
        yield return new object[] { new Point(0, 0, 0), new Point(0, 0, 10), 10 };
        yield return new object[] { new Point(0, 0, 0), new Point(1, 2, 3), 3.7416573867739413 };
        yield return new object[] { new Point(-10, -10, -10), new Point(10, 10, 10), 34.641016151377549 };
    }
}