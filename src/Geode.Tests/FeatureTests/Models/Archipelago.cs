using System.Collections.Generic;

namespace Geode.Tests.FeatureTests.Models;
public class Archipelago : IFeatureConvertible
{
    public IEnumerable<Polygon> Islands { get; set; }

    public string Name { get; set; }

    public IFeature ToFeature()
    {
        return new Feature<Polygon>
        {
            Properties = new Dictionary<string, object>
                {
                    { nameof(Name), Name }
                },
            Geometry = new GeometryCollection()
            {
                Geometries = Islands
            }
        };
    }
}
