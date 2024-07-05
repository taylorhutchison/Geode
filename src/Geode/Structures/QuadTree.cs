using System.Collections.Generic;

namespace Geode;
public class QuadTree<T> where T : IPoint
{
    public QuadTree(IEnumerable<T> positions)
    {

    }

    public QuadTree<T> Add(IPoint position)
    {
        return this;
    }

    public QuadTree<T> Add(IEnumerable<IPoint> positions)
    {
        return this;
    }
}
