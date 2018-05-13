using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zlib;

namespace TricksterMap
{
    public class CompressedFileLoader
    {
        public static byte[] Decompress(Stream stream, bool skipType = false)
        {
            using (var reader = new BinaryReader(stream))
            {
                if (!skipType)
                {
                    var type = reader.ReadInt32();
                }

                var realSize = reader.ReadInt32();
                var compressedSize = reader.ReadInt32();

                var decompressed = ZlibStream.UncompressBuffer(reader.ReadBytes(compressedSize));

                if (decompressed.Length != realSize)
                {
                    throw new Exception("Decompressed size does not match the header's value.");
                }

                return decompressed;
            }
        }
    }
}
