using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照明模块软件
{
    public partial class PanelDay : UserControl
    {
        public PanelDay()
        {
            InitializeComponent();
        }

        public delegate void ClickCallBack(string day);
        public event ClickCallBack OnClick;
        public event ClickCallBack OnSetIdolClick;
        public string Day { get; set; }

        public bool IsSelect { set; get; }  //背景图片
        public bool IsSet { set; get; }  //假期

        private void PanelDay_Load(object sender, EventArgs e)
        {
            lbDay.Location = new Point((roundPanel1.Width - lbDay.Width) / 2 + 1, 10);
        }
        
        /// <summary></summary>
        public void SetValue()
        {
            this.SuspendLayout();
            if (IsSelect)  //如果改天被选中
            {
                roundPanel1.ButtonCenterColorStart = Color.FromArgb(82, 196, 188);
                roundPanel1.ButtonCenterColorEnd = Color.FromArgb(82, 196, 188);
                lbDay.ForeColor = Color.White;
            }
            else
            {
                roundPanel1.ButtonCenterColorStart = Color.White;
                roundPanel1.ButtonCenterColorEnd = Color.White;
                lbDay.ForeColor = Color.Black;
            }
            lbDay.Text = Day;
            this.ResumeLayout(false);
        }

        public void SetIdol()
        {
            this.SuspendLayout();
            if (IsSet)  //如果改天被选中
            {
                roundPanel1.ButtonCenterColorStart = Color.Red;
                roundPanel1.ButtonCenterColorEnd = Color.Red;
                lbDay.ForeColor = Color.White;
            }
            else
            {
                roundPanel1.ButtonCenterColorStart = Color.White;
                roundPanel1.ButtonCenterColorEnd = Color.White;
                lbDay.ForeColor = Color.Black;
            }
            lbDay.Text = Day;
            this.ResumeLayout(false);
        }

        /// <summary>
        /// 点击选中天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Day_Click(object sender, EventArgs e)
        {
            //roundPanel1.ButtonCenterColorStart = Color.FromArgb(82, 196, 188);
            //roundPanel1.ButtonCenterColorEnd = Color.FromArgb(82, 196, 188);
            //lbDay.ForeColor = Color.White;
            string day = lbDay.Text.Trim().ToString();
            if (!string.IsNullOrEmpty(day))
            {
                IsSelect = true;  //已选中
                OnClick?.Invoke(day);
            }
        }

        private void lbDay_MouseDown(object sender, MouseEventArgs e)
        {
            string day = lbDay.Text.Trim().ToString();
            if (!string.IsNullOrEmpty(day))
            {
                IsSelect = true;  //已选中
                OnClick?.Invoke(day);
                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(lbDay,new Point(e.X,e.Y));
                }
            }
        }
        private void 设置为假期_Click(object sender, EventArgs e)
        {
            string day = lbDay.Text.Trim().ToString();
            OnSetIdolClick(day);
        }

        private void roundPanel1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
