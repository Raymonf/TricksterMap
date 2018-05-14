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
using System.Globalization;
using System.Reflection;
using System.Threading;

namespace TricksterMap
{
    public partial class MDIParent : Form
    {
        bool ChangedLanguage = false;

        public MDIParent()
        {
            InitializeComponent();

            fileMenu.Text = Strings.File;
            openToolStripMenuItem.Text = Strings.FileOpen;
            exitToolStripMenuItem.Text = Strings.FileExit;
            languageToolStripMenuItem.Text = Strings.Language;
            
            this.SetFonts();
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
                        Text = String.Format(Strings.PointObjectView, fileName),
                        MdiParent = this,
                        Map = mapInfo
                    };

                    pointForm.RepopulateData();

                    pointForm.Show();

                    var rangeForm = new RangeObjectForm
                    {
                        Text = String.Format(Strings.RangeObjectView, fileName),
                        MdiParent = this,
                        Map = mapInfo
                    };

                    rangeForm.RepopulateData();

                    rangeForm.Show();

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
                                    //Console.WriteLine("{0}: ({1}, {2})", tileIndex + 1, j, i);
                                    tileIndex++;
                                }
                            }
                        }

                        tiles.Add(bmp);
                    }

                    var tileViewForm = new TileViewForm
                    {
                        Text = String.Format(Strings.TileView, fileName.Replace(".md3", ".til")),
                        MdiParent = this,
                        Map = mapInfo
                    };

                    tileViewForm.tiles = tiles;

                    tileViewForm.Show();

                    // Get filesizes for temporary stuff
                    mapInfo.BacFileSize = (int)new FileInfo(fileName.Replace(".md3", ".bac")).Length;
                    mapInfo.TilFileSize = (int)new FileInfo(fileName.Replace(".md3", ".til")).Length;
                    mapInfo.LyrFileSize = (int)new FileInfo(fileName.Replace(".md3", ".lyr")).Length;

                    var controlForm = new MapControlForm()
                    {
                        MdiParent = this,
                        Map = mapInfo,
                        Text = String.Format(Strings.MapControl, fileName)
                    };

                    controlForm.Show();
                }
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = Strings.OpenType + "|*.md3|All Files (*.*)|*.*"
            };

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

#pragma warning disable IDE1006 // Naming Styles
        private void loadMegalopolisMenuItem_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            OpenMap("map_sq00.md3");
        }

        public IEnumerable<CultureInfo> GetSupportedCultures()
        {
            CultureInfo[] culture = CultureInfo.GetCultures(CultureTypes.AllCultures);
            string exeLocation = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            return culture.Where(cultureInfo => Directory.Exists(Path.Combine(exeLocation, cultureInfo.Name)));
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            var cultures = GetSupportedCultures();
            
            foreach(var culture in cultures)
            {
                var lang = new ToolStripMenuItem($"{(culture.TwoLetterISOLanguageName == "iv" ? "English" : culture.NativeName)}");

                lang.Click += (object s, EventArgs ea) =>
                {
                    ChangedLanguage = true;
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                    new MDIParent().Show();
                    Close();
                };

                languageToolStripMenuItem.DropDownItems.Add(lang);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason != CloseReason.WindowsShutDown && !ChangedLanguage)
            {
                Application.Exit();
            }
        }
    }
}
