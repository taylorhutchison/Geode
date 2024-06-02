namespace Geode.Benchmarks;

public class MidpointBenchmarks
{
    private readonly Polyline _polyline;
    public MidpointBenchmarks()
    {
        _polyline = new double[][]
        {
            [0, 0],
            [10.1, 30.5],
            [23.4, 27.4],
            [58.1, 43.562345],
            [67.67, 8],
            [70, 0.00]
        }.ToPolyline();
    }

    [Benchmark]
    public Point GetMidpoint() => _polyline.GetMidPoint();
}
