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
    public partial class 场景模块添加界面 : Form
    {
        public List< string> 模块编号 = new List<string>();
        public 场景模块添加界面()
        {
            InitializeComponent();
        }

        private void 场景模块添加界面_Load(object sender, EventArgs e)
        {
            //combo_Addr.Items.Clear();
            //foreach (var v in ModelsOperate.ModelsList)
            //    combo_Addr.Items.Add(v.模块编号);
            checkedListBox1.Items.Clear();
            foreach (var v in ModelsOperate.ModelsList)
                checkedListBox1.Items.Add(v.模块编号);
            checkedListBox1.CheckOnClick = true;
        }

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            //if (combo_Addr.SelectedIndex == -1)
            //{
            //    MessageBox.Show("请选择地址！");
            //    return;
            //}

            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    模块编号.Add(checkedListBox1.GetItemText(checkedListBox1.Items[i]));
                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_全选_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void btn_反选_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, !checkedListBox1.GetItemChecked(i));
            }
        }
    }
}
