using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DMP.Infrastructure.Common;


namespace Domain.ModelDesigner.Editer.ListItem
{
    public partial class ListItemEditerForm : Form
    {
        private NameObjectCollection<Domain.Model.Elements.ListItem> _returnValue =
                                            new NameObjectCollection<Domain.Model.Elements.ListItem>();
        public NameObjectCollection<Domain.Model.Elements.ListItem> ReturnValue
        {
            get { return _returnValue; }
        }
        public ListItemEditerForm()
        {
            InitializeComponent();
            grid.AutoGenerateColumns =
            grid.AllowUserToAddRows = false;
            grid.RowPostPaint += dataGridView1_RowPostPaint;
        }

        public void BindListItems(object listItems)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn { ColumnName = "is_default", DataType = typeof(bool) });
            dt.Columns.Add(new DataColumn { ColumnName = "key", DataType = typeof(string) });
            dt.Columns.Add(new DataColumn { ColumnName = "value", DataType = typeof(string) });

            NameObjectCollection<Domain.Model.Elements.ListItem> items =
                                        (NameObjectCollection<Domain.Model.Elements.ListItem>)listItems;
            if (items != null && items.Count > 0)
            {
                foreach (string k in items.AllKeys)
                {
                    DataRow dr = dt.NewRow();
                    dr["key"] = items[k].Text;
                    dr["value"] = items[k].Value;
                    dr["is_default"] = items[k].IsDefault;
                    dt.Rows.Add(dr);
                }
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
            }
            grid.DataSource = dt;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            NameObjectCollection<Domain.Model.Elements.ListItem> items = new NameObjectCollection<Domain.Model.Elements.ListItem>();
            DataTable dt = grid.DataSource as DataTable;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    items.Add(row["key"].ToStr(), new Domain.Model.Elements.ListItem
                    {
                        Text = row["key"].ToStr(),
                        Value = row["value"].ToStr(),
                        IsDefault = row["is_default"] != null && row["is_default"] != DBNull.Value && (bool)row["is_default"]
                    });
                }
            }
            _returnValue = items;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            GridOpearte("del");
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            GridOpearte("up");
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            GridOpearte("down");
        }

        // 显示序号,行号
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                            e.RowBounds.Location.Y,
                            grid.RowHeadersWidth - 4,
                            e.RowBounds.Height); TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
             grid.RowHeadersDefaultCellStyle.Font, rectangle,
             grid.RowHeadersDefaultCellStyle.ForeColor,
             TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GridOpearte("new");
        }

        private void GridOpearte(string type)
        {
            if (grid.CurrentRow == null)
            {
                MessageBox.Show("请选择要需要操作的工序所在行");
                return;
            }
            if (type == "new")//新增一行
            {
                DataTable dt = (grid.DataSource as DataTable);
                dt.Rows.Add(dt.NewRow());
                grid.DataSource = dt;
            }
            else if (type == "del")//删 
            {
                if (MessageBox.Show("确定要删除吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    grid.Rows.Remove(grid.CurrentRow);
                }
            }
            else if (type == "up")//上 
            {
                if (grid.CurrentRow.Index <= 0)
                {
                    MessageBox.Show("此工序已在顶端，不能再上移！");
                }
                else
                {
                    DataTable dt = (grid.DataSource as DataTable);
                    int nowIndex = grid.CurrentRow.Index;
                    if (dt != null)
                    {
                        object[] rowData = dt.Rows[nowIndex].ItemArray;
                        dt.Rows[nowIndex].ItemArray = dt.Rows[nowIndex - 1].ItemArray;
                        dt.Rows[nowIndex - 1].ItemArray = rowData;
                        grid.CurrentCell = grid.Rows[nowIndex - 1].Cells[0];//设定当前行     
                    }

                }
            }
            else if (type == "down")//下 
            {
                if (grid.CurrentRow.Index >= grid.Rows.Count - 1)
                {
                    MessageBox.Show("此工序已在底端，不能再下移！");
                }
                else
                {
                    DataTable dt = (grid.DataSource as DataTable);
                    int nowIndex = grid.CurrentRow.Index;
                    if (dt != null)
                    {
                        object[] rowData = dt.Rows[nowIndex].ItemArray;
                        dt.Rows[nowIndex].ItemArray = dt.Rows[nowIndex + 1].ItemArray;
                        dt.Rows[nowIndex + 1].ItemArray = rowData;
                        grid.CurrentCell = grid.Rows[nowIndex + 1].Cells[0]; //设定当前行 
                    }
                }
            }
        }

    }
}
