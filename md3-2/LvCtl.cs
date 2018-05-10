using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace md3_2
{
    public static class LvCtl
    {
        static List<ListView> LVs = new List<ListView>();

        delegate string StringFrom(string s);

        static Dictionary<string, StringFrom> funx = new Dictionary<string, StringFrom>();

        public static void registerLV(ListView lv)
        {
            if (!LVs.Contains(lv) && lv is ListView)
            {
                LVs.Add(lv);
                lv.ColumnClick += Lv_ColumnClick;

                funx.Add("", stringFromString);
                for (int i = 0; i < lv.Columns.Count; i++)
                {
                    if (lv.Columns[i].Text == null) continue;
                    string n = lv.Columns[i].Text.ToString();
                    if (n == "") continue;
                    if (n.Contains("__date")) funx.Add(n, stringFromDate);
                    if (n.Contains("__int")) funx.Add(n, stringFromInt);
                    else funx.Add(n, stringFromString);
                }

            }
        }

        static string stringFromString(string s)
        {
            return s;
        }
        static string stringFromInt(string s)
        {
            int i = 0;
            int.TryParse(s, out i);
            return i.ToString("00000");
        }
        static string stringFromDate(string s)
        {
            DateTime dt = Convert.ToDateTime(s);
            return dt.ToString("yyyy.MM.dd HH.mm.ss");
        }

        private static void Lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv == null) return;


            int c = e.Column;
            string nt = lv.Columns[c].Text.ToString();
            string n = nt.Replace("__", "§").Split('§')[0];

            bool asc = (lv.Text == null) || (lv.Text.ToString() != c + "");
            var items = lv.Items.Cast<ListViewItem>().ToList();
            var sorted = asc ?
                items.OrderByDescending(x => funx[nt](c < x.SubItems.Count ?
                                        x.SubItems[c].Text : "")).ToList() :
                items.OrderBy(x => funx[nt](c < x.SubItems.Count ?
                              x.SubItems[c].Text : "")).ToList();
            lv.Items.Clear();
            lv.Items.AddRange(sorted.ToArray());
            if (asc) lv.Text = c + ""; else lv.Text = null;
        }

        public static void unRegisterLV(ListView lv)
        {
            if (LVs.Contains(lv) && lv is ListView)
            {
                LVs.Remove(lv);
                lv.ColumnClick -= Lv_ColumnClick;
            }
        }
    }
}
