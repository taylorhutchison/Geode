# Geode
## A .NET library for geometric and geographic processing.

- [Installation](#installation)
- [About](#about)
- [Examples](#examples)

### Installation:
```bash
dotnet add package Geode
```
[https://www.nuget.org/packages/Geode/](https://www.nuget.org/packages/Geode/)

### About
Geode is a library that contains a set of Geometric primatives including: 
- Point
- MultiPoint
- Polyline
- Polygon
- MultiPolyline
- MultiPolygon

#### Top Features
- Map any type to GeoJson compatible format
- Import/Export to common GIS file formats including shapefile.
- Calculate statistics on 

### Examples

#### Convert an about to a Feature:
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
