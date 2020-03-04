using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using CAEA.Common.HMIControl.Button;

namespace 照明模块软件
{
    public delegate void ValuEventHandler(object sender, 调试模块 e);
    public class MainModelPanel:Panel
    {
        public event ValuEventHandler ButtonClick;
        int faultState = 0;
        public int FaultState
        {
            get { return faultState; }
            set
            {
                if (faultState != value )
                {
                    faultState = value;
                    if (faultState == 3)
                    {
                        if (AddrNumber == null)
                            return;
                        var tmp = ModelsOperate.GetModel(int.Parse(AddrNumber));
                        if (tmp == null)
                            return;
                        AccessLib.SaveError(new FaultModles()
                        {
                            故障时间 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            模块地址 = tmp.模块编号,
                            模块名称 = tmp.模块名称,
                            模块位置 = tmp.安装位置,
                            故障代码 = "01",
                            故障描述 = "连接断开"
                        });
                    }
                }
            }
        }
        public string AddrNumber { set; get; }

        string tmom = "";
        public string ModlesType
        {
            set
            {
                if (tmom != value)
                {
                    tmom = value;
                    addAcre();
                    //Color c1 = drawColor;
                    //if (tmom != "调光模块")
                    //    c1 = Color.LimeGreen;
                    //Rectangle rect = new Rectangle(5, 5, this.Width - 10, this.Height - 10);
                    //int cRadius = 15;  // 圆角半径
                    //GraphicsPath myPath1 = new GraphicsPath();
                    //myPath1.StartFigure();
                    //myPath1.AddLine(new Point(rect.Right - cRadius - 5, rect.Y), new Point(rect.Right - cRadius, rect.Y));
                    //myPath1.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 270, 90);
                    //myPath1.AddLine(new Point(rect.Right, rect.Y + cRadius), new Point(rect.Right, rect.Top + cRadius + 5));
                    //myPath1.AddLine(new Point(rect.Right - cRadius - 5, rect.Y), new Point(rect.Right, rect.Top + cRadius + 5));
                    ////Color c1 = Color.Red;
                    //var e = this.CreateGraphics();
                    //e.DrawPath(new Pen(c1, 1), myPath1);
                    //SolidBrush mysbrush2 = new SolidBrush(c1);
                    //e.FillPath(mysbrush2, myPath1);
                }
            }
            get { return tmom; }
        }
        public int State { set; get; }
        Label numLable;
        Label typeLable;
        private Color drawColor = Color.FromArgb(220, 220, 220);
        public MainModelPanel(int width,int length,string addrNumber,string modlesType,int state)
        {
            this.Size = new Size(width, length);
            this.Paint += onPain;
            this.Name = "模块" + addrNumber.ToString();
            AddrNumber = addrNumber;
            numLable = new Label();
            numLable.AutoSize = true;
            numLable.Text = "地 址："+ addrNumber;
            numLable.ForeColor = SystemColors.ControlDarkDark;
            numLable.Font = new Font("宋体",7, FontStyle.Regular);
            numLable.Location = new Point((this.Width - numLable.PreferredWidth) / 2, (this.Height - 2* numLable.Height-10)/2);
            //numLable.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            numLable.BackColor = Color.Transparent;
            this.Controls.Add(numLable);

            typeLable = new Label();
            typeLable.AutoSize = true;
            typeLable.Text = "开关通道：" + modlesType;
            typeLable.ForeColor = Color.DodgerBlue;
            typeLable.Font = new Font(typeLable.Font, FontStyle.Bold);
            typeLable.Location = new Point((this.Width - typeLable.PreferredWidth) / 2, (this.Height - 2 * numLable.Height) / 2 + numLable.Height);
            //typeLable.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            typeLable.BackColor = Color.Transparent;
            this.Controls.Add(typeLable);
            RefreshPanel(addrNumber, modlesType,state, state);

            this.Click += new EventHandler(Panel_Click);
            numLable.Click += new EventHandler(numLabel_Click);
            typeLable.Click += new EventHandler(typeLable_Click);
        }

        public void addAcre()
        {
            Color c1 = drawColor;
            //if (tmom == "调光模块")
            if (tmom == "调光模块")
                c1 = Color.LimeGreen;
            Rectangle rect = new Rectangle(5, 5, this.Width - 10, this.Height - 10);
            int cRadius = 15;  // 圆角半径
            GraphicsPath myPath1 = new GraphicsPath();
            myPath1.StartFigure();
            myPath1.AddLine(new Point(rect.Right - cRadius - 5, rect.Y), new Point(rect.Right - cRadius, rect.Y));
            myPath1.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 270, 90);
            myPath1.AddLine(new Point(rect.Right, rect.Y + cRadius), new Point(rect.Right, rect.Top + cRadius + 5));
            myPath1.AddLine(new Point(rect.Right - cRadius - 5, rect.Y), new Point(rect.Right, rect.Top + cRadius + 5));
            //Color c1 = Color.Red;
            var e = this.CreateGraphics();
            e.DrawPath(new Pen(c1, 1), myPath1);
            SolidBrush mysbrush2 = new SolidBrush(c1);
            e.FillPath(mysbrush2, myPath1);
        }

        private void typeLable_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }

        private void numLabel_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }

        private void Panel_Click(object sender,EventArgs e)
        {
            var tmp = ModelsOperate.GetModel(int.Parse(AddrNumber));
            if(ButtonClick != null)
                ButtonClick(sender, tmp);
        }

        private void onPain(object sender, PaintEventArgs e)
        {
            // 要实现 圆角化的 矩形
            Rectangle rect = new Rectangle(5, 5, this.Width - 10, this.Height - 10);
            int cRadius = 15;  // 圆角半径

            // 指定图形路径， 有一系列 直线/曲线 组成
            GraphicsPath myPath = new GraphicsPath();
            myPath.StartFigure();
            myPath.AddArc(new Rectangle(new Point(rect.X, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 180, 90);
            myPath.AddLine(new Point(rect.X + cRadius, rect.Y), new Point(rect.Right - cRadius, rect.Y));
            myPath.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 270, 90);
            myPath.AddLine(new Point(rect.Right, rect.Y + cRadius), new Point(rect.Right, rect.Bottom - cRadius));
            myPath.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Bottom - 2 * cRadius), new Size(2 * cRadius, 2 * cRadius)), 0, 90);
            myPath.AddLine(new Point(rect.Right - cRadius, rect.Bottom), new Point(rect.X + cRadius, rect.Bottom));
            myPath.AddArc(new Rectangle(new Point(rect.X, rect.Bottom - 2 * cRadius), new Size(2 * cRadius, 2 * cRadius)), 90, 90);
            myPath.AddLine(new Point(rect.X, rect.Bottom - cRadius), new Point(rect.X, rect.Y + cRadius));
            myPath.CloseFigure();
            Color c = drawColor;
            e.Graphics.DrawPath(new Pen(c, 1), myPath);
            SolidBrush mysbrush1 = new SolidBrush(c);
            e.Graphics.FillPath(mysbrush1, myPath);

            addAcre();
            //GraphicsPath myPath1 = new GraphicsPath();
            //myPath1.StartFigure();
            //myPath1.AddLine(new Point(rect.Right - 2*cRadius, rect.Y), new Point(rect.Right - cRadius, rect.Y));
            //myPath1.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 270, 90);
            //myPath1.AddLine(new Point(rect.Right, rect.Y + cRadius), new Point(rect.Right, rect.Top + 2*cRadius));
            //myPath1.AddLine(new Point(rect.Right - 2 * cRadius, rect.Y), new Point(rect.Right, rect.Top + 2 * cRadius));
            //Color c1 = Color.Red;
            //e.Graphics.DrawPath(new Pen(c1, 1), myPath1);
            //SolidBrush mysbrush2 = new SolidBrush(c1);
            //e.Graphics.FillPath(mysbrush2, myPath1);
        }

        public void RefreshPanel(string addrNumber, string modlesType,int state,int falut)
        {
            //string s = "";
            //if (modlesType == "开关模块")
            //    s = "开关型";
            //else if (modlesType == "调光模块")
            //    s = "调光型";
            //else
            //    s = "未获取";
            numLable.Text = addrNumber + "：" + modlesType;
            numLable.BackColor = Color.Transparent;
            var v = ModelsOperate.GetModel(int.Parse(addrNumber));
            typeLable.Text =  v.模块名称;
            numLable.Location = new Point((this.Width - numLable.PreferredWidth - 13), (17));
            typeLable.Location = new Point((this.Width - typeLable.PreferredWidth) / 2, (this.Height - 2 * numLable.Height) / 2 + numLable.Height);
            if (State != state)
            {
                if (state == 0)
                {
                    drawColor = SystemColors.ControlLight;
                }
                else if (state == 2)
                {
                    drawColor = Color.PaleTurquoise;
                }
                else if(state == 3)
                {
                    drawColor = Color.Khaki;
                }
                this.Refresh();
            }
            State = state;
            FaultState = falut;
            AddrNumber = addrNumber;
            ModlesType = modlesType;
        }
    }
}
