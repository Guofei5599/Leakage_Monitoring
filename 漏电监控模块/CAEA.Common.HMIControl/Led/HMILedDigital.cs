//=================================================================
//
//文件名:HMILedDigital
//
//描述:动态数码管显示控件
//
//创建人:刘健
//
//创建日期:2016-09-09 14:49:23
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.Led
{
    public partial class HMILedDigital : HMICtrlBase
    {
        #region (* 变量 *)
        protected int _dpPos = 0;
        protected int _numDigits = 0;
        #endregion

        #region (* 构造函数 *)
        public HMILedDigital()
        {
            InitializeComponent();

            // 背景色
            this.BackColor = Color.Black;
            this.ForeColor = Color.Red;
            this.Format = "000";
        }
        #endregion

        public event LedDigitalValueChange ValueChange;

        #region (* 属性 *)
        /// <summary>
        ///背景色
        /// </summary>
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                if (base.BackColor == value) return;
                base.BackColor = value;

                foreach (Control disp in this.Controls)
                {
                    if (disp.GetType() == typeof(HMI7Segment))
                    {
                        HMI7Segment d = disp as HMI7Segment;

                        d.BackColor = value;
                    }
                }
            }
        }

        /// <summary>
        /// 显示颜色
        /// </summary>
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (base.ForeColor == value) return;
                base.ForeColor = value;

                foreach (Control disp in this.Controls)
                {
                    if (disp.GetType() == typeof(HMI7Segment))
                    {
                        HMI7Segment d = disp as HMI7Segment;

                        d.ForeColor = value;
                    }
                }
            }
        }

        /// <summary>
        /// 符号
        /// </summary>
        private bool _signed = false;
        [
            Category("Digital meter"),
            Description("是否显示符号，负数时用")
        ]
        public bool Signed
        {
            set
            {
                if (this._signed == value)
                    return;

                this._signed = value;

                this.UpdateControls();
            }

            get { return this._signed; }
        }

        /// <summary>
        /// 设置显示格式
        /// </summary>
        private string _format = string.Empty;
        [
            Category("Digital meter"),
            Description("显示格式：00.00，显示值不能超过这里设置的位数")
        ]
        public string Format
        {
            set
            {
                if (this._format == value)
                    return;

                this._format = value;

                this.UpdateControls();

                this.Value = this.Value;
            }

            get { return this._format; }
        }

        /// <summary>
        /// 设置显示值
        /// </summary>
        private double val = 0.0;
        [
            Category("Digital meter"),
            Description("显示值设置")
        ]
        public double Value
        {
            set
            {
                if (val == value) return;
                this.val = value;
                LedDigitalEventArgs e = new LedDigitalEventArgs();
                e.Value = value;
                OnValuehange(this,e);
                string str = this.val.ToString(this.Format);
                str = str.Replace(".", string.Empty);
                str = str.Replace(",", string.Empty);

                bool sign = false;
                if (str[0] == '-')
                {
                    sign = true;
                    str = str.TrimStart(new char[] { '-' });
                }

                if (str.Length > this._numDigits)
                {
                    foreach (HMI7Segment d in this.Controls)
                        d.Value = (int)'E';

                    return;
                }

                int idx = 0;
                for (idx = str.Length - 1; idx >= 0; idx--)
                {
                    int id = idx;
                    if (this.Signed != false)
                        id++;
                    HMI7Segment d = this.Controls[id] as HMI7Segment;
                    d.Value = Convert.ToInt32(str[idx].ToString());
                }

                HMI7Segment s = this.Controls["digit_sign"] as HMI7Segment;
                if (s != null)
                {
                    if (sign != false)
                        s.Value = (int)'-';
                    else
                        s.Value = -1;
                }
            }

            get { return this.val; }
        }
        #endregion

        #region (* 重写方法 *)
        /// <summary>
        /// 默认渲染器
        /// </summary>
        /// <returns></returns>
        protected override IRenderer CreateDefaultRenderer()
        {
            return new HMILedDigitalRenderer();
        }
        /// <summary>
        /// 改变大小
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.RepositionControls();
        }
        #endregion

        #region (* 保护方法 *)
        /// <summary>
        /// 刷新控件
        /// </summary>
        protected virtual void UpdateControls()
        {
            int count = this.Format.Length;

            this._dpPos = -1;

            char[] seps = new char[] { '.', ',' };
            int sepIndex = this.Format.IndexOfAny(seps);
            if (sepIndex > 0)
            {
                count--;
                this._dpPos = sepIndex - 1;
                this._numDigits = count;
            }

            this._numDigits = count;

            this.Controls.Clear();

            if (this.Signed != false)
            {
                HMI7Segment disp = new HMI7Segment();
                disp.Name = "digit_sign";
                disp.Value = -1;
                this.Controls.Add(disp);
            }

            for (int idx = 0; idx < count; idx++)
            {
                HMI7Segment disp = new HMI7Segment();

                disp.Name = "digit_" + idx.ToString();

                disp.Click += this.DisplayClicked;

                if (sepIndex - 1 == idx)
                    disp.ShowDP = true;

                this.Controls.Add(disp);
            }

            this.RepositionControls();
        }

        /// <summary>
        /// 重定位控件
        /// </summary>
        protected void RepositionControls()
        {
            Rectangle rc = this.ClientRectangle;

            if (this.Controls.Count <= 0)
                return;

            int digitW = rc.Width / this.Controls.Count;
            bool signFind = false;
            foreach (Control disp in this.Controls)
            {
                if (disp.GetType() == typeof(HMI7Segment))
                {
                    HMI7Segment d = disp as HMI7Segment;

                    int idDigit = 0;
                    if (d.Name.Contains("digit_sign") != false)
                    {
                        signFind = true;
                    }
                    else
                    {
                        if (d.Name.Contains("digit_") != false)
                        {
                            string s = d.Name.Remove(0, 6);
                            idDigit = Convert.ToInt32(s);

                            if (signFind != false)
                                idDigit++;
                        }
                    }

                    Point pos = new Point();
                    pos.X = idDigit * digitW;
                    pos.Y = 0;
                    d.Location = pos;

                    Size dim = new Size();
                    dim.Width = digitW;
                    dim.Height = rc.Height;
                    d.Size = dim;
                }
            }
        }

        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayClicked(object sender, System.EventArgs e)
        {
            this.InvokeOnClick(this, e);
        }
        protected virtual void OnValuehange(object sender, LedDigitalEventArgs e)
        {
            if (ValueChange != null)
                ValueChange(this, e);
        }
        #endregion
        #region
        public delegate void LedDigitalValueChange(object sender, LedDigitalEventArgs e);
        #endregion
    }
    public class LedDigitalEventArgs : EventArgs
    {
        double val = 0;
        public double Value
        {
            get { return val; }
            set { val = value; }
        }
    }
}
