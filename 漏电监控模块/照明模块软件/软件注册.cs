using Microsoft.Win32;
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
    public partial class 软件注册 : Form
    {
        public 软件注册()
        {
            InitializeComponent();
        }
        private void 软件注册_Load(object sender, EventArgs e)
        {
            txt_机器码.Text =MainForm.softReg.GetMachineNum();
            bool b = MainForm.checkReg.GetIsReg();
            if (b)
            {
                txt_机器码.Visible = false;
                txt_注册码.Visible = false;
                btnReg.Enabled = false;
                lab_提示.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
            }
            else
            {
                txt_机器码.Visible = true;
                txt_注册码.Visible = true;
                btnReg.Enabled = true;
                lab_提示.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
            }
        }
        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_注册码.Text == MainForm.softReg.GetRegisterNum())
                {
                    MessageBox.Show("注册成功！重启软件后生效！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RegistryKey retkey = Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("mySoftWare").CreateSubKey("Register.INI").CreateSubKey(txt_注册码.Text);
                    retkey.SetValue("UserName", "Rsoft");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册码错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_注册码.SelectAll();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
