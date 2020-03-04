using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.ProgressBar
{
    public partial class HMIProgressBar : HMICtrlBase
    {
        public HMIProgressBar()
        {
            InitializeComponent();
        }

        private bool finish = false;
        [
            Category("FLASH"),
            Description("")
        ]
        /// <summary>
        /// 进度完成
        /// </summary>
        public bool Finish
        {
            set
            {
                if (value)
                    progressBar1.Value = progressBar1.Maximum;
                finish = false;
            }
            get
            {
                return finish;
            }
        }
        [
            Category("FLASH"),
            Description("")
        ]
        /// <summary>
        /// 刷新间隔
        /// </summary>
        public int InterVal
        {
            set
            {
                timer1.Interval = value;
            }
            get { return timer1.Interval; }
        }
        [
            Category("FLASH"),
            Description("")
        ]
        /// <summary>
        /// 当前进度条的值
        /// </summary>
        public int CurrentValue
        {
            set { progressBar1.Value = value; }
            get { return progressBar1.Value; }
        }
        [
            Category("FLASH"),
            Description("")
        ]
        /// <summary>
        /// 最大值
        /// </summary>
        public int MaxValue
        {
            set
            {
                progressBar1.Maximum = value;
            }
            get { return progressBar1.Maximum; }
        }
        [
            Category("FLASH"),
            Description("")
        ]
        /// <summary>
        /// 单步的值
        /// </summary>
        public int Step
        {
            set
            {
                progressBar1.Step = value;
            }
            get { return progressBar1.Step; }
        }
        [
            Category("FLASH"),
            Description("")
        ]
        /// <summary>
        /// 使能
        /// </summary>
        public bool BarEnable
        {
            set
            {
                if(value == true)
                    CurrentValue = 0;
                timer1.Enabled = value;
            }
            get { return timer1.Enabled; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < MaxValue - Step)
                progressBar1.PerformStep();
            else
            {
                BarEnable = false;
            }
        }

        private void HMIProgressBar_Resize(object sender, EventArgs e)
        {
            progressBar1.Size = this.Size;
        }
    }
}
