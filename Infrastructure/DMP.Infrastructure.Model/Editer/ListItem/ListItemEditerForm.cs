using DMP.Infrastructure.Common;
using DMP.Infrastructure.Model.Elements;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;
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

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            upOrdownOrDelete("del");
        }

        private void upOrdownOrDelete(string type)

        {

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选择要需要操作的工序所在行");
            }
            else if (type == "del")//删 
            {
                if (MessageBox.Show("确定要删除吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                }
            }
            else if (type == "up")//上 
            {
                if (dataGridView1.CurrentRow.Index <= 0)
                {
                    MessageBox.Show("此工序已在顶端，不能再上移！");
                }
                else
                {
                    int nowIndex = dataGridView1.CurrentRow.Index;

                    object[] _rowData = (dataGridView1.DataSource as DataTable).Rows[nowIndex].ItemArray;

                    (dataGridView1.DataSource as DataTable).Rows[nowIndex].ItemArray = (dataGridView1.DataSource as DataTable).Rows[nowIndex - 1].ItemArray;

                    (dataGridView1.DataSource as DataTable).Rows[nowIndex - 1].ItemArray = _rowData;

                    dataGridView1.CurrentCell = dataGridView1.Rows[nowIndex - 1].Cells[0];//设定当前行 
                }
            }
            else if (type == "down")//下 
            {
                if (dataGridView1.CurrentRow.Index >= dataGridView1.Rows.Count - 1)
                {
                    MessageBox.Show("此工序已在底端，不能再下移！");
                }
                else
                {
                    int nowIndex = dataGridView1.CurrentRow.Index;
                    object[] _rowData = (dataGridView1.DataSource as DataTable).Rows[nowIndex].ItemArray;
                    (dataGridView1.DataSource as DataTable).Rows[nowIndex].ItemArray =
                                (dataGridView1.DataSource as DataTable).Rows[nowIndex + 1].ItemArray;
                    (dataGridView1.DataSource as DataTable).Rows[nowIndex + 1].ItemArray = _rowData;
                    dataGridView1.CurrentCell = dataGridView1.Rows[nowIndex + 1].Cells[0];//设定当前行 
                }
            }
        }

        private void btnUp_Click(object sender, System.EventArgs e)
        {
            upOrdownOrDelete("up");
        }

        private void btnDown_Click(object sender, System.EventArgs e)
        {
            upOrdownOrDelete("down");
        }

        // 上移
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            // 选择的行号
            int selectedRowIndex = GetSelectedRowIndex(dataGridView1);

            if (selectedRowIndex >= 1)
            {
                // 拷贝选中的行
                DataGridViewRow newRow = dataGridView1.Rows[selectedRowIndex];

                // 删除选中的行
                dataGridView1.Rows.Remove(dataGridView1.Rows[selectedRowIndex]);

                // 将拷贝的行，插入到选中的上一行位置
                dataGridView1.Rows.Insert(selectedRowIndex - 1, newRow);

                // 选中最初选中的行
                dataGridView1.Rows[selectedRowIndex - 1].Selected = true;
            }

        }

        // 下移
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = GetSelectedRowIndex(dataGridView1);
            if (selectedRowIndex < dataGridView1.Rows.Count - 1)
            {
                // 拷贝选中的行
                DataGridViewRow newRow = dataGridView1.Rows[selectedRowIndex];

                // 删除选中的行
                dataGridView1.Rows.Remove(dataGridView1.Rows[selectedRowIndex]);

                // 将拷贝的行，插入到选中的下一行位置
                dataGridView1.Rows.Insert(selectedRowIndex + 1, newRow);

                // 选中最初选中的行
                dataGridView1.Rows[selectedRowIndex + 1].Selected = true;
            }
        }
        // 获取DataGridView中选择的行索引号
        private int GetSelectedRowIndex(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                return 0;
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Selected)
                {
                    return row.Index;
                }
            }
            return 0;
        }

        // 显示序号,行号
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                            e.RowBounds.Location.Y,
                            dataGridView1.RowHeadersWidth - 4,
                            e.RowBounds.Height); TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
             dataGridView1.RowHeadersDefaultCellStyle.Font, rectangle,
             dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
             TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }


    }
}
