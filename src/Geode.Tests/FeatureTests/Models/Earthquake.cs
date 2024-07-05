using System.Collections.Generic;

namespace Geode.Tests.FeatureTests.Models;
public class Earthquake : IFeatureConvertible
{
    public Polygon ImpactArea { get; set; }
    public Point Epicenter { get; set; }
    public double Magnitude { get; set; }
    public IFeature ToFeature()
    {
        var feature = new Feature
        {
            Location = new GeometryCollection
            {
                Geometries = new List<IGeometry> {
                        ImpactArea,
                        Epicenter
                    }
            },
            Properties = new Dictionary<string, object>
                {
                    {nameof(Magnitude), Magnitude }
                }
        };
        return feature;
    }
}
