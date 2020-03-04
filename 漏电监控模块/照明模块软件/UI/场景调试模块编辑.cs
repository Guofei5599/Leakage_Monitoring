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
    public partial class 场景调试模块编辑 : Form
    {
        public 场景子模块 tmp场景子模块;
        public 场景调试模块编辑()
        {
            InitializeComponent();
        }

        private void btn_M添加_Click(object sender, EventArgs e)
        {
            场景模块添加界面 frm = new 场景模块添加界面();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (tmp场景子模块.场景调试模块列表2 == null)
                    tmp场景子模块.场景调试模块列表2 = new List<场景调试模块>();
                foreach (var v in frm.模块编号)
                {
                    if (tmp场景子模块.场景调试模块列表2.FindIndex(t => t.模块编号 == v) != -1)
                    {
                        continue;
                    }
                    场景调试模块 tmp = new 场景调试模块();
                    tmp.场景开关信息列表 = new List<场景开关信息>();
                    while (tmp.场景开关信息列表.Count < 16)
                    {
                        var vmsg = new 场景开关信息();
                        vmsg.开关通道 = (tmp.场景开关信息列表.Count + 1).ToString();
                        vmsg.开关状态 = "是";
                        vmsg.开关亮度 = "0";
                        tmp.场景开关信息列表.Add(vmsg);
                    }
                    tmp.模块编号 = v;
                    var v1 = ModelsOperate.GetModel(int.Parse(tmp.模块编号));
                    tmp场景子模块.场景调试模块列表2.Add(tmp);
                }
                RefreshForm_场景模块(tmp场景子模块.场景调试模块列表2);
            }
        }
        private void RefreshForm_场景模块(List<场景调试模块> tmp)
        {
            dgv_调试模块.Rows.Clear();
            var vv = tmp.OrderBy(t => int.Parse(t.模块编号)).ToList();
            foreach (var v in vv)
            {
                var v1 = ModelsOperate.GetModel(int.Parse(v.模块编号));
                dgv_调试模块.Rows.Add(v.模块编号, v1.模块名称);
            }
        }

        private void btn_M删除_Click(object sender, EventArgs e)
        {
            if (dgv_调试模块.SelectedRows.Count == 0)
            {
                dgv_开关模块.Rows.Clear();
                MessageBox.Show("请先选择产品模块模块！");
                return;
            }
            if (MessageBox.Show("请问是否删除选择行", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgv_调试模块.SelectedRows)
                {
                    tmp场景子模块.场景调试模块列表2.RemoveAll(t => t.模块编号 == Convert.ToString(row.Cells[0].Value));
                }
                ConfigClass.SaveCookie_List(场景设置.当前场景模块, "场景模块.dat");
                RefreshForm_场景模块(tmp场景子模块.场景调试模块列表2);
            }
        }

        private void dgv_调试模块_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_调试模块.SelectedRows.Count != 1)
            {
                dgv_开关模块.Rows.Clear();
                //MessageBox.Show("请先选择产品模块！");
                return;
            }
            dgv_开关模块.Rows.Clear();
            int index = dgv_调试模块.SelectedRows[0].Index;
            场景调试模块 tmp = tmp场景子模块.场景调试模块列表2.Find(t => t.模块编号 == Convert.ToString(dgv_调试模块.Rows[index].Cells[0].Value));
            if (tmp == null)
            {
                MessageBox.Show("该地址模块不存在！");
                return;
            }
            if (tmp.场景开关信息列表 == null)
                tmp.场景开关信息列表 = new List<场景开关信息>();
            while (tmp.场景开关信息列表.Count < 16)
            {
                var v = new 场景开关信息();
                v.开关通道 = (tmp.场景开关信息列表.Count + 1).ToString();
                v.开关状态 = "是";
                v.开关亮度 = "0";
                tmp.场景开关信息列表.Add(v);
            }
            var tmp1 = ModelsOperate.GetModel(int.Parse(tmp.模块编号));
            //for (int i = 0; i < tmp1.开关列表.Count; i++)
            //{
            //    tmp.场景开关信息列表.Find(t => t.开关通道 == tmp1.开关列表[i].模块编号).开关名称 = tmp1.开关列表[i].开关名称;
            //}
            Refresh_dgv_开关模块(tmp.场景开关信息列表, tmp1);
        }
        private void Refresh_dgv_开关模块(List<场景开关信息> tmp, 调试模块 tmp1)
        {
            dgv_开关模块.Rows.Clear();
            foreach (var v in tmp)
            {
                int index = dgv_开关模块.Rows.Add(v.开关通道, v.开关名称, v.开关状态, v.开关亮度);
                //if (int.Parse(tmp1.开关路数) < int.Parse(v.开关通道))
                //    dgv_开关模块.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
                //else
                //    dgv_开关模块.Rows[index].DefaultCellStyle.ForeColor = Color.Black;

            }

            if (tmp1.模块类型 == "开关模块")
            {
                dgv_开关模块.Columns["亮度"].Visible = false;
            }
            else
            {
                dgv_开关模块.Columns["亮度"].Visible = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_开关模块.EndEdit();
                if (dgv_调试模块.SelectedRows.Count != 1)
                {
                    dgv_开关模块.Rows.Clear();
                    MessageBox.Show("请先选择产品模块！");
                    return;
                }
                场景调试模块 tmp = tmp场景子模块.场景调试模块列表2.Find(t => t.模块编号 == Convert.ToString(dgv_调试模块.SelectedRows[0].Cells[0].Value));
                foreach (DataGridViewRow row in dgv_开关模块.Rows)
                {
                    string id = Convert.ToString(row.Cells[0].Value);
                    var v = tmp.场景开关信息列表.Find(t => t.开关通道 == id);
                    if (v != null)
                    {
                        v.开关状态 = Convert.ToString(row.Cells[2].Value);
                        v.开关亮度 = Convert.ToString(row.Cells[3].Value);
                    }
                }
                ConfigClass.SaveCookie_List(场景设置.当前场景模块, "场景模块.dat");
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_开关模块_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void dgv_开关模块_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!dgv_开关模块.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
                return;
            if (e.ColumnIndex != 3)
                return;
            try
            {
                int value = Convert.ToInt32(e.FormattedValue);
                if (value <= 10 && value >= 0)
                {

                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("输入必须为 0-10范围数值");
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show("输入必须为 0-10范围数值");
            }
        }

        private void 场景调试模块编辑_Load(object sender, EventArgs e)
        {
            if (tmp场景子模块.场景调试模块列表2 == null)
                tmp场景子模块.场景调试模块列表2 = new List<场景调试模块>();
            RefreshForm_场景模块(tmp场景子模块.场景调试模块列表2);
            this.Text = tmp场景子模块.场景子名称;
        }

        private void dgv_开关模块_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgv_开关模块_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            if (dgv_开关模块.Columns[e.ColumnIndex].Name == "开关状态")
            {
                if (Convert.ToString(dgv_开关模块.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == "否")
                    dgv_开关模块.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "是";
                else
                    dgv_开关模块.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "否";
            }
        }
    }
}
