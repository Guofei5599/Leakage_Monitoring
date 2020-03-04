using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照明模块软件
{
    public partial class 注册界面 : Form
    {
        public 注册界面()
        {
            InitializeComponent();
        }

        private void btn_取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
