using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TricksterMap.Create;
using TricksterMap.Data;

namespace TricksterMap
{
    public partial class RangeObjectForm : Form
    {
        public MapDataInfo Map = null;
        public Dictionary<string, int> types = new Dictionary<string, int>();

        public RangeObjectForm()
        {
            InitializeComponent();

            // Initialize localization
            idHeader.Text = Strings.ID;
            typeHeader.Text = Strings.Type;
            mapIdHeader.Text = Strings.MapID;
            x1PosHeader.Text = Strings.X1Pos;
            y1PosHeader.Text = Strings.Y1Pos;
            x2PosHeader.Text = Strings.X2Pos;
            y2PosHeader.Text = Strings.Y2Pos;

            btnCreate.Text = Strings.Create;
            btnDelete.Text = Strings.Delete;
            btnEdit.Text = Strings.Edit;

            foreach (var type in RangeObject.ValidTypes)
            {
                var typeName = RangeObject.GetTypeNameFromId(type);

                types.Add(typeName, type);
            }
        }

        public void RepopulateData()
        {
            pointList.Items.Clear();

            foreach (var point in Map.RangeObjects)
            {
                pointList.Items.Add(new ListViewItem(new string[] { point.Id.ToString(), point.GetTypeName(), point.Destination.ToString(), point.X1.ToString(), point.Y1.ToString(), point.X2.ToString(), point.Y2.ToString() }));
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new CreateRangeObject()
            {
                Map = Map,
                RangeListForm = this
            };

            createForm.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (pointList.SelectedIndices.Count > 0)
            {
                Map.RangeObjects.RemoveAt(pointList.Items.IndexOf(pointList.SelectedItems[0]));
                pointList.SelectedItems[0].Remove();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void RangeObjectForm_Load(object sender, EventArgs e)
        {
            this.SetFonts();
        }

        private void RangeList_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void EditSelectedItem()
        {
            if (pointList.SelectedIndices.Count > 0)
            {
                var index = pointList.Items.IndexOf(pointList.SelectedItems[0]);

                var range = Map.RangeObjects[index];

                Map.RangeObjects.RemoveAt(index);
                pointList.SelectedItems[0].Remove();

                var createForm = new CreateRangeObject()
                {
                    Map = Map,
                    RangeListForm = this,
                    isEditing = true
                };

                createForm.Text = Strings.EditRangeObject;
                createForm.btnCreate.Text = Strings.Edit;
                createForm.txtId.Text = range.Id.ToString();
                createForm.txtMapId.Text = range.Destination.ToString();
                createForm.txtX1.Text = range.X1.ToString();
                createForm.txtY1.Text = range.Y1.ToString();
                createForm.txtX2.Text = range.X2.ToString();
                createForm.txtY2.Text = range.Y2.ToString();
                createForm.cmbType.SelectedIndex = createForm.cmbType.FindStringExact(range.GetTypeName());

                createForm.ShowDialog();
            }
        }
    }
}
