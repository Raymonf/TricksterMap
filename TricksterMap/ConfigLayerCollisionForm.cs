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
using TricksterMap.Data;

namespace TricksterMap
{
    public partial class ConfigLayerCollisionForm : Form
    {
        public Color WalkableColor = Color.Green;
        public Color NotWalkableColor = Color.Black;

        string font = "Microsoft JhengHei UI";
        Color textColor = Color.Black;
        Color backgroundColor = Color.FromArgb(160, 255, 255, 255);

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

            var fontObject = new Font(font, 12);

            using (var brush = new SolidBrush(backgroundColor))
            {
                var walkSize = g.MeasureString(Strings.Walkable, fontObject);
                var notWalkSize = g.MeasureString(Strings.NotWalkable, fontObject);
                var boxWidth = Math.Max(walkSize.Width, notWalkSize.Width); // get larger

                g.FillRectangle(brush, 0, 0, boxWidth + 32, 64);
            }

            g.DrawRectangle(new Pen(WalkableColor, 10), 10, 10, 10, 10);
            g.DrawString(Strings.Walkable, fontObject, new SolidBrush(textColor), 30, 6);
            
            g.DrawRectangle(new Pen(NotWalkableColor, 10), 10, 34, 10, 10);
            g.DrawString(Strings.NotWalkable, fontObject, new SolidBrush(textColor), 30, 30);

            g.Flush();

            collisionPicture.Image = bmp;
        }

        public void LoadData(ConfigLayer layer)
        {
            var iTotal = 0;
            Bitmap collision = new Bitmap(layer.X, layer.Y);

            for (int iY = 0; iY < layer.Y; iY++)
            {
                for (int iX = 0; iX < layer.X; iX++)
                {
                    collision.SetPixel(iX, iY, layer.Data[iTotal] == 0x0 ? WalkableColor : NotWalkableColor);
                    iTotal++;
                }
            }

            collisionPicture.BackgroundImage = collision;
        }
    }
}
