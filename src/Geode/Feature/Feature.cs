using System.Collections.Generic;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Geode.Tests")]

namespace Geode;
/// <summary>
/// A Feature represents a discrete geometry and it's associated attributes. 
/// </summary>
public class Feature : IFeature
{
    public IDictionary<string, object> Properties { get; set; }
    public IGeometry Geometry { get; set; }
}

public class Feature<T> : IFeature<T>
{
    public IDictionary<string, object> Properties { get; set; }
    IGeometry IFeature.Geometry { get; set; }
    public IGeometry<T> Geometry { get; set; }
}
