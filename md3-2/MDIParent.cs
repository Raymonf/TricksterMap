using md3_2.Data;
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

namespace md3_2
{
    public partial class MDIParent : Form
    {
        public MDIParent()
        {
            InitializeComponent();

            fileMenu.Text = Strings.File;
            openToolStripMenuItem.Text = Strings.FileOpen;
            exitToolStripMenuItem.Text = Strings.FileExit;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Trickster Map Data Files (*.md3)|*.md3|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;

                using (var reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
                {
                    var signature = reader.ReadBytes(4);
                    var version = reader.ReadBytes(4);
                    var header1 = reader.ReadBytes(0x3C);
                    var config_layer_count = reader.ReadInt32();
                    Console.WriteLine("config_layer_count = {0}", config_layer_count);

                    var range_object_size = reader.ReadInt32();
                    Console.WriteLine("range_object_size = {0}", range_object_size);

                    var point_object_size = reader.ReadInt32();
                    Console.WriteLine("point_object_size = {0}", point_object_size);

                    var effect_object_size = reader.ReadInt32();
                    Console.WriteLine("effect_object_size = {0}", effect_object_size);

                    var header2 = reader.ReadBytes(0xC);

                    for (var i = 0; i < config_layer_count; i++)
                    {
                        var configType = reader.ReadInt32();
                        var x = reader.ReadInt32();
                        var y = reader.ReadInt32();
                        var bppX = reader.ReadInt32();
                        var bppY = reader.ReadInt32();

                        Console.WriteLine("X: {0} / Y: {1} / Total length: {2} ( {2:X} )", x, y, x * y);

                        var config_layer_data = reader.ReadBytes(x * y);

                        Console.WriteLine("Bytes read: {0:X}", 0x64 + 4 + 4 + 8 + (x * y));
                        Console.WriteLine("Config layer {0} length: {1:X}", i + 1, config_layer_data.Length);

                        if (configType == 1)
                        {
                            var iTotal = 0;
                            Bitmap collision = new Bitmap(x, y);

                            for (int iY = 0; iY < y; iY++)
                            {
                                for (int iX = 0; iX < x; iX++)
                                {   
                                    var walkable = config_layer_data[iTotal] == 0x0;
                                    collision.SetPixel(iX, iY, walkable ? Color.Green : Color.Black);
                                    iTotal++;
                                }
                            }

                            var collisionForm = new ConfigLayerCollisionForm();
                            collisionForm.MdiParent = this;
                            collisionForm.Text = String.Format(Strings.CollisionFormTitle, FileName);
                            collisionForm.collisionPicture.BackgroundImage = collision;
                            collisionForm.Show();
                        }
                    }

                    Console.WriteLine("range_object_data");

                    var range_object_data = reader.ReadBytes(32 * range_object_size);

                    for (int i = 0; i < range_object_size; i++)
                    {
                        Console.WriteLine(ByteArrayToString(range_object_data.Skip(i * 32).Take(32).ToArray()));
                    }

                    Console.WriteLine("point_object_data");

                    var point_object_data = reader.ReadBytes(24 * point_object_size);

                    var pointForm = new PointObjectForm();
                    pointForm.Text = "Point Object Data (" + FileName + ")";
                    pointForm.Parent = this;

                    for (int i = 0; i < point_object_size; i++)
                    {
                        var pointBytes = point_object_data.Skip(i * 24).Take(24).ToArray();
                        using (var pointReader = new BinaryReader(new MemoryStream(pointBytes)))
                        {
                            var pointObject = new PointObject()
                            {
                                Id = pointReader.ReadInt32(),
                                Type = pointReader.ReadInt32(),
                                MapId = pointReader.ReadInt32(),
                                X = pointReader.ReadInt32(),
                                Y = pointReader.ReadInt32(),
                                Options = pointReader.ReadInt32()
                            };

                            pointForm.pointList.Items.Add(new ListViewItem(new string[] { pointObject.Id.ToString(), pointObject.GetTypeName(), pointObject.MapId.ToString(), pointObject.X.ToString(), pointObject.Y.ToString() }));
                        }
                    }

                    pointForm.Show();

                    Console.WriteLine("effect_object_data");

                    var effect_object_data = reader.ReadBytes(52 * effect_object_size);

                    for (int i = 0; i < effect_object_size; i++)
                    {
                        Console.WriteLine(ByteArrayToString(effect_object_data.Skip(i * 52).Take(52).ToArray()));
                    }
                }
            }
        }
        
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", " ").ToUpper();
        }

        

        private void MDIParent_Load(object sender, EventArgs e)
        {
            
        }
    }
}
