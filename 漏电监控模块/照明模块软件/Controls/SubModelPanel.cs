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
    public class SubModelPanel:Panel
    {
        public delegate void ValuEventHandler(object sender, 开关模块 e);
        public event ValuEventHandler LightValueChange;
        public event ValuEventHandler ButtonClick;
        public string PanleNumber { set; get; }
        public bool Flag { set; get; }
        public int LightValue { set; get; }

        public string ModelsNumber { set; get; }
        public string ModelsType { set; get; }

        PictureBox pictureBox;
        SwitchButton switchButton;
        TrackBar trackBar;
        Label numTrackBar;
        Label nameLable;
        Label numLable;
        public SubModelPanel(int l,int w,int number,int modelsNumber)
        {
            this.Size = new Size(l,w);
            this.Paint += onPain;
            this.Name = "开关"+ number.ToString();

            PanleNumber = number.ToString().PadLeft(2, '0');
            ModelsNumber = modelsNumber.ToString();
            numLable = new Label();
            numLable.AutoSize = true;
            numLable.Text = PanleNumber;
            numLable.ForeColor = Color.DodgerBlue;
            numLable.Location = new Point((this.Width - numLable.PreferredWidth)/2, 10);
            numLable.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            numLable.BackColor = Color.Transparent;
            this.Controls.Add(numLable);

            nameLable = new Label();
            nameLable.AutoSize = true;
            nameLable.Text = "模块" + PanleNumber;
            nameLable.ForeColor = Color.DodgerBlue;
            nameLable.Location = new Point((this.Width - nameLable.PreferredWidth) / 2, this.Height-nameLable.Height+3);
            nameLable.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            nameLable.BackColor = Color.Transparent;
            this.Controls.Add(nameLable);

            pictureBox = new PictureBox();
            pictureBox.Image = Properties.Resources.灯泡关;
            pictureBox.Width = 70;
            pictureBox.Height = 70;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            pictureBox.Location = new Point((this.Width - pictureBox.Width)/2,(this.Height - pictureBox.Height)/2);
            this.Controls.Add(pictureBox);

            switchButton = new SwitchButton();
            switchButton.Location = new Point(this.Width - switchButton.Width-10 , (this.Height - switchButton.Height)/2);
            switchButton.Anchor = AnchorStyles.Bottom |  AnchorStyles.Right;
            this.Controls.Add(switchButton);

            trackBar = new TrackBar();
            trackBar.Location = new Point(15, (this.Height - trackBar.Width) / 2);
            trackBar.Maximum = 10;
            trackBar.Minimum = 1;
            trackBar.LargeChange = 1;
            trackBar.SmallChange = 1;
            trackBar.TickFrequency = 5;
            trackBar.Orientation = Orientation.Vertical;
            trackBar.Size = new Size(40, 85);
            trackBar.BackColor = Color.FromArgb(220, 220, 220);
            trackBar.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            trackBar.SendToBack();
            this.Controls.Add(trackBar);

            numTrackBar = new Label();
            numTrackBar.AutoSize = true;
            numTrackBar.Text = "亮度:" + "1";
            numTrackBar.Location = new Point(trackBar.Location.X -8 , trackBar.Location.Y + trackBar.Height - 5);
            numTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            numTrackBar.BackColor = Color.Transparent;
            numTrackBar.Font = new Font("宋体",8, FontStyle.Regular);
            numTrackBar.ForeColor = Color.DodgerBlue;
            this.Controls.Add(numTrackBar);
            this.Controls.SetChildIndex(numTrackBar, 0);
            trackBar.SmallChange = 0;
            trackBar.LargeChange = 0;
            trackBar.MouseUp += new MouseEventHandler(trackBar_MouseUp);
            trackBar.MouseDown += new MouseEventHandler(trackBar_MouseDown);
            trackBar.ValueChanged += new EventHandler(ValueChanged);
            switchButton.Click += new EventHandler(button_ButtonChangeState);
            
        }

        bool flag = false;
        private void trackBar_MouseDown(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void trackBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (flag == false)
                return;
            if (Communication.RoutInspecting || Communication.EachRoutInspecting || (ModelsType != "调光模块" && ModelsType != "开关模块"))
            {
                trackBar.Value = LightValue;
                return;
            }
            numTrackBar.Text = "亮度:" + trackBar.Value.ToString();
            LightValue = trackBar.Value;
            if (LightValueChange != null)
                LightValueChange(sender, new 开关模块() { 开关编号 = PanleNumber, 亮度 = LightValue, 模块编号 = ModelsNumber, 模块类型 = ModelsType });
        }
        private void ValueChanged(object sender, EventArgs e)
        {
            flag = true;
        }

        private void button_ButtonChangeState(object sender, EventArgs e)
        {
            if (Communication.EachRoutInspecting || Communication.RoutInspecting)
                return;
            if (ModelsType != "调光模块" && ModelsType != "开关模块")
            {
                return;
            }
            if (ButtonClick != null)
                ButtonClick(sender, new 开关模块() { 开关编号 = PanleNumber, 亮度 = LightValue, 模块编号 = ModelsNumber, flag = switchButton.flag, 模块类型 = ModelsType });
            if (!switchButton.flag)
            {
                pictureBox.Image = Properties.Resources.灯泡关;
            }
            else
            {
                pictureBox.Image = Properties.Resources.灯泡开;
            }
        }

        

        private void onPain(object sender, PaintEventArgs e)
        {
            // 要实现 圆角化的 矩形
            Rectangle rect = new Rectangle(0, 0, this.Width - 3, this.Height - 3);
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
            Color c = Color.FromArgb(220, 220, 220);
            e.Graphics.DrawPath(new Pen(c, 1), myPath);
            SolidBrush mysbrush1 = new SolidBrush(c);
            e.Graphics.FillPath(mysbrush1, myPath);
        }

        public void RefreshPanel(开关模块 tmp, string modelsType)
        {
            ModelsType = modelsType;
            switchButton.ButtonDisplay(tmp.flag);
            ModelsNumber = tmp.模块编号;
            numLable.Text = tmp.开关编号;
            nameLable.Text = tmp.开关名称;
            nameLable.Location = new Point((this.Width - nameLable.PreferredWidth) / 2, nameLable.Location.Y);
            if (ModelsType == "开关模块")
            {
                trackBar.Visible = false;
                numTrackBar.Visible = false;
            }
            else
            {
                trackBar.Visible = true;
                numTrackBar.Visible = true;
                numTrackBar.Text = "亮度:" + tmp.亮度.ToString();
            }
            var tmp1 = ModelsOperate.GetModel(int.Parse(tmp.模块编号));
            //if (tmp1.开关路数 == null)
            //    tmp1.开关路数 = "16";
            //int channel = int.Parse(tmp1.开关路数);
            //if (channel < int.Parse(PanleNumber))
            //    this.Visible = false;
            //else
            //    this.Visible = true;
            trackBar.Value = tmp.亮度;
            if (!switchButton.flag)
                pictureBox.Image = Properties.Resources.灯泡关;
            else
                pictureBox.Image = Properties.Resources.灯泡开;
            LightValue = tmp.亮度;
            Flag = tmp.flag;
            LightValue = tmp.亮度;
        }
    }
}
