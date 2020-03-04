//=================================================================
//
//文件名:HMIAnlogMeter
//
//描述:仪表盘控件
//
//创建人:刘健
//
//创建日期:2016-09-12 13:38:56
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System.ComponentModel;
using System.Drawing;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.Meter
{
    public partial class HMIAnlogMeter : HMICtrlBase
    {
        #region (* 枚举 *)
        public enum AnalogMeterStyle
        {
            Circular = 0,
        };
        #endregion

        #region (* 属性变量 *)
        private AnalogMeterStyle meterStyle;
        private Color bodyColor;
        private Color needleColor;
        private Color scaleColor;
        private Color unNorColor;
        private bool viewGlass;
        private double currValue;
        private double minValue;
        private double maxValue;
        private double minNorValue;
        private double maxNorValue;
        private int scaleDivisions;
        private int scaleSubDivisions;
        private MeterThresholdCollection listThreshold;
        #endregion

        #region (* 类变量 *)
        protected float startAngle;
        protected float endAngle;
        #endregion

        #region (* 构造函数 *)
        public HMIAnlogMeter()
        {
            // 控件初始化
            InitializeComponent();

            // 属性初始化
            this.bodyColor = Color.MidnightBlue;
            this.needleColor = Color.White;
            this.scaleColor = Color.White;
            this.unNorColor = Color.Red;
            this.meterStyle = AnalogMeterStyle.Circular;
            this.viewGlass = false;
            this.startAngle = 135;
            this.endAngle = 405;
            this.minValue = 0;
            this.maxValue = 1;
            this.minNorValue = 0;
            this.maxNorValue = 1;
            this.currValue = 0;
            this.scaleDivisions = 11;
            this.scaleSubDivisions = 10;

            // 刻度值列表
            this.listThreshold = new MeterThresholdCollection();

            this.CalculateDimensions();
        }
        #endregion

        #region (* 属性 *)
        [
            Category("Analog Meter"),
            Description("控件样式")
        ]
        public AnalogMeterStyle MeterStyle
        {
            get { return meterStyle; }
            set
            {
                if (meterStyle == value) return;
                meterStyle = value;
                Invalidate();
            }
        }


        [
            Category("Analog Meter"),
            Description("控件体颜色")
        ]
        public Color BodyColor
        {
            get { return bodyColor; }
            set
            {
                if (bodyColor == value) return;
                bodyColor = value;
                Invalidate();
            }
        }


        [
            Category("Analog Meter"),
            Description("指针颜色")
        ]
        public Color NeedleColor
        {
            get { return needleColor; }
            set
            {
                if (needleColor == value) return;
                needleColor = value;
                Invalidate();
            }
        }


        [
            Category("Analog Meter"),
            Description("毛玻璃效果，并不好看")
        ]
        public bool ViewGlass
        {
            get { return viewGlass; }
            set
            {
                if (viewGlass == value) return;
                viewGlass = value;
                Invalidate();
            }
        }


        [
            Category("Analog Meter"),
            Description("刻度颜色")
        ]
        public Color ScaleColor
        {
            get { return scaleColor; }
            set
            {
                if (scaleColor == value) return;
                scaleColor = value;
                Invalidate();
            }
        }
        [
            Category("Analog Meter"),
            Description("超限值颜色")
        ]
        public Color UnNormalColor
        {
            get { return unNorColor; }
            set
            {
                if (unNorColor == value) return;
                unNorColor = value;
                Invalidate();
            }
        }

        [
            Category("Analog Meter"),
            Description("值")
        ]
        public double Value
        {
            get { return currValue; }
            set
            {
                if (currValue == value) return;
                double val = value;
                if (val > maxValue)
                    val = maxValue;

                if (val < minValue)
                    val = minValue;

                currValue = val;
                Invalidate();
            }
        }


        [
            Category("Analog Meter"),
            Description("最小值")
        ]
        public double MinValue
        {
            get { return minValue; }
            set
            {
                if (minValue == value) return;
                minValue = value;
                Invalidate();
            }
        }


        [
            Category("Analog Meter"),
            Description("最大值")
        ]
        public double MaxValue
        {
            get { return maxValue; }
            set
            {
                if (maxValue == value) return;
                maxValue = value;
                Invalidate();
            }
        }
        [
            Category("Analog Meter"),
            Description("正常值下限")
        ]
        public double MinNValueNor
        {
            get { return minNorValue; }
            set
            {
                if (minNorValue == value) return;
                double val = value;
                if (val > maxValue)
                    val = maxValue;

                if (val < minValue)
                    val = minValue;

                minNorValue = val;
                Invalidate();                
            }
        }
        [
            Category("Analog Meter"),
            Description("正常值上限")
        ]
        public double MaxValueNor
        {
            get { return maxNorValue; }
            set
            {
                if (maxNorValue == value) return;
                double val = value;
                if (val > maxValue)
                    val = maxValue;

                if (val < minValue)
                    val = minValue;

                maxNorValue = val;
                Invalidate();
                
            }
        }

        [
            Category("Analog Meter"),
            Description("大刻度数量")
        ]
        public int ScaleDivisions
        {
            get { return scaleDivisions; }
            set
            {
                if (scaleDivisions == value) return;
                scaleDivisions = value;
                this.CalculateDimensions();
            }
        }


        [
            Category("Analog Meter"),
            Description("小刻度数量")
        ]
        public int ScaleSubDivisions
        {
            get { return scaleSubDivisions; }
            set
            {
                if (scaleSubDivisions == value) return;
                scaleSubDivisions = value;
                this.CalculateDimensions();
            }
        }

        [Browsable(false)]
        public MeterThresholdCollection Thresholds
        {
            get { return this.listThreshold; }
        }
        #endregion

        #region (* Public 方法 *)
        public float GetStartAngle()
        {
            return this.startAngle;
        }

        public float GetEndAngle()
        {
            return this.endAngle;
        }
        #endregion

        #region (* 重写方法 *)
        protected override IRenderer CreateDefaultRenderer()
        {
            return new HMIAnlogMeterRenderer();
        }
        #endregion
    }
}
