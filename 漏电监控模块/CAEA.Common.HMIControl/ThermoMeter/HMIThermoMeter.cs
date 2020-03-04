//=================================================================
//
//文件名:HMIThermoMeter
//
//描述:温度计控件
//
//创建人:刘健
//
//创建日期:2016-09-13 14:19:13
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System.ComponentModel;
using System.Drawing;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.ThermoMeter
{
    public partial class HMIThermoMeter : HMICtrlBase
    {
        #region(*构造函数*)
        public HMIThermoMeter()
        {
            InitializeComponent();
            this.highTemperature = 50;
            this.lowTemperature = 0;
            this.Temperature = 0;
            this.bigScale = 5;
            this.smallScale = 5;
            this.bigScaleColor = Color.Black;
            this.dialBackColor = Color.Silver;
            this.dialOutLineColor = Color.Silver;
            this.drawColor = Color.Black;
            this.mercuryBackColor = Color.White;
            this.mercuryColor = Color.Red;
        }
        #endregion

        #region(*属性*)
        // 温度
        private float temperature = 0F;
        [Category("ThermoMeter"), Description("当前温度")]
        public float Temperature
        {
            set 
            {
                if (temperature == value) return;
                float var = value;
                if (var > HighTemperature)
                    var = HighTemperature;
                if (var < LowTemperature)
                    var = LowTemperature;
                temperature = var;
                Invalidate();
            }
            get { return temperature; }
        }

        // 最高温度
        private float highTemperature = 50F;
        [Category("ThermoMeter"), Description("最高温度")]
        public float HighTemperature
        {
            set { if (highTemperature == value) return; highTemperature = value; Invalidate(); }
            get { return highTemperature; }
        }

        // 最低温度
        private float lowTemperature = -20F;
        [Category("ThermoMeter"), Description("最低温度")]
        public float LowTemperature
        {
            set { if (lowTemperature == value) return; lowTemperature = value; Invalidate(); }
            get { return lowTemperature; }
        }

        // 当前温度数值的字体
        private Font tempFont = new Font("宋体", 12);
        [Category("ThermoMeter"), Description("当前温度数值的字体")]
        public Font TempFont
        {
            set { if (tempFont == value) return; tempFont = value; Invalidate(); }
            get { return tempFont; }
        }

        // 当前温度数值的颜色
        private Color tempColor = Color.Black;
        [Category("ThermoMeter"), Description("当前温度数值的颜色")]
        public Color TempColor
        {
            set { if (tempColor == value) return; tempColor = value; Invalidate(); }
            get { return tempColor; }
        }

        // 大刻度线数量
        private int bigScale = 5;
        [Category("ThermoMeter"), Description("大刻度线数量")]
        public int BigScale
        {
            set { if (bigScale == value) return; bigScale = value; Invalidate(); }
            get { return bigScale; }
        }

        // 小刻度线数量
        private int smallScale = 5;
        [Category("ThermoMeter"), Description("小刻度线数量")]
        public int SmallScale
        {
            set { if (smallScale == value) return; smallScale = value; Invalidate(); }
            get { return smallScale; }
        }

        // 刻度字体
        private Font drawFont = new Font("Aril", 9);
        [Category("ThermoMeter"), Description("刻度数字的字体")]
        public Font DrawFont
        {
            get { return drawFont; }
            set { if (drawFont == value) return; drawFont = value; Invalidate(); }
        }

        // 字体颜色
        private Color drawColor = Color.Black;
        [Category("ThermoMeter"), Description("刻度数字的颜色")]
        public Color DrawColor
        {
            set { if (drawColor == value) return; drawColor = value; Invalidate(); }
            get { return drawColor; }
        }

        // 刻度盘最外圈线条的颜色
        private Color dialOutLineColor = Color.Gray;
        [Category("ThermoMeter"), Description("刻度盘最外圈线条的颜色")]
        public Color DialOutLineColor
        {
            set { if (dialOutLineColor == value) return; dialOutLineColor = value; Invalidate(); }
            get { return dialOutLineColor; }
        }

        // 刻度盘背景颜色
        private Color dialBackColor = Color.Gray;
        [Category("ThermoMeter"), Description("刻度盘背景颜色")]
        public Color DialBackColor
        {
            set { if (dialBackColor == value) return; dialBackColor = value; Invalidate(); }
            get { return dialBackColor; }
        }

        // 大刻度线颜色
        private Color bigScaleColor = Color.Black;
        [Category("ThermoMeter"), Description("大刻度线颜色")]
        public Color BigScaleColor
        {
            set { if (bigScaleColor == value) return; bigScaleColor = value; Invalidate(); }
            get { return bigScaleColor; }
        }

        // 小刻度线颜色
        private Color smallScaleColor = Color.Black;
        [Category("ThermoMeter"), Description("小刻度线颜色")]
        public Color SmallScaleColor
        {
            set { if (smallScaleColor == value) return; smallScaleColor = value; Invalidate(); }
            get { return smallScaleColor; }
        }

        // 温度柱背景颜色
        private Color mercuryBackColor = Color.LightGray;
        [Category("ThermoMeter"), Description("温度柱背景颜色")]
        public Color MercuryBackColor
        {
            set { if (mercuryBackColor == value) return; mercuryBackColor = value; Invalidate(); }
            get { return mercuryBackColor; }
        }

        // 温度柱颜色
        private Color mercuryColor = Color.Red;
        [Category("ThermoMeter"), Description("温度柱颜色")]
        public Color MercuryColor
        {
            set { if (mercuryColor == value) return; mercuryColor = value; Invalidate(); }
            get { return mercuryColor; }
        }
        #endregion

        #region (* 重写方法 *)
        protected override IRenderer CreateDefaultRenderer()
        {
            return new HMIThermoMeterRenderer();
        }
        #endregion
    }
}
