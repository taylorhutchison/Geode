using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometry
{
    public class GeometryCollection: IGeoType, IEnumerable<IGeoType>, IGeometryCollection
    {
        public GeoType Type => GeoType.GeometryCollection;

        public IEnumerable<IGeoType> Geometries { get; set; }
        public IEnumerable Geometry => Geometries;
        public bool Equals(IGeoType other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IGeoType> GetEnumerator()
        {
            if (Geometries != null)
            {
                foreach(var geometry in Geometries)
                {
                    yield return geometry;
                }
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (Geometries != null)
            {
                foreach (var geometry in Geometries)
                {
                    yield return geometry;
                }
            }
            yield break;
        }
    }
}
