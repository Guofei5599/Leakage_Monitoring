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
    public partial class 场景添加 : Form
    {
        public 场景模块 tmp;
        public bool isNew = false;

        public 场景添加()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (date_开始日期.Value.Date > date_结束日期.Value.Date)
            {
                MessageBox.Show("开始日期不能大于结束日期");
                return;
            }
            if (isNew)
            {
                if (场景设置.当前场景模块.FindIndex(t => t.场景名称 == txt_场景名称.Text) != -1)
                {
                    MessageBox.Show("模块名称已存在！");
                    return;
                }
                if (场景设置.当前场景模块.FindIndex(t => t.场景名称 == txt_场景名称.Text) == -1)
                {
                    byte b = check_1.Checked ? (byte)(1 << 0) : (byte)0;
                    b |= (check_2.Checked ? (byte)(1 << 1) : (byte)0);
                    b |= (check_3.Checked ? (byte)(1 << 2) : (byte)0);
                    b |= (check_4.Checked ? (byte)(1 << 3) : (byte)0);
                    b |= (check_5.Checked ? (byte)(1 << 4) : (byte)0);
                    b |= (check_6.Checked ? (byte)(1 << 5) : (byte)0);
                    b |= (check_7.Checked ? (byte)(1 << 6) : (byte)0);

                    场景模块 tmp1 = new 场景模块()
                    {
                        启用标志 = true,
                        场景名称 = txt_场景名称.Text,
                        模式 = radio国家公休日.Checked ? SceneModel.国家公休日 : SceneModel.工作日模式,
                        开始时间 = date_开始日期.Value,
                        结束时间 = date_结束日期.Value,
                        星期数据 = b,
                        场景子名称列表 = new List<场景子模块>(),
                        场景调试模块列表 = new List<场景调试模块>()
                    };
                    tmp = tmp1;
                    this.DialogResult = DialogResult.OK;
                    场景设置.当前场景模块.Add(tmp);
                    ConfigClass.SaveCookie_List(场景设置.当前场景模块, "场景模块.dat");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("该名称已存在！");
                }
            }
            else
            {
                int index = -1;
                if ((index = 场景设置.当前场景模块.FindIndex(t => t.场景名称 == tmp.场景名称)) == -1)
                {
                    MessageBox.Show("模块名称不存在！");
                    return;
                }
                if (场景设置.当前场景模块.FindIndex(t => t.场景名称 == txt_场景名称.Text) != -1 && txt_场景名称.Text != tmp.场景名称)
                {
                    MessageBox.Show("该名称已存在！");
                    return;
                }
                byte b = check_1.Checked ? (byte)(1 << 0) : (byte)0;
                b |= (check_2.Checked ? (byte)(1 << 1) : (byte)0);
                b |= (check_3.Checked ? (byte)(1 << 2) : (byte)0);
                b |= (check_4.Checked ? (byte)(1 << 3) : (byte)0);
                b |= (check_5.Checked ? (byte)(1 << 4) : (byte)0);
                b |= (check_6.Checked ? (byte)(1 << 5) : (byte)0);
                b |= (check_7.Checked ? (byte)(1 << 6) : (byte)0);
                tmp.场景名称 = txt_场景名称.Text;
                tmp.模式 = radio国家公休日.Checked ? SceneModel.国家公休日 : SceneModel.工作日模式;
                tmp.开始时间 = date_开始日期.Value;
                tmp.结束时间 = date_结束日期.Value;
                tmp.星期数据 = b;
                ConfigClass.SaveCookie_List(场景设置.当前场景模块, "场景模块.dat");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            国家公休日界面 frm = new 国家公休日界面();
            frm.ShowDialog();
        }

        private void 场景添加_Load(object sender, EventArgs e)
        {
            radio普通定时.Checked = true;
            if (!isNew)
            {
                //txt_场景名称.Enabled = false;
                txt_场景名称.Text = tmp.场景名称;
                if (tmp.模式 == SceneModel.国家公休日)
                    radio国家公休日.Checked = true;
                else
                    radio普通定时.Checked = true;
                check_1.Checked = (((tmp.星期数据 >> 0) & 0x01) == 1) ? true : false;
                check_2.Checked = (((tmp.星期数据 >> 1) & 0x01) == 1) ? true : false;
                check_3.Checked = (((tmp.星期数据 >> 2) & 0x01) == 1) ? true : false;
                check_4.Checked = (((tmp.星期数据 >> 3) & 0x01) == 1) ? true : false;
                check_5.Checked = (((tmp.星期数据 >> 4) & 0x01) == 1) ? true : false;
                check_6.Checked = (((tmp.星期数据 >> 5) & 0x01) == 1) ? true : false;
                check_7.Checked = (((tmp.星期数据 >> 6) & 0x01) == 1) ? true : false;
                date_开始日期.Value = tmp.开始时间;
                date_结束日期.Value = tmp.结束时间;

            }
            else
            {
                check_1.Checked = true;
                check_2.Checked = true;
                check_3.Checked = true;
                check_4.Checked = true;
                check_5.Checked = true;
                check_6.Checked = true;
                check_7.Checked = true;
            } 
        }
    }
}
