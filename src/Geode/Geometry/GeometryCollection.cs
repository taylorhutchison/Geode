using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Geode
{
    public class GeometryCollection: IGeoType, IGeoCollection, IEnumerable<IGeoType>
    {
        public GeoType Type => GeoType.GeometryCollection;
        public IEnumerable<IGeometry> Geometries { get; set; }
        public IEnumerable Geometry => Geometries;

        public IEnumerator<IGeoType> GetEnumerator()
        {
            if (Geometries != null)
            {
                foreach(var geometry in Geometries)
                {
                    yield return (IGeoType)geometry;
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
