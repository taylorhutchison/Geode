﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Geode
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
