﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Geometries
{
    public class GeoTypeMap
    {
        public string XMap { get; private set; }
        public string YMap { get; private set; }
        public GeoTypeMap(string xmap, string ymap)
        {
            XMap = xmap;
            YMap = ymap;
        }
    }
}