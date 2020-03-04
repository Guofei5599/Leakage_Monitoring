using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using SerialCardReaderLib;

namespace 照明模块软件
{
    public partial class 参数设置 : Form
    {
        public 参数设置()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 参数设置_Load(object sender, EventArgs e)
        {
            string [] name = SerialPort.GetPortNames();
            comb_SerialPort.Items.AddRange(name);
            radio_SerialCheck.Checked = MainForm.currentParam.串口通信选择;
            radio_TcpCheck.Checked = MainForm.currentParam.以太网通信选择;
            comb_SerialPort.Text = MainForm.currentParam.串口名称;
            num_Baud.Text = MainForm.currentParam.波特率.ToString();
            num_Port.Value = MainForm.currentParam.端口;
            comb_IP.Text = MainForm.currentParam.IP地址;

            //check_开机巡检.Checked = MainForm.currentParam.开机自动巡检;
            radio_巡检.Checked = MainForm.currentParam.开机自动巡检;
            radioB_广播.Checked = MainForm.currentParam.开机自动广播;
            Check_Auto.Checked = MainForm.currentParam.自动刷新;

            num_ReceiveSpeed.Value = MainForm.currentParam.接收速度;
            num_sendSpeed.Value = MainForm.currentParam.发送速度;
            num_SceneCheck.Value = MainForm.currentParam.场景巡检;
            num_经度.Value = (decimal)MainForm.currentParam.经度;
            num_维度.Value = (decimal)MainForm.currentParam.维度;

            txt_标题掩码.Text = MainForm.currentParam.标题;
            txt_公司掩码.Text = MainForm.currentParam.公司;
            txt_网址掩码.Text = MainForm.currentParam.网址;
            txt_电话掩码.Text = MainForm.currentParam.电话;
            txt_QQ掩码.Text = MainForm.currentParam.QQ;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.currentParam.串口通信选择 = radio_SerialCheck.Checked;
            MainForm.currentParam.以太网通信选择 = radio_TcpCheck.Checked;
            MainForm.currentParam.串口名称 = comb_SerialPort.Text;
            MainForm.currentParam.波特率 = Convert.ToInt32(num_Baud.Text);
            MainForm.currentParam.端口 = (int)num_Port.Value;
            MainForm.currentParam.IP地址 = comb_IP.Text;

            MainForm.currentParam.开机自动巡检 = radio_巡检.Checked;
            MainForm.currentParam.开机自动广播 = radioB_广播.Checked;
            MainForm.currentParam.自动刷新 = Check_Auto.Checked;

            MainForm.currentParam.接收速度 = (int)num_ReceiveSpeed.Value;
            MainForm.currentParam.发送速度 = (int)num_sendSpeed.Value;
            MainForm.currentParam.场景巡检 = (int)num_SceneCheck.Value;
            //MainForm.currentParam.状态巡检 = (int)num_StateCheck.Value;
            MainForm.currentParam.经度 = (double)num_经度.Value;
            MainForm.currentParam.维度 = (double)num_维度.Value;

            MainForm.currentParam.标题 = txt_标题掩码.Text;
            MainForm.currentParam.公司 = txt_公司掩码.Text;
            MainForm.currentParam.网址 = txt_网址掩码.Text;
            MainForm.currentParam.电话 = txt_电话掩码.Text;
            MainForm.currentParam.QQ =   txt_QQ掩码.Text;

            ConfigClass.SaveCookie_List(MainForm.currentParam, "config.dat");
            InitPort();
            //MessageBox.Show("保存成功！");
            this.Close();
        }
        private bool InitPort()
        {
            try
            {
                if (MainForm.currentParam.串口通信选择)
                {
                    if (MainForm.CommMaster != null && MainForm.CommMaster is TcpMaster)
                    {
                        (MainForm.CommMaster as TcpMaster).Dispose();
                        MainForm.CommMaster = null;
                    }
                    if (MainForm.CommMaster == null)
                    {
                        MainForm.CommMaster = new Master(new SerialReadBase(MainForm.currentParam.串口名称, MainForm.currentParam.波特率));
                        return true;
                    }
                }
                else
                {
                    if (MainForm.CommMaster != null && MainForm.CommMaster is Master)
                    {
                        (MainForm.CommMaster as Master).Dispose();
                        MainForm.CommMaster = null;
                    }
                    if (MainForm.CommMaster == null)
                    {
                        MainForm.CommMaster = new TcpMaster(new TcpReadBase(MainForm.currentParam.IP地址, MainForm.currentParam.端口, 500));
                        return true;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MainForm.通信状态 = 3;
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void btn_获取经纬度_Click(object sender, EventArgs e)
        {
            try
            {
                var v = GetLocaltion.GetPoint();
                num_维度.Value = decimal.Parse(v.y);
                num_经度.Value = decimal.Parse(v.x);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //num_纬度.Value = 0;
                //num_经度.Value = 0;
            }
        }

        public void displayGxb()
        {
            groupBox7.Visible = true;
        }

        //private void 参数设置_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Control && e.Alt && e.KeyCode == Keys.T)
        //    {
        //        groupBox7.Visible = true;
        //    }
        //}
    }
}
