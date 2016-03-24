using DMP.Infrastructure.Common;
using DMP.Infrastructure.Model.Elements;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DMP.Infrastructure.Model.Editer
{
    public partial class ListItemEditerForm : Form
    {
        private List<ListItem> returnValue = new List<ListItem>();

        public List<ListItem> ReturnValue
        {
            get { return returnValue; }
        }
        public ListItemEditerForm()
        {
            InitializeComponent();
        }

        public void BindListItems(object value)
        {
            if (value != null)
            {
                foreach (ListItem item in (List<ListItem>)value)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = item.Text;
                    row.Cells[1].Value = item.Value;
                    row.Cells[2].Value = item.IsDefault;
                    dataGridView1.Rows.Add(row);


                }
            }
        }


        private void btnOk_Click(object sender, System.EventArgs e)
        {
            List<ListItem> items = new List<ListItem>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                items.Add(new ListItem
                {
                    Text = row.Cells["value"].Value.ToStr(),
                    Value = row.Cells["key"].Value.ToStr(),
                    IsDefault = row.Cells["is_default"].Value == null ? false : (bool)row.Cells["is_default"].Value
                });
            }
            returnValue = items;
            DialogResult = DialogResult.OK;
            Close();
        }


    }
}
