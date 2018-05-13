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
    public partial class PointObjectForm : Form
    {
        public MapDataInfo Map = null;
        public Dictionary<string, int> types = new Dictionary<string, int>();

        public PointObjectForm()
        {
            InitializeComponent();

            // Initialize localization
            idHeader.Text = Strings.ID;
            typeHeader.Text = Strings.Type;
            mapIdHeader.Text = Strings.MapID;
            xPosHeader.Text = Strings.XPos;
            yPosHeader.Text = Strings.YPos;

            btnCreate.Text = Strings.Create;
            btnDelete.Text = Strings.Delete;
            btnEdit.Text = Strings.Edit;

            foreach (var type in PointObject.ValidTypes)
            {
                var typeName = PointObject.GetTypeNameFromId(type);

                types.Add(typeName, type);
            }
        }

        public void RepopulateData()
        {
            pointList.Items.Clear();

            foreach (var point in Map.PointObjects)
            {
                pointList.Items.Add(new ListViewItem(new string[] { point.Id.ToString(), point.GetTypeName(), point.MapId.ToString(), point.X.ToString(), point.Y.ToString() }));
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        private void btnCreate_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            var createForm = new CreatePointObject()
            {
                Map = Map,
                PointListForm = this
            };

            createForm.ShowDialog();
        }

#pragma warning disable IDE1006 // Naming Styles
        private void btnDelete_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            if (pointList.SelectedIndices.Count > 0)
            {
                Map.PointObjects.RemoveAt(pointList.Items.IndexOf(pointList.SelectedItems[0]));
                pointList.SelectedItems[0].Remove();
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        private void btnEdit_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            EditSelectedItem();
        }

        private void PointObjectForm_Load(object sender, EventArgs e)
        {
            this.SetFonts();
        }

#pragma warning disable IDE1006 // Naming Styles
        private void pointList_DoubleClick(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            EditSelectedItem();
        }

        private void EditSelectedItem()
        {
            if (pointList.SelectedIndices.Count > 0)
            {
                var index = pointList.Items.IndexOf(pointList.SelectedItems[0]);

                var point = Map.PointObjects[index];

                Map.PointObjects.RemoveAt(index);
                pointList.SelectedItems[0].Remove();

                var createForm = new CreatePointObject()
                {
                    Map = Map,
                    PointListForm = this
                };

                createForm.Text = Strings.EditPointObject;
                createForm.btnCreate.Text = Strings.Edit;
                createForm.txtId.Text = point.Id.ToString();
                createForm.txtMapId.Text = point.MapId.ToString();
                createForm.txtX.Text = point.X.ToString();
                createForm.txtY.Text = point.Y.ToString();
                createForm.cmbType.SelectedIndex = createForm.cmbType.FindStringExact(point.GetTypeName());

                createForm.ShowDialog();
            }
        }
    }
}
