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
    public partial class PointObjectForm : Form
    {
        public PointObjectForm()
        {
            InitializeComponent();

            // Initialize localization
            typeHeader.Text = Strings.Type;
            mapIdHeader.Text = Strings.MapID;
            xPosHeader.Text = Strings.XPos;
            yPosHeader.Text = Strings.YPos;
        }
    }
}
