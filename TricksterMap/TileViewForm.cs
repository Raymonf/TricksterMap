using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TricksterMap.Data;

namespace TricksterMap
{
    public partial class TileViewForm : Form
    {
        public MapDataInfo Map = null;
        public List<Bitmap> tiles = null;
        int i = 0;

        public TileViewForm()
        {
            InitializeComponent();

            this.SetFonts();
        }

        private void MapViewForm_Load(object sender, EventArgs e)
        {
            if (tiles.Count > 0)
            {
                i = 0;

                lblInfo.Text = String.Format(Strings.NumOfNum, (i + 1), tiles.Count);

                mapPicture.BackgroundImage = tiles[0];
            }
            else
            {
                Close();
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        private void btnForward_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            if (tiles.Count > 0)
            {
                if (i >= tiles.Count - 1)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                
                lblInfo.Text = String.Format(Strings.NumOfNum, (i + 1), tiles.Count);

                mapPicture.BackgroundImage = tiles[i];
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        private void btnBack_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            if (tiles.Count > 0)
            {
                if (i <= 0)
                {
                    i = tiles.Count - 1;
                }
                else
                {
                    i--;
                }

                lblInfo.Text = String.Format(Strings.NumOfNum, (i + 1), tiles.Count);

                mapPicture.BackgroundImage = tiles[i];
            }
        }
    }
}
