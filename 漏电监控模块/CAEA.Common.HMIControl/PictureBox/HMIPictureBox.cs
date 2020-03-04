using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.HMIPictureBox
{
    public class HMIPictureBox : PictureBox
    {
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
        public enum eDisplayType
        {
            none = 0,
            visable,
            enable,
        }
        public HMIPictureBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
        }

        private Base.HMICtrlBase.eAddrType addrType = Base.HMICtrlBase.eAddrType.none;
        private uint startAddr = 0;
        private uint addrLen = 0;
        private bool displayFlag = true;
        private bool updateToSqlFlag = false;
        private string updateTips = "";
        private string updateValue = "";
        private string updateUnit = "";
        public bool isrelate = false;

        public int val = 0;
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
            Category("Display"),
            Description("显示值")
        ]
        public int Value
        {
            set
            {
                HMIPicEventArgs e = new HMIPicEventArgs();
                if (val == value) return;
                this.val = value;
                e.Value = value;
                OnPicValueChange(e);
                this.Invalidate();
            }
            get { return this.val; }
        }
        [
            Category("MyPicureBox"),
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
          Category("Modbus"),
          Description("自动关联上传")
      ]
        public bool IsRelate
        {
            set
            {
                if (isrelate == value) return;
                isrelate = value;
            }
            get { return isrelate; }
        }
        [
            Category("Modbus"),
            Description("上传值单位")
        ]
        public string UpdateUnit
        {
            set
            {
                if (updateUnit == value) return;
                updateUnit = value;
            }
            get { return updateUnit; }
        }
        [
            Category("Modbus"),
            Description("上传值")
        ]
        public string UpdateValue
        {
            set
            {
                if (updateValue == value) return;
                updateValue = value;
            }
            get { return updateValue; }
        }
        [
            Category("Modbus"),
            Description("上传提示")
        ]
        public string UpdateTips
        {
            set
            {
                if (updateTips == value) return;
                updateTips = value;
            }
            get { return updateTips; }
        }
        [
            Category("Modbus"),
            Description("上传标志")
        ]
        public bool UpdateToSqlFlag
        {
            set
            {
                if (updateToSqlFlag == value) return;
                updateToSqlFlag = value;
            }
            get { return updateToSqlFlag; }
        }

        [
            Category("Modbus"),
            Description("Modbus地址类型")
        ]
        public Base.HMICtrlBase.eAddrType AddrType
        {
            set
            {
                if (addrType == value) return;
                addrType = value;
            }
            get { return this.addrType; }
        }
        [
            Category("Modbus"),
            Description("起始地址")
        ]
        public uint StartAddr
        {
            set
            {
                if (startAddr == value) return;
                startAddr = value;
            }
            get { return this.startAddr; }
        }
        [
            Category("Modbus"),
            Description("地址长度")
        ]
        public uint AddrLen
        {
            set
            {
                if (addrLen == value) return;
                addrLen = value;
            }
            get { return this.addrLen; }
        }
        [
          Category("变量关联"),
          Description("根据变量名获取变量，更新控件")
       ]
        public string VariableName
        {
            set
            {
                if (variablename == value) return;
                variablename = value;
            }
            get { return this.variablename; }
        }
        private Base.HMICtrlBase.eAddrType dispalyAddrType = Base.HMICtrlBase.eAddrType.none;
        private uint dispalyAddr = 0;
        private bool enableDispaly = false;
        private eDisplayType displaytype = eDisplayType.none;
        private string dispalycondition = "";
        [
         Category("显示条件"),
         Description("显示条件使能")
       ]
        public bool EnableDispaly
        {
            set
            {
                if (enableDispaly == value) return;
                enableDispaly = value;
            }
            get { return this.enableDispaly; }
        }
        [
          Category("显示条件"),
          Description("显示条件地址类型")
        ]
        public Base.HMICtrlBase.eAddrType DispalyAddrType
        {
            set
            {
                if (dispalyAddrType == value) return;
                dispalyAddrType = value;
            }
            get { return this.dispalyAddrType; }
        }
        [
         Category("显示条件"),
         Description("显示条件地址")
       ]
        public uint DispalyAddr
        {
            set
            {
                if (dispalyAddr == value) return;
                dispalyAddr = value;
            }
            get { return this.dispalyAddr; }
        }
        [
         Category("显示条件"),
         Description("显示类型")
        ]
        public eDisplayType ControlDisplayType
        {
            set
            {
                if (displaytype == value) return;
                displaytype = value;
            }
            get { return this.displaytype; }
        }
        [
         Category("显示条件"),
         Description("显示条件")
        ]
        public string DispalyCondition
        {
            set
            {
                if (dispalycondition == value) return;
                dispalycondition = value;
            }
            get { return this.dispalycondition; }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            if(this.DisplayFlag)
                base.OnPaint(pe);
        }
        #region (* 事件 *)
        /// <summary>
        /// 状态改变事件
        /// </summary>
        public event PicValueChange PicValueChange;
        /// <summary>
        /// 委托调用方法
        /// </summary>
        /// <param name="e"></param>
        protected void OnPicValueChange(HMIPicEventArgs e)
        {
            if (this.PicValueChange != null)
                this.PicValueChange(this, e);
        }
        #endregion
    }
    #region (* 事件委托类*)
    /// <summary>
    /// 事件委托
    /// </summary>
    public class HMIPicEventArgs : EventArgs
    {
        private int value = 0;

        public HMIPicEventArgs()
        {
        }
        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
    #endregion
    #region
    public delegate void PicValueChange(object sender, HMIPicEventArgs e);
    #endregion
}
