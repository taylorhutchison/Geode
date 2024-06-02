namespace Geode;
/// <summary>
/// The classification of a geometry (e.g. Point, Polyline, Polygon, etc.).
/// </summary>
public enum GeoType
{
    Point,
    MultiPoint,
    Polyline,
    MultiPolyline,
    Polygon,
    MultiPolygon,
    GeometryCollection
}
