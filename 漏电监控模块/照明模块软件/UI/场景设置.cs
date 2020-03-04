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
    public partial class 场景设置 : Form
    {
        public static List<场景模块> 当前场景模块;
        public 场景设置()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_添加_Click(object sender, EventArgs e)
        {
            场景添加 frm = new 场景添加();
            frm.isNew = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //场景编辑 frm1 = new 场景编辑();
                //frm1.tmp = frm.tmp;
                //frm1.isNew = true;
                //frm1.ShowDialog();
                RefreshForm();
                if (dgv_场景模块.Rows.Count != 0)
                    dgv_场景模块.Rows[dgv_场景模块.Rows.Count - 1].Selected = true;
            }
        }

        private void btn_修改_Click(object sender, EventArgs e)
        {
            if (dgv_场景模块.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑项！");
                return;
            }
            int index = -1;
            if ((index = 当前场景模块.FindIndex(t => t.场景名称 == Convert.ToString(dgv_场景模块.Rows[dgv_场景模块.SelectedRows[0].Index].Cells[0].Value))) == -1)
            {
                MessageBox.Show("编辑项不存在");
                return;
            }
            场景添加 frm1 = new 场景添加();
            frm1.tmp = 当前场景模块[index];
            frm1.isNew = false;
            if (frm1.ShowDialog() == DialogResult.OK)
            {
                //场景编辑 frm = new 场景编辑();
                //frm.tmp = frm1.tmp;
                //frm.ShowDialog();
                int i = dgv_场景模块.SelectedRows[0].Index;
                RefreshForm();
                dgv_场景模块.Rows[i].Selected = true;
            }
        }

        private void dgv_场景模块_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            int index = -1;
            if ((index = 当前场景模块.FindIndex(t => t.场景名称 == Convert.ToString(dgv_场景模块.Rows[e.RowIndex].Cells[0].Value))) == -1)
            {
                MessageBox.Show("编辑项不存在");
                return;
            }
            场景编辑 frm = new 场景编辑();
            frm.tmp = 当前场景模块[index];
            frm.ShowDialog();
            RefreshForm();
        }

        private void btn_M添加_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_场景模块.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请先选择一项场景！");
                    return;
                }
                场景模块添加界面 frm = new 场景模块添加界面();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int index = -1;
                    string name = Convert.ToString(dgv_场景模块.SelectedRows[0].Cells[0].Value);
                    if ((index = 当前场景模块.FindIndex(t => t.场景名称 == name)) == -1)
                    {
                        dgv_调试模块.Rows.Clear();
                        dgv_开关模块.Rows.Clear();
                        return;
                    }
                    if (当前场景模块[index].场景调试模块列表 == null)
                        当前场景模块[index].场景调试模块列表 = new List<场景调试模块>();
                    foreach (var v in frm.模块编号)
                    {
                        if (当前场景模块[index].场景调试模块列表.FindIndex(t => t.模块编号 == v) != -1)
                        {
                            //MessageBox.Show("该地址已存在");
                            continue;
                        }
                        场景调试模块 tmp = new 场景调试模块();
                        tmp.场景开关信息列表 = new List<场景开关信息>();
                        tmp.模块编号 = v;
                        var v1 = ModelsOperate.GetModel(int.Parse(tmp.模块编号));
                        当前场景模块[index].场景调试模块列表.Add(tmp);
                    }
                    ConfigClass.SaveCookie_List(场景设置.当前场景模块, "场景模块.dat");
                    RefreshForm_场景模块(当前场景模块[index].场景调试模块列表);
                    MessageBox.Show("添加成功");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshForm()
        {
            dgv_场景模块.Rows.Clear();
            当前场景模块.RemoveAll(t=>t.场景名称 == null);
            foreach (var v in 当前场景模块)
            {
               int index = dgv_场景模块.Rows.Add(v.场景名称,v.启用标志?"已启用":"禁用", v.模式.ToString(), v.开始时间.ToString("yyyyMMdd") , v.结束时间.ToString("yyyyMMdd"));
                dgv_场景模块.Rows[index].HeaderCell.Value = (index + 1).ToString();
            }
        }

        private void 场景设置_Load(object sender, EventArgs e)
        {
            dgv_场景模块.TopLeftHeaderCell.Value = "场景";
            dgv_场景模块.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RefreshForm();
        }

        private void btn_删除_Click(object sender, EventArgs e)
        {
            if (dgv_场景模块.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑项！");
                return;
            }
            if (MessageBox.Show("请问是否删除该项！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int index = -1;
                if ((index = 当前场景模块.FindIndex(t => t.场景名称 == Convert.ToString(dgv_场景模块.Rows[dgv_场景模块.SelectedRows[0].Index].Cells[0].Value))) != -1)
                {
                    当前场景模块.RemoveAt(index);
                    dgv_场景模块.Rows.RemoveAt(dgv_场景模块.SelectedRows[0].Index);
                    ConfigClass.SaveCookie_List(场景设置.当前场景模块, "场景模块.dat");
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除项不存在");
                }
            }
        }

        private void btn_启用_Click(object sender, EventArgs e)
        {
            if (dgv_场景模块.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要启用项！");
                return;
            }
            int index = -1;
            if ((index = 当前场景模块.FindIndex(t => t.场景名称 == Convert.ToString(dgv_场景模块.Rows[dgv_场景模块.SelectedRows[0].Index].Cells[0].Value))) != -1)
            {
                当前场景模块[index].启用标志 = true;
                ConfigClass.SaveCookie_List(场景设置.当前场景模块, "场景模块.dat");
                MessageBox.Show("启用成功！");

                int i = dgv_场景模块.SelectedRows[0].Index;
                RefreshForm();
                dgv_场景模块.Rows[i].Selected = true;
            }
            else
            {
                MessageBox.Show("启用项不存在");
            }
        }

        private void btn_禁用_Click(object sender, EventArgs e)
        {
            if (dgv_场景模块.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要启用项！");
                return;
            }
            int index = -1;
            if ((index = 当前场景模块.FindIndex(t => t.场景名称 == Convert.ToString(dgv_场景模块.Rows[dgv_场景模块.SelectedRows[0].Index].Cells[0].Value))) != -1)
            {
                当前场景模块[index].启用标志 = false;
                ConfigClass.SaveCookie_List(场景设置.当前场景模块, "场景模块.dat");
                MessageBox.Show("禁用成功！");
                int i = dgv_场景模块.SelectedRows[0].Index;
                RefreshForm();
                dgv_场景模块.Rows[i].Selected = true;
            }
            else
            {
                MessageBox.Show("禁用项不存在");
            }
        }

        private void dgv_场景模块_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
            {
                dgv_调试模块.Rows.Clear();
                dgv_开关模块.Rows.Clear();
                return;
            }
            if (dgv_场景模块.SelectedRows.Count == 0)
                return;
            string name = Convert.ToString(dgv_场景模块.SelectedRows[0].Cells[0].Value);
            int index = -1;
            if ((index = 当前场景模块.FindIndex(t => t.场景名称 == name)) == -1)
            {
                dgv_调试模块.Rows.Clear();
                dgv_开关模块.Rows.Clear();
                return;
            }
            if(当前场景模块[index].场景调试模块列表 == null)
                当前场景模块[index].场景调试模块列表 = new List<场景调试模块>();
            RefreshForm_场景模块(当前场景模块[index].场景调试模块列表);
        }

        private void RefreshForm_场景模块(List<场景调试模块> tmp)
        {
            dgv_调试模块.Rows.Clear();
            var vv = tmp.OrderBy(t=>int.Parse(t.模块编号)).ToList();
            foreach (var v in vv)
            {
                var v1 = ModelsOperate.GetModel(int.Parse( v.模块编号));
                dgv_调试模块.Rows.Add(v.模块编号,v1.模块名称);
            }
        }

        private void btn_M删除_Click(object sender, EventArgs e)
        {
            if (dgv_场景模块.SelectedRows.Count == 0)
            {
                dgv_调试模块.Rows.Clear();
                dgv_开关模块.Rows.Clear();
                MessageBox.Show("请先选择场景模块！");
                return;
            }
            if (dgv_调试模块.SelectedRows.Count == 0)
            {
                dgv_开关模块.Rows.Clear();
                MessageBox.Show("请先选择产品模块模块！");
                return;
            }
            if (MessageBox.Show("请问是否删除选择行", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int index = -1;
                string name = Convert.ToString(dgv_场景模块.SelectedRows[0].Cells[0].Value);
                if ((index = 当前场景模块.FindIndex(t => t.场景名称 == name)) == -1)
                {
                    MessageBox.Show("该场景不存在！");
                    return;
                }
                if (当前场景模块[index].场景调试模块列表 == null)
                    当前场景模块[index].场景调试模块列表 = new List<场景调试模块>();
                foreach (DataGridViewRow row in dgv_调试模块.SelectedRows)
                {
                    当前场景模块[index].场景调试模块列表.RemoveAll(t => t.模块编号 == Convert.ToString(row.Cells[0].Value));
                }
                ConfigClass.SaveCookie_List(场景设置.当前场景模块, "场景模块.dat");
                RefreshForm_场景模块(当前场景模块[index].场景调试模块列表);
            }
        }

        private void dgv_调试模块_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                dgv_开关模块.Rows.Clear();
                return;
            }
            if (dgv_场景模块.SelectedRows.Count == 0)
            {
                dgv_调试模块.Rows.Clear();
                dgv_开关模块.Rows.Clear();
                MessageBox.Show("请先选择场景模块！");
                return;
            }
            if (dgv_调试模块.SelectedRows.Count == 0)
            {
                dgv_开关模块.Rows.Clear();
                MessageBox.Show("请先选择产品模块模块！");
                return;
            }
            string name = Convert.ToString(dgv_场景模块.SelectedRows[0].Cells[0].Value);
            int index = -1;
            if ((index = 当前场景模块.FindIndex(t => t.场景名称 == name)) == -1)
            {
                dgv_调试模块.Rows.Clear();
                dgv_开关模块.Rows.Clear();
                return;
            }
            if (当前场景模块[index] == null)
                当前场景模块[index].场景调试模块列表 = new List<场景调试模块>();
            场景调试模块 tmp = 当前场景模块[index].场景调试模块列表.Find(t => t.模块编号 == Convert.ToString(dgv_调试模块.Rows[e.RowIndex].Cells[0].Value));
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
            var tmp1 = ModelsOperate.GetModel(int.Parse( tmp.模块编号));
            //for (int i = 0; i < tmp1.开关列表.Count; i++)
            //{
            //    tmp.场景开关信息列表.Find(t=>t.开关通道 == tmp1.开关列表[i].模块编号).开关名称 = tmp1.开关列表[i].开关名称;
            //}
            Refresh_dgv_开关模块(tmp.场景开关信息列表, tmp1);
        }

        private void Refresh_dgv_开关模块(List<场景开关信息> tmp, 调试模块 tmp1)
        {
            dgv_开关模块.Rows.Clear();
            foreach (var v in tmp)
            {
               int index = dgv_开关模块.Rows.Add(v.开关通道, v.开关名称, v.开关状态, v.开关亮度);
                //if (int.Parse( tmp1.开关路数) < int.Parse(v.开关通道))
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
                if (dgv_场景模块.SelectedRows.Count == 0)
                {
                    dgv_调试模块.Rows.Clear();
                    dgv_开关模块.Rows.Clear();
                    MessageBox.Show("请先选择场景模块！");
                    return;
                }
                if (dgv_调试模块.SelectedRows.Count == 0)
                {
                    dgv_开关模块.Rows.Clear();
                    MessageBox.Show("请先选择产品模块模块！");
                    return;
                }
                string name = Convert.ToString(dgv_场景模块.SelectedRows[0].Cells[0].Value);
                int index = -1;
                if ((index = 当前场景模块.FindIndex(t => t.场景名称 == name)) == -1)
                {
                    dgv_调试模块.Rows.Clear();
                    dgv_开关模块.Rows.Clear();
                    return;
                }
                if (当前场景模块[index] == null)
                    当前场景模块[index].场景调试模块列表 = new List<场景调试模块>();
                场景调试模块 tmp = 当前场景模块[index].场景调试模块列表.Find(t => t.模块编号 == Convert.ToString(dgv_调试模块.SelectedRows[0].Cells[0].Value));
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

        private void dgv_场景模块_SelectionChanged(object sender, EventArgs e)
        {
            dgv_开关模块.Rows.Clear();
        }

        private void btn_保存_Click(object sender, EventArgs e)
        {
            ConfigClass.SaveCookie_List(场景设置.当前场景模块, "场景模块.dat");
            MessageBox.Show("保存成功！");
            this.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
