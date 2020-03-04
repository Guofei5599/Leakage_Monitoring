using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAEA.Common.HMIControl.UserProgressBar
{
    public partial class UserProgressBar : UserControl
    {
        public UserProgressBar()
        {
            InitializeComponent();
        }

        private float m_Value = 0;
        private float m_Maximum = 100;
        private SolidBrush m_ProgressBarFillBrush = new SolidBrush(Color.Green);
        private SolidBrush m_ProgressBarbackColor = new SolidBrush(Color.Green);
        private float text_Value = 100.0f;
        private bool text_target = false;
        /// <summary>
        /// 重绘进度条控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserProgressBar_Paint(object sender, PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            Pen pn = new Pen(ForeColor);
            SolidBrush br = new SolidBrush(m_ProgressBarbackColor.Color);
            SolidBrush br1 = new SolidBrush(m_ProgressBarFillBrush.Color);
            Brush brush = new SolidBrush(ForeColor);//填充的颜色
            initCoordinates(dc, br);
            DrawProgressBar(dc, m_Value, br1);
        }
        /// <summary>
        /// 绘制进度条前景色
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="m_Value"></param>
        /// <param name="br1"></param>
        private void DrawProgressBar(Graphics dc, float m_Val, SolidBrush br1)
        {
            dc.FillRectangle(br1, 0, 0, (this.Width) / m_Maximum * m_Val, this.Height);
        }

        /// <summary>
        /// 绘制进度条背景色
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="br"></param>
        private void initCoordinates(Graphics dc, SolidBrush br)
        {
            dc.FillRectangle(br, 0, 0, this.Width, this.Height);
        }

        [Category("进度条颜色"), Description("进度条前景色"), DefaultValue(typeof(Color))]
        public Color ProgressBarFillColor
        {
            get
            {
                return m_ProgressBarFillBrush.Color;
            }
            set
            {
                if(m_ProgressBarFillBrush.Color != value)
                {
                    m_ProgressBarFillBrush.Color = value;
                    this.Invalidate();
                }
            }
        }

        [Category("进度条颜色"), Description("进度条背景色"), DefaultValue(typeof(Color))]
        public Color ProgressBarBackColor
        {
            get
            {
                return m_ProgressBarbackColor.Color;
            }
            set
            {
                if (m_ProgressBarbackColor.Color != value)
                {
                    m_ProgressBarbackColor.Color = value;
                    this.Invalidate();
                }
            }
        }

        [Category("进度条值"), Description("进度条实时值"), DefaultValue(0)]
        public float Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > m_Maximum)
                {
                    m_Value = m_Maximum;
                }
                else
                {
                    m_Value = value;
                }
                this.Invalidate();
                this.Update();
            }
        }

        [Category("进度条值"), Description("进度条最大值"), DefaultValue(100)]
        public float Maixnum
        {
            get
            {
                return m_Maximum;
            }
            set
            {
                if (m_Maximum != value)
                {
                    if(value < 1)
                    {
                        m_Maximum = 1;
                    }
                    else
                    {
                        m_Maximum = value;
                    }
                    if (m_Maximum < m_Value)
                    {
                        m_Value = m_Maximum;
                    }
                    this.Invalidate();
                    this.Update();
                }
            }
        }

        private void UserProgressBar_Load(object sender, EventArgs e)
        {

        }
    }
}
