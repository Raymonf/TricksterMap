using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TricksterMap.Data;

namespace TricksterMap
{
    public class MapDataLoader
    {
        public static MapDataInfo Load(BinaryReader reader)
        {
            var mapData = new MapDataInfo();

            var signature = reader.ReadBytes(4);
            mapData.Version = reader.ReadInt32();

            // TODO
            var header1 = reader.ReadBytes(0x3C);

            var layerCount = reader.ReadInt32();
            Console.WriteLine("layerCount = {0}", layerCount);

            var rangeCount = reader.ReadInt32();
            Console.WriteLine("rangeCount = {0}", rangeCount);

            var pointCount = reader.ReadInt32();
            Console.WriteLine("pointCount = {0}", pointCount);

            var effectCount = reader.ReadInt32();
            Console.WriteLine("effectCount = {0}", effectCount);

            var header2 = reader.ReadBytes(0xC);

            for (var i = 0; i < layerCount; i++)
            {
                var layer = new ConfigLayer()
                {
                    Type = reader.ReadInt32(),
                    X = reader.ReadInt32(),
                    Y = reader.ReadInt32(),
                    BppX = reader.ReadInt32(),
                    BppY = reader.ReadInt32()
                };
                
                layer.Data = reader.ReadBytes(layer.X * layer.Y);
                
                Console.WriteLine("X: {0} / Y: {1} / Total length: {2} ( {2:X} )", layer.X, layer.Y, layer.X * layer.Y);
                Console.WriteLine("Config layer {0} length: {1:X}", i + 1, layer.Data.Length);
                
                mapData.ConfigLayers.Add(layer);
            }

            Console.WriteLine("Reading rangeData");

            var rangeData = reader.ReadBytes(32 * rangeCount);

            for (var i = 0; i < rangeCount; i++)
            {
                var obj = rangeData.Skip(i * 32).Take(32).ToArray();

                using (var range = new BinaryReader(new MemoryStream(obj)))
                {
                    mapData.RangeObjects.Add(new RangeObject()
                    {
                        Type = range.ReadInt32(),
                        Id = range.ReadInt32(),
                        Destination = range.ReadInt32(),
                        X1 = range.ReadInt32(),
                        Y1 = range.ReadInt32(),
                        X2 = range.ReadInt32(),
                        Y2 = range.ReadInt32(),
                        Options = range.ReadInt32()
                    });
                }
            }

            Console.WriteLine("Reading pointData");

            var pointData = reader.ReadBytes(24 * pointCount);

            for (var i = 0; i < pointCount; i++)
            {
                var pointBytes = pointData.Skip(i * 24).Take(24).ToArray();

                using (var pointReader = new BinaryReader(new MemoryStream(pointBytes)))
                {
                    mapData.PointObjects.Add(new PointObject()
                    {
                        Id = pointReader.ReadInt32(),
                        Type = pointReader.ReadInt32(),
                        MapId = pointReader.ReadInt32(),
                        X = pointReader.ReadInt32(),
                        Y = pointReader.ReadInt32(),
                        Options = pointReader.ReadInt32()
                    });
                }
            }


            Console.WriteLine("Reading effectData");

            var effectData = reader.ReadBytes(52 * effectCount);

            for (int i = 0; i < effectCount; i++)
            {
                var effect = effectData.Skip(i * 52).Take(52).ToArray();
            }

            return mapData;
        }
    }
}
