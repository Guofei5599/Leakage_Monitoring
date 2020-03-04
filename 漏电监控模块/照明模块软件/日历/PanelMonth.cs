using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照明模块软件
{
    public partial class PanelMonth : UserControl
    {
        #region 属性

        private int _bordWidth = 0;
        private Color _bordColor = Color.White;
        private ButtonBorderStyle _bordStyle = ButtonBorderStyle.None;


        /// <summary>
        /// 设置或获取控件边框的宽度
        /// </summary>
        [Browsable(true), DefaultValue(2)]
        [Category("Appearance")]
        public int BordWidth
        {
            get { return _bordWidth; }
            set
            {
                _bordWidth = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// 设置或获取控件边框的颜色
        /// </summary>
        [Browsable(true), DefaultValue(2)]
        [Category("Appearance")]
        public Color BordColor
        {
            get { return _bordColor; }
            set
            {
                _bordColor = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// 设置或获取控件边框的样式
        /// </summary>
        [Browsable(true), DefaultValue(2)]
        [Category("Appearance")]
        public ButtonBorderStyle BordStyle
        {
            get { return _bordStyle; }
            set
            {
                _bordStyle = value;
                base.Invalidate();
            }
        }

        #endregion

        public delegate void ClickDateCallBack(DateTime datetime);
        public event ClickDateCallBack OnClick;
        public static List<string> IdolList = new List<string>();
        public PanelMonth()
        {
            InitializeComponent();

            BordColor = Color.White;
            BordWidth = 0;
            BorderStyle = BorderStyle.None;
            IdolList.Add("20191115");
            IdolList.Add("20191116");
            IdolList.Add("20191210");
        }

        /// <summary>
        /// load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelMonth_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            txtYear.Text = now.Year.ToString();
            txtMonth.Text = now.Month.ToString();

            txtYear.TextChanged += TxtYear_TextChanged;
            txtMonth.TextChanged += TxtMonth_TextChanged;

            AddDayToFlpControls();
        }

        private void TxtMonth_TextChanged(object sender, EventArgs e)
        {
            AddDayToFlpControls();
        }

        private void TxtYear_TextChanged(object sender, EventArgs e)
        {
            AddDayToFlpControls();
        }

        #region 添加日期

        /// <summary>
        /// 根据年月加载日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDayToFlpControls()
        {
            DateTime now = DateTime.Now;
            string year = txtYear.Text.Trim();
            string month = txtMonth.Text.Trim();
            if (string.IsNullOrEmpty(txtYear.Text))
            {
                txtYear.Text = DateTime.Now.Year.ToString();
                year = DateTime.Now.Year.ToString();
            }
            if (string.IsNullOrEmpty(txtMonth.Text))
            {
                txtMonth.Text = DateTime.Now.Month.ToString();
                month = DateTime.Now.Month.ToString();
            }

            flpControls.Controls.Clear();

            int dim = DaysInMonth(int.Parse(year), int.Parse(month));

            int index = 0;
            DateTime firstDay = new DateTime(int.Parse(year), int.Parse(month), 1);

            int firstdayOfWeek = (int)firstDay.DayOfWeek;

            for (int i = 0; i < 6; i++)  //一个月日历最多显示为6行
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 0 && j < firstdayOfWeek)  //第一行，如果当月1号的星期数小于第j列,那么填充一个没有日期的PanelDay控件
                    {
                        Add(false,false, "");
                    }
                    else if (index < dim)  //如果当前日期数字小月当月天数，填充一个日期为（index+1）的日期
                    {
                        int iii = -1;
                        iii = PanelMonth.IdolList.FindIndex(t => t == year.PadLeft(4, '0') + month.PadLeft(2, '0') + (index + 1).ToString().PadLeft(2, '0'));
                        if (int.Parse(year) == now.Year && int.Parse(month) == now.Month && (index + 1) == now.Day)  //如果改日期是今天，设置改日期被选中
                        {
                            Add(true, (iii == -1) ? false : true,(index + 1).ToString());
                        }
                        else  //如果改日期是今天，设置改日期不被选中
                        {
                            Add(false, (iii == -1) ? false : true, (index + 1).ToString());
                        }
                        index++;
                    }
                }
            }

        }

        /// <summary>
        /// 添加日期
        /// </summary>
        /// <param name="isSelect">当天是否被选中</param>
        /// <param name="day">日期</param>
        private void Add(bool isSelect,bool isSet, string day) 
        {
            PanelDay panelDay = new PanelDay();
            panelDay.Day = day;
            panelDay.IsSelect = isSelect;
            panelDay.IsSet = isSet;
            panelDay.SetValue();
            panelDay.SetIdol();
            panelDay.OnClick += PanelDay_OnClick;
            panelDay.OnSetIdolClick += PanelDay_OnSetIdolClick;
            flpControls.Controls.Add(panelDay);
        }

        private void PanelDay_OnSetIdolClick(string day)
        {
            int iii = PanelMonth.IdolList.FindIndex(t => t == txtYear.Text.PadLeft(4, '0') + txtMonth.Text.PadLeft(2, '0') + day.PadLeft(2, '0'));
            if (iii == -1)
                PanelMonth.IdolList.Add(txtYear.Text.PadLeft(4, '0') + txtMonth.Text.PadLeft(2, '0') + day.PadLeft(2, '0'));
            foreach (var control in flpControls.Controls)
            {
                if (control is PanelDay)
                {
                    PanelDay panelDay = control as PanelDay;
                    iii = PanelMonth.IdolList.FindIndex(t=>t == txtYear.Text.PadLeft(4,'0') + txtMonth.Text.PadLeft(2,'0')+ panelDay.Day.PadLeft(2,'0'));
                    //if (iii != -1)
                    //    PanelMonth.IdolList.Add(txtYear.Text.PadLeft(4, '0') + txtMonth.Text.PadLeft(2, '0') + day.PadLeft(2, '0'));
                    if (iii != -1)
                    {
                        panelDay.IsSet = true;
                        panelDay.SetIdol();
                    }
                    else
                    {
                        panelDay.IsSet = false;
                        panelDay.SetIdol();
                    }
                }
            }
        }

        /// <summary>
        /// 点击选中日期
        /// </summary>
        /// <param name="day"></param>
        private void PanelDay_OnClick(string day)
        {
            foreach (var control in flpControls.Controls)
            {
                if (control is PanelDay)
                {
                    PanelDay panelDay = control as PanelDay;
                    if (panelDay.Day == day)
                    {
                        panelDay.IsSelect = true;
                        if (!panelDay.IsSet)
                            panelDay.SetValue();
                    }
                    else if (panelDay.IsSelect == true)
                    {
                        panelDay.IsSelect = false;
                        if(!panelDay.IsSet)
                            panelDay.SetValue();
                    }
                }
            }

            string year = txtYear.Text.Trim();
            string month = txtMonth.Text.Trim();

            DateTime date = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));

            //OnClick?.Invoke(string.Format("{0}年{1}月{2}日", year, month, day));
            OnClick?.Invoke(date);
        }

        #region 根据年月计算日期

        /// <summary>
        /// 根据年月计算天数
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public int DaysInMonth(int year, int month)
        {
            int days = 0;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    days = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    days = 30;
                    break;
                case 2:
                    if ((year % 100 != 0 && year % 4 == 0) || (year % 400 == 0))
                        days = 29;
                    else
                        days = 28;
                    break;
                default:
                    days = 0;
                    break;
            }
            return days;
        }
        #endregion

        #endregion

        #region 年月

        private bool IsNext = false; //是否是下一个月，true为下一个月，false为上一个月
        /// <summary>
        /// 上一月
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUp_Click(object sender, EventArgs e)
        {
            txtYear.TextChanged -= TxtYear_TextChanged;
            txtMonth.TextChanged -= TxtMonth_TextChanged;

            IsNext = false;
            GetPreviousOrNextMonth();

            txtYear.TextChanged += TxtYear_TextChanged;
            txtMonth.TextChanged += TxtMonth_TextChanged;
        }
        
        /// <summary>
        /// 下一月
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDown_Click(object sender, EventArgs e)
        {
            txtYear.TextChanged -= TxtYear_TextChanged;
            txtMonth.TextChanged -= TxtMonth_TextChanged;

            IsNext = true;
            GetPreviousOrNextMonth();

            txtYear.TextChanged += TxtYear_TextChanged;
            txtMonth.TextChanged += TxtMonth_TextChanged;
        }

        /// <summary>
        /// 获取上一月或者下一月
        /// </summary>
        /// <returns></returns>
        private void GetPreviousOrNextMonth()
        {
            string newYear = "";
            string newMonth = "";

            string year = txtYear.Text.Trim();  //当前年
            string month = txtMonth.Text.Trim();  //当前月
            int y = 0, m = 0;
            if (!string.IsNullOrEmpty(month))
            {
                m = int.Parse(month);
            }
            if (!string.IsNullOrEmpty(year))
            {
                y = int.Parse(year);
            }
            if (IsNext)  //下一个月
            {
                if (m == 12)
                {
                    newYear = (y + 1).ToString();
                    newMonth = 1.ToString();
                }
                else
                {
                    newYear = year;
                    newMonth = (m + 1).ToString();
                }
            }
            else  //上一个月
            {
                if (m == 1)
                {
                    newYear = (y - 1).ToString();
                    newMonth = 12.ToString();
                }
                else
                {
                    newYear = year;
                    newMonth = (m - 1).ToString();
                }
            }
            if (newYear != year)
            {
                txtYear.Text = newYear;
            }
            txtMonth.Text = newMonth;

            AddDayToFlpControls();
        }

        /// <summary>
        /// 键盘上下键控制年份增加减少
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            int year = 0;
            if (!string.IsNullOrEmpty(txtYear.Text.Trim()))
            {
                year = int.Parse(txtYear.Text.Trim());
            }
            if (e.KeyCode == Keys.Up)
            {
                txtYear.Text = (year + 1).ToString();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtYear.Text = (year - 1).ToString();
            }
        }
        /// <summary>
        /// 键盘上下键控制月份增加减少
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMonth_KeyDown(object sender, KeyEventArgs e)
        {
            int month = 0;
            int year = 0;
            if (!string.IsNullOrEmpty(txtMonth.Text.Trim()))
            {
                month = int.Parse(txtMonth.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtYear.Text.Trim()))
            {
                year = int.Parse(txtYear.Text.Trim());
            }

            if (e.KeyCode == Keys.Up)  //上一个月
            {
                IsNext = false;
                GetPreviousOrNextMonth();
            }
            else if (e.KeyCode == Keys.Down)  //下一个月
            {
                IsNext = true;
                GetPreviousOrNextMonth();
            }
        }

        /// <summary>
        /// 点击年份获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYear_Click(object sender, EventArgs e)
        {
            txtYear.SelectAll();
        }

        /// <summary>
        /// 点击月份获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMonth_Click(object sender, EventArgs e)
        {
            txtMonth.SelectAll();
        }

        #endregion


        /// <summary>
        /// 重绘边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelMonth_Paint(object sender, PaintEventArgs e)
        {
            this.Width = 258 + (2 * BordWidth);
            this.Height = 285 + (2 * BordWidth);
            this.Padding = new Padding(BordWidth);

            Rectangle myRectangle = new Rectangle(0, 0, this.Width, this.Height);
            ControlPaint.DrawBorder(e.Graphics, myRectangle,
                BordColor, BordWidth, BordStyle,
                BordColor, BordWidth, BordStyle,
                BordColor, BordWidth, BordStyle,
                BordColor, BordWidth, BordStyle
            );
        }
    }
}
