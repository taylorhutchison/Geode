using System;
using System.Collections.Generic;
using System.Text;
using Geode;
using Geode.Geometry;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Geode.Tests")]

namespace Geode.Readers
{
    internal class ShapefileHeader
    {
        public int FileLength { get; set; }
        public int Version { get; set; }
        public int ShapeType { get; set; }
        public double XMin { get; set; }
        public double YMin { get; set; }
        public double XMax { get; set; }
        public double YMax { get; set; }
        public double ZMin { get; set; }
        public double ZMax { get; set; }
        public double MMin { get; set; }
        public double MMax { get; set; }
    }

    internal class ShapefileReader : FeatureReader
    {
        /// <summary>
        /// The file length of a shapefile is stored as an Integer starting at byte 24. It is stored in big endian byte order so that is why it is fed backwards into the new byte array.this of course would fail to produce the correct integer on a big endian processor. All other data that we want from the header is in little endian byte order so creating a reverse order byte is unnecessary.
        /// </summary>
        /// <param name="headerBytes"></param>
        /// <returns></returns>
        private ShapefileHeader GetShapefileHeader(byte[] headerBytes)
        {
            if (headerBytes.Length >= 100)
            {
                return new ShapefileHeader
                {
                    FileLength = BitConverter.ToInt32(new byte[4] { headerBytes[27], headerBytes[26], headerBytes[25], headerBytes[24] }, 0),
                    //Take 4 or 8 bytes and convert it to a int/double.
                    Version = BitConverter.ToInt32(headerBytes, 28),
                    ShapeType = BitConverter.ToInt32(headerBytes, 32),
                    XMin = BitConverter.ToDouble(headerBytes, 36),
                    YMin = BitConverter.ToDouble(headerBytes, 44),
                    XMax = BitConverter.ToDouble(headerBytes, 52),
                    YMax = BitConverter.ToDouble(headerBytes, 60),
                    ZMin = BitConverter.ToDouble(headerBytes, 68),
                    ZMax = BitConverter.ToDouble(headerBytes, 76),
                    MMin = BitConverter.ToDouble(headerBytes, 84),
                    MMax = BitConverter.ToDouble(headerBytes, 92)
                };
            }
            throw new Exception($"Byte length of {headerBytes.Length} is less than required 100 to calculate Shapefile Header.");
        }
        public override IFeatureCollection Read(string path)
        {
            if (path.EndsWith(".shp"))
            {

            }
            return new FeatureCollection();
        }

        public ShapefileHeader GetShpHeader(string path)
        {
            if (path.EndsWith(".shp"))
            {
                using (var stream = new FileStream(path, FileMode.Open)) {
                    var headerBytes = ReadBytesFromStream(stream, 100);
                    return GetShapefileHeader(headerBytes);
                }
            }
            return null;
        }
    }

}
