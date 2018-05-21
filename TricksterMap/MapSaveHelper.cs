using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TricksterMap.Data;

namespace TricksterMap
{
    public class MapSaveHelper
    {
        private static byte[] GetPointObjectBytes(MapDataInfo Map)
        {
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                    foreach (var point in Map.PointObjects)
                    {
                        bw.Write(point.Id);
                        bw.Write(point.Type);
                        bw.Write(point.MapId);
                        bw.Write(point.X);
                        bw.Write(point.Y);
                        bw.Write(point.Options);
                    }

                    return ms.ToArray();
                }
            }
        }

        private static byte[] GetRangeObjectBytes(MapDataInfo Map)
        {
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                    foreach (var range in Map.RangeObjects)
                    {
                        bw.Write(range.Type);
                        bw.Write(range.Id);
                        bw.Write(range.Destination);
                        bw.Write(range.X1);
                        bw.Write(range.Y1);
                        bw.Write(range.X2);
                        bw.Write(range.Y2);
                        bw.Write(range.Options);
                    }

                    return ms.ToArray();
                }
            }
        }

        private static byte[] GetConfigLayerBytes(MapDataInfo Map)
        {
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                    foreach (var layer in Map.ConfigLayers)
                    {
                        // Header
                        bw.Write(layer.Type);
                        bw.Write(layer.X);
                        bw.Write(layer.Y);
                        bw.Write(layer.BppX);
                        bw.Write(layer.BppY);

                        // Data
                        bw.Write(layer.Data);
                    }

                    return ms.ToArray();
                }
            }
        }

        private static byte[] GetEffectObjectBytes(MapDataInfo Map)
        {
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                    foreach (var effect in Map.EffectObjects)
                    {
                        bw.Write(effect);
                    }

                    return ms.ToArray();
                }
            }
        }

        public static void Save(string filename, MapDataInfo map)
        {
            var layers = GetConfigLayerBytes(map);
            var ranges = GetRangeObjectBytes(map);
            var points = GetPointObjectBytes(map);
            var effects = GetEffectObjectBytes(map);

            // Header is 96 bytes long
            const int md3HeaderSize = 96;
            var md3Size = md3HeaderSize + layers.Length + points.Length + ranges.Length + effects.Length;
            var totalSize = md3Size + map.BacFileSize + map.TilFileSize + map.LyrFileSize;

            var file = File.OpenWrite(filename);

            using (var w = new BinaryWriter(file))
            {
                w.Write('M');
                w.Write('D');
                w.Write('N');
                w.Write('_');
                w.Write(map.Version);
                w.Write(map.TileBpp);
                w.Write(map.Param3);
                w.Write(map.Param4);

                // todo?
                w.Write(totalSize); // Total size of MD3 + BAC + TIL + LYR

                w.Write(map.Param6);
                w.Write(map.Param7);
                w.Write(map.MapSizeX);
                w.Write(map.MapSizeY);
                w.Write(map.TileSizeX);
                w.Write(map.TileSizeY);
                w.Write(map.TileCountX);
                w.Write(map.TileCountY);
                w.Write(map.Param14);
                w.Write(map.LyrDataCount);
                w.Write(map.TileGroupCount);
                w.Write(map.ConfigLayers.Count);
                w.Write(map.RangeObjects.Count);
                w.Write(map.PointObjects.Count);
                w.Write(map.EffectObjects.Count);
                w.Write(map.Param21);
                w.Write(map.Param22);
                w.Write(map.Param23);

                w.Write(layers);
                w.Write(ranges);
                w.Write(points);
                w.Write(effects);
            }

            file.Close();
        }
    }
}
