using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.Oscilloscope
{
    public partial class Oscilloscope : HMICtrlBase
    {
        public Oscilloscope()
        {
            InitializeComponent();
        }
        #region ** 私有成员：属性 **
        /// <summary>
        /// 波形所容纳的最大值
        /// </summary>
        private int range = 100;
        private int timespan = 10;
        private int valuespan = 1;
        /// <summary>
        /// 定时器间隔
        /// </summary>
        private int interval = 1;
        /// <summary>
        /// Chart 值数组
        /// </summary>
        private float[] val;
        private float[] val1;
        /// <summary>
        /// 当前值
        /// </summary>
        public float currentValue = 0;
        /// <summary>
        /// channelcount:通道总数
        /// </summary>
        private int channelcount;
        /// <summary>
        /// W：画布宽度 ，H：画布高度
        /// </summary>
        private int w, h, divmain;
        /// <summary>
        /// 定时器
        /// </summary>
        private Timer tmrRefresh;
        /// <summary>
        /// 私有成员：绘图  绘图方式
        /// </summary>
        private ChartMode chartMode = ChartMode.Waveform;
        /// <summary>
        /// 平移偏移量
        /// </summary>
        private int iOffset = 0;
        /// <summary>
        /// 网格是否平移
        /// </summary>
        private bool gridShiftting = true;
        /// <summary>
        /// 网格平移间距
        /// </summary>
        private int gridShifttingIncrement = 10;
        /// <summary>
        /// 网格宽度
        /// </summary>
        private int gridWidth = 10;
        /// <summary>
        /// 网格高度
        /// </summary>
        private int gridHeight = 10;
        /// <summary>
        /// 绘制网格画笔
        /// </summary>
        private Pen penChart = new Pen(Color.Lime, 2);
        /// <summary>
        /// 绘制曲线画笔
        /// </summary>
        private Pen penGrid = new Pen(Color.Green);
        /// <summary>
        /// 魔版
        /// </summary>
        private Graphics graph;
        public int count = 0;
        public List<float> datalist = new List<float>();

        List<LineClass> LineList = new List<LineClass>();
        Queue<float> queue = new Queue<float>();
        private bool isRun;
        #endregion
        #region ** 私有方法：绘制图形 **
        /// <summary>
        /// 
        /// </summary>
        public class LineClass
        {
            public List<int> timelist = new List<int>();
            public List<int> valuelist = new List<int>();
            public Color color;
            public string name;
        }

        private void WriteString(ref Graphics g, int value, PointF point)
        {
            String drawString = (value).ToString();
            Font drawFont = new Font("Arial", 6);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            PointF drawPoint = point;
            g.DrawString(drawString, drawFont, drawBrush, drawPoint);
        }

        /// <summary>
        /// 根据画布大小绘制所需求大小的网格
        /// </summary>
        /// <param name="g">魔板</param>
        /// <param name="offset">网格每次平移变量</param>
        private void DrawGrids(ref Graphics g, int offset)
        {
            //网格数（不计边缘）
            float div;
            float pos = 0F;


            //先画 垂直 方向
            //可以少画一根线无所谓，看各自需求  画多少条线（画布大小除以网格的宽度）
            div = (float)w / (float)gridWidth + 1;
            //循环画横线
            for (int i = 0; i < (int)div; i++)
            {
                if ((i) % 5 == 0)
                {
                    String drawString = (interval * i).ToString();
                    Font drawFont = new Font("Arial", 6);
                    SolidBrush drawBrush = new SolidBrush(Color.Black);
                    PointF drawPoint = new PointF(pos - offset, h);
                    g.DrawString(drawString, drawFont, drawBrush, drawPoint);
                    penGrid.Width = 2;
                }
                pos += gridWidth;
                g.DrawLine(penGrid, pos - offset, 0, pos - offset, h);
                penGrid.Width = 1;

            }
            //g.DrawLine(penGrid, 0, 0, 0, h);
            //画 水平 方向    画多少条线（画布大小除以网格的高度）
            div = (float)h / (float)gridHeight + 1;
            int range_value = (int)(range / div);
            int max_value = range_value * (int)div;
            pos = 0F;
            //循环画竖线
            for (int i = 0; i < (int)div; i++)
            {
                if ((i) % 5 == 0)
                {
                    String drawString = (max_value - range_value * i).ToString();
                    Font drawFont = new Font("Arial", 6);
                    SolidBrush drawBrush = new SolidBrush(Color.Black);
                    PointF drawPoint = new PointF(0, pos);
                    g.DrawString(drawString, drawFont, drawBrush, drawPoint);
                    //g.DrawString("0", drawFont, drawBrush, ConvertCoordinate(new PointF(10,10)));
                    penGrid.Width = 2;
                }
                g.DrawLine(penGrid, 20, pos, w, pos);
                pos += gridHeight;
                penGrid.Width = 1;

            }
        }

        /// <summary>
        /// 坐标转换
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private PointF ConvertPiex(PointF Point)
        {
            PointF newPoint = new PointF();
            newPoint.X = Point.X;
            newPoint.Y = h - Point.Y;
            return newPoint;
        }
        private PointF ConvertCoordinate(PointF Point)
        {
            //PointF newPoint = new PointF();
            //newPoint.X = Point.X ;
            //newPoint.Y = h - Point.Y + 3*gridHeight;
            //return newPoint;
            PointF newPoint = ConvertPiex(Point);
            newPoint.X = newPoint.X + 2 * GridWidth;
            newPoint.Y = newPoint.Y - 1 * gridHeight;
            return newPoint;
        }


        /// <summary>（难点）
        /// 根据数据绘制示波数据线
        /// </summary>
        /// <param name="g">魔板</param>
        /// <param name="p">画笔</param>
        /// <param name="val">数据数组</param>
        private void DrawChart(ref Graphics g, Pen p, ref float[] val)
        {
            //从 0 到 w 绘制
            //int len = w;
            int len = divmain;
            //根据绘制方式（多重阴影与单线）
            if (chartMode == ChartMode.Histogram)
            {
                //绘制的是数据A点与画布高度之间的连线
                //绘制第一个数据，一直到，倒数第二个数据
                for (int i = 0; i < len; i++)
                {
                    //第一个点（i,画布高度减去第i个数据）,第二个点（i,画布高度）
                    g.DrawLine(p, i, h - val[i], i, h);
                }
                //第一个点（画布宽度,画布宽度减去最后一个数据）,第二个点（画布宽度,画布高度）
                g.DrawLine(p, len, h - val[len - 1], len, h);
            }
            else
            {
                len--;
                //绘制的是一条数据A点与数据B点的连线
                //绘制第一个数据，一直到，倒数第二个数据之间每一个点的连线
                for (int i = 0; i < len; i++)
                {

                    //两点决定1向量
                    //第一个点（i,画布高度减去第i个数据），第二个点（i+1，画布高度减去第i+1个数据）
                    //if(i > 2*GridWidth)
                    // g.DrawLine(p, i, val[i] /(float)valuespan, (i + 1), val[i + 1] / (float)valuespan);
                    g.DrawLine(p, ConvertCoordinate(new PointF(i * gridWidth, gridHeight * val[i] / (float)valuespan)), ConvertCoordinate(new PointF((i + 1) * gridWidth, gridHeight * val[i + 1] / (float)valuespan)));
                    //g.DrawLine(p, i, h - val[i], i + 1, h - val[i + 1]);

                }
                len++;
                //绘制倒数第二个与最后一个数据之间的连线（绘制最后两个点之间的连线）
                //第一个点（画布宽度-1，画布宽度减去倒数第二个数据），第二个点（画布宽度，画布宽带减去倒数第一个数据）
                //g.DrawLine(p, len - 1, h - val[len - 2], len, h - val[len - 1]);
                //g.DrawLine(p, i, h - val[i], i + 1, h - val[i + 1]);
                //g.DrawLine(p,ConvertCoordinate(new PointF(20,20)),ConvertCoordinate(new PointF(60,60)));
            }
        }

        /// <summary>
        /// 私有方法：重写方法系统  OnLoad  方法  (窗体加载事件)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            //base.OnLoad(e);
            //打开双缓冲（双缓存），防止闪烁
            DoubleBuffered = true;
            //h = base.ClientSize.Height - 1;
            h = (base.ClientSize.Height / gridHeight - 1) * gridHeight;
            // w = (base.ClientSize.Width / gridWidth - 1) * gridWidth;
            w = base.ClientSize.Width - 1;
            divmain = (int)((float)w / (float)gridWidth);
            val1 = new float[divmain];
            val = new float[w];
            //创建一个 Timer 控件
            tmrRefresh = new Timer();
            //设置Timer时间
            tmrRefresh.Interval = interval;
            //开始Timer
            tmrRefresh.Enabled = true;
            //绑定事件
            tmrRefresh.Tick += new EventHandler(tmrRefresh_Tick);

            for (int i = 0; i < channelcount; i++)
            {
                LineClass line = new LineClass();
                line.name = "Line" + i.ToString();
                LineList.Add(line);
            }
        }

        /// <summary>
        /// 重写改变窗体大小事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            h = base.ClientSize.Height;
            w = base.ClientSize.Width;
            Array.Resize(ref val, w);
            Array.Resize(ref val1, divmain);
            //使控件的整个图面无效并导致重绘控件。(导致OnPaint事件的发生)
            Invalidate();
        }

        /// <summary>
        /// 控件重写，重新绘制事件（由系统控制，每秒不知道重绘N次）
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            graph = e.Graphics;
            //DrawGrids(ref graph, iOffset - GridWidth);
            penChart.Width = 3;
            DrawChart(ref graph, penChart, ref val1);
            penChart.Width = 1;
            //DrawChart(ref graph, penChart, ref val1);
            float div = (float)(h) / (float)gridHeight;
            int count = 0;
            //循环画横线
            for (int i = 1; i < (int)div; i++)
            {
                if (count % 5 == 0 && count != 0)
                {
                    float div1 = range / ((h - 2 * gridHeight) / gridHeight);
                    WriteString(ref graph, count * valuespan, ConvertCoordinate(new PointF(-15, count * gridHeight)));
                    penGrid.Width = 2;
                }
                else
                {
                    penGrid.Width = 1;
                }
                Point p1 = new Point(2 * gridHeight, i * gridHeight);
                Point p2 = new Point(w, i * gridHeight);
                graph.DrawLine(penGrid, ConvertPiex(p1), ConvertPiex(p2));
                penGrid.Width = 1;
                count++;
            }
            count = 0;
            div = (float)w / (float)gridWidth;
            for (int i = 2; i < (int)div; i++)
            {
                if (count % 5 == 0)
                {
                    WriteString(ref graph, count * interval, ConvertCoordinate(new PointF(count * gridWidth - 5, 0)));
                    penGrid.Width = 2;
                }
                else
                {
                    penGrid.Width = 1;
                }
                Point p1 = new Point(i * gridWidth, gridWidth);
                Point p2 = new Point(i * gridWidth, h);
                graph.DrawLine(penGrid, ConvertPiex(p1), ConvertPiex(p2));
                count++;
            }

            Font drawFont = new Font("Arial", 6);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            // PointF drawPoint = new PointF(0, pos);
            // graph.DrawString(drawString, drawFont, drawBrush, drawPoint);
            PointF p = ConvertCoordinate(new PointF(50, 50));
        }
        /// <summary>
        /// 定时器更新（由tmrRefresh定时器绑定的方法）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            if (!isRun)
                return;
            //（难点）
            //更新网格偏移
            //只有启用了网格移动才处理
            if (gridShiftting)
            {
                iOffset += gridShifttingIncrement;
                iOffset %= gridWidth;
            }
            //更新图形（整体左移）
            //必须在这里而不能在画图的同时移动，
            //若在画图中移动，则当画面被遮挡（OnPaint）事件不发生时无法更新
            int len = w;
            int len1 = divmain;
            //不断的将数组中的第i个位置的数据移动到第i-1的位置。
            for (int i = 0; i < len1; i++)
            {
                //判断数组越界
                if (i < len1 - 1)
                {
                    val1[i] = val1[i + 1];
                }
                else
                {
                    val1[len1 - 1] = currentValue;
                    //break;
                }
            }
            for (int i = 0; i < len; i++)
            {
                //判断数组越界
                if (i < len - 1)
                {
                    val[i] = val[i + 1];
                }
                else
                {
                    val[len - 1] = currentValue;
                    //break;
                }
            }
            datalist.Add(currentValue);
            count = datalist.Count;
            //val[len] = currentValue;
            //使控件的整个图面无效并导致重绘控件。(导致OnPaint事件的发生)
            Invalidate();
        }
        #endregion

        #region
        ///<summary>
        /// 通道总数
        /// </summary>
        [Category("内容"), Description("通道数"), DefaultValue(1)]
        public int ChannelCount
        {
            get
            {
                return channelcount;
            }
            set
            {
                channelcount = value;
            }
        }
        #endregion

        #region ** 公共成员：设置绘制方式（多重阴影与单线） **
        /// <summary>
        /// 波形图显示方式枚举。
        /// </summary>
        public enum ChartMode
        {
            /// <summary>
            /// 直方图
            /// </summary>
            Histogram = 0,    //直方图
            /// <summary>
            /// 波形图
            /// </summary>
            Waveform        //波形图
        }
        #endregion
        #region ** 公共属性 **
        //指定一个属性或事件是否应显示在“属性”窗口中。
        [Browsable(true)]
        /// <summary>
        /// 当前值（给的数据，外面用一个Timer来每多少毫秒给一次数据，对外的Timer要与本StatusChart用户控件中的Timer时间同步）。
        /// </summary>
        [Category("内容"), Description("当前值。"), DefaultValue(0)]
        public float Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                //约束 value
                //if (value > range)
                //{
                //    value = range;
                //}
                //if (value < 0)
                //{
                //    value = 0;
                //}
                //根据 Range 属性修正 value
                //尽量减小误差
                //value = (int)((float)value / (float)range * (float)h);
                currentValue = value;
            }
        }
        /// <summary>
        /// 数据值范围。绘图时将根据此值缩放 Value 值。
        /// </summary>
        [Category("内容"), Description("数据值范围。绘图时将根据此值缩放 Value 值。"), DefaultValue(100)]
        public int Range
        {
            get
            {
                return range;
            }
            set
            {
                range = value;
            }
        }

        [Category("内容"), Description("横坐标时间"), DefaultValue(10)]
        public int Timespan
        {
            get
            {
                return timespan;
            }
            set
            {
                timespan = value;
            }
        }

        [Category("内容"), Description("横坐标时间"), DefaultValue(1)]
        public int ValueSpan
        {
            get
            {
                return valuespan;
            }
            set
            {
                valuespan = value;
            }
        }
        /// <summary>
        /// 波形图刷新间隔。
        /// </summary>
        [Category("内容"), Description("波形图刷新间隔。"), DefaultValue(500)]
        public int Interval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value;
                if (tmrRefresh != null)
                {
                    tmrRefresh.Interval = interval;
                }
            }
        }
        /// <summary>
        /// 指示波形是否继续更新。
        /// </summary>
        [Category("内容"), Description("指示波形是否继续更新。"), DefaultValue(false)]
        public  bool IsRun
        {
            get
            {
                return isRun;
            }
            set
            {
                isRun = value;
            }
        }
        /// <summary>
        /// 显示方式。
        /// </summary>
        [Category("外观"), Description("波形显示方式。"), DefaultValue(typeof(ChartMode), "Histogram")]
        public ChartMode Mode
        {
            get
            {
                return chartMode;
            }
            set
            {
                chartMode = value;
            }
        }
        /// <summary>
        /// 网格每次更新时向左平移的距离。
        /// </summary>
        [Category("外观"), Description("网格每次更新时向左平移的距离。"), DefaultValue(10)]
        public int ShifttingIncrement
        {
            get
            {
                return gridShifttingIncrement;
            }
            set
            {
                gridShifttingIncrement = value;
                if (gridShifttingIncrement < 0)
                {
                    gridShifttingIncrement = 0;
                }
            }
        }
        /// <summary>
        /// 指示网格是否每次更新时向左平移。
        /// </summary>
        [Category("外观"), Description("指示网格是否每次更新时向左平移。"), DefaultValue(true)]
        public bool GridShiftting
        {
            get
            {
                return gridShiftting;
            }
            set
            {
                gridShiftting = value;
            }
        }
        /// <summary>
        /// 网格宽度。
        /// </summary>
        [Category("外观"), Description("网格宽度。"), DefaultValue(10)]
        public int GridWidth
        {
            get
            {
                return gridWidth;
            }
            set
            {
                gridWidth = value;
                Invalidate();
            }
        }
        /// <summary>
        /// 网格高度。
        /// </summary>
        [Category("外观"), Description("网格高度。"), DefaultValue(10)]
        public int GridHeight
        {
            get
            {
                return gridHeight;
            }
            set
            {
                gridHeight = value;
                Invalidate();
            }
        }
        /// <summary>
        /// 网格颜色。
        /// </summary>
        [Category("外观"), Description("网格颜色。"), DefaultValue(typeof(Color), "Color.Dark")]
        public Color GridColor
        {

            get
            {
                return penGrid.Color;
            }
            set
            {
                penGrid.Color = value;
            }
        }
        /// <summary>
        /// 波形颜色。
        /// </summary>
        [Category("外观"), Description("波形颜色。"), DefaultValue(typeof(Color), "Lime")]
        public override Color ForeColor
        {
            get
            {
                return penChart.Color;
            }
            set
            {
                penChart.Color = value;
            }
        }
        #endregion

        #region ** 公共方法 **
        /// <summary>
        /// 启动计时器更新。返回执行情况。
        /// </summary>
        /// <returns>执行情况。true 成功；false 失败。</returns>
        public bool Start()
        {
            try
            {
                if (tmrRefresh != null)
                {
                    tmrRefresh.Enabled = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 停止计时器更新。返回执行情况。
        /// </summary>
        /// <returns>执行情况。true 成功；false 失败。</returns>
        public bool Stop()
        {
            try
            {
                if (tmrRefresh != null)
                {
                    tmrRefresh.Enabled = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 清除历史状态记录。
        /// </summary>
        public void Clear()
        {
            if (val1 != null)
            {
                //没用
                //val.Initialize();
                //Array.Resize(ref val, 0);
                //Array.Resize(ref val1, 0);
                for (int i = 0; i < val1.Length; i++)
                {
                    val1[i] = 0;
                }
                currentValue = 0;
            }
            datalist.Clear();
            count = datalist.Count;
            int len1 = divmain;
            //不断的将数组中的第i个位置的数据移动到第i-1的位置。
            //for (int i = 0; i < len1; i++)
            //{
            //    //判断数组越界
            //    if (i < len1 - 1)
            //    {
            //        val1[i] = val1[i + 1];
            //    }
            //    else
            //    {
            //        val1[len1 - 1] = currentValue;
            //        //break;
            //    }
            //}
            Invalidate();
        }
        /// <summary>
        /// 控制计时器更新。返回执行情况。
        /// </summary>
        /// <returns>执行情况。true 成功；false 失败。</returns>
        public void StopTrim(bool bol)
        {
            tmrRefresh.Enabled = bol;
        }

        #endregion
    }
}
