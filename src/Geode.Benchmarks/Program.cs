global using BenchmarkDotNet.Running;
global using BenchmarkDotNet.Attributes;
global using Geode.Geometry;
global using Geode.Algorithms;
global using Geode.Serializers;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
