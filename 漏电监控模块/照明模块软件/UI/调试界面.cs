using SerialCardReaderLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照明模块软件
{
    public partial class 调试界面 : Form
    {
        public static bool flag = false;
        List<批量发送信息> dataList = null;
        public 调试界面()
        {
            InitializeComponent();
        }
        private void 调试界面_Load(object sender, EventArgs e)
        {
            var tmpList1 = ConfigClass.LoadCookie<批量发送信息>("批量发送信息.dat");
            if (tmpList1 == null)
            {
                tmpList1 = new List<批量发送信息>();
            }
            dataList = tmpList1;
            refreshDgv();
            this.Location = new Point(0,0);
            flag = true;
            if (MainForm.CommMaster != null)
                Communication.StartDebug(textBox1);
            else
                this.Close();
        }

        private void 调试界面_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.CommMaster != null)
                Communication.StopDebug();
            flag = false;
            StartFlag = false;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private List<byte> analyse()
        {
            string data = txt_data.Text.Replace(" ","");
            if (data.Length % 2 != 0)
                data += "0" + data;
            bool b = true;
            List<byte> tmpList = new List<byte>();
            for (int i = 0; i < data.Length; i += 2)
            {
                try
                {
                    byte dat = byte.Parse(data.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
                    tmpList.Add(dat);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("输入数据异常！");
                    b = false;
                    return null;
                }
            }
            if (tmpList.Count != 12)
            {
                MessageBox.Show("数据长度异常！");
                return null;
            }
            data = "";
            foreach (var v in tmpList)
            {
                data += v.ToString("x").PadLeft('0') + " ";
            }
            txt_data.Text = data.Trim() ;
            return tmpList;
        }

        private void refreshDgv()
        {
            dataGridView1.Rows.Clear();
            foreach (var v in dataList)
                dataGridView1.Rows.Add(new object[] { v.en, v.sn, v.timeout, BitConverter.ToString(v.data).Replace("-"," ") });

        }
        private void refreshDgv(bool b)
        {
            int index = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                 index = dataGridView1.SelectedRows[0].Index;
            dataGridView1.Rows.Clear();
            foreach (var v in dataList)
                dataGridView1.Rows.Add(new object[] { v.en, v.sn, v.timeout, BitConverter.ToString(v.data).Replace("-", " ") });
            if(index != -1)
                dataGridView1.Rows[index].Selected = true;
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            List<byte> tmp = null;
            if ((tmp = analyse()) != null)
            {
                批量发送信息 tmpdata = new 批量发送信息()
                {
                    data = tmp.ToArray(),
                    en = check_使能.Checked,
                    timeout = (int)numericUpDown1.Value,
                    sn = (dataList.Count + 1)
                };
                dataList.Add(tmpdata);
                refreshDgv(true);
            }
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            int index = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value)-1;
            批量发送信息 tmp1 = dataList[index];
            List<byte> tmp = null;
            if ((tmp = analyse()) != null)
            {
                tmp1.en = check_使能.Checked;
                tmp1.data = tmp.ToArray();
                tmp1.timeout = (int)numericUpDown1.Value;
                refreshDgv(true);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            int index = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value) - 1;
            dataList.RemoveAt(index);
            refreshDgv();
        }

        private void btn_Clr_Click(object sender, EventArgs e)
        {
            dataList.Clear();
            refreshDgv();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            txt_data.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[3].Value);
            check_使能.Checked = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[0].Value);
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[2].Value);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            ConfigClass.SaveCookie_List(dataList,"批量发送信息.dat");
        }

        private void btn_Ext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static bool StartFlag = false;
        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (MainForm.WriteDic.Count > 0 && Communication.GetCommState() == CommState.Idel)
            {
                MessageBox.Show("通信繁忙，请稍后再试");
                return;
            }
            //PackCRC(data, 5, 7);
            StartFlag = true;
            dt1 = DateTime.Now;
            i = 0;
            stopflag = false;
        }
        bool stopflag = false;
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            //StartFlag = false;
            if (!stopflag)
            {
                dt2 = DateTime.Now;
                stopflag = true;
            }
        }
        public static byte[] PackCRC(byte[] data, int index, int length)
        {
            byte tmpdata = GetCrcModbus(data, index, length);
            List<byte> bList = new List<byte>();
            bList.AddRange(data);
            bList.Add(tmpdata);
            return bList.ToArray();
        }
        public static byte GetCrcModbus(byte[] Buffer, int index, int len)
        {
            ushort temp = 0;
            for (int i = index; i < len + index; i++)
            {
                temp += Buffer[i];
            }
            return (byte)(temp & 0xff);
        }

        DateTime dt1 = DateTime.Now;
        DateTime dt2 = DateTime.Now;
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (StartFlag)
            {
                btn_Add.Enabled = false;
                btn_Clr.Enabled = false;
                btn_Ext.Enabled = false;
                btn_Modify.Enabled = false;
                btn_Save.Enabled = false;
                btn_Start.Enabled = false;
                btn_Delete.Enabled = false;
                btn_Stop.Enabled = true;
            }
            else
            {
                btn_Add.Enabled = true;
                btn_Clr.Enabled = true;
                btn_Ext.Enabled = true;
                btn_Modify.Enabled = true;
                btn_Save.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Start.Enabled = true;
                btn_Stop.Enabled = false;
            }
            if (stopflag && (DateTime.Now - dt2).TotalMilliseconds >= 2000)
            {
                StartFlag = false;
                stopflag = false;
            }
            if (StartFlag)
            {
                if (dataList != null)
                {
                    if (i < dataList.Count)
                    {
                        if (dataList[i].en)
                        {
                            if ((DateTime.Now - dt1).TotalMilliseconds >= dataList[i].timeout)
                            {
                                byte[] d = PackCRC(dataList[i].data, 5, 7);
                                Communication.CommWriteData(d);
                                dt1 = DateTime.Now;
                                i++;
                            }
                        }
                        else
                            i++;
                    }
                    else
                    {
                        if ((DateTime.Now - dt1).TotalMilliseconds > 2000)
                        {
                            StartFlag = false;
                        }
                    }
                }
                else
                {
                    StartFlag = false;
                }
            }
        }
    }
}
