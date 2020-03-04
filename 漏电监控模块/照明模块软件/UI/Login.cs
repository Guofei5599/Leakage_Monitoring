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
    public partial class Login : Form
    {
        public bool unLogin = false;
        public Login()
        {
            InitializeComponent();
        }

        private void txt_User_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txt_Password.Focus();
            }
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        List<sysParam> paramList;
        private void Login_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (AccessLib.CheckPassword(comboBox1.Text, txt_Password.Text) > 0)
                {
                    MainForm.UserName = comboBox1.Text;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("密码不正确！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录异常！");
            }
        }


        private void btn_Conn_Click(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        bool leftFlag = false;
        Point mouseOff;
        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            //鼠标指向检测
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
    }
}
