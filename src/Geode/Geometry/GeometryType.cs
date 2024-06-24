namespace Geode;
/// <summary>
/// The classification of a geometry (e.g. Point, Polyline, Polygon, etc.).
/// </summary>
public enum GeometryType
{
    Unknown,
    Null,
    Point2D,
    Point3D,
    MultiPoint,
    Polyline,
    MultiPolyline,
    Polygon,
    MultiPolygon,
    GeometryCollection
}
