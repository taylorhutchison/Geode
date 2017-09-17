# Geode
## A .NET library for geometric and geographic processing.

- [Installation](#installation)
- [About](#about)
- [Examples](#examples)
	- [Feature Creation](#feature-creation)
	- [Feature To GeoJSON](#feature-to-geojson)

### Installation:
```bash
dotnet add package Geode
```
[https://www.nuget.org/packages/Geode/](https://www.nuget.org/packages/Geode/)

### About
Geode is a library that contains a set of Geometric primatives including: 
- Point
- MultiPoint
- LineString
- Polygon
- MultiLineString
- MultiPolygon

#### Top Features
- Map any custom CLR type to GeoJson compatible format
- Import/Export to common GIS file formats including shapefile.
- Calculate statistics on geometry collections.

### Examples

#### Feature Creation:
The preferred method for transforming your own types into features is to implement the IFeatureConvertible interface. This interface defines a single method, ConvertToFeature, that takes no parameters and returns an object that implements IFeature. This gives you the ability to tightly control what attributes are added to the Properties dictionary and the names of the keys. 
```c#
public class Archipelago: IFeatureConvertible
{
	public IEnumerable<Polygon> Islands { get; set; }

	public string Name { get; set; }

	public IFeature ConvertToFeature()
	{
		return new GeoCollectionFeature
		{
			Properties = new Dictionary<string, object>
			{
				{ nameof(Name), Name }
			},
			Geometries = Islands                
		};
	}
}
```

#### Feature To GeoJSON:
Anything that implements IFeature or IFeatureCollection can be converted to GeoJSON. Assuming
```c#
public class Event: IFeatureConvertible
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
var testEvent = new Event()
{
	Name = "Test Event",
	Description = "TestDescription",
    Coordinates = new Point(10, 10),
};          
var geoJson= testEvent.ToFeature().ToGeoJson(indented: true);
```
The value returned by the call to ToGeoJson(indented: true) is then:
```json
{
  "type": "Feature",
  "properties": {
    "name": "Test Event",
    "description": "TestDescription"
  },
  "geometry": {
    "type": "Point",
    "coordinates": [
      10.0,
      10.0
    ]
  }
}
```
