//=================================================================
//
//文件名:HMILed
//
//描述:LED控件
//
//创建人:刘健
//
//创建日期:2016-09-09 09:09:54
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
    public partial class HMILed : HMICtrlBase
    {
        #region (* 枚举 *)
		public enum LedState
		{
			Off	= 0,
			On,
			Blink,
		}
		
		public enum LedLabelPosition
		{
			Left = 0,
			Top,
			Right,
			Bottom,
		}

        public enum LedStyle
        {
            Circular = 0,
            Rectangular,
        }

        #endregion
		
		#region (* 属性变量 *)
		private Color				ledColor;
		private LedState			state;
		private LedStyle			style;
		private LedLabelPosition	labelPosition;
		private	String				label = "Led";
		private SizeF				ledSize;
		private int					blinkInterval = 500;
		#endregion
		
		#region (* 类变量 *)
		private	Timer 				tmrBlink;
		private	bool 				blinkIsOn = false;
		#endregion
		
		#region (* 构造函数 *)
		public HMILed()
		{
			InitializeComponent();
            this.tmrBlink       = new Timer();
            this.tmrBlink.Tick  += this.OnBlink;
            this.Size           = new Size(20, 20);
			this.ledColor		= Color.Red;
			this.state 			= HMILed.LedState.Off;
            this.style          = HMILed.LedStyle.Circular;
			this.blinkIsOn		= false;
			this.ledSize		= new SizeF ( 10F, 10F );
			this.labelPosition  = LedLabelPosition.Top;
		}
		#endregion
		
		#region (* 属性 *)
        [
            Category("Led"),
            Description("样式")
        ]
        public LedStyle Style
        {
            get { return style; }
            set
            {
                if (style == value) return;
                style = value;
                this.CalculateDimensions();
            }
        }
        [
			Category("Led"),
			Description("颜色")
		]
		public Color LedColor
		{
			get { return ledColor; }
			set
			{
                if (ledColor == value) return;
                ledColor = value;
				Invalidate();
			}
		}
		
		
		[
			Category("Led"),
			Description("状态")
		]
		public LedState State
		{
			get { return state; }
			set
			{
                if (state == value) return;
                HMILedEventArgs e = new HMILedEventArgs();
                e.State = value;
                state = value;
                OnLedStateChange(e);
                if ( state == LedState.Blink )
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
		
		
		[
			Category("Led"),
			Description("大小")
		]
		public SizeF LedSize
		{
			get { return this.ledSize; }
			set
			{
                if (ledSize == value) return;
                this.ledSize = value;
				this.CalculateDimensions();
				Invalidate();
			}
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
                HMILedEventArgs e = new HMILedEventArgs();
                e.Value = value;
                if (val == value)
                    return;
                this.val = value;
                OnLedValueChange(e);
                this.Invalidate();
            }
            get { return this.val; }
        }

        [
			Category("Led"),
			Description("显示文本")
		]
		public string Label
		{
			get { return this.label; }
			set
			{
                if (label == value) return;
                this.label = value;
				Invalidate();
			}
		}
		
				
		[
			Category("Led"),
			Description("文本位置")
		]
		public LedLabelPosition LabelPosition
		{
			get { return this.labelPosition; }
			set
			{
                if (labelPosition == value) return;
                this.labelPosition = value;
				this.CalculateDimensions();
				Invalidate();
			}
		}
		
				
		[
			Category("Led"),
			Description("闪烁间隔时间ms")
		]
		public int BlinkInterval
		{
			get { return this.blinkInterval; }
			set { if (blinkInterval == value) return; this.blinkInterval = value; }
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
			if ( this.State == LedState.Blink )
			{
				if ( this.blinkIsOn == false )
					this.blinkIsOn = true;
				else
					this.blinkIsOn = false;
				
				this.Invalidate();
			}
		}
		#endregion
		
		#region (* 重写方法 *)
        protected override IRenderer CreateDefaultRenderer()
        {
            return new HMILedRenderer();
        }
        #endregion

        #region (* 事件 *)
        /// <summary>
        /// 状态改变事件
        /// </summary>
        public event LedStateChange LedStateChange;
        public event LedValueChange LedValueChange;
        /// <summary>
        /// 委托调用方法
        /// </summary>
        /// <param name="e"></param>
        protected  void OnLedStateChange(HMILedEventArgs e)
        {
            if (this.LedStateChange != null)
                this.LedStateChange(this, e);
        }
        protected  void OnLedValueChange(HMILedEventArgs e)
        {
            if (this.LedValueChange != null)
                this.LedValueChange(this, e);
        }
        #endregion

    }
    #region (* 事件委托类*)
    /// <summary>
    /// 事件委托
    /// </summary>
    public class HMILedEventArgs : EventArgs
    {
        private HMILed.LedState state;
        private int value = 0;

        public HMILedEventArgs()
        {
        }

        public HMILed.LedState State
        {
            get { return this.state; }
            set { this.state = value; }
        }
        public int Value
        {
            get { return this.value; }
            set { this.value = value; }

        }
    }
    #endregion
    #region
    public delegate void LedStateChange(object sender, HMILedEventArgs e);
    public delegate void LedValueChange(object sender, HMILedEventArgs e);
    #endregion
}
