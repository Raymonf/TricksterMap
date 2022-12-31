using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TricksterMap
{
    public static class Extensions
    {
        public static void SetFont(Control.ControlCollection controls)
        {
            foreach (var control in controls)
            {
                if (control is Control.ControlCollection collection)
                {
                    SetFont(collection);
                }
                else if (control is TableLayoutPanel panel)
                {
                    SetFont(panel.Controls);
                }
                else if (control is Control c)
                {
                    c.Font = new Font(Strings.PreferredFont, c.Font.Size);
                }
            }
        }

        public static void SetFonts(this Form form)
        {
            SetFont(form.Controls);
        }
    }
}
