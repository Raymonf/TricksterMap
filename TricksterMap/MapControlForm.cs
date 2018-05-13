using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TricksterMap.Data;

namespace TricksterMap
{
    public partial class MapControlForm : Form
    {
        public MapDataInfo Map = null;

        public MapControlForm()
        {
            InitializeComponent();

            btnSaveAs.Text = Strings.SaveAs;
            
            this.SetFonts();
        }

        private byte[] GetPointObjectBytes()
        {
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                    foreach(var point in Map.PointObjects)
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

        private byte[] GetRangeObjectBytes()
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

        private byte[] GetConfigLayerBytes()
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

        private byte[] GetEffectObjectBytes()
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

#pragma warning disable IDE1006 // Naming Styles
        private void btnSaveAs_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = Strings.OpenType + "|*.md3|All Files (*.*)|*.*"
            };

            if (saveDialog.ShowDialog(this) == DialogResult.OK)
            {
                var layers = GetConfigLayerBytes();
                var ranges = GetRangeObjectBytes();
                var points = GetPointObjectBytes();
                var effects = GetEffectObjectBytes();

                // Header is 96 bytes long
                const int md3HeaderSize = 96;
                var md3Size = md3HeaderSize + layers.Length + points.Length + ranges.Length + effects.Length;
                var totalSize = md3Size + Map.BacFileSize + Map.TilFileSize + Map.LyrFileSize;

                var file = File.OpenWrite(saveDialog.FileName);

                using (var w = new BinaryWriter(file))
                {
                    w.Write('M');
                    w.Write('D');
                    w.Write('N');
                    w.Write('_');
                    w.Write(Map.Version);
                    w.Write(Map.TileBpp);
                    w.Write(Map.Param3);
                    w.Write(Map.Param4);
                    
                    // todo?
                    w.Write(totalSize); // Total size of MD3 + BAC + TIL + LYR

                    w.Write(Map.Param6);
                    w.Write(Map.Param7);
                    w.Write(Map.MapSizeX);
                    w.Write(Map.MapSizeY);
                    w.Write(Map.TileSizeX);
                    w.Write(Map.TileSizeY);
                    w.Write(Map.TileCountX);
                    w.Write(Map.TileCountY);
                    w.Write(Map.Param14);
                    w.Write(Map.LyrDataCount);
                    w.Write(Map.TileGroupCount);
                    w.Write(Map.ConfigLayers.Count);
                    w.Write(Map.RangeObjects.Count);
                    w.Write(Map.PointObjects.Count);
                    w.Write(Map.EffectObjects.Count);
                    w.Write(Map.Param21);
                    w.Write(Map.Param22);
                    w.Write(Map.Param23);

                    w.Write(layers);
                    w.Write(ranges);
                    w.Write(points);
                    w.Write(effects);
                }

                file.Close();
            }
        }
    }
}
