using System.Collections.Generic;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Geode.Tests")]

namespace Geode;
/// <summary>
/// A Feature represents a discrete geometry and it's associated attributes. 
/// </summary>
public sealed class Feature : IFeature
{
    public IDictionary<string, object> Properties { get; set; }
    public IGeometry Geometry { get; set; }

}
