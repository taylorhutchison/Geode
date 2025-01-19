using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Geode.Tests.FeatureTests.Models;

namespace Geode.Tests.FeatureTests;
public class CreateFeatureFromAuto {

    [Fact]
    public void LocationWithProperties_IsConvertedToFeature_WithExistingGeometry()
    {
        var loc = new LocationWithProperties
        {
            MyLoc = new Point(1, 2),
            Name = "My Location",
            Description = "This is a location"
        };

        var x = loc.ToFeature(loc => loc.MyLoc);

        Assert.Equal(1, x?.Location.Geometry?.X);
        Assert.Equal(2, x?.Location.Geometry?.Y);
        Assert.Equal("My Location", x?.Properties["Name"]);
        Assert.Equal("This is a location", x?.Properties["Description"]);
    }

    [Fact]
    public void LocationWithProperties_IsConvertedToFeature_WithNewGeometry()
    {
        var loc = new LocationWithProperties2
        {
            X = 1,
            Y = 2,
            Name = "My Location",
            Description = "This is a location"
        };

        var x = loc.ToFeature(obj => new Point(obj.X, obj.Y));

        Assert.Equal(1, x?.Location.Geometry?.X);
        Assert.Equal(2, x?.Location.Geometry?.Y);
        Assert.Equal("My Location", x?.Properties["Name"]);
        Assert.Equal("This is a location", x?.Properties["Description"]);
    }

}

public class LocationWithProperties {

    public IGeometry<IPoint> MyLoc { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}

public class LocationWithProperties2
{

    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}

