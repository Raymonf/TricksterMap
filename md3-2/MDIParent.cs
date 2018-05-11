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
            using (var reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
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

                    var pointForm = new PointObjectForm
                    {
                        Text = "Point Object Data (" + fileName + ")",
                        Parent = this
                    };

                    foreach (var point in mapInfo.PointObjects)
                    {
                        pointForm.pointList.Items.Add(new ListViewItem(new string[] { point.Id.ToString(), point.GetTypeName(), point.MapId.ToString(), point.X.ToString(), point.Y.ToString() }));
                    }

                    pointForm.Show();
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
