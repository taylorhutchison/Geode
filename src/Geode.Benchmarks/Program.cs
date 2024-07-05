global using BenchmarkDotNet.Running;
global using BenchmarkDotNet.Attributes;
global using Geode;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
