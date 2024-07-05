namespace Geode;
internal abstract class FeatureReader : Reader
{
    public abstract FeatureCollection Read(string path);
}
