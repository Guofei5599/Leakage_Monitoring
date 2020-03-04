using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static 照明模块软件.MainForm;

namespace 照明模块软件
{
    public partial class 国家公休日界面 : Form
    {
        public 国家公休日界面()
        {
            InitializeComponent();
        }

        private void 国家公休日界面_Load(object sender, EventArgs e)
        {
            txt_Year.Text = DateTime.Now.Date.Year.ToString();
            refreshForm(MainForm.国家公休日列表,dataGridView1);
        }

        private void refreshForm(List<公休日> list,DataGridView dgv)
        {
            dgv.Rows.Clear();
            int i = 0;
            foreach (var v in list)
            {
                dgv.Rows.Add((i++).ToString(), v.日期, v.说明);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //int value;
            //bool b = int.TryParse(txt_Year.Text, out value);
            //if (b)
            //{
            //    if (MessageBox.Show(string.Format("是否删除：{0}年节假日", txt_Year.Text), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //    {
            //        MainForm.国家公休日列表.RemoveAll(t => t.Substring(0, 4) == txt_Year.Text);
            //        refreshForm();
            //        MessageBox.Show("删除成功！");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("年份输入错误，必须为数值！");
            //}

          
        }

        private void btn_Update_Click_1(object sender, EventArgs e)
        {
            try
            {
                int value;
                bool b = int.TryParse(txt_Year.Text, out value);
                if (b)
                {
                    var v = 获取节假日.GetData(value);
                    //foreach (var v1 in v)
                    //    if (!MainForm.国家公休日列表.Contains(v1))
                    //        MainForm.国家公休日列表.Add(v1);
                    refreshForm(v,dataGridView2);
                    //MessageBox.Show("更新成功！");
                }
                else
                {
                    MessageBox.Show("年份输入错误，必须为数值！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Save_Click_1(object sender, EventArgs e)
        {
            try
            {
                ConfigClass.SaveCookie_List(MainForm.国家公休日列表, "国家公休日.dat");
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (MainForm.国家公休日列表.FindIndex(t=>t.日期 == Convert.ToString(row.Cells["公休日1"].Value)) == -1)
                    MainForm.国家公休日列表.Add(new MainForm.公休日() { 日期 = Convert.ToString(row.Cells["公休日1"].Value), 说明 = Convert.ToString(row.Cells["说明1"].Value) });
            }
            dataGridView2.Rows.Clear();
            refreshForm(MainForm.国家公休日列表,dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("必须选择一行！");
                return;
            }
            if (MainForm.国家公休日列表.FindIndex(t => t.日期 == Convert.ToString(dataGridView2.SelectedRows[0].Cells["公休日1"].Value)) == -1)
            {
                MainForm.国家公休日列表.Add(new MainForm.公休日() { 日期 = Convert.ToString(dataGridView2.SelectedRows[0].Cells["公休日1"].Value), 说明 = Convert.ToString(dataGridView2.SelectedRows[0].Cells["说明1"].Value) });
                string d = Convert.ToString(dataGridView2.SelectedRows[0].Cells["公休日1"].Value);
                refreshForm(MainForm.国家公休日列表, dataGridView1);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells["公休日"].Value) == d)
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                        row.Selected = true;
                    }
                       
                }
            }  
            dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
            foreach (DataGridViewRow row in dataGridView2.Rows)
                row.Selected = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            txt_No.Text =Convert.ToString( dataGridView1.SelectedRows[0].Cells[0].Value);
            txt_Date.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
            txt_Note.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txt_No.Text = "";
            txt_Date.Text = dateTimePicker1.Value.Date.ToString("yyyyMMdd");
            if (MainForm.国家公休日列表.Find(t => t.日期 == txt_Date.Text) != null)
            {
                txt_Note.Text = MainForm.国家公休日列表.Find(t => t.日期 == txt_Date.Text).说明;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请问是否清空公休日列表", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                MainForm.国家公休日列表.Clear();
                refreshForm(MainForm.国家公休日列表, dataGridView1);
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Date.Text = "";
            txt_No.Text = "";
            txt_Note.Text = "";
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_Date.Text.Length == 0)
            {
                MessageBox.Show("公休日不能为空");
                return;
            }
            if (MainForm.国家公休日列表.FindIndex(t => t.日期 == txt_Date.Text) == -1)
            {
                MainForm.国家公休日列表.Add(new MainForm.公休日() { 日期 = txt_Date.Text, 说明 = txt_Note.Text });
                string d = txt_Date.Text;
                refreshForm(MainForm.国家公休日列表, dataGridView1);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells["公休日"].Value) == d)
                    {
                        row.Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                       
                }
            }
            else
            {
                MessageBox.Show("日期已存在！");
            }
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (txt_Date.Text.Length == 0)
            {
                MessageBox.Show("公休日不能为空");
                return;
            }
            int index = -1;
            if ((index = MainForm.国家公休日列表.FindIndex(t => t.日期 == txt_Date.Text)) != -1)
            {
                MainForm.国家公休日列表[index].说明 = txt_Note.Text;
                string d = txt_Date.Text;
                refreshForm(MainForm.国家公休日列表, dataGridView1);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells["公休日"].Value) == d)
                    {
                        row.Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                }
            }
            else
            {
                MessageBox.Show("日期不存在！");
            }
        }

        private void btn_Delete_Click_1(object sender, EventArgs e)
        {
            if (txt_Date.Text.Length == 0)
            {
                MessageBox.Show("公休日不能为空");
                return;
            }
            if (MessageBox.Show("请问是否删除该项", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int index = -1;
                if ((index = MainForm.国家公休日列表.FindIndex(t => t.日期 == txt_Date.Text)) != -1)
                {
                    MainForm.国家公休日列表.RemoveAt(index);
                    refreshForm(MainForm.国家公休日列表, dataGridView1);
                }
                else
                {
                    MessageBox.Show("日期不存在！");
                }
            }
        }
    }
}
