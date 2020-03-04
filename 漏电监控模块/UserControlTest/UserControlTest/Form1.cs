using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindBorderStyle();

            DateTime now = DateTime.Now;

            txtDate.Text = string.Format("{0}年{1}月{2}日",
                now.Year.ToString(), now.Month.ToString(), now.Day.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderColor_Change(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb((int)numColor1.Value, (int)numColor2.Value, (int)numColor3.Value);
        }

        private void BindBorderStyle()
        {
            List<string> list = new List<string>();
            list.Add("无边框");
            list.Add("虚线边框");
            list.Add("虚线的边框");
            list.Add("实线边框");
            list.Add("凹陷边框");
            list.Add("凸起的边框");

            comboBox1.DataSource = list;
            comboBox1.SelectedIndex = 3;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private enum BorderStyle
        {
            //无边框。
            None = 0,

            //虚线边框。
            Dotted = 1,

            //虚线的边框。
            Dashed = 2,

            //实线边框。
            Solid = 3,

            //凹陷边框。
            Inset = 4,

            //凸起的边框。
            Outset = 5

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numBordWidth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonBorderStyle style = ButtonBorderStyle.Solid;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    style = ButtonBorderStyle.None;
                    break;
                case 1:
                    style = ButtonBorderStyle.Dotted;
                    break;
                case 2:
                    style = ButtonBorderStyle.Dashed;
                    break;
                case 3:
                    style = ButtonBorderStyle.Solid;
                    break;
                case 4:
                    style = ButtonBorderStyle.Inset;
                    break;
                case 5:
                    style = ButtonBorderStyle.Outset;
                    break;
                default:
                    break;
            }

            panelMonth1.BordWidth = (int)numWidth.Value;

            panelMonth1.BordStyle = style;

            panelMonth1.BordColor = Color.FromArgb((int)numColor1.Value, (int)numColor2.Value, (int)numColor3.Value);
        }

        /// <summary>
        /// 点击选中日期
        /// </summary>
        /// <param name="datetime"></param>
        private void panelMonth1_OnClick(DateTime datetime)
        {
            //dateTimePicker1.Value = datetime;

            //txtDate.Text = datetime;

            txtDate.Text = string.Format("{0}年{1}月{2}日",
                datetime.Year.ToString(), datetime.Month.ToString(), datetime.Day.ToString());
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
