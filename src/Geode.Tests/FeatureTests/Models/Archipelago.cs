using System.Collections.Generic;

namespace Geode.Tests.FeatureTests.Models;
public class Archipelago : IFeatureConvertible
{
    public IEnumerable<IGeometry> Islands { get; set; }

    public string Name { get; set; }

    public IFeature ToFeature()
    {
        return new Feature
        {
            Properties = new Dictionary<string, object>
                {
                    { nameof(Name), Name }
                },
            Location = new GeometryCollection()
            {
                Geometries = Islands
            }
        };
    }
}
