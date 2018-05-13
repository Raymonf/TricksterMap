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
            typeHeader.Text = Strings.Type;
            mapIdHeader.Text = Strings.MapID;
            xPosHeader.Text = Strings.XPos;
            yPosHeader.Text = Strings.YPos;

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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new CreatePointObject()
            {
                Map = Map,
                PointListForm = this
            };

            createForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (pointList.SelectedIndices.Count > 0)
            {
                Map.PointObjects.RemoveAt(pointList.Items.IndexOf(pointList.SelectedItems[0]));
                pointList.SelectedItems[0].Remove();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
                    PointListForm = this,
                    Text = "Edit Point Object"
                };

                createForm.btnCreate.Text = "Edit";
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
