using SerialCardReaderLib;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照明模块软件
{
    public partial class MainForm : Form
    {
        [Serializable]
        public class 公休日
        {
            public string 日期 { set; get; }
            public string 说明 { set; get; }
        }
        public static sysParam currentParam;
        public delegate void DeleDoWork(调试模块 tmp);
        public static DeleDoWork deleDoWork;
        public delegate bool DeleDoInspect(bool first);
        public static DeleDoInspect deleDoInspect;
        public static DeleDoInspect deleEachDoInspect;
        public static IMaster CommMaster;
        public static bool OpenModel;
        public static List<公休日> 国家公休日列表;
        public static List<string> 地址重复列表 = new List<string>();
        public static ConcurrentDictionary<string, ModlesMsg> WriteDic = new ConcurrentDictionary<string, ModlesMsg>();
        public static ConcurrentDictionary<string, ModlesMsg> UpWriteDic = new ConcurrentDictionary<string, ModlesMsg>();
        public static string 日出日落时间 = "";
        public static string 日出时间 = "";
        public static string 日落时间 = "";
        public static string UserName = "";
        public MainForm()
        {
            InitializeComponent();
        }

        public static SoftReg softReg = new SoftReg();
        public static CheckReg checkReg = new CheckReg();
        public static string tipRegister = "";
        public static bool isRegex = true;
        private void Inti()
        {
            //txtb_MachineNum.Text = softReg.GetMachineNum();
            if (checkReg.GetIsReg())
            {
                tipRegister = "软件已注册";
            }
            else
            {
                double count = 0;
                if (checkReg.GetUseInfo(ref count))
                {
                    this.Text += string.Format("(试用3天，剩余{0}天)", count.ToString());
                    tipRegister = string.Format(" - 试用3天，剩余{0}天", count.ToString());
                }
                else
                {
                    软件注册 frm = new 软件注册();
                    frm.Text += tipRegister;
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        isRegex = false;
                        //Application.Exit();
                    }
                    else
                    {
                        isRegex = true;
                    }
                }
            }
        }

        public static string getstring(string code)
        {
            try
            {
                string[] s = code.Split('-');
                List<byte> list = new List<byte>();
                foreach (var v in s)
                {
                    list.Add(byte.Parse(v, System.Globalization.NumberStyles.HexNumber));
                }
                return Encoding.Default.GetString(list.ToArray());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void InitMsg()
        {
            string s = currentParam.标题;
            if (tipRegister == "软件已注册")
            {
                this.Text = s == null ? "获取标题异常" : s;
            }
            else
            {
                this.Text = (s == null ? "获取标题异常" : s) + tipRegister;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (MainForm.UserName != "管理员")
            {
                btn_场景设置.Enabled = false;
                btn_场景设置.BackColor = Color.LightGray;
                btn_场景设置.ForeColor = Color.White;
                btn_参数设置.Enabled = false;
                btn_参数设置.BackColor = Color.LightGray;
                btn_参数设置.ForeColor = Color.White;
            }
            try
            {
                Inti();
            }
            catch (Exception ex)
            {

            }
            CheckForIllegalCrossThreadCalls = false;
            var tmpList = ConfigClass.LoadClass<sysParam>("config.dat");
            if (tmpList == null)
            {
                tmpList = new sysParam();
            }
            currentParam = tmpList;

            var tmpList1 = ConfigClass.LoadCookie<场景模块>("场景模块.dat");
            if (tmpList1 == null )
            {
                tmpList1 = new List<场景模块>();
            }
            场景设置.当前场景模块 = tmpList1;

            var tmpList2 = ConfigClass.LoadCookie<公休日>("国家公休日.dat");
            if (tmpList2 == null)
            {
                tmpList2 = new List<公休日>();
            }
            国家公休日列表 = tmpList2;
            foreach (var v in 场景设置.当前场景模块)
            {
                if (v.场景子名称列表 != null)
                {
                    foreach (var v1 in v.场景子名称列表)
                    {
                        //v1.closestate = 0;
                        //v1.openstate = 0;
                    }
                }
            }

            btn_模块监控_Click(null, null);
            try
            {
                var dt1 = 计算日出日落.计算日出时间(MainForm.currentParam.经度, MainForm.currentParam.维度, DateTime.Now);
                var dt2 = 计算日出日落.计算日落时间(MainForm.currentParam.经度, MainForm.currentParam.维度, DateTime.Now);
                MainForm.日出日落时间 = string.Format("日出:{0} 日落:{1}", dt1.ToString("HH:mm:ss"), dt2.ToString("HH:mm:ss"));
                MainForm.日出时间 = dt1.ToString("HH:mm:ss");
                MainForm.日落时间 = dt2.ToString("HH:mm:ss");
                //ModelsOperate.LoadModelMsg();
                var tmpList3 = ConfigClass.LoadCookie<调试模块>("model.dat");
                if (tmpList3 == null)
                {
                    tmpList3 = new List<调试模块>();
                }
                ModelsOperate.AllModelsList = tmpList3.OrderBy(t => int.Parse(t.模块编号)).ToList();
                ModelsOperate.ModelsList = ModelsOperate.AllModelsList.FindAll(t=>!t.IsRemove);
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取数据异常，请检查是否安装Access数据库组件");
                Application.Exit();
            }
            deleDoWork += OpenSubPanel;
            InitPort();
            frm_主模块.RefreshPanel();
            timer1.Enabled = true;
        }
        private bool InitPort()
        {
            try
            {
                if (MainForm.currentParam.串口通信选择)
                {
                    CommMaster = new Master(new SerialReadBase(currentParam.串口名称, currentParam.波特率));
                    return true;
                }
                else
                {
                    CommMaster = new TcpMaster(new TcpReadBase(currentParam.IP地址, currentParam.端口,500));
                    return true;
                }
               
            }
            catch (Exception ex)
            {
                通信状态 = 3;
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public T New_Form<T>(T Form) where T : Form, new()
        {
            if (WorkSpace.Controls.Contains(Form))
            {
                WorkSpace.Controls.SetChildIndex(Form, 0);
                Form.Width = WorkSpace.Width;
                Form.Height = WorkSpace.Height;
                Form.WindowState = FormWindowState.Maximized;
            }
            else
            {
                Form = new T();
                Form.TopLevel = false;
                WorkSpace.Controls.Add(Form);
                WorkSpace.Controls.SetChildIndex(Form, 0);
                Form.Width = WorkSpace.Width;
                Form.Height = WorkSpace.Height;
                Form.Show();
            }
            return Form;
        }

        主模块 frm_主模块 = null;
        private void btn_模块监控_Click(object sender, EventArgs e)
        {
            frm_主模块 = New_Form<主模块>(frm_主模块);
        }
        开关模块界面 frm_开关模块界面 = null;
        private void btn_开关监控_Click(object sender, EventArgs e)
        {
            if (调试界面.flag)
                return;
            //frm_开关模块界面 = New_Form<开关模块界面>(frm_开关模块界面);
            调试界面 frm = new 调试界面();
            frm.Show();
        }

        public void OpenSubPanel(调试模块 tmp)
        {
            ModlesMsg modlesMsg = new ModlesMsg()
            {
                addr = int.Parse(tmp.模块编号),
                模块类型 = "模块查询"
            };
            MainForm.UpWriteDic.AddOrUpdate(tmp.模块编号 + "," + "查询", modlesMsg, (key, value) => value);

            ModlesMsg modlesMsg1 = new ModlesMsg()
            {
                addr = int.Parse(tmp.模块编号),
                模块类型 = "信息查询"
            };
            MainForm.UpWriteDic.AddOrUpdate(tmp.模块编号 + "," + "信息", modlesMsg, (key, value) => value);
            OpenModel = true;

            //frm_开关模块界面 = New_Form<开关模块界面>(frm_开关模块界面);
            //frm_开关模块界面.tmp = tmp;
            //frm_开关模块界面.PanelLayout();
            
        }
        故障查询 frm_故障查询;
        private void btn_故障查询_Click(object sender, EventArgs e)
        {
            frm_故障查询 = New_Form<故障查询>(frm_故障查询);
        }

        场景设置 frm_场景设置;
        private void btn_场景设置_Click(object sender, EventArgs e)
        {
            frm_场景设置 = New_Form<场景设置>(frm_场景设置);
        }

        参数设置 frm_参数设置;
        private void btn_参数设置_Click(object sender, EventArgs e)
        {
            frm_参数设置 = New_Form<参数设置>(frm_参数设置);
        }

        private void btn_退出_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            foreach (var v in WorkSpace.Controls)
            {
                if (v is Form)
                {
                    (v as Form).Width = WorkSpace.Width;
                    (v as Form).Height = WorkSpace.Height;
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_软件注册_Click(object sender, EventArgs e)
        {
            软件注册 frm = new 软件注册();
            frm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRegex)
            {
                if (MessageBox.Show("确定退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
                ConfigClass.SaveCookie_List(ModelsOperate.AllModelsList,"model.dat");
            }
        }

        public void DOInquire(调试模块 tmp)
        {
            ModlesMsg modlesMsg = new ModlesMsg()
            {
                addr = int.Parse(tmp.模块编号),
                模块类型 = "模块查询"
            };
            MainForm.WriteDic.AddOrUpdate(tmp.模块编号 + "," + "查询", modlesMsg, (key, value) => value);
        }

        List<string> tmpRepeadList = new List<string>();
        public static int 通信状态 ;
        public static int pre_通信状态;
        public static int 通信状态1;
        DateTime LastReadDatetime = DateTime.Now;
        DateTime LastWriteDatetime = DateTime.Now;
        DateTime lastFailCommTime = DateTime.Now;
        public int CurreentInquireindex = 0;
        DateTime LastInquireDatetime = DateTime.Now;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if ((DateTime.Now - LastInquireDatetime).TotalMilliseconds > 300 && Communication.GetDoCommState() != 1 && UpWriteDic.Count == 0)
            {
                if (ModelsOperate.ModelsList.Count > 0)
                {
                    if (CurreentInquireindex >= ModelsOperate.ModelsList.Count)
                        CurreentInquireindex = 0;
                    DOInquire(ModelsOperate.ModelsList[CurreentInquireindex]);
                    CurreentInquireindex++;
                }
                //LastInquireDatetime = DateTime.Now;
            }
            if (!isRegex)
            {
                btn_场景设置.Enabled = false;
            }
            else
            {
                if(MainForm.UserName == "管理员")
                    btn_场景设置.Enabled = true;
            }
            DateTime tmpDate = DateTime.Now;
            当前时间.Text = tmpDate.ToString("yyyy/MM/dd HH:mm:ss");
            if (frm_主模块 != null)
                frm_主模块.RefreshForm(Communication.RoutInspecting || Communication.EachRoutInspecting);
            if (frm_开关模块界面 != null)
                frm_开关模块界面.RefreshForm(Communication.RoutInspecting || Communication.EachRoutInspecting);
            if (Communication.GetDoCommState() == 2)
            {
                int index = 0;
                CommState state = Communication.GetCommState();
                OperateResult result = Communication.EndDoCommunication();
                if (result.IsSuccess == false)
                {
                    switch (state)
                    {
                        #region "数据处理"
                        case CommState.GetModlesMsg:
                            if ((index = ModelsOperate.ModelsList.FindIndex(t => t.模块编号 == Communication.CurrentAddr.ToString())) != -1)
                            {
                                ModelsOperate.ModelsList[index].State = 3;
                                ModelsOperate.ModelsList[index].FalutState = 3;
                                if (OpenModel)
                                    OpenModel = false;
                            }
                            frm_主模块.RefreshPanel();
                            if (frm_开关模块界面 != null)
                                frm_开关模块界面.RefreshPanel();
                            break;
                        case CommState.GetModlesAllMsg:
                            if ((index = ModelsOperate.ModelsList.FindIndex(t => t.模块编号 == Communication.CurrentAddr.ToString())) != -1)
                            {
                                ModelsOperate.ModelsList[index].State = 3;
                                ModelsOperate.ModelsList[index].FalutState = 3;
                                if (OpenModel)
                                    OpenModel = false;
                            }
                            break;
                        case CommState.SetModles_TK:
                            break;
                        case CommState.SetModles_Reset:
                            //通信状态 = 3;
                            break;
                            #endregion
                    }
                }
                else
                {
                    index = 0;
                    if (result.IsSuccess)
                    {
                        List<byte[]> tmpList = new List<byte[]>();
                        switch (state)
                        {
                            #region "数据处理"
                            case CommState.GetModlesMsg:
                                通信状态 = 2;
                                for (int i = 0; i < result.ResultData.Length; i += 13)
                                {
                                    if (result.ResultData.Length < i + 13)
                                        continue;
                                    if ((result.ResultData[i] & 0x80) > 0 && result.ResultData[i + 1] == 0 && result.ResultData[i + 2] == 0)
                                    {
                                        continue;
                                    }
                                    byte[] b = new byte[13];
                                    Array.Copy(result.ResultData, i, b, 0, 13);
                                    tmpList.Add(b);
                                }
                                tmpList = tmpList.OrderBy(t => (t[3] << 8 | t[4])).ToList();
                                ModelsOperate.RefreshModel(tmpList);
                                frm_主模块.RefreshPanel();
                                if (frm_开关模块界面 != null)
                                    frm_开关模块界面.RefreshPanel();
                                LastInquireDatetime = DateTime.Now;
                                break;
                            case CommState.GetModlesAllMsg:
                                if ((index = ModelsOperate.ModelsList.FindIndex(t => t.模块编号 == Communication.CurrentAddr.ToString())) != -1)
                                {
                                    if (OpenModel == true)
                                    {
                                        frm_开关模块界面 = New_Form<开关模块界面>(frm_开关模块界面);
                                        frm_开关模块界面.tmp = ModelsOperate.ModelsList[index];
                                        OpenModel = false;
                                    }
                                }
                                for (int i = 0; i < result.ResultData.Length; i += 13)
                                {
                                    byte[] b = new byte[13];
                                    Array.Copy(result.ResultData, i, b, 0, 13);
                                    tmpList.Add(b);
                                }
                                if (tmpList.Count > 0)
                                    tmpList = tmpList.OrderBy(t => (t[4] << 8 | t[5])).ToList();
                                ModelsOperate.RefreshModel(tmpList);
                                if (frm_开关模块界面 != null)
                                    frm_开关模块界面.RefreshPanel();
                                break;
                            case CommState.SetModles_TK:
                               
                                break;
                            case CommState.SetModles_Reset:

                                break;
                                #endregion
                        }
                    }
                }
            }
            if ((DateTime.Now - LastReadDatetime).TotalMilliseconds > currentParam.接收速度 && MainForm.CommMaster != null)
            {
                LastReadDatetime = DateTime.Now;
                OperateResult operateResult;
                byte[] tmp = Communication.CommReadData(out operateResult);
                if (operateResult.IsSuccess)
                {
                    List<byte[]> tmpList = new List<byte[]>();
                    for (int i = 0; i < operateResult.ResultData.Length; i += 13)
                    {
                        if (operateResult.ResultData.Length < i + 13)
                            continue;
                        if ((operateResult.ResultData[i] & 0x80) > 0 && operateResult.ResultData[i + 1] == 0 && operateResult.ResultData[i + 2] == 0)
                            continue;
                        byte[] b = new byte[13];
                        Array.Copy(operateResult.ResultData, i, b, 0, 13);
                        tmpList.Add(b);
                    }
                    tmpList = tmpList.OrderBy(t => (t[4] << 8 | t[5])).ToList();
                    ModelsOperate.RefreshModel(tmpList);
                    if (frm_开关模块界面 != null)
                        frm_开关模块界面.RefreshPanel();
                }
            }
            if ((DateTime.Now - LastWriteDatetime).TotalMilliseconds > currentParam.发送速度 && (MainForm.WriteDic.Count() > 0 || MainForm.UpWriteDic.Count() > 0) && Communication.GetDoCommState() != 1 && !Communication.RoutInspecting && !Communication.EachRoutInspecting)
            {
                LastWriteDatetime = DateTime.Now;
                ModlesMsg v;
                if (MainForm.UpWriteDic.Count > 0)
                {
                    MainForm.UpWriteDic.TryRemove(MainForm.UpWriteDic.ElementAt(0).Key, out v);
                }
                else
                {
                    MainForm.WriteDic.TryRemove(MainForm.WriteDic.ElementAt(0).Key, out v);
                }
                if (v.模块类型 == "模块查询")
                {
                    v.Function = CommState.GetModlesMsg;
                    Communication.BeginDoCommunication(v);
                }
                else if (v.模块类型 == "信息查询")
                {
                    v.Function = CommState.GetModlesAllMsg;
                    Communication.BeginDoCommunication(v);
                }
                else
                {
                    switch (v.action)
                    {
                        case ActionState.脱扣:
                            v.Function = CommState.SetModles_TK;
                            Communication.BeginDoCommunication(v);
                            break;
                        case ActionState.复位:
                            v.Function = CommState.SetModles_Reset;
                            Communication.BeginDoCommunication(v);
                            break;
                    }
                }
            }
            timer1.Start();
            label2.Text = (DateTime.Now - tmpDate).TotalMilliseconds.ToString();
            InitMsg();
        }

        DateTime pre_Date = DateTime.Now;
        private void timerWrite_Tick(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// DORountInspect(true);
            //ModlesMsg v = new ModlesMsg();
            //v.模块类型 = "调光模块";
            //v.bit = 10;
            ////v.value = 10;
            //v.bitArray = new ushort[] { 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1 };
            //v.valueArray = new int[] { 1, 2, 3, 4, 5, 6, 0, 0, 1, 2, 0, 0, 0, 0, 3, 4 };
            //if (v.模块类型 == "调光模块")
            //{
            //    if (v.bit > 8)
            //        v.Function = CommState.LightModlesOpenScene9_16;
            //    else
            //        v.Function = CommState.LightModlesOpenScene1_8;
            //}
            //Communication.BeginDoCommunication(v);
        }

        private void btn_关于_Click(object sender, EventArgs e)
        {
            关于 frm = new 关于();
            frm.ShowDialog();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.D)
            {
                调试界面 frm = new 调试界面();
                frm.Show();
            }
            if (e.Control && e.Alt && e.KeyCode == Keys.T)
            {
                if (WorkSpace.Controls[0] is 参数设置)
                {
                    if (frm_参数设置 != null)
                        frm_参数设置.displayGxb();
                }
            }
        }
    }
}
