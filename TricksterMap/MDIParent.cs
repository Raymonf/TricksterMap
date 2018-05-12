using TricksterMap.Data;
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

namespace TricksterMap
{
    public partial class MDIParent : Form
    {
        public MDIParent()
        {
            InitializeComponent();

            AutoScaleMode = AutoScaleMode.Dpi;

            fileMenu.Text = Strings.File;
            openToolStripMenuItem.Text = Strings.FileOpen;
            exitToolStripMenuItem.Text = Strings.FileExit;
        }

        private void OpenMap(string fileName)
        {
            using (var fileStream = File.Open(fileName, FileMode.Open))
            {
                using (var reader = new BinaryReader(fileStream))
                {
                    var mapInfo = MapDataLoader.Load(reader);

                    foreach (var layer in mapInfo.ConfigLayers)
                    {
                        if (layer.Type == 1)
                        {
                            var collisionForm = new ConfigLayerCollisionForm
                            {
                                MdiParent = this,
                                Text = String.Format(Strings.CollisionFormTitle, fileName)
                            };

                            // Load the collision data from the layer
                            collisionForm.LoadData(layer);

                            // Show the actual form
                            collisionForm.Show();
                        }
                    }

                    var pointForm = new PointObjectForm
                    {
                        Text = "Point Object Data (" + fileName + ")",
                        MdiParent = this
                    };

                    foreach (var point in mapInfo.PointObjects)
                    {
                        pointForm.pointList.Items.Add(new ListViewItem(new string[] { point.Id.ToString(), point.GetTypeName(), point.MapId.ToString(), point.X.ToString(), point.Y.ToString() }));
                    }

                    pointForm.Show();

                    // At this point, we need to grab the tile data
                    var tileData = TileReader.Read(mapInfo, File.Open(fileName.Replace(".md3", ".til"), FileMode.Open));
                    var tiles = new List<Bitmap>();

                    foreach (var tile in tileData)
                    {
                        var bmp = new Bitmap(tile.TilesX * mapInfo.TileSizeX, tile.TilesY * mapInfo.TileSizeY);

                        var tileIndex = 0;
                        using (var g = Graphics.FromImage(bmp))
                        {
                            for (int i = 0; i < tile.TilesY; i++)
                            {
                                for (int j = 0; j < tile.TilesX; j++)
                                {
                                    g.DrawImage(tile.Bitmaps[tileIndex], j * mapInfo.TileSizeX, i * mapInfo.TileSizeY, mapInfo.TileSizeX, mapInfo.TileSizeY);
                                    g.DrawString((tileIndex + 1).ToString(), new Font("Arial", 10), Brushes.Black, j * mapInfo.TileSizeX, i * mapInfo.TileSizeY);
                                    Console.WriteLine("{0}: ({1}, {2})", tileIndex + 1, j, i);
                                    tileIndex++;
                                }
                            }
                        }

                        tiles.Add(bmp);
                    }

                    var mapViewForm = new MapViewForm
                    {
                        Text = "Tile View (" + fileName.Replace(".md3", ".til") + ")",
                        MdiParent = this
                    };

                    mapViewForm.tiles = tiles;

                    mapViewForm.Show();
                }
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = Strings.OpenType + "|*.md3|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                OpenMap(openFileDialog.FileName);
            }
        }
        
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", " ").ToUpper();
        }

        private void loadMegalopolisMenuItem_Click(object sender, EventArgs e)
        {
            OpenMap("map_sq00.md3");
        }
    }
}
