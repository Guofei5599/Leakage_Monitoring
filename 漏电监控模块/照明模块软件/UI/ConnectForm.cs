using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerialCardReaderLib;

namespace 照明模块软件
{
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            foreach (var v in System.IO.Ports.SerialPort.GetPortNames())
            {
                comb_Serial.Items.Add(v);
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {

                SerialReadBase readBase = new SerialReadBase(comb_Serial.Text, int.Parse(comb_Baud.Text));
                MainForm.CommMaster = new Master(readBase);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
