//=================================================================
//
//文件名:HMIArrow
//
//描述:箭头控件
//
//创建人:刘健
//
//创建日期:2016-11-14 13:48:49
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.Arrow
{
    public partial class HMIArrow : HMICtrlBase
    {
        #region(*枚举*)
        public enum conditions
        {
            None,
            大于,
            小于,
            等于,
            大于等于,
            小于等于,
            AND,
            OR,
            NOT
        }

        /// <summary>
        /// 箭头方向
        /// </summary>
        public enum ArrowDirection
        {
            Left = 0,
            Right = 1,
            Top = 2,
            Buttom = 3,
            TopLeft = 4,
            LeftButtom = 5,
            ButtomRight = 6,
            RightTop = 7
        }
        /// <summary>
        /// 箭头状态，显示，不显示，闪烁
        /// </summary>
        public enum ArrowState
        {
            On = 0,
            Off = 1,
            Blink = 2
        }
        #endregion

        #region (*变量*)
        private Color               arrowColor = Color.Red;
        private ArrowDirection      direction = ArrowDirection.Buttom;
        private ArrowState          state = ArrowState.On;
        private int                 blinkInterval = 500;
        private string              arrowLable = "";
        private bool                displayFlag = true;
        #endregion

        #region(*类变量*)
        private Timer               tmrBlink;
        private bool                blinkIsOn = true;
        #endregion

        #region(*构造函数*)
        public HMIArrow()
        {
            InitializeComponent();
            this.tmrBlink = new Timer();
            this.tmrBlink.Tick += this.OnBlink;
            this.Size = new Size(20, 70);
            this.arrowColor = Color.Red;
            this.state = ArrowState.On;
            this.blinkIsOn = true;
            //this.ValueChange += this.OnValueChange;
        }
        #endregion
        public event ArrowValueChange ValueChange;
        #region(*属性*)
        [
            Category("Arrow"),
            Description("是否显示")
        ]
        public bool DisplayFlag
        {
            set
            {
                if (displayFlag == value)
                    return;
                this.displayFlag = value;
                this.Invalidate();
            }
            get { return this.displayFlag; }
        }

        private int val = 0;
        [
            Category("Display"),
            Description("显示值")
        ]
        public int Value
        {
            set
            {
                ArrowEventArgs e = new ArrowEventArgs();
                e.Value = value;
                if (val == value)
                    return;
                this.val = value;
                OnValueChange(this, e);
                this.Invalidate();
            }
            get { return this.val; }
        }
        private string variablename;
        private int conditvalue;
        private conditions condition;

        [
            Category("Display"),
            Description("条件")
        ]
        public conditions Condition
        {
            set
            {
                condition = value;
                this.Invalidate();
            }
            get { return condition; }
        }
        [
            Category("Display"),
            Description("条件值")
        ]
        public int ConditValue
        {
            set
            {
                conditvalue = value;
                this.Invalidate();
            }
            get { return conditvalue; }
        }


        [
			Category("Arrow"),
			Description("箭头颜色")
		]
        public Color ArrowColor
        {
            get { return arrowColor; }
            set
            {
                if (arrowColor != value)
                {
                    arrowColor = value;
                    Invalidate();
                }
            }
        }
        [
            Category("Arrow"),
            Description("箭头文字")
        ]
        public string ArrowLable
        {
            get { return arrowLable; }
            set
            {
                if (arrowLable != value)
                {
                    arrowLable = value;
                    Invalidate();
                }
            }
        }
        [
            Category("Arrow"),
            Description("箭头方向")
        ]
        public ArrowDirection Direction
        {
            get { return direction; }
            set
            {
                if (direction != value)
                {
                    direction = value;
                    Invalidate();
                }
            }
        }
        [
            Category("Arrow"),
            Description("闪烁间隔时间")
        ]
        public int BlinkInterval
        {
            get { return blinkInterval; }
            set { blinkInterval = value; }
        }
        [
            Category("Arrow"),
            Description("状态")
        ]
        public ArrowState State
        {
			get { return state; }
			set
			{
                if (state == value)
                    return;
				state = value;
				if ( state ==  ArrowState.Blink )
				{
					this.blinkIsOn = true;
					this.tmrBlink.Interval = this.BlinkInterval;
					this.tmrBlink.Start();
				}
				else
				{
					this.blinkIsOn = true;
					this.tmrBlink.Stop();
				}
				
				Invalidate();
			}
		}
        [Browsable(false)]
        public bool BlinkIsOn
        {
            get { return this.blinkIsOn; }
        }
        #endregion

        #region (* 事件委托 *)
        void OnBlink(object sender, EventArgs e)
        {
            if (this.State ==  ArrowState.Blink)
            {
                if (this.blinkIsOn == false)
                    this.blinkIsOn = true;
                else
                    this.blinkIsOn = false;

                this.Invalidate();
            }
        }
        void OnValueChange(object sender, ArrowEventArgs e)
        {
            if (ValueChange != null)
                ValueChange(this, e);
        }
        public delegate void ArrowValueChange(object sender, ArrowEventArgs e);
        #endregion

        #region (* 重写方法 *)
        protected override IRenderer CreateDefaultRenderer()
        {
            return new  HMIArrowRenderer();
        }
        #endregion
    }
    public class ArrowEventArgs : EventArgs
    {
        int val = 0;
        public int Value
        {
            set { val = value; }
            get { return val; }
        }
    }
}
