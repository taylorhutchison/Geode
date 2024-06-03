using System.Collections.Generic;

namespace Geode;

public interface IFeature
{
    IDictionary<string, object> Properties { get; set; }
    IGeometry Geometry { get; set; }
}

public interface IFeature<T> : IFeature
{
    new IGeometry<T> Geometry { get; set; }
}
