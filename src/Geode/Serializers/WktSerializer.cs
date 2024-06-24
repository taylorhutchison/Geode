namespace Geode;
public class WktSerializer
{
    public static string ToWKT(IPoint2D position)
    {
        if (position == null)
        {
            return string.Empty;
        }
        return $"POINT ({position.X} {position.Y})";
    }
}
