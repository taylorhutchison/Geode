using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Structures
{
    public class QuadTree
    {
        public QuadTree(IEnumerable<IPosition> positions)
        {

        }

        public QuadTree Add(IPosition position)
        {
            return this;
        }
        
        public QuadTree Add(IEnumerable<IPosition> position)
        {
            return this;
        }
    }
}
