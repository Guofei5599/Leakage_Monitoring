using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照明模块软件
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login log = new Login();
            if (log.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
            else
                Application.Exit();
           
        }
    }
}
