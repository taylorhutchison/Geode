using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Geode.Benchmarks;
public class QuadTreeBenchmarks
{
    public readonly QuadTree _libraries;

    public QuadTreeBenchmarks()
    {
        var libraryList = new List<Point> {
            new Point(0, 0),
            new Point(0, 1),
            new Point(1, 0),
            new Point(1, 1),
            new Point(2, 2)
        };
        _libraries = new QuadTree(libraryList);
    }

    [Benchmark]
    public void Insert()
    {
        _libraries.Insert(new Point(0.1, 0.1));
    }

    [Benchmark]
    public void FindNearest()
    {
        _libraries.FindNearest(0.5, 0.5);
    }
    
}

