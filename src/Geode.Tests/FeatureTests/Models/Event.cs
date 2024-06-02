using System.Collections.Generic;

namespace Geode.Tests.FeatureTests.Models;
public class Event : IFeatureConvertible
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Point Coordinates { get; set; }
    public IFeature ToFeature()
    {
        return new Feature<Point>
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
