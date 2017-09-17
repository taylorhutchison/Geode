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

    internal class ShapefileReader : FeatureReader
    {
        #region internal-classes
        internal class ShapefileHeader
        {
            public IGeoType GeoType { get; set; }
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
            public int SizeInBytes => FileLength * 2;
            private enum ShapeTypes
            {
                Null = 0,
                Point = 1,
                PolyLine = 3,
                Polygon = 5,
                MultiPoint = 8,
                PointZ = 11,
                PolyLineZ = 13,
                PolygonZ = 15,
                MultiPointZ = 18,
                PointM = 21,
                PolyLineM = 23,
                PolygonM = 25,
                MultiPointM = 28,
                MultiPatch = 31
            }
        }
        internal class ShapefileRecordGeometry
        {
            public IGeometry Geometry { get; set; }
            public int RecordNumber { get; set; }
            public ShapefileRecordGeometry(int recordNumber, byte[] recordContents, GeoType geoType)
            {
                RecordNumber = recordNumber;
                if (geoType == GeoType.Point)
                {
                    var x = BitConverter.ToDouble(recordContents, 4);
                    var y = BitConverter.ToDouble(recordContents, 12);
                    Geometry = new Point(x, y);
                }
            }
        }
        internal class ShapefileRecord
        {
            public int RecordNumber { get; set; }
            public int ContentLength { get; set; }
            public byte[] RecordContents { get; set; }
            public ShapefileRecord(byte[] recordHeader)
            {
                if (recordHeader.Length == 8)
                {
                    //Reverse array because record headers are stored in Big-Endian notation.
                    Array.Reverse(recordHeader);

                    //Content length is measured in 16-bit words.
                    this.ContentLength = BitConverter.ToInt32(recordHeader, 0);

                    this.RecordNumber = BitConverter.ToInt32(recordHeader, 4);
                    this.RecordContents = new byte[ContentLength * 2];
                }
            }
        }
        internal class ShapefileIndexRecord
        {
            public int Offset { get; private set; }
            public int Length { get; private set; }

            public ShapefileIndexRecord(byte[] recordHeader)
            {
                if (recordHeader.Length == 8)
                {
                    Array.Reverse(recordHeader);
                    this.Length = BitConverter.ToInt32(recordHeader, 0);
                    this.Offset = BitConverter.ToInt32(recordHeader, 4);
                }
            }
        }
        internal class Dbase
        {
            public int Version { get; private set; }
            public string LastUpdated { get; private set; }
            public int RecordCount { get; private set; }
            public int HeaderLength { get; private set; }
            public int FieldCount
            {
                get
                {
                    return (HeaderLength - 33) / 32;
                }
            }
            public int RecordLength { get; private set; }

            public string[] FieldNames { get; private set; }
            public string[] FieldTypes { get; private set; }

            private void GetFieldsFromHeader(byte[] tableHeader)
            {
                if (tableHeader.Length >= this.HeaderLength)
                {
                    this.FieldNames = new string[this.FieldCount];
                    this.FieldTypes = new string[this.FieldCount];
                    for (int i = 1; i <= this.FieldCount; i++)
                    {
                        this.FieldNames[i - 1] = System.Text.ASCIIEncoding.ASCII.GetString(tableHeader, i * 32, 10);
                        this.FieldTypes[i - 1] = System.Text.ASCIIEncoding.ASCII.GetString(tableHeader, (i * 32) + 11, 1);
                    }
                }
                else
                {
                    this.FieldNames = new string[0];
                    this.FieldTypes = new string[0];
                }
            }

            public Dbase(byte[] tableHeader)
            {
                if (tableHeader != null && tableHeader.Length >= 32)
                {
                    this.Version = tableHeader[0];
                    this.LastUpdated = tableHeader[1].ToString() + tableHeader[2].ToString() + tableHeader[3].ToString();
                    this.RecordCount = BitConverter.ToInt32(tableHeader, 4);
                    this.HeaderLength = BitConverter.ToInt16(tableHeader, 8);
                    this.RecordLength = BitConverter.ToInt16(tableHeader, 10);
                    this.GetFieldsFromHeader(tableHeader);
                }
            }
        }
        #endregion

        private List<ShapefileIndexRecord> Index { get; set; }
        private int CurrentRecord { get; set; } //State variable for iterating through main records.

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

        private ShapefileHeader GetShapefileHeader(Stream stream)
        {
            stream.Position = 0;
            var headerBytes = ReadBytesFromStream(stream, 100);
            return GetShapefileHeader(headerBytes);
        }

        private byte[] GetNextRecord(Stream stream, long recordOffset, int recordLength)
        {
            if (stream.CanRead)
            {
                if (stream.Position != recordOffset)
                {
                    stream.Position = recordOffset;
                }
                byte[] record = ReadBytesFromStream(stream, recordOffset, recordLength);
                if (record != null && record.Length == recordLength)
                {
                    return record;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public byte[] GetNextRecord(Stream stream)
        {
            if (this.Index != null && this.Index.Count > 0)
            {
                this.CurrentRecord++;
                if (CurrentRecord > Index.Count)
                {
                    return null;
                }
                return GetNextRecord(stream, Index[CurrentRecord - 1].Offset * 2 + 8, Index[CurrentRecord - 1].Length * 2);
            }
            else
            {
                if (stream.Position < 100)
                {
                    stream.Position = 100;
                }

                byte[] recordHeader = ReadBytesFromStream(stream, (int)stream.Position, 8);
                if (recordHeader == null || recordHeader.Length < 8)
                {
                    return null;
                }
                Array.Reverse(recordHeader);

                int recordLength = BitConverter.ToInt32(recordHeader, 0);
                return GetNextRecord(stream, stream.Position, recordLength * 2);
            }
        }

        private List<ShapefileRecord> GetAllMainRecords(Stream stream)
        {
            List<ShapefileRecord> records = new List<ShapefileRecord>();
            byte[] streamBuffer;
            try
            {
                stream.Position = 100;
                do
                {
                    streamBuffer = ReadBytesFromStream(stream, 8);
                    if (streamBuffer.Length < 8)
                    {
                        break;
                    }
                    else
                    {
                        ShapefileRecord myRecord = new ShapefileRecord(streamBuffer);
                        myRecord.RecordContents = ReadBytesFromStream(stream, myRecord.ContentLength * 2);
                        records.Add(myRecord);
                    }
                } while (streamBuffer.Length > 0);
            }
            catch
            {
                //Clear the list so it is returned empty.
                records.Clear();
            }
            return records;
        }

        public override IFeatureCollection Read(string path)
        {
            if (path.EndsWith(".shp"))
            {
                var reader = new ShapefileReader();
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    var header = reader.GetShapefileHeader(stream);
                    var records = reader.GetAllMainRecords(stream);
                    if(header.ShapeType == 1)
                    {
                        var features = records.Select(r => new ShapefileRecordGeometry(r.RecordNumber, r.RecordContents, GeoType.Point)).Select(gr =>
                        {
                            return new Feature
                            {
                                Geometry = gr.Geometry
                            };
                        });

                        return new FeatureCollection
                        {
                            Features = features
                        };
                        
                    }
                }
            }
            return new FeatureCollection();
        }

    }

}
