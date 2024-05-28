namespace Geode.Benchmarks;
public class SerializersBenchmarks
{

    private readonly Point _point;
    public SerializersBenchmarks()
    {
        _point = new Point(10.1, 30.5);
    }

    [Benchmark]
    public string ToWKT() => WktSerializer.ToWKT(_point);
}