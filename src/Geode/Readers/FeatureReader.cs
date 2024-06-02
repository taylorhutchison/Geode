using Geode.Geometry;

namespace Geode.Readers
{
    internal abstract class FeatureReader: Reader
    {
        public abstract IFeatureCollection Read(string path);
    }
}
