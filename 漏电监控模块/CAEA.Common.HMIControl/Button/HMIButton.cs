//=================================================================
//
//文件名:HMIButton
//
//描述:按钮控件
//
//创建人:刘健
//
//创建日期:2016-09-08 14:56:35
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.Button
{
    public partial class HMIButton : HMICtrlBase
    {
        #region (* 枚举 *)
        /// <summary>
        /// 样式
        /// </summary>
        public enum ButtonStyle
        {
            Circular = 0,
            Rectangular = 1,
            Elliptical = 2,
        }

        /// <summary>
        /// 按键类型
        /// </summary>
        public enum ButtonTypeenum
        {
            AutoReset = 0,
            ManualReset = 1,
        }
        /// <summary>
        /// 状态
        /// </summary>
        public enum ButtonState
        {
            Normal = 0,
            Pressed,
        }
        public enum ButtonLabelSylt
        {
            Text = 0,
            Image = 1
        }
        #endregion

        #region (* 变量 *)
        private ButtonStyle buttonStyle = ButtonStyle.Circular;
        private ButtonState buttonState = ButtonState.Normal;
        private ButtonTypeenum buttonType = ButtonTypeenum.AutoReset;
        private Color buttonColor = Color.Red;
        private string label = String.Empty;
        private bool enableRepeatState = false;
        private int startRepeatInterval = 500;
        private int repeatInterval = 100;
        private ButtonLabelSylt lableStyl = ButtonLabelSylt.Text;
        private Image lableImage = null;
        private bool displayFlag = true;
        #endregion

        #region (* 定时器 *)
        private Timer tmrRepeat = null;
        #endregion

        #region (* 构造函数 *)
        public HMIButton()
        {
            // 初始化
            InitializeComponent();

            // 属性初始化
            this.buttonColor = Color.Red;
            this.Size = new Size(50, 50);

            // 定时器初始化 
            this.tmrRepeat = new Timer();
            this.tmrRepeat.Enabled = false;
            this.tmrRepeat.Interval = this.startRepeatInterval;
            this.tmrRepeat.Tick += this.Timer_Tick;
            this.MouseUp += this.OnMuoseUp;
            this.MouseDown += this.OnMouseDown;
        }
        #endregion

        #region (* 重写方法 *)
        protected override IRenderer CreateDefaultRenderer()
        {
            return new HMIButtonRenderer();
        }
        #endregion

        #region (* 属性 *)
        [
            Category("Button"),
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
        [
           Category("Button"),
           Description("按键类型")
       ]
        public ButtonTypeenum ButtonType
        {
            set
            {
                if (buttonType == value)
                    return;
                this.buttonType = value;
                this.Invalidate();
            }
            get { return this.buttonType; }
        }
        [
            Category("Button"),
            Description("标签显现样式")
        ]
        public ButtonLabelSylt LableStyl
        {
            set
            {
                if (lableStyl == value)
                    return;
                this.lableStyl = value;
                this.Invalidate();
            }
            get { return this.lableStyl; }
        }
        [
            Category("Button"),
            Description("图片")
        ]
        public Image LableImage
        {
            set
            {
                if (lableImage == value)
                    return;
                this.lableImage = value;
                this.Invalidate();
            }
            get { return this.lableImage; }
        }

        [
            Category("Button"),
            Description("样式")
        ]
        public ButtonStyle Style
        {
            set
            {
                if (buttonStyle == value)
                    return;
                this.buttonStyle = value;
                this.CalculateDimensions();
            }
            get { return this.buttonStyle; }
        }

        [
            Category("Button"),
            Description("颜色")
        ]
        public Color ButtonColor
        {
            get { return buttonColor; }
            set
            {
                if (buttonColor == value) return;
                buttonColor = value;
                Invalidate();
            }
        }

        [
            Category("Button"),
            Description("text"),
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
            Category("Button"),
            Description("状态")
        ]
        public ButtonState State
        {
            set
            {
                if (buttonState == value) return;
                this.buttonState = value;
                this.Invalidate();
            }
            get { return this.buttonState; }
        }

        [
            Category("Button"),
            Description("当按钮按下时是否触发事件")
        ]
        public bool RepeatState
        {
            set { if (enableRepeatState == value) return; this.enableRepeatState = value; }
            get { return this.enableRepeatState; }
        }

        [
            Category("Button"),
            Description("等待开始刷新时间，单位ms")
        ]
        public int StartRepeatInterval
        {
            set { if (startRepeatInterval == value) return; this.startRepeatInterval = value; }
            get { return this.startRepeatInterval; }
        }

        [
            Category("Button"),
            Description("刷新间隔，单位ms")
        ]
        public int RepeatInterval
        {
            set { if (repeatInterval == value) return; this.repeatInterval = value; }
            get { return this.repeatInterval; }
        }
        #endregion

        #region (* 事件 *)
        /// <summary>
        /// 定时器事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Timer_Tick(object sender, EventArgs e)
        {
            this.tmrRepeat.Enabled = false;

            // 更新刷新间隔
            if (tmrRepeat.Interval == this.startRepeatInterval)
                this.tmrRepeat.Interval = this.repeatInterval;

            // 调用事件
            HMIButtonEventArgs ev = new HMIButtonEventArgs();
            ev.State = this.State;
            this.OnButtonRepeatState(ev);

            this.tmrRepeat.Enabled = true;
        }

        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMouseDown(object sender, MouseEventArgs e)
        {
            // 改变状态
            if (ButtonType == ButtonTypeenum.AutoReset)
            {
                this.State = ButtonState.Pressed;
                this.Invalidate();
            }
            else
            {
                if (this.State == ButtonState.Pressed)
                    this.State = ButtonState.Normal;
                else
                    this.State = ButtonState.Pressed;
            }

			// 调用事件
			HMIButtonEventArgs ev = new HMIButtonEventArgs();
			ev.State = this.State;
			this.OnButtonChangeState ( ev );

            // 使能定时器
            if (this.RepeatState != false)
            {
                this.tmrRepeat.Interval = this.StartRepeatInterval;
                this.tmrRepeat.Enabled = true;
            }
		}
		
		/// <summary>
		/// 鼠标事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnMuoseUp(object sender, MouseEventArgs e)
		{
            // 改变状态
            if (ButtonType == ButtonTypeenum.AutoReset)
            {
                this.State = ButtonState.Normal;
                this.Invalidate();
            }
               
			
			// 调用事件
			HMIButtonEventArgs ev = new HMIButtonEventArgs();
			ev.State = this.State;
			this.OnButtonChangeState ( ev );

            //关定时器
            this.tmrRepeat.Enabled = false;
		}
		#endregion
		
		#region (* 事件 *)
		/// <summary>
		/// 状态改变事件
		/// </summary>
		public event ButtonChangeState ButtonChangeState;
		
		/// <summary>
		/// 委托调用方法
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnButtonChangeState( HMIButtonEventArgs e )
	    {
	        if( this.ButtonChangeState != null )
	            this.ButtonChangeState( this, e );
	    }		

		/// <summary>
		/// 委托事件
		/// </summary>
        public event ButtonRepeatState ButtonRepeatState;
		
		/// <summary>
		/// 委托函数
		/// </summary>
		/// <param name="e"></param>
        protected virtual void OnButtonRepeatState(HMIButtonEventArgs e)
	    {
            if (this.ButtonRepeatState != null)
                this.ButtonRepeatState(this, e);
	    }		
		#endregion
	}

	#region (* 事件和事件委托类 *)
	
	#region (* 事件委托类*)
	/// <summary>
	/// 事件委托
	/// </summary>
	public class HMIButtonEventArgs : EventArgs
	{
        private HMIButton.ButtonState state;
			
		public HMIButtonEventArgs()
		{			
		}

        public HMIButton.ButtonState State
		{
			get { return this.state; }
			set { this.state = value; }
		}
	}
	#endregion
	
	#region (* 委托 *)
	public delegate void ButtonChangeState ( object sender, HMIButtonEventArgs e );
	public delegate void ButtonRepeatState ( object sender, HMIButtonEventArgs e );
	#endregion
	
	#endregion
}
