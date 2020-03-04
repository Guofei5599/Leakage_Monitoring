using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照明模块软件
{
    public partial class 模块管理界面 : Form
    {
        public 模块管理界面()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (num_addr1.Value == 0 || num_addr2.Value == 0)
            {
                tip_Lable.Text = "地址必须大于0";
                return;
            }
            if (num_addr1.Value > num_addr2.Value)
            {
                tip_Lable.Text = "前个地址必须小于后个地址";
                return;
            }
            if (MessageBox.Show("请问是否新增数据","提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 1; i < (int)(num_addr2.Value) + 1; i++)
                {
                    ModelsOperate.Add(i);
                }
                ModelsOperate.ModelsList = ModelsOperate.AllModelsList.FindAll(t => !t.IsRemove);
                ModelsOperate.Display(dataGridView1);
                tip_Lable.Text = "";
            }
        }

        private void 模块管理界面_Load(object sender, EventArgs e)
        {
            tip_Lable.Text = "";
            ModelsOperate.Display(dataGridView1);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (num_addr1.Value == 0 || num_addr2.Value == 0)
            {
                tip_Lable.Text = "地址必须大于0";
                return;
            }
            if (num_addr1.Value > num_addr2.Value)
            {
                tip_Lable.Text = "前个地址必须大于后个地址";
                return;
            }
            if (num_addr2.Value != ModelsOperate.ModelsList.Count)
            {
                tip_Lable.Text = "最后地址必须是最大地址！";
                return;
            }
            if (MessageBox.Show("请问是否删除数据", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = (int)num_addr1.Value; i < (int)(num_addr2.Value) + 1; i++)
                {
                    ModelsOperate.Delete(i);
                    tip_Lable.Text = "";
                }
                ModelsOperate.ModelsList = ModelsOperate.AllModelsList.FindAll(t => !t.IsRemove);
                ModelsOperate.Display(dataGridView1);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == -1 && e.RowIndex == -1)
            //{
            //    return;
            //}
            
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_模块地址.Text.Trim().Length == 0)
            {
                tip_Lable.Text = "模块地址不能为空！";
            }
            ModelsOperate.Modify(int.Parse(txt_模块地址.Text),txt_模块名称.Text,txt_安装位置.Text,"",check_为空.Checked);
            ModelsOperate.OnlyDisplay(dataGridView1);
            MessageBox.Show("保存成功！");
            tip_Lable.Text = "";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int index = dataGridView1.SelectedCells[0].RowIndex;
                txt_模块地址.Text = Convert.ToString( dataGridView1.Rows[index].Cells["模块地址"].Value);
                txt_模块名称.Text = Convert.ToString(dataGridView1.Rows[index].Cells["模块名称"].Value);
                txt_安装位置.Text = Convert.ToString(dataGridView1.Rows[index].Cells["安装位置"].Value);
                check_为空.Checked = Convert.ToBoolean(dataGridView1.Rows[index].Cells["为空"].Value);
            }
        }
        int Editindex = -1;
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right )
            {
                DataGridView.HitTestInfo info = dataGridView1.HitTest(e.X,e.Y);
                Editindex = info.RowIndex;
                if (Editindex != -1 && info.ColumnIndex != -1)
                {
                    foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                    {
                        cell.Selected = false;
                    }
                    dataGridView1.Rows[info.RowIndex].Cells[info.ColumnIndex].Selected = true;
                    contextMenuStrip1.Show(dataGridView1, new Point(e.X,e.Y));
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "开关编辑")
            {
                开关管理 frm = new 开关管理();
                frm.tmp = ModelsOperate.GetModel(Convert.ToInt32(dataGridView1.Rows[Editindex].Cells[0].Value));
                frm.ShowDialog();
                Editindex = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否清空数据", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ModelsOperate.ClearModelMsg();
                ModelsOperate.Display(dataGridView1);
            }
        }
    }
}
