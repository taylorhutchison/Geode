﻿using System;
using System.Collections.Generic;
using System.Text;
using Geode.Geometry;

namespace Geode.Tests.FeatureTests.Models.Geometries
{
    public class LatLng
    {
        public LatLng() { }
        public LatLng(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
