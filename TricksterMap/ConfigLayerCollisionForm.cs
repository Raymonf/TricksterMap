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
        public Color WalkableColor = Color.FromArgb(128, 0, 200, 0);
        public Color NotWalkableColor = Color.FromArgb(128, 0, 0, 0);

        string font = Strings.PreferredFont;
        Color textColor = Color.Black;
        Color backgroundColor = Color.FromArgb(160, 255, 255, 255);
        
        public ConfigLayerCollisionForm()
        {
            InitializeComponent();
            
            this.SetFonts();
        }

        public void LoadType3(ConfigLayer layer)
        {
            var iTotal = 0;

            Bitmap pic = new Bitmap(layer.X, layer.Y);

            for (int iY = 0; iY < layer.Y; iY++)
            {
                for (int iX = 0; iX < layer.X; iX++)
                {
                    pic.SetPixel(iX, iY, layer.Data[iTotal] == 0x0 ? Color.FromArgb(100, 0, 0, 200) : Color.FromArgb(0, 0, 0, 0));
                    iTotal++;
                }
            }

            type3Picture.BackgroundImage = pic;
        }

        public void LoadType2(ConfigLayer layer)
        {
            var iTotal = 0;
            
            Bitmap pic = new Bitmap(layer.X, layer.Y);

            for (int iY = 0; iY < layer.Y; iY++)
            {
                for (int iX = 0; iX < layer.X; iX++)
                {
                    pic.SetPixel(iX, iY, layer.Data[iTotal] == 0x0 ? Color.FromArgb(100, 200, 0, 0) : Color.FromArgb(0, 0, 0, 0));
                    iTotal++;
                }
            }

            type2Picture.BackgroundImage = pic;
        }

        public void LoadCollisionData(ConfigLayer layer)
        {
            WriteLegend(layer);

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

        public void WriteLegend(ConfigLayer layer)
        {
            Bitmap bmp = new Bitmap(512, 90);
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

                g.FillRectangle(brush, 0, 0, boxWidth + 32, 90);
            }

            g.DrawRectangle(new Pen(WalkableColor, 10), 10, 10, 10, 10);
            g.DrawString(Strings.Walkable, fontObject, new SolidBrush(textColor), 30, 6);

            g.DrawRectangle(new Pen(NotWalkableColor, 10), 10, 34, 10, 10);
            g.DrawString(Strings.NotWalkable, fontObject, new SolidBrush(textColor), 30, 30);

            g.DrawString(String.Format(Strings.XSize, layer.X), fontObject, new SolidBrush(textColor), 2, 52);
            g.DrawString(String.Format(Strings.YSize, layer.Y), fontObject, new SolidBrush(textColor), 2, 70);

            g.Flush();

            collisionPicture.Image = bmp;
        }

        private void ConfigLayerCollisionForm_Load(object sender, EventArgs e)
        {
            type2Picture.Parent = collisionPicture;
            type2Picture.BringToFront();
            type3Picture.Parent = type2Picture;
            type3Picture.BringToFront();
        }
    }
}
