using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Structures
{
    public class QuadTree<T> where T: IPosition
    {
        public QuadTree(IEnumerable<T> positions)
        {

        }

        public QuadTree<T> Add(IPosition position)
        {
            return this;
        }
        
        public QuadTree<T> Add(IEnumerable<IPosition> positions)
        {
            return this;
        }
    }
}
