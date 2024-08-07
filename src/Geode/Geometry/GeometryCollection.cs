﻿using System.Collections;
using System.Collections.Generic;

namespace Geode;
public record GeometryCollection : IGeometry, IGeoCollection, IEnumerable<IGeometry>
{
    public GeometryType Type => GeometryType.GeometryCollection;
    public IEnumerable<IGeometry>? Geometries { get; set; }
    object? IGeometry.Geometry => Coordinates;
    public IEnumerable? Geometry => Geometries;
    public IEnumerable? Coordinates => Geometries;

    public IEnumerator<IGeometry> GetEnumerator()
    {
        if (Geometries != null)
        {
            foreach (var geometry in Geometries)
            {
                yield return (IGeometry)geometry;
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
