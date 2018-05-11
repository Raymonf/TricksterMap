using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace md3_2
{
    public partial class ConfigLayerCollisionForm : Form
    {
        string font = "Microsoft JhengHei UI";

        public ConfigLayerCollisionForm()
        {
            InitializeComponent();
        }

        private void ConfigLayerCollisionForm_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(512, 64);
            Graphics g = Graphics.FromImage(bmp);
            
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            var fontObject = new Font("Microsoft JhengHei UI", 12);

            using (var brush = new SolidBrush(Color.FromArgb(160, 255, 255, 255)))
            {
                var walkSize = g.MeasureString(Strings.Walkable, fontObject);
                var notWalkSize = g.MeasureString(Strings.NotWalkable, fontObject);
                var boxWidth = Math.Max(walkSize.Width, notWalkSize.Width); // get larger

                g.FillRectangle(brush, 0, 0, boxWidth + 32, 64);
            }

            g.DrawRectangle(new Pen(Color.Green, 10), 10, 10, 10, 10);
            g.DrawString(Strings.Walkable, fontObject, new SolidBrush(Color.Black), 30, 6);
            
            g.DrawRectangle(new Pen(Color.Black, 10), 10, 34, 10, 10);
            g.DrawString(Strings.NotWalkable, fontObject, new SolidBrush(Color.Black), 30, 30);

            g.Flush();

            collisionPicture.Image = bmp;
        }
    }
}
