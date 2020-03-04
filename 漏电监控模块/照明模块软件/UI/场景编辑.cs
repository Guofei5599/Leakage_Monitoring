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
    public partial class 场景编辑 : Form
    {
        public bool isNew = false;
        public 场景模块 tmp;
        public 场景编辑()
        {
            InitializeComponent();
        }

        private void 场景编辑_Load(object sender, EventArgs e)
        {
            dataGridView1.TopLeftHeaderCell.Value = "动作";
            dataGridView1.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            radio_open.Checked = true;
            radio_普通定时.Checked = true;
            this.Text = tmp.场景名称;
            RefreshForm();
        }
        private void btn_获取日出时间_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    double value1, value2;
            //    bool b1 = double.TryParse(txt_经度.Text, out value1);
            //    bool b2 = double.TryParse(txt_纬度.Text, out value2);
            //    if (!(b1 && b2))
            //    {
            //        MessageBox.Show("经纬度异常！");
            //        return;
            //    }
            //    DateTime dt = 计算日出日落.计算日出时间(value1, value2, DateTime.Now);
            //    time_开启时间.Value = dt;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btn_获取日落时间_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    double value1, value2;
            //    bool b1 = double.TryParse(txt_经度.Text, out value1);
            //    bool b2 = double.TryParse(txt_纬度.Text, out value2);
            //    if (!(b1 && b2))
            //    {
            //        MessageBox.Show("经纬度异常！");
            //        return;
            //    }
            //    DateTime dt = 计算日出日落.计算日落时间(value1, value2, DateTime.Now);
            //    time_结束时间.Value = dt;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void btn_添加_Click(object sender, EventArgs e)
        {
            if (txt_名称.Text.Trim().Length == 0)
            {
                MessageBox.Show("名称不能为空！");
                return;
            }
            if (tmp.场景子名称列表.FindIndex(t1 => t1.场景子名称 == txt_名称.Text) != -1)
            {
                MessageBox.Show("名称已存在！");
                return;
            }
            SetTimeType t;
            if (radio_普通定时.Checked)
                t = SetTimeType.普通定时;
            else if (radio_日出时间.Checked)
                t = SetTimeType.日出时间;
            else
                t = SetTimeType.日落时间;
            var v = new 场景子模块
            {
                场景子名称 = txt_名称.Text,
                动作 = radio_open.Checked ? true : false,
                动作时间 = time_开启时间.Value,
                定时方式 = t,
                场景调试模块列表2 = new List<场景调试模块>()
            };
            tmp.场景子名称列表.Add(v);
            string s = "";
            if (radio_普通定时.Checked)
                s = v.动作时间.ToString("HH:mm:ss");
            else if (radio_日出时间.Checked)
                s = MainForm.日出时间;
            else if (radio_日落时间.Checked)
                s = MainForm.日落时间;
            int i = dataGridView1.Rows.Add(v.场景子名称,v.动作?"开":"关",v.定时方式,s);
            dataGridView1.Rows[i].HeaderCell.Value = "动作" + dataGridView1.Rows.Count.ToString();
            dataGridView1.Rows[i].Selected = true;
        }

        private void RefreshForm()
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (var v in tmp.场景子名称列表)
                {
                    string s = "";
                    if (radio_普通定时.Checked)
                        s = v.动作时间.ToString("HH:mm:ss");
                    else if(radio_日出时间.Checked)
                        s = MainForm.日出时间;
                    else if (radio_日落时间.Checked)
                        s = MainForm.日落时间;
                    int index = dataGridView1.Rows.Add(v.场景子名称, v.动作 ? "开" : "关", v.定时方式.ToString(), s);
                    dataGridView1.Rows[index].HeaderCell.Value = "动作" + (index + 1).ToString();
                }
                   
            }
            catch(Exception ex)
            { 
                
            }
        }
        private void btn_修改_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                    return;
                if ((tmp.场景子名称列表.FindIndex(t1 => t1.场景子名称 == txt_名称.Text) != -1) && Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value) != txt_名称.Text)
                {
                    MessageBox.Show("名称已存在！");
                    return;
                }
                int index = -1;
                if ((index = tmp.场景子名称列表.FindIndex(t => t.场景子名称 == Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value))) != -1)
                {
                    SetTimeType t;
                    if (radio_普通定时.Checked)
                        t = SetTimeType.普通定时;
                    else if (radio_日出时间.Checked)
                        t = SetTimeType.日出时间;
                    else
                        t = SetTimeType.日落时间;
                    tmp.场景子名称列表[index].场景子名称 = txt_名称.Text;
                    tmp.场景子名称列表[index].动作 = radio_open.Checked;
                    tmp.场景子名称列表[index].动作时间 = time_开启时间.Value;
                    tmp.场景子名称列表[index].定时方式 = t;
                    MessageBox.Show("修改成功！");
                    int i = dataGridView1.SelectedRows[0].Index;
                    RefreshForm();
                    dataGridView1.Rows[i].Selected = true;

                }
                else
                {
                    MessageBox.Show("名称不存在！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败：" + ex.Message);
            }
            
        }

        private void btn_删除_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择删除项！");
                return;
            }
            int index = dataGridView1.SelectedRows[0].Index;
            if (MessageBox.Show("请问是否删除：" + Convert.ToString(dataGridView1.Rows[index].Cells[0].Value),"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            tmp.场景子名称列表.RemoveAll(t=>t.场景子名称 == Convert.ToString(dataGridView1.Rows[index].Cells[0].Value));
            dataGridView1.Rows.RemoveAt(index);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //if (isNew)
                //    场景设置.当前场景模块.Add(tmp);
                ConfigClass.SaveCookie_List(场景设置.当前场景模块, "场景模块.dat");
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1 || e.ColumnIndex == -1)
            //    return;
            //int index = -1;
            //if ((index = tmp.场景子名称列表.FindIndex(t => t.场景子名称 == Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value))) != -1)
            //{
            //    txt_名称.Text = tmp.场景子名称列表[index].场景子名称;
            //    if (tmp.场景子名称列表[index].动作)
            //        radio_open.Checked = true;
            //    else
            //        radio_Close.Checked = true;
            //    if (tmp.场景子名称列表[index].定时方式 == SetTimeType.日出时间)
            //        radio_日出时间.Checked = true;
            //    else if (tmp.场景子名称列表[index].定时方式 == SetTimeType.日落时间)
            //        radio_日落时间.Checked = true;
            //    else
            //        radio_普通定时.Checked = true;
            //    time_开启时间.Value = tmp.场景子名称列表[index].动作时间;
            //}
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
            {
                return;
            }
            场景调试模块编辑 frm = new 场景调试模块编辑();
            int index = -1;
            if ((index = tmp.场景子名称列表.FindIndex(t => t.场景子名称 == Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value))) != -1)
            {
                frm.tmp场景子模块 = tmp.场景子名称列表[index];
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("该子场景不存在！");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //if (e.RowIndex == -1 || e.ColumnIndex == -1)
            //    return;
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            int index = -1;
            if ((index = tmp.场景子名称列表.FindIndex(t => t.场景子名称 == Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value))) != -1)
            {
                txt_名称.Text = tmp.场景子名称列表[index].场景子名称;
                if (tmp.场景子名称列表[index].动作)
                    radio_open.Checked = true;
                else
                    radio_Close.Checked = true;
                if (tmp.场景子名称列表[index].定时方式 == SetTimeType.日出时间)
                    radio_日出时间.Checked = true;
                else if (tmp.场景子名称列表[index].定时方式 == SetTimeType.日落时间)
                    radio_日落时间.Checked = true;
                else
                    radio_普通定时.Checked = true;
                time_开启时间.Value = tmp.场景子名称列表[index].动作时间;
            }
        }
    }
}
