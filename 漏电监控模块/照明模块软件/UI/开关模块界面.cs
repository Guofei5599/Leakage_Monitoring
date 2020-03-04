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
    public partial class 开关模块界面 : Form
    {
        public 调试模块 tmp = null;
        public 开关模块界面()
        {
            InitializeComponent();
        }
        bool flag = false;
        private void 开关模块_Load(object sender, EventArgs e)
        {
           flag = true;
        }
        public void RefreshForm(bool flag)
        {
            lab_提示.Visible = flag;
        }
        public void RefreshData()
        {
            lab_模块地址.Text = tmp.模块编号.ToString();
            lab_模块名称.Text = tmp.模块名称.ToString();
            lab_安装位置.Text = tmp.安装位置.ToString();

            listView1.BeginUpdate();
            ListViewGroup 温度Group = new ListViewGroup();
            温度Group.Header = "温度";
            ListViewGroup 漏电Group = new ListViewGroup();
            漏电Group.Header = "漏电";
            listView1.Groups.Add(温度Group);
            listView1.Groups.Add(漏电Group);
            listView1.ShowGroups = true;
            tmp.ModelsDataList = tmp.ModelsDataList.OrderBy(t=>t.DataChannel).ToList();
            foreach (var v in tmp.ModelsDataList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = v.DataChannel.ToString() + "路：";
                lvi.SubItems.Add(v.DataValue.ToString(),v.IsWarning?Color.Red:Color.White,Color.Black,listView1.Font);
                lvi.SubItems.Add(v.WarnDateTime.ToString());
                if (v.DataType == "温度")
                    温度Group.Items.Add(lvi);
                else if(v.DataType == "漏电")
                    温度Group.Items.Add(lvi);
                this.listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
            // tmp.
        }
        public void RefreshPanel()
        {
            RefreshData();
            if (tmp.State == 2)
            {
                通信状态1.ForeColor = Color.Green;
                通信状态1.Text = "通信正常";
            }
            else if (tmp.State == 3)
            {
                通信状态1.ForeColor = Color.Red;
                通信状态1.Text = "通信异常";
            }
            else
            {
                通信状态1.ForeColor = Color.Gray;
                通信状态1.Text = "未通信";
            }
        }

        private void ButtonClickChangeEvent(object sender, 开关模块 e)
        {
            //ModlesMsg modlesMsg = new ModlesMsg()
            //{
            //    addr = int.Parse(e.模块编号),
            //    bit = ushort.Parse(e.开关编号),
            //     模块类型 = e.模块类型,
            //    value = e.亮度,
            //    action = e.flag ? ActionState.Open : ActionState.Close
            //};
            //MainForm.WriteDic.AddOrUpdate(e.模块编号 + "," + e.开关编号, modlesMsg, (key, value) => value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_刷新_Click(object sender, EventArgs e)
        {
            DOInquire(tmp);
        }
        public void DOInquire(调试模块 tmp)
        {
            if (Communication.GetDoCommState() != 1)
            {
                ModlesMsg modlesMsg = new ModlesMsg()
                {
                    addr = int.Parse(tmp.模块编号),
                    模块类型 = "模块查询"
                };
                MainForm.WriteDic.AddOrUpdate(tmp.模块编号 + "," + "查询", modlesMsg, (key, value) => value);
            }
        }

        private void 开关模块界面_SizeChanged(object sender, EventArgs e)
        {
            //if(flag)
            //    PanelLayout();
        }
    }
}
