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
    public partial class 开关管理 : Form
    {
        public 调试模块 tmp = null;

        public 开关管理()
        {
            InitializeComponent();
        }

        private void 开关管理_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < int.Parse( tmp.开关路数); i++)
            //{
            //    dataGridView1.Rows.Add(new string[] {"通道"+ tmp.开关列表[i].开关编号 , tmp.开关列表[i].开关名称 , tmp.开关列表[i].开关位置 });
            //}
            this.Text = "模块" + tmp.模块编号;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
