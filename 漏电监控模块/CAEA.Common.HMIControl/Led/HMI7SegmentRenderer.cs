//=================================================================
//
//文件名:HMI7SegmentRenderer
//
//Framework版本:4.0
//
//描述:当个数码管控件渲染器
//
//创建人:刘健
//
//创建日期:2016-09-09 10:25:45
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.Led
{
    public class HMI7SegmentRenderer : HMIRenderBase
    {
        #region (* 常量 *)
        public const int WIDTH_PIXEL = 11;
        public const int HEIGHT_PIXELS = 18;
        #endregion

        #region (* 变量 *)
        /// <summary>
        /// 数码管个段号画出所需的对应点号
        /// </summary>
        protected SegmentDictionary segments = new SegmentDictionary();
        /// <summary>
        /// 数码管默认尺寸下点列表，画值时所用的所有坐标点
        /// </summary>
        protected PointsList defPoints = new PointsList();
        /// <summary>
        /// 尺寸变化后的真实的坐标点
        /// </summary>
        protected PointsList points = new PointsList();
        /// <summary>
        /// 各个值对应的所需的段号，段号逆时针数ABCDEFG，小数点另画
        /// </summary>
        protected SegmentsValueDictionary valuesSegments = new SegmentsValueDictionary();
        /// <summary>
        /// 小数点
        /// </summary>
        protected RectangleF rectDP = new RectangleF();
        #endregion

        #region (* 构造函数 *)
        public HMI7SegmentRenderer()
        {
            this.CreateSegmetsData();
            this.CreateDefPointsCoordinates();
            this.CreateSegmentsValuesList();
            this.UpdatePointsCoordinates();
        }
        #endregion

        #region (* 重写方法 *)
        public override bool Update()
        {
            this.UpdatePointsCoordinates();
            return true;
        }

        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            HMI7Segment ctrl = this.Display;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            RectangleF _rc = new RectangleF(0, 0, ctrl.Width, ctrl.Height);
            Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            this.DrawBackground(Gr, _rc);
            this.DrawOffSegments(Gr, _rc);
            this.DrawValue(Gr, _rc);
        }
        #endregion

        #region (* 属性 *)
        [Browsable(false)]
        public HMI7Segment Display
        {
            set { this.Control = value; }
            get { return this.Control as HMI7Segment; }
        }

        [Browsable(false)]
        public SegmentDictionary Segments
        {
            get { return this.segments; }
        }
        #endregion

        #region (* 虚方法 *)
        /// <summary>
        /// 创建默认坐标点
        /// </summary>
        protected virtual void CreateDefPointsCoordinates()
        {
            PointF pt = new PointF(3F, 1F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 1F);
            this.defPoints.Add(pt);
            pt = new PointF(9F, 2F);
            this.defPoints.Add(pt);
            pt = new PointF(10F, 3F);
            this.defPoints.Add(pt);
            pt = new PointF(10F, 8F);
            this.defPoints.Add(pt);
            pt = new PointF(9F, 9F);
            this.defPoints.Add(pt);
            pt = new PointF(10F, 10F);
            this.defPoints.Add(pt);
            pt = new PointF(10F, 15F);
            this.defPoints.Add(pt);
            pt = new PointF(9F, 16F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 17F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 17F);
            this.defPoints.Add(pt);
            pt = new PointF(2F, 16F);
            this.defPoints.Add(pt);
            pt = new PointF(1F, 15F);
            this.defPoints.Add(pt);
            pt = new PointF(1F, 10F);
            this.defPoints.Add(pt);
            pt = new PointF(2F, 9F);
            this.defPoints.Add(pt);
            pt = new PointF(1F, 8F);
            this.defPoints.Add(pt);
            pt = new PointF(1F, 3F);
            this.defPoints.Add(pt);
            pt = new PointF(2F, 2F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 3F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 3F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 8F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 10F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 15F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 15F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 10F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 8F);
            this.defPoints.Add(pt);
        }

        /// <summary>
        /// 创建各个段号对应的坐标闭包
        /// </summary>
        protected virtual void CreateSegmetsData()
        {
            this.Segments.Clear();

            Segment s = new Segment();
            s.PointsIndexs[0] = 0;
            s.PointsIndexs[1] = 1;
            s.PointsIndexs[2] = 2;
            s.PointsIndexs[3] = 19;
            s.PointsIndexs[4] = 18;
            s.PointsIndexs[5] = 17;
            this.Segments.Add('A', s);

            s = new Segment();
            s.PointsIndexs[0] = 2;
            s.PointsIndexs[1] = 3;
            s.PointsIndexs[2] = 4;
            s.PointsIndexs[3] = 5;
            s.PointsIndexs[4] = 20;
            s.PointsIndexs[5] = 19;
            this.Segments.Add('B', s);

            s = new Segment();
            s.PointsIndexs[0] = 6;
            s.PointsIndexs[1] = 7;
            s.PointsIndexs[2] = 8;
            s.PointsIndexs[3] = 22;
            s.PointsIndexs[4] = 21;
            s.PointsIndexs[5] = 5;
            this.Segments.Add('C', s);

            s = new Segment();
            s.PointsIndexs[0] = 9;
            s.PointsIndexs[1] = 10;
            s.PointsIndexs[2] = 11;
            s.PointsIndexs[3] = 23;
            s.PointsIndexs[4] = 22;
            s.PointsIndexs[5] = 8;
            this.Segments.Add('D', s);

            s = new Segment();
            s.PointsIndexs[0] = 12;
            s.PointsIndexs[1] = 13;
            s.PointsIndexs[2] = 14;
            s.PointsIndexs[3] = 24;
            s.PointsIndexs[4] = 23;
            s.PointsIndexs[5] = 11;
            this.Segments.Add('E', s);

            s = new Segment();
            s.PointsIndexs[0] = 15;
            s.PointsIndexs[1] = 16;
            s.PointsIndexs[2] = 17;
            s.PointsIndexs[3] = 18;
            s.PointsIndexs[4] = 25;
            s.PointsIndexs[5] = 14;
            this.Segments.Add('F', s);

            s = new Segment();
            s.PointsIndexs[0] = 25;
            s.PointsIndexs[1] = 20;
            s.PointsIndexs[2] = 5;
            s.PointsIndexs[3] = 21;
            s.PointsIndexs[4] = 24;
            s.PointsIndexs[5] = 14;
            this.Segments.Add('G', s);
        }

        /// <summary>
        /// 创建各个值对应的段号
        /// </summary>
        protected virtual void CreateSegmentsValuesList()
        {
            SegmentsList list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            list.Add('D');
            list.Add('E');
            list.Add('F');
            this.valuesSegments.Add(0, list);

            list = new SegmentsList();
            list.Add('B');
            list.Add('C');
            this.valuesSegments.Add(1, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('G');
            list.Add('E');
            list.Add('D');
            this.valuesSegments.Add(2, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('G');
            list.Add('C');
            list.Add('D');
            this.valuesSegments.Add(3, list);

            list = new SegmentsList();
            list.Add('F');
            list.Add('G');
            list.Add('B');
            list.Add('C');
            this.valuesSegments.Add(4, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('F');
            list.Add('G');
            list.Add('C');
            list.Add('D');
            this.valuesSegments.Add(5, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('F');
            list.Add('G');
            list.Add('C');
            list.Add('D');
            list.Add('E');
            this.valuesSegments.Add(6, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            this.valuesSegments.Add(7, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            list.Add('D');
            list.Add('E');
            list.Add('F');
            list.Add('G');
            this.valuesSegments.Add(8, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            list.Add('D');
            list.Add('F');
            list.Add('G');
            this.valuesSegments.Add(9, list);

            list = new SegmentsList();
            list.Add('G');
            this.valuesSegments.Add((int)'-', list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('D');
            list.Add('E');
            list.Add('F');
            list.Add('G');
            this.valuesSegments.Add((int)'E', list);
        }

        /// <summary>
        /// 计算新尺寸下的坐标点
        /// </summary>
        protected virtual void UpdatePointsCoordinates()
        {
            this.points.Clear();

            double rappW = 1;
            double rappH = 1;

            if (this.Display != null)
            {
                rappW = (double)this.Display.Width / (double)WIDTH_PIXEL;
                rappH = (double)this.Display.Height / (double)HEIGHT_PIXELS;
            }

            for (int idx = 0; idx < this.defPoints.Count; idx++)
            {
                PointF ptDef = this.defPoints[idx];
                PointF pt = new PointF((float)((double)ptDef.X * rappW), (float)((double)ptDef.Y * rappH));
                this.points.Add(pt);
            }

            this.rectDP.X = this.points[7].X - (float)(0.5 * rappW);
            this.rectDP.Y = this.points[8].Y;
            this.rectDP.Width = (float)(rappW*1.5);
            this.rectDP.Height = (float)(rappH*1.5);
        }

        /// <summary>
        /// 画背景
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        protected virtual bool DrawBackground(Graphics gr, RectangleF rc)
        {
            if (this.Display == null)
                return false;

            Color c = this.Display.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.Display.Width, this.Display.Height);
            gr.DrawRectangle(pen, _rcTmp);
            gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }

        /// <summary>
        /// 画暗状态
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        protected virtual bool DrawOffSegments(Graphics gr, RectangleF rc)
        {
            if (this.Display == null)
                return false;

            //SolidBrush br = new SolidBrush(LBColorManager.StepColor(this.Display.ForeColor, 30));
            Color clr = Color.FromArgb(this.Display.Pecent, this.Display.ForeColor);
            SolidBrush br = new SolidBrush(clr);

            foreach (Segment seg in this.Segments.Values)
            {
                GraphicsPath pth = new GraphicsPath();

                for (int idx = 0; idx < seg.PointsIndexs.Length - 1; idx++)
                {
                    PointF pt1 = this.points[seg.PointsIndexs[idx]];
                    PointF pt2 = this.points[seg.PointsIndexs[idx + 1]];
                    pth.AddLine(pt1, pt2);
                }
                pth.CloseFigure();

                gr.FillPath(br, pth);

                pth.Dispose();
            }

            gr.FillEllipse(br, this.rectDP);

            br.Dispose();
            return true;
        }

        /// <summary>
        /// 画亮状态
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        protected virtual bool DrawValue(Graphics gr, RectangleF rc)
        {
            if (this.Display == null)
                return false;

            if (this.valuesSegments.Contains(this.Display.Value) == false)
                return false;

            SegmentsList list = this.valuesSegments[this.Display.Value];
            if (list == null)
                return false;

            SolidBrush br = new SolidBrush(this.Display.ForeColor);

            foreach (char ch in list)
            {
                Segment seg = this.segments[ch];
                if (seg != null)
                {
                    GraphicsPath pth = new GraphicsPath();

                    for (int idx = 0; idx < seg.PointsIndexs.Length - 1; idx++)
                    {
                        PointF pt1 = this.points[seg.PointsIndexs[idx]];
                        PointF pt2 = this.points[seg.PointsIndexs[idx + 1]];
                        pth.AddLine(pt1, pt2);
                    }
                    pth.CloseFigure();

                    gr.FillPath(br, pth);

                    pth.Dispose();
                }
            }

            if (this.Display.ShowDP != false)
                gr.FillEllipse(br, this.rectDP);

            br.Dispose();

            return true;
        }
        #endregion
    }
    #region (*数据类定义*)
    /// <summary>
    /// 段字典
    /// </summary>
    public class SegmentDictionary : DictionaryBase
    {
        public Segment this[char ch]
        {
            set
            {
                if (Dictionary.Contains(ch) == false)
                    this.Add(ch, value);
                else
                    Dictionary[ch] = value;
            }
            get
            {
                if (Dictionary.Contains(ch) == false)
                    return null;

                return (Segment)this.Dictionary[ch];
            }
        }

        public void Add(char ch, Segment seg)
        {
            if (this.Contains(ch) == false)
                this.Dictionary.Add(ch, seg);
            else
                this[ch] = seg;
        }

        public bool Contains(char ch)
        {
            return this.Dictionary.Contains(ch);
        }

        public ICollection Values
        {
            get { return this.Dictionary.Values; }
        }

        public ICollection Keys
        {
            get { return this.Dictionary.Keys; }
        }
    }

    /// <summary>
    /// 段对应的6个坐标
    /// </summary>
    public class Segment
    {
        private int[] points = new int[6];
        public Segment()
        {
        }

        public int[] PointsIndexs
        {
            get { return this.points; }
        }
    }

    /// <summary>
    /// 坐标点列表
    /// </summary>
    public class PointsList : List<PointF>
    {
        public PointsList()
        {
        }
    }

    /// <summary>
    /// 段列表
    /// </summary>
    public class SegmentsList : List<char>
    {
        public SegmentsList()
        {
        }
    }

    /// <summary>
    /// 值对应的段字典
    /// </summary>
    public class SegmentsValueDictionary : DictionaryBase
    {
        public SegmentsList this[int num]
        {
            set
            {
                if (Dictionary.Contains(num) == false)
                    this.Add(num, value);
                else
                    Dictionary[num] = value;
            }
            get
            {
                if (Dictionary.Contains(num) == false)
                    return null;

                return (SegmentsList)this.Dictionary[num];
            }
        }

        public void Add(int num, SegmentsList seg)
        {
            if (this.Contains(num) == false)
                this.Dictionary.Add(num, seg);
            else
                this[num] = seg;
        }

        public bool Contains(int ch)
        {
            return this.Dictionary.Contains(ch);
        }

        public ICollection Values
        {
            get { return this.Dictionary.Values; }
        }

        public ICollection Keys
        {
            get { return this.Dictionary.Keys; }
        }
    }
    #endregion
}
