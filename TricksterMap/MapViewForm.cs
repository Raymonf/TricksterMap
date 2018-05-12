using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TricksterMap
{
    public partial class MapViewForm : Form
    {
        public List<Bitmap> tiles = null;
        int i = 0;

        public MapViewForm()
        {
            InitializeComponent();
        }

        private void MapViewForm_Load(object sender, EventArgs e)
        {
            if (tiles.Count > 0)
            {
                i = 0;

                lblInfo.Text = (i + 1) + " of " + tiles.Count;

                mapPicture.BackgroundImage = tiles[0];
            }
            else
            {
                Close();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
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

                lblInfo.Text = (i + 1) + " of " + tiles.Count;

                mapPicture.BackgroundImage = tiles[i];
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
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

                lblInfo.Text = (i + 1) + " of " + tiles.Count;

                mapPicture.BackgroundImage = tiles[i];
            }
        }
    }
}
