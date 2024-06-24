namespace Geode.Benchmarks;
public class SerializersBenchmarks
{

    private readonly Point2D _point;
    public SerializersBenchmarks()
    {
        _point = new Point2D(10.1, 30.5);
    }

    [Benchmark]
    public string ToWKT() => WktSerializer.ToWKT(_point);
}