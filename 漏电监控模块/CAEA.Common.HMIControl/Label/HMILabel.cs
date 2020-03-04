using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.Label
{
    public partial class HMILabel : HMICtrlBase
    {
        public HMILabel()
        {
            InitializeComponent();
            this.label1.TextChanged += new EventHandler(OnValueChange);
        }
        public enum DisplayType
        {
            ASCII = 0,
            DEC,
            HEX,
            GB2312,
            DicString
        }

        private Base.HMICtrlBase.eAddrType addrType = Base.HMICtrlBase.eAddrType.none;
        private uint startAddr = 0;
        private uint addrLen = 0;
        private string VALUE;
        private DisplayType displaytype = 0;
        private string disarray = "";
        private string suffixe = "";
        /// <summary>
        /// 设置显示格式
        /// </summary>

        private int nombre = 0; 
        [
            Category("Display"),
            Description("小数位数")
        ]
        public int Nombre
        {
            set
            {
                if (this.nombre == value)
                    return;
                this.nombre = value;
            }

            get { return this.nombre; }
        }

        [
           Category("Display"),
           Description("显示字符串")
        ]
        public string DisArray
        {
            set
            {
                if (disarray == value) return;
                disarray = value;
            }
            get
            {
                return this.disarray;
            }
        }

        [
           Category("Display"),
           Description("后缀")
        ]
        public string Suffixe
        {
            set
            {
                if (suffixe == value) return;
                suffixe = value;
            }
            get
            {
                return this.suffixe;
            }
        }

        [
           Category("数据"),
           Description("值")
        ]
        public string Value
        {
            set
            {
                label1.Text = value;
                if (VALUE == value) return;
                VALUE = value;
                this.Size = label1.Size;
            }
            get
            {
                return this.VALUE;
            }
        }

        [
            Category("Display"),
            Description("数据显示类型")
        ]
        public DisplayType Displaytype
        {
            set
            {
                if (displaytype == value) return;
                displaytype = value;
            }
            get { return this.displaytype; }
        }

        private bool hightolow = true;
        [
            Category("Display"),
            Description("高低位数据转换")
        ]
        public bool HighToLow
        {
            set
            {
                if (hightolow == value)
                    return;
                this.hightolow = value;
                this.Invalidate();
            }
            get { return this.hightolow; }
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
        public event EventHandler ValueChange;
        public void OnValueChange(object sender,System.EventArgs e)
        {
            if (ValueChange != null)
                ValueChange(this,e);
        }
    }
}
