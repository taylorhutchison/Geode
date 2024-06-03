using System;

namespace Geode;
public interface IPoint : IEquatable<IPoint>
{
    double[] Position { get; }
    double X { get; }
    double Y { get; }
    double Z { get; }
}
