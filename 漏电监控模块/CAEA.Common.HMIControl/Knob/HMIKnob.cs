//=================================================================
//
//文件名:HMIKnob
//
//描述:旋钮控件
//
//创建人:刘健
//
//创建日期:2016-11-14 11:04:30
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.Knob
{
    public partial class HMIKnob : HMICtrlBase
    {
        #region *( 枚举 *)
        public enum ScaleStyle
        {
            Scale = 0,
            Circular = 1
        }
        public enum KnobStyle
        {
            Circular = 0,
        }
        public enum ButtonState
        {
            Normal = 0,
            Pressed,
        }
        /// <summary>
        /// 箭头样式
        /// </summary>
        public enum KnobArrowStyle
        {
            /// <summary>
            /// 无箭头
            /// </summary>
            None = 0,
            /// <summary>
            /// 顺时针
            /// </summary>
            Clockwise = 1,
            /// <summary>
            /// 逆时针
            /// </summary>
            Eastern = 2
        }
        /// <summary>
        /// 外圈八向调节指示
        /// </summary>
        public enum Knob8DerectionType
        {
            None = 0,
            Top = 1,
            Buttom = 2,
            Left = 3,
            Right = 4,
            Top_Left = 5,
            Top_Right = 6,
            Buttom_Left = 7,
            Buttom_Right = 8
        }
        #endregion

        #region (* 属性变量 *)
        private float minValue = 0.0F;
        private float maxValue = 1.0F;
        private float stepValue = 0.1F;
        private float currValue = 0.0F;
        private RectangleF derectionRect = RectangleF.Empty;
        private RectangleF knobRect = RectangleF.Empty;
        private PointF knobCenter = PointF.Empty;
        private KnobStyle style = KnobStyle.Circular;
        private ButtonState state = ButtonState.Normal;
        private Color scaleColor = Color.Green;
        private Color knobColor = Color.Black;
        private Color indicatorColor = Color.Red;
        private Color valueColor = Color.Red;
        private Color scalevalueColor = Color.Red;
        private float indicatorOffset = 10F;
        private float drawRatio = 1F;
        private KnobArrowStyle arrowStyle = KnobArrowStyle.None;
        private Color knobArrowColor = Color.Red;
        private bool display8DerectionFlag = false;
        private float knob8DerectionWight = 10.0F;
        private Knob8DerectionType knobDerectionType = Knob8DerectionType.None;
        private Color topColor = Color.Red;
        private Color buttomColor = Color.CadetBlue;
        private Color leftColor = Color.Olive;
        private Color rightColor = Color.Yellow;
        private Color top_Left_Color = Color.DarkOrange;
        private Color top_Right_Color = Color.Orange;
        private Color buttom_Left_Color = Color.Blue;
        private Color buttom_Right_Color = Color.Green;
        private int derectionColorStep = 50;
        //刻度表现部分
        private ScaleStyle knobScaleStyle = ScaleStyle.Scale;
        private Color scaleOtherColor = Color.Red;
        private int scaleColorStep = 50;
        private bool scaleInterverlFlag = false;

        private eAddrType arrowAddrType = eAddrType.none;
        private uint arrowAddr = 0;
        private uint arrowAddrLen = 0;
        private uint clockwiseValue = 0;
        private uint nonClockwiseValue = 0;
        #endregion

        #region (* 类变量 *)
        private bool isKnobRotating = false;
        #endregion

        #region (* 构造 *)
        public HMIKnob()
        {
            InitializeComponent();
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.CalculateDimensions();
        }
        #endregion

        #region (* 属性 *)
        [
            Category("Modbus"),
            Description("箭头地址类型")
        ]
        public eAddrType ArrowAddrType
        {
            set
            {
                if (arrowAddrType == value) return;
                arrowAddrType = value;
            }
            get { return this.arrowAddrType; }
        }
        [
            Category("Modbus"),
            Description("箭头起始地址")
        ]
        public uint ArrowAddr
        {
            set
            {
                if (arrowAddr == value) return;
                arrowAddr = value;
            }
            get { return this.arrowAddr; }
        }
        [
            Category("Modbus"),
            Description("箭头地址长度")
        ]
        public uint ArrowAddrLen
        {
            set
            {
                if (arrowAddrLen == value) return;
                arrowAddrLen = value;
            }
            get { return this.arrowAddrLen; }
        }
        [
            Category("Modbus"),
            Description("顺时针值")
        ]
        public uint ClockwiseValue
        {
            set
            {
                if (clockwiseValue == value) return;
                clockwiseValue = value;
            }
            get { return this.clockwiseValue; }
        }
        [
           Category("Modbus"),
           Description("逆时针值")
       ]
        public uint NonClockwiseValue
        {
            set
            {
                if (nonClockwiseValue == value) return;
                nonClockwiseValue = value;
            }
            get { return this.nonClockwiseValue; }
        }
        [
            Category("Knob"),
            Description("刻度间隔标识")
        ]
        public bool ScaleInterverlFlag
        {
            set
            {
                if (scaleInterverlFlag == value) return;
                scaleInterverlFlag = value;
                Invalidate();
            }
            get { return this.scaleInterverlFlag; }
        }
        [
            Category("Knob"),
            Description("颜色深度")
        ]
        public int ScaleColorStep
        {
            set
            {
                if (scaleColorStep == value) return;
                scaleColorStep = value;
                Invalidate();
            }
            get { return this.scaleColorStep; }
        }
        [
            Category("Knob"),
            Description("刻度表现模式")
        ]
        public ScaleStyle KnobScaleStyle
        {
            set
            {
                if (knobScaleStyle == value) return;
                knobScaleStyle = value;
                Invalidate();
            }
            get { return this.knobScaleStyle; }
        }
        [
            Category("Knob"),
            Description("环形刻度的另一种颜色")
        ]
        public Color ScaleOtherColor
        {
            set
            {
                if (scaleOtherColor == value) return;
                scaleOtherColor = value;
                Invalidate();
            }
            get { return this.scaleOtherColor; }
        }
        [
            Category("Knob8"),
            Description("是否显示外圈8向指示")
        ]
        public bool Display8DerectionFlag
        {
            set
            {
                if (display8DerectionFlag == value) return;
                display8DerectionFlag = value;
                Invalidate();
            }
            get { return this.display8DerectionFlag; }
        }
        [
            Category("Knob8"),
            Description("外圈8向指示宽度")
        ]
        public float Knob8DerectionWight
        {
            set
            {
                if (knob8DerectionWight == value) return;
                knob8DerectionWight = value;
                Invalidate();
            }
            get { return this.knob8DerectionWight; }
        }
        [
            Category("Knob8"),
            Description("指示哪个方向处于触发状态")
        ]
        public Knob8DerectionType KnobDerectionType
        {
            set
            {
                if (knobDerectionType == value) return;
                knobDerectionType = value;
                Invalidate();
            }
            get { return this.knobDerectionType; }
        }
        [
            Category("Knob8"),
            Description("上方颜色设置")
        ]
        public Color TopColor
        {
            set
            {
                if (topColor == value) return;
                topColor = value;
                Invalidate();
            }
            get { return this.topColor; }
        }
        [
            Category("Knob8"),
            Description("下方颜色设置")
        ]
        public Color ButtomColor
        {
            set
            {
                if (buttomColor == value) return;
                buttomColor = value;
                Invalidate();
            }
            get { return this.buttomColor; }
        }
        [
            Category("Knob8"),
            Description("左方颜色设置")
        ]
        public Color LeftColor
        {
            set
            {
                if (leftColor == value) return;
                leftColor = value;
                Invalidate();
            }
            get { return this.leftColor; }
        }
        [
            Category("Knob8"),
            Description("右方颜色设置")
        ]
        public Color RightColor
        {
            set
            {
                if (rightColor == value) return;
                rightColor = value;
                Invalidate();
            }
            get { return this.rightColor; }
        }
        [
            Category("Knob8"),
            Description("左上方颜色设置")
        ]
        public Color Top_Left_Color
        {
            set
            {
                if (top_Left_Color == value) return;
                top_Left_Color = value;
                Invalidate();
            }
            get { return this.top_Left_Color; }
        }
        [
            Category("Knob8"),
            Description("右上方颜色设置")
        ]
        public Color Top_Right_Color
        {
            set
            {
                if (top_Right_Color == value) return;
                top_Right_Color = value;
                Invalidate();
            }
            get { return this.top_Right_Color; }
        }
        [
            Category("Knob8"),
            Description("左下方颜色设置")
        ]
        public Color Buttom_Left_Color
        {
            set
            {
                if (buttom_Left_Color == value) return;
                buttom_Left_Color = value;
                Invalidate();
            }
            get { return this.buttom_Left_Color; }
        }
        [
            Category("Knob8"),
            Description("右下方颜色设置")
        ]
        public Color Buttom_Right_Color
        {
            set
            {
                if (buttom_Right_Color == value) return;
                buttom_Right_Color = value;
                Invalidate();
            }
            get { return this.buttom_Right_Color; }
        }
        [
            Category("Knob8"),
            Description("未触发时的颜色深度")
        ]
        public int DerectionColorStep
        {
            set
            {
                if (derectionColorStep == value) return;
                derectionColorStep = value;
                Invalidate();
            }
            get { return this.derectionColorStep; }
        }

        [
            Category("Knob"),
            Description("箭头样式，选择无箭头，顺时针，或者逆时针")
        ]
        public KnobArrowStyle ArrowStyle
        {
            set
            {
                if (arrowStyle == value) return;
                this.arrowStyle = value;
                this.Invalidate();
            }
            get { return this.arrowStyle;}
        }
        [
            Category("Knob"),
            Description("设置箭头颜色")
        ]
        public Color ArrowColor
        {
            set
            {
                if (knobArrowColor == value) return;
                this.knobArrowColor = value;
                this.Invalidate();
            }
            get { return this.knobArrowColor; }
        }
        [
            Category("Knob"),
            Description("状态")
        ]
        public ButtonState State
        {
            set
            {
                if (state == value) return;
                this.state = value;
                this.Invalidate();
            }
            get { return this.state; }
        }
        [
            Category("Knob"),
            Description("最小值")
        ]
        public float MinValue
        {
            set
            {
                if (minValue == value) return;
                this.minValue = value;
                this.Invalidate();
            }
            get { return this.minValue; }
        }

        [
            Category("Knob"),
            Description("最大值")
        ]
        public float MaxValue
        {
            set
            {
                if (maxValue == value) return;
                this.maxValue = value;
                this.Invalidate();
            }
            get { return this.maxValue; }
        }

        [
            Category("Knob"),
            Description("步进值")
        ]
        public float StepValue
        {
            set
            {
                if (stepValue == value) return;
                this.stepValue = value;
                this.Invalidate();
            }
            get { return this.stepValue; }
        }

        [
            Category("Knob"),
            Description("当前值")
        ]
        public float Value
        {
            set
            {
                if (value != this.currValue)
                { 
                    this.currValue = value;
                    this.CalculateDimensions();
                    this.Invalidate();

                    HMIKnobEventArgs e = new HMIKnobEventArgs();
                    e.Value = this.currValue;
                    this.OnKnobChangeValue(e);
                }
            }
            get { return this.currValue; }
        }

        [
            Category("Knob"),
            Description("样式")
        ]
        public KnobStyle Style
        {
            set
            {
                if (style == value) return;
                this.style = value;
                this.Invalidate();
            }
            get { return this.style; }
        }

        [
            Category("Knob"),
            Description("颜色")
        ]
        public Color KnobColor
        {
            set
            {
                if (knobColor == value) return;
                this.knobColor = value;
                this.Invalidate();
            }
            get { return this.knobColor; }
        }
        [
            Category("Knob"),
            Description("当前值颜色")
        ]
        public Color ValueColor
        {
            set
            {
                if (valueColor == value) return;
                this.valueColor = value;
                this.Invalidate();
            }
            get { return this.valueColor; }
        }
        [
            Category("Knob"),
            Description("刻度值颜色")
        ]
        public Color ScaleValueColor
        {
            set
            {
                if (scalevalueColor == value) return;
                this.scalevalueColor = value;
                this.Invalidate();
            }
            get { return this.scalevalueColor; }
        }
        [
            Category("Knob"),
            Description("刻度颜色")
        ]
        public Color ScaleColor
        {
            set
            {
                if (scaleColor == value) return;
                this.scaleColor = value;
                this.Invalidate();
            }
            get { return this.scaleColor; }
        }

        [
            Category("Knob"),
            Description("标示颜色")
        ]
        public Color IndicatorColor
        {
            set
            {
                if (indicatorColor == value) return;
                this.indicatorColor = value;
                this.Invalidate();
            }
            get { return this.indicatorColor; }
        }

        [
            Category("Knob"),
            Description("标志点离外圈的距离")
        ]
        public float IndicatorOffset
        {
            set
            {
                if (indicatorOffset == value) return;
                this.indicatorOffset = value;
                this.CalculateDimensions();
                this.Invalidate();
            }
            get { return this.indicatorOffset; }
        }

        public RectangleF DerectionRect
        {
            set { if (derectionRect == value) return; derectionRect = value; }
            get { return derectionRect; }
        }
        [Browsable(false)]
        public PointF KnobCenter
        {
            set { if (knobCenter == value) return; this.knobCenter = value; }
            get { return this.knobCenter; }
        }

        [Browsable(false)]
        public RectangleF KnobRect
        {
            set { if (knobRect == value) return; this.knobRect = value; }
            get { return this.knobRect; }
        }

        [Browsable(false)]
        public float DrawRatio
        {
            set { if (drawRatio == value) return; this.drawRatio = value; }
            get { return this.drawRatio; }
        }
        #endregion

        #region (* 事件委托 *)

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool blResult = true;

            const int WM_KEYDOWN = 0x0100;

            const int WM_SYSKEYDOWN = 0x0104;

            float val = this.Value;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Up:
                        val += this.StepValue;
                        if (val <= this.MaxValue)
                            this.Value = val;
                        break;

                    case Keys.Down:
                        val -= this.StepValue;
                        if (val >= this.MinValue)
                            this.Value = val;
                        break;

                    case Keys.PageUp:
                        if (val < this.MaxValue)
                        {
                            val += (this.StepValue * 10);
                            this.Value = val;
                        }
                        break;

                    case Keys.PageDown:
                        if (val > this.MinValue)
                        {
                            val -= (this.StepValue * 10);
                            this.Value = val;
                        }
                        break;

                    case Keys.Home:
                        this.Value = this.MinValue;
                        break;

                    case Keys.End:
                        this.Value = this.MaxValue;
                        break;

                    default:
                        blResult = base.ProcessCmdKey(ref msg, keyData);
                        break;
                }
            }

            return blResult;
        }

        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            this.Invalidate();
            base.OnClick(e);
        }

        void OnMouseUp(object sender, MouseEventArgs e)
        {
            this.isKnobRotating = false;

            if (this.knobRect.Contains(e.Location) == false)
                return;

            float val = this.GetValueFromPosition(e.Location);
            if (val != this.Value)
            {
                this.Value = val;
                this.Invalidate();
            }
        }

        void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (this.knobRect.Contains(e.Location) == false)
                return;

            this.isKnobRotating = true;

            this.Focus();
        }

        void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (this.isKnobRotating == false)
                return;

            float val = this.GetValueFromPosition(e.Location);
            if (val != this.Value)
            {
                this.Value = val;
                this.Invalidate();
            }
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            float val = this.Value;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    val = this.Value + this.StepValue;
                    break;

                case Keys.Down:
                    val = this.Value - this.StepValue;
                    break;
            }

            if (val < this.MinValue)
                val = this.MinValue;

            if (val > this.MaxValue)
                val = this.MaxValue;

            this.Value = val;
        }
        #endregion

        #region (* 虚方法*)
        public virtual float GetValueFromPosition(PointF position)
        {
            float degree = 0.0F;
            float v = 0.0F;

            PointF center = this.KnobCenter;

            if (position.X <= center.X)
            {
                degree = (center.Y - position.Y) / (center.X - position.X);
                degree = (float)Math.Atan(degree);
                degree = (float)((degree) * (180F / Math.PI) + 45F);
                v = (degree * (this.MaxValue - this.MinValue) / 270F);
            }
            else
            {
                if (position.X > center.X)
                {
                    degree = (position.Y - center.Y) / (position.X - center.X);
                    degree = (float)Math.Atan(degree);
                    degree = (float)(225F + (degree) * (180F / Math.PI));
                    v = (degree * (this.MaxValue - this.MinValue) / 270F);
                }
            }

            if (v > this.MaxValue)
                v = this.MaxValue;

            if (v < this.MinValue)
                v = this.MinValue;
            //四舍五入，当鼠标直接操作时，超过两个档位的中间位置跳转到下一档位
            v = (float)((int)(v/this.StepValue+0.5F))*this.StepValue;
            return v;
        }

        public virtual PointF GetPositionFromValue(float val)
        {
            PointF pos = new PointF(0.0F, 0.0F);

            if ((this.MaxValue - this.MinValue) == 0)
                return pos;

            float _indicatorOffset = this.IndicatorOffset * this.drawRatio;

            float degree = 270F * (val-this.MinValue) / (this.MaxValue - this.MinValue);
            degree = (degree + 135F) * (float)Math.PI / 180F;

            pos.X = (int)(Math.Cos(degree) * ((this.knobRect.Width * 0.5F) - indicatorOffset) + this.knobRect.X + (this.knobRect.Width * 0.5F));
            pos.Y = (int)(Math.Sin(degree) * ((this.knobRect.Width * 0.5F) - indicatorOffset) + this.knobRect.Y + (this.knobRect.Height * 0.5F));

            return pos;
        }
        public virtual PointF[] GetDerectionPoints()
        {
            PointF[] points = new PointF[16];
            for(int i=0;i<16;i++)
            {
                points[i] = new PointF(0.0F, 0.0F);
            }
            float degree = 0;

            degree = 247.5F * (float)Math.PI / 180F;
            points[0].X = (float)(Math.Cos(degree) * (this.DerectionRect.Width * 0.5F - this.DrawRatio * this.Knob8DerectionWight) + this.DerectionRect.Width * 0.5F);
            points[0].Y = (float)(Math.Sin(degree) * (this.DerectionRect.Width * 0.5F - this.DrawRatio * this.Knob8DerectionWight) + this.DerectionRect.Height * 0.5F);
            points[1].X = (float)(Math.Cos(degree) * (this.DerectionRect.Width * 0.5F) + this.DerectionRect.Width * 0.5F);
            points[1].Y = (float)(Math.Sin(degree) * (this.DerectionRect.Width * 0.5F) + this.DerectionRect.Height * 0.5F);

            degree = 292.5F * (float)Math.PI / 180F;
            points[3].X = (float)(Math.Cos(degree) * ((this.DerectionRect.Width * 0.5F) - Knob8DerectionWight * DrawRatio) + (this.DerectionRect.Width * 0.5F));
            points[3].Y = (float)(Math.Sin(degree) * ((this.DerectionRect.Width * 0.5F) - Knob8DerectionWight * DrawRatio) + (this.DerectionRect.Height * 0.5F));
            points[2].X = (float)(Math.Cos(degree) * ((this.DerectionRect.Width * 0.5F))  + (this.DerectionRect.Width * 0.5F));
            points[2].Y = (float)(Math.Sin(degree) * ((this.DerectionRect.Width * 0.5F))  + (this.DerectionRect.Height * 0.5F));

            degree = 337.5F * (float)Math.PI / 180F;
            points[4].X = (float)(Math.Cos(degree) * (this.DerectionRect.Width * 0.5F - this.DrawRatio * this.Knob8DerectionWight) + this.DerectionRect.Width * 0.5F);
            points[4].Y = (float)(Math.Sin(degree) * (this.DerectionRect.Width * 0.5F - this.DrawRatio * this.Knob8DerectionWight) + this.DerectionRect.Height * 0.5F);
            points[5].X = (float)(Math.Cos(degree) * (this.DerectionRect.Width * 0.5F) + this.DerectionRect.Width * 0.5F);
            points[5].Y = (float)(Math.Sin(degree) * (this.DerectionRect.Width * 0.5F) + this.DerectionRect.Height * 0.5F);

            degree = 22.5F * (float)Math.PI / 180F;
            points[7].X = (float)(Math.Cos(degree) * ((this.DerectionRect.Width * 0.5F) - Knob8DerectionWight * DrawRatio) + (this.DerectionRect.Width * 0.5F));
            points[7].Y = (float)(Math.Sin(degree) * ((this.DerectionRect.Width * 0.5F) - Knob8DerectionWight * DrawRatio) + (this.DerectionRect.Height * 0.5F));
            points[6].X = (float)(Math.Cos(degree) * ((this.DerectionRect.Width * 0.5F)) + (this.DerectionRect.Width * 0.5F));
            points[6].Y = (float)(Math.Sin(degree) * ((this.DerectionRect.Width * 0.5F)) + (this.DerectionRect.Height * 0.5F));

            degree = 67.5F * (float)Math.PI / 180F;
            points[8].X = (float)(Math.Cos(degree) * ((this.DerectionRect.Width * 0.5F) - Knob8DerectionWight * DrawRatio) + (this.DerectionRect.Width * 0.5F));
            points[8].Y = (float)(Math.Sin(degree) * ((this.DerectionRect.Width * 0.5F) - Knob8DerectionWight * DrawRatio) + (this.DerectionRect.Height * 0.5F));
            points[9].X = (float)(Math.Cos(degree) * ((this.DerectionRect.Width * 0.5F)) + (this.DerectionRect.Width * 0.5F));
            points[9].Y = (float)(Math.Sin(degree) * ((this.DerectionRect.Width * 0.5F)) + (this.DerectionRect.Height * 0.5F));

            degree = 112.5F * (float)Math.PI / 180F;
            points[11].X = (float)(Math.Cos(degree) * ((this.DerectionRect.Width * 0.5F) - Knob8DerectionWight * DrawRatio) + (this.DerectionRect.Width * 0.5F));
            points[11].Y = (float)(Math.Sin(degree) * ((this.DerectionRect.Width * 0.5F) - Knob8DerectionWight * DrawRatio) + (this.DerectionRect.Height * 0.5F));
            points[10].X = (float)(Math.Cos(degree) * ((this.DerectionRect.Width * 0.5F)) + (this.DerectionRect.Width * 0.5F));
            points[10].Y = (float)(Math.Sin(degree) * ((this.DerectionRect.Width * 0.5F)) + (this.DerectionRect.Height * 0.5F));

            degree = 157.5F * (float)Math.PI / 180F;
            points[12].X = (float)(Math.Cos(degree) * ((this.DerectionRect.Width * 0.5F) - Knob8DerectionWight * DrawRatio) + (this.DerectionRect.Width * 0.5F));
            points[12].Y = (float)(Math.Sin(degree) * ((this.DerectionRect.Width * 0.5F) - Knob8DerectionWight * DrawRatio) + (this.DerectionRect.Height * 0.5F));
            points[13].X = (float)(Math.Cos(degree) * ((this.DerectionRect.Width * 0.5F)) + (this.DerectionRect.Width * 0.5F));
            points[13].Y = (float)(Math.Sin(degree) * ((this.DerectionRect.Width * 0.5F)) + (this.DerectionRect.Height * 0.5F));

            degree = 202.5F * (float)Math.PI / 180F;
            points[15].X = (float)(Math.Cos(degree) * ((this.DerectionRect.Width * 0.5F) - Knob8DerectionWight * DrawRatio) + (this.DerectionRect.Width * 0.5F));
            points[15].Y = (float)(Math.Sin(degree) * ((this.DerectionRect.Width * 0.5F) - Knob8DerectionWight * DrawRatio) + (this.DerectionRect.Height * 0.5F));
            points[14].X = (float)(Math.Cos(degree) * ((this.DerectionRect.Width * 0.5F)) + (this.DerectionRect.Width * 0.5F));
            points[14].Y = (float)(Math.Sin(degree) * ((this.DerectionRect.Width * 0.5F)) + (this.DerectionRect.Height * 0.5F));

            return points;
        }
        #endregion

        #region (* 事件 *)
        public event KnobChangeValue KnobChangeValue;
        protected virtual void OnKnobChangeValue(HMIKnobEventArgs e)
        {
            if (this.KnobChangeValue != null)
                this.KnobChangeValue(this, e);
        }
        #endregion

        #region (* 重写方法 *)
        protected override IRenderer CreateDefaultRenderer()
        {
            return new HMIKnobRenderer();
        }
        #endregion
    }

    #region (* 事件用的类 *)

    #region (* 类事件类型*)
    /// <summary>
    /// 事件委托
    /// </summary>
    public class HMIKnobEventArgs : EventArgs
    {
        private float val;

        public HMIKnobEventArgs()
        {
        }

        public float Value
        {
            get { return this.val; }
            set { this.val = value; }
        }
    }
    #endregion

    #region (* 委托 *)
    public delegate void KnobChangeValue(object sender, HMIKnobEventArgs e);
    #endregion

    #endregion
}
