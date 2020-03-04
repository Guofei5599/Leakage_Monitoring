//=================================================================
//
//文件名:HMI7Segment
//
//描述:单个数码管控件
//
//创建人:刘健
//
//创建日期:2016-09-09 10:22:46
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System.ComponentModel;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.Led
{
    public partial class HMI7Segment : HMICtrlBase
    {
        #region (* 构造函数 *)
        public HMI7Segment()
        {
            InitializeComponent();
        }
        #endregion

        #region (* 属性 *)
        public int val = 0;
        [
            Category("Display"),
            Description("显示值")
        ]
        public int Value
        {
            set { if (val == value) return; this.val = value; this.Invalidate(); }
            get { return this.val; }
        }
        private int pecent = 25;
        [
            Category("Display"),
            Description("点亮和熄灭亮度比率，颜色在FoceColor中设置")
        ]
        public int Pecent
        {
            set { if (pecent == value) return; this.pecent = value; this.Invalidate(); }
            get { return this.pecent; }
        }
        private bool showDp = false;
        [
            Category("Display"),
            Description("显示小数点")
        ]
        public bool ShowDP
        {
            set { if (showDp == value) return; this.showDp = value; this.Invalidate(); }
            get { return this.showDp; }
        }
        #endregion

        #region (* 重写方法 *)
        protected override IRenderer CreateDefaultRenderer()
        {
            return new HMI7SegmentRenderer();
        }
        #endregion
    }
}
