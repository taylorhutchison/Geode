﻿using System;
using System.Collections.Generic;
using System.Collections;

namespace Geode;
public class Polygon : IGeometry, IPoly
{
    private IEnumerable<IPosition> _coordinates;
    public GeometryType Type => GeometryType.Polygon;
    public Bounds Bounds { get; set; }
    public IEnumerable Coordinates => _coordinates;
    public IEnumerable Geometry => _coordinates;
    public IEnumerable<IPosition> Positions => _coordinates;
    public Polygon(IEnumerable<IPosition> coordinates)
    {
        _coordinates = coordinates;
    }
    public bool Equals(IGeometry other)
    {
        throw new NotImplementedException();
    }

}
