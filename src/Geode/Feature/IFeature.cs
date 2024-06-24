using System.Collections.Generic;

namespace Geode;

public interface IFeature
{
    IDictionary<string, object> Properties { get; set; }
    IGeometry Location { get; set; }
}

public interface IFeature<T> : IFeature where T : IGeometry
{
    new T Location { get; set; }
}
