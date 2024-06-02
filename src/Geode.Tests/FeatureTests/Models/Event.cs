using System.Collections.Generic;

namespace Geode.Tests.FeatureTests.Models;
public class Event : IFeatureConvertible
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IGeoType Coordinates { get; set; }
    public IFeature ToFeature()
    {
        return new Feature
        {
            Properties = new Dictionary<string, object>()
                {
                    {nameof(Name), Name },
                    {nameof(Description), Description }
                },
            Geometry = Coordinates
        };
    }
}
