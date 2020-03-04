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
    public partial class 故障查询 : Form
    {
        public 故障查询()
        {
            InitializeComponent();
        }

        private void btn_退出_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            AccessLib.DeleteError(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"), dateTimePicker1.Value.Date.AddDays(1).ToString("yyyy-MM-dd"));
            btn_查询.PerformClick();
        }

        private void btn_查询_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataTable dt = AccessLib.GetError(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"), dateTimePicker2.Value.Date.AddDays(1).ToString("yyyy-MM-dd"));
            int j = 0;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int index = dataGridView1.Rows.Add(new string[] {Convert.ToString(row[1]),Convert.ToString(row[2]), Convert.ToString(row[3]), Convert.ToString(row[4]), Convert.ToString(row[5]), Convert.ToString(row[6]) });
                    dataGridView1.Rows[index].HeaderCell.Value = Convert.ToString(j+1);
                    j++;
                }
            }
        }
    }
}
