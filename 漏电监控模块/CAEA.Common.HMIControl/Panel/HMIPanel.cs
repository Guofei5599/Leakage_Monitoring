using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAEA.Common.HMIControl.Panel
{
    public partial class HMIPanel :System.Windows.Forms.Panel
    {
        public HMIPanel()
        {
            InitializeComponent();
        }

        private int gwno = 0;
        private bool valid = false;

        [
            Category("工位信息"),
            Description("工位信息")
        ]
        public bool Valid
        {
            set
            {
                if (valid == value) return;
                valid = value;
            }
            get { return this.valid; }
        }

        [
            Category("工位信息"),
            Description("工位信息")
        ]
        public int GWNO
        {
            set
            {
                if (gwno == value) return;
                    gwno = value;
            }
            get { return this.gwno; }
        }
    }
}
