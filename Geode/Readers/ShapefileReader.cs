using System;
using System.Collections.Generic;
using System.Text;
using Geode;
using Geode.Geometry;
using System.IO;
using System.Linq;

namespace Geode.Readers
{
    internal class ShapefileReader: FeatureReader
    {
        public override IFeatureCollection Read(string path)
        {
            return new FeatureCollection();
        }
    }

}
