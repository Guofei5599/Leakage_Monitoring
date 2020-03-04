using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 注册机
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int[] m_intCode = new int[127];  //存储密钥  
        public char[] m_charASCII = new char[25];  //存储ASCII  
        public int[] m_intASCII = new int[25]; //存储ASCII的值  


        /// <summary>  
        /// 初始化密钥(通过模9生成)  
        /// </summary>  
        public void IntiIntCode()
        {
            for (int i = 0; i < m_intCode.Length; i++)
            {
                m_intCode[i] = i % 9;
            }
        }
        public string GetRegisterNum(string MachineNume)
        {
            IntiIntCode();
            //if (MachineNume.Length != 25)
            //    return "机器编码有误,请重新输入!";
            //通过机器码获取ASCII码  
            for (int i = 1; i < m_charASCII.Length; i++)
            {
                m_charASCII[i] = Convert.ToChar(MachineNume.Substring(i - 1, 1));
            }
            //通过简单算法，改变ASCII的值， ASCII的值，再加上初始化密钥的值  
            for (int j = 1; j < m_intASCII.Length; j++)
            {
                m_intASCII[j] = Convert.ToInt32(m_charASCII[j]) + m_intCode[Convert.ToInt32(m_charASCII[j])];
            }
            string MachineASCII = "";
            for (int k = 1; k < m_intASCII.Length; k++)
            {
                if ((m_intASCII[k] >= 48 && m_intASCII[k] <= 57) || (m_intASCII[k] >= 65 && m_intASCII[k] <= 90) || (m_intASCII[k] >= 97 && m_intASCII[k] <= 122))
                {
                    MachineASCII += Convert.ToChar(m_intASCII[k]).ToString();  //在0-9,A-Z,a-z之间  
                }
                else if (m_intASCII[k] > 122)
                {
                    MachineASCII += Convert.ToChar(m_intASCII[k] - 10).ToString(); //大于z  
                }
                else
                {
                    MachineASCII += Convert.ToChar(m_intASCII[k] - 9).ToString();
                }
            }
            return MachineASCII;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            //txt_机器码.Text = "";
            txt_注册码.Text = GetRegisterNum(txt_机器码.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
