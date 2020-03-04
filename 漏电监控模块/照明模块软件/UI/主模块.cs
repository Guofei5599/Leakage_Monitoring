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
    public partial class 主模块 : Form
    {
        public delegate void ReFreshPanelDelegate();
        public static ReFreshPanelDelegate reFreshPanelDelegate;
        public static bool ReFreshPanelFlag = false;
        public 主模块()
        {
            InitializeComponent();
        }
        bool flag = false;
        private void 主模块_Load(object sender, EventArgs e)
        {
            reFreshPanelDelegate += ReFreshPanel;
            RefreshPanel1();
            flag = true;
            lab_地址重复.Text = "";
        }
        public void ReFreshPanel()
        {
            int count = 0;
            foreach (var v in MainModelPanel_1.Controls)
            {
                count += (v is MainModelPanel) ? 1 : 0;
            }
            if (count != ModelsOperate.ModelsList.Count || ReFreshPanelFlag)
            {
                RefreshPanel1();
                ReFreshPanelFlag = false;
            } 
        }
        public void RefreshForm(bool flag)
        {
            lab_提示.Visible = flag;
            lab_日出日落.Text = MainForm.日出日落时间;
            string s = "";
            if (MainForm.地址重复列表.Count > 0)
            {
                foreach (var v in MainForm.地址重复列表)
                    s += v + ",";
                s = s.TrimEnd(',');
                s += "地址重复：" + s;
            }
            else
                s = "";
            lab_地址重复.Text = s;
            if (!MainForm.isRegex)
            {
                //btn_AllClose.Enabled = false;
                //btn_AllOpen.Enabled = false;
                //btn_刷新.Enabled = false;
            }
            else
            {
                //btn_AllClose.Enabled = true;
                //btn_AllOpen.Enabled = true;
                //btn_刷新.Enabled = true;
            }
        }
        public void RefreshPanel()
        {
            if (ModelsOperate.PanelCreate)
            {
                RefreshPanel1();
                ModelsOperate.PanelCreate = false;
            }
            else
            {
                foreach (var v in ModelsOperate.ModelsList)
                {
                    RefreshPanel2(v);
                }
            }
            if (MainForm.通信状态 == 2)
            {
                通信状态1.LedColor = Color.Green;
                通信状态1.State = CAEA.Common.HMIControl.Led.HMILed.LedState.Blink;
            }
            else if (MainForm.通信状态 == 3)
            {
                通信状态1.LedColor = Color.Red;
                通信状态1.State = CAEA.Common.HMIControl.Led.HMILed.LedState.On;
            }
            else
            {
                通信状态1.State = CAEA.Common.HMIControl.Led.HMILed.LedState.Off;
            }
        }

        public void RefreshPanel1()
        {
            int max = ModelsOperate.GetMaxAddr();
            //if (max == 0)
            //{
            //    max = 16;
            //    for (int i = 0; i < max; i++)
            //        ModelsOperate.Add(i+1,1);
            //}
            if(max > 0)
                PanelLayout(200, 140, max);
        }

        public void RefreshPanel2(调试模块 tmp)
        {
            Control [] c = MainModelPanel_1.Controls.Find("模块" + tmp.模块编号.ToString(), false);
            if (c != null && c.Count() != 0 && c[0] is MainModelPanel)
            {
                MainModelPanel mainModelPanel = (c[0] as MainModelPanel);
                mainModelPanel.RefreshPanel(tmp.模块编号,tmp.模块类型,tmp.State, tmp.FalutState);
            }
        }

        public void PanelLayout(int setWitdh = 200, int setHeight = 140, int count = 16)
        {
            for (int t = 0; t < MainModelPanel_1.Controls.Count;)
            {
                if (MainModelPanel_1.Controls[t] is MainModelPanel)
                    MainModelPanel_1.Controls.Remove(MainModelPanel_1.Controls[t] as MainModelPanel);
                else
                    t++;
            }
            int initSetWitdh = setWitdh;
            int initSetHeight = setHeight;
            int cols = MainModelPanel_1.Width / setWitdh;
            //int rows = MainModelPanel_1.Height / setHeight;
            int rows = (count % cols) == 0? (count / cols): (count / cols)+1;
            //rows = MainModelPanel_1.Height / setHeight;
            bool b = true;
            //while (true)
            //{
            //    if (cols * rows < count)
            //    {
            //        //if (MainModelPanel.Height < rows * setHeight)
            //        //    MainModelPanel.Height = rows * setHeight;
            //        //if(MainModelPanel.Width < cols * setWitdh)
            //        //    MainModelPanel.Width = cols * setWitdh;
            //        if (b)
            //        {
            //            //setWitdh = (int)(setWitdh - setWitdh * 0.1);
            //            //setHeight = (int)(setHeight - setHeight * 0.1);
            //            setWitdh = (int)(setWitdh - 0);
            //            setHeight = (int)(setHeight - 0);
            //            cols = MainModelPanel_1.Width / setWitdh;
            //        }
            //        if (setWitdh < initSetWitdh * 0.5)
            //        {
            //            b = false;
            //            rows++;
            //        }
            //    }
            //    else
            //        break;
            //}
            //MainModelPanel.Height += 30;
            int xmargin = (MainModelPanel_1.Width - setWitdh * cols) / 3;
            //int ymargin = 30;
            //int ymargin = (MainModelPanel.Height - setHeight * rows) / 2;
            int tmpCount = 0;
            int i;
            for ( i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (tmpCount < count)
                    {
                        int w = (int)(setWitdh);
                        int l = (int)(setHeight);
                        MainModelPanel tmp1 = new MainModelPanel(w, l, ModelsOperate.ModelsList[tmpCount].模块编号,  ModelsOperate.ModelsList[tmpCount].模块类型, ModelsOperate.ModelsList[tmpCount].State);
                        tmp1.ButtonClick += new ValuEventHandler(MainPanel_Click);
                        tmp1.Location = new Point((int)(xmargin + setWitdh * j), (int)(setHeight * i));
                        MainModelPanel_1.Controls.Add(tmp1);
                        tmpCount++;
                    }
                }
            }
        }

        private void MainPanel_Click(object sender, 调试模块 e)
        {
            if(MainForm.isRegex)
                MainForm.deleDoWork(e);
        }

        private void 主模块_SizeChanged(object sender, EventArgs e)
        {
            if(flag)
              PanelLayout(200,140,ModelsOperate.ModelsList.Count);
        }

        private void btn_模块管理_Click(object sender, EventArgs e)
        {
            模块管理界面 frm = new 模块管理界面();
            frm.ShowDialog();
            ReFreshPanelFlag = true;
            ModelsOperate.ModelsList = ModelsOperate.AllModelsList.FindAll(t => !t.IsRemove);
            //ModelsOperate.LoadModelMsg();
        }

        private void MainModelPanel_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
