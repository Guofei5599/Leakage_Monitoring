using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 系统信息生成
{
    public partial class 编码转换 : Form
    {
        public 编码转换()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_标题掩码.Text.Length == 0)
            {
                textBox1.Text = "";
                MessageBox.Show("输入框内容不能为空！");
                return;
            }
            byte[] tmp = Encoding.Default.GetBytes(txt_标题掩码.Text);
            textBox1.Text = BitConverter.ToString(tmp,0);
        }
    }
}
