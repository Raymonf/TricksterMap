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

namespace TricksterMap.Create
{
    public partial class CreatePointObject : Form
    {
        public MapDataInfo Map = null;
        public PointObjectForm PointListForm = null;
        public Dictionary<string, int> types = new Dictionary<string, int>();

        public CreatePointObject()
        {
            InitializeComponent();

            foreach (var type in PointObject.ValidTypes)
            {
                var typeName = PointObject.GetTypeNameFromId(type);

                types.Add(typeName, type);

                cmbType.Items.Add(typeName);
            }

            if (PointObject.ValidTypes.Length > 0)
            {
                cmbType.SelectedIndex = 0;
            }
        }

        private void CreatePointObject_Load(object sender, EventArgs e)
        {

        }

        public int GetTypeIdFromName(string name)
        {
            if (types.ContainsKey(name))
            {
                return types[name];
            }

            return -1;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtId.Text);
            var typeId = GetTypeIdFromName(cmbType.Text);

            // Portals, respawns, and none should have ID 0
            if (typeId == 0x01 || typeId == 0x02)
            {
                id = 0;
            }
            else
            {
                // Check for a duplicate ID
                if (Map.PointObjects.Exists(p => p.Type == typeId && p.Id == id))
                {
                    MessageBox.Show("Duplicate ID found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var point = new PointObject()
            {
                Id = id,
                Type = typeId,
                MapId = int.Parse(txtMapId.Text),
                X = int.Parse(txtX.Text),
                Y = int.Parse(txtY.Text)
            };

            Map.PointObjects.Add(point);
            PointListForm.RepopulateData();
            Close();
        }
    }
}
