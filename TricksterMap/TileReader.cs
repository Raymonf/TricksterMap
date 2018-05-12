using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TricksterMap.Data;

namespace TricksterMap
{
    public class TileReader
    {
        public static List<TileData> Read(MapDataInfo map, Stream stream)
        {
            // 0x0000E0F0 is the magic number for compressed til files
            // Keep in mind that this is little endian
            if (stream.ReadByte() == 0xF0 && stream.ReadByte() == 0xE0)
            {
                // Decompress
                stream.Seek(0, SeekOrigin.Begin);
                return ParseData(CompressedFileLoader.Decompress(stream), map);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return ParseData(GetBytesFromStream(stream), map);
        }

        private static byte[] GetBytesFromStream(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private static List<TileData> ParseData(byte[] data, MapDataInfo map)
        {
            var tiles = new List<TileData>();

            var groupCount = map.TileGroupCount;
            var countX = map.TileCountX;
            var countY = map.TileCountY;
            var tileSizeX = map.TileSizeX;
            var tileSizeY = map.TileSizeY;

            Console.WriteLine("groupCount = {0}", groupCount);

            using (var memoryStream = new MemoryStream(data))
            {
                using (var reader = new BinaryReader(memoryStream))
                {
                    var addresses = new List<int>();
                    
                    // i = group base address
                    for (var i = 0; i < groupCount; i++)
                    {
                        var address = reader.ReadInt32();
                        addresses.Add(address);
                        Console.WriteLine(address);
                    }

                    foreach (var address in addresses)
                    {
                        // Seek to the address header location
                        memoryStream.Seek(address + (4 * groupCount), SeekOrigin.Begin);

                        var groupSize = reader.ReadInt32();
                        var xSize = reader.ReadInt32();
                        var ySize = reader.ReadInt32();

                        Console.WriteLine("groupSize = {0}", groupSize);
                        Console.WriteLine("tileSizeX = {0}", tileSizeX);
                        Console.WriteLine("tileSizeY = {0}", tileSizeY);
                        Console.WriteLine("xSize = {0}", xSize);
                        Console.WriteLine("ySize = {0}", ySize);
                        
                        var bmps = new List<Bitmap>();

                        var sizePerTile = (tileSizeX * tileSizeY * (map.TileBpp / 8));
                        for (int i = 0; i < groupSize / sizePerTile; i++)
                        {
                            using (var bmpStream = new MemoryStream())
                            {
                                var writer = new BinaryWriter(bmpStream);

                                var headerSize = 54;
                                var totalSize = headerSize + sizePerTile;

                                writer.Write('B');
                                writer.Write('M');
                                writer.Write(totalSize);
                                writer.Write(0);
                                writer.Write(headerSize);
                                writer.Write(headerSize - 14); // DIB header size
                                writer.Write(tileSizeX);
                                writer.Write(tileSizeY);
                                writer.Write((short)1);
                                writer.Write((short)map.TileBpp);
                                writer.Write(0); // No compression
                                writer.Write(sizePerTile);
                                writer.Write(0);
                                writer.Write(0);
                                writer.Write(0);
                                writer.Write(0);
                                writer.Write(reader.ReadBytes(2048));

                                int paddingSize = totalSize % 4;
                                for (int p = 0; p < paddingSize; p++)
                                {
                                    writer.Write(0x0);
                                }

                                bmpStream.Seek(0, SeekOrigin.Begin);
                                bmps.Add((Bitmap)Image.FromStream(bmpStream));

                                writer.Dispose();
                            }
                        }

                        tiles.Add(new TileData()
                        {
                            Address = address,
                            TilesX = xSize,
                            TilesY = ySize,
                            Bitmaps = bmps
                        });
                    }
                }
            }

            return tiles;
        }
    }
}
