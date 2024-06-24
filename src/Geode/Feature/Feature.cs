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
    public IGeometry Location { get; set; }
}

public class Feature<T> : IFeature<T> where T : IGeometry
{
    public IDictionary<string, object> Properties { get; set; }
    IGeometry IFeature.Location { get; set; }
    public T Location { get; set; }

    public Feature()
    {

    }
    public Feature(T geometry, IDictionary<string, object> properties)
    {
        Location = geometry;
        Properties = properties;
    }
}
