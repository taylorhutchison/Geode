using Geode.Algorithms;

namespace Geode.Benchmarks;
public class MidPointBenchmark
{
    private readonly LineString _lineString;
    public MidPointBenchmark()
    {
        _lineString = new double[][]
        {
            new double[] { 0, 0 },
            new double[] { 10.1, 30.5 },
            new double[] { 23.4, 27.4 },
            new double[] { 58.1, 43.562345 },
            new double[] { 67.67, 8 },
            new double[] { 70, 0.00 }
        }.ToLineString();
    }

    [Benchmark]
    public Point GetMidPoint() => Midpoint.GetMidPoint(_lineString);
}
