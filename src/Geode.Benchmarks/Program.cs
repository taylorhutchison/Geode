using System.Security.Cryptography;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Geode.Readers;


var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

[MemoryDiagnoser]
public class ShapefileRead
{

    [Benchmark]
    public void ReadShapefile()
    {
        var path = @"./Data/Shapefiles/places.shp";
        var features = new ShapefileReader().Read(path);
    }

}