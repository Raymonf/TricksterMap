using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TricksterMap
{
    // https://stackoverflow.com/a/13484101
    /// <summary>
    /// Inherits from PictureBox; adds Interpolation Mode Setting
    /// </summary>
    public class NearestNeighborPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            paintEventArgs.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            paintEventArgs.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            base.OnPaint(paintEventArgs);
        }
    }
}
