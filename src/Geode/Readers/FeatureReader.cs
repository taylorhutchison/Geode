namespace Geode
{
    internal abstract class FeatureReader: Reader
    {
        public abstract IFeatureCollection Read(string path);
    }
}
