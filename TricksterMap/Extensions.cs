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
                if (control is Control.ControlCollection)
                {
                    SetFont((Control.ControlCollection)control);
                }
                else if (control is TableLayoutPanel)
                {
                    SetFont(((TableLayoutPanel)control).Controls);
                }
                else if (control is Label)
                {
                    ((Label)control).Font = new Font(Strings.PreferredFont, ((Label)control).Font.Size);
                }
                else if (control is TextBox)
                {
                    ((TextBox)control).Font = new Font(Strings.PreferredFont, ((TextBox)control).Font.Size);
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).Font = new Font(Strings.PreferredFont, ((ComboBox)control).Font.Size);
                }
                else if (control is Button)
                {
                    ((Button)control).Font = new Font(Strings.PreferredFont, ((Button)control).Font.Size);
                }
                else if (control is ListView)
                {
                    ((ListView)control).Font = new Font(Strings.PreferredFont, ((ListView)control).Font.Size);
                }
            }
        }
        public static void SetFonts(this Form form)
        {
            SetFont(form.Controls);
        }
    }
}
