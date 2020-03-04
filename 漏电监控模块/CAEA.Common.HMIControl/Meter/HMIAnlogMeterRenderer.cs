//=================================================================
//
//文件名:HMIAnlogMeterRenderer
//
//Framework版本:4.0
//
//描述:仪表盘空间渲染器
//
//创建人:刘健
//
//创建日期:2016-09-12 13:39:15
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using CAEA.Common.HMIControl.Base;
using CAEA.Common.HMIControl.Utils;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CAEA.Common.HMIControl.Meter
{
    public class HMIAnlogMeterRenderer : HMIRenderBase
    {
        #region (* 变量 *)
        protected PointF needleCenter;
        protected RectangleF drawRect;
        protected RectangleF glossyRect;
        protected RectangleF needleCoverRect;
        protected float drawRatio;
        #endregion

        #region (* 属性 *)
        public HMIAnlogMeter AnalogMeter
        {
            get { return this.Control as HMIAnlogMeter; }
        }
        #endregion

        #region (* 重写方法 *)
        public override bool Update()
        {
            if (this.AnalogMeter == null)
                throw new NullReferenceException("Invalid 'AnalogMeter' object");

            // 矩形范围
            float x, y, w, h;
            x = 0;
            y = 0;
            w = this.AnalogMeter.Size.Width;
            h = this.AnalogMeter.Size.Height;

            // 计算比率
            drawRatio = (Math.Min(w, h)) / 200;
            if (drawRatio == 0.0)
                drawRatio = 1;

            //作业区域
            drawRect.X = x;
            drawRect.Y = y;
            drawRect.Width = w - 2;
            drawRect.Height = h - 2;

            if (w < h)
                drawRect.Height = w;
            else if (w > h)
                drawRect.Width = h;

            if (drawRect.Width < 10)
                drawRect.Width = 10;
            if (drawRect.Height < 10)
                drawRect.Height = 10;

            // 计算指针
            needleCenter.X = drawRect.X + (drawRect.Width / 2);
            needleCenter.Y = drawRect.Y + (drawRect.Height / 2);

            //指针圆圈
            needleCoverRect.X = needleCenter.X - (20 * drawRatio);
            needleCoverRect.Y = needleCenter.Y - (20 * drawRatio);
            needleCoverRect.Width = 40 * drawRatio;
            needleCoverRect.Height = 40 * drawRatio;

            // 玻璃反光效果区域
            glossyRect.X = drawRect.X + (20 * drawRatio);
            glossyRect.Y = drawRect.Y + (10 * drawRatio);
            glossyRect.Width = drawRect.Width - (40 * drawRatio);
            glossyRect.Height = needleCenter.Y + (30 * drawRatio);

            return false;
        }

        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            HMIAnlogMeter ctrl = this.AnalogMeter;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            this.DrawBackground(Gr, ctrl.Bounds);
            this.DrawBody(Gr, drawRect);
            this.DrawThresholds(Gr, drawRect);
            this.DrawDivisions(Gr, drawRect);
            this.DrawUM(Gr, drawRect);
            this.DrawValue(Gr, drawRect);
            this.DrawNeedle(Gr, drawRect);
            this.DrawNeedleCover(Gr, this.needleCoverRect);
            this.DrawGlass(Gr, this.glossyRect);
        }
        #endregion

        #region (*虚方法 *)
        /// <summary>
        /// 画背景
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawBackground(Graphics gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            Color c = this.AnalogMeter.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.AnalogMeter.Width, this.AnalogMeter.Height);
            gr.DrawRectangle(pen, _rcTmp);
            gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }
        /// <summary>
        /// 画表盘
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawBody(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            Color bodyColor = this.AnalogMeter.BodyColor;
            Color cDark = HMIColorManager.StepColor(bodyColor, 20);

            LinearGradientBrush br1 = new LinearGradientBrush(rc,
                                                               bodyColor,
                                                               cDark,
                                                               45);
            Gr.FillEllipse(br1, rc);

            RectangleF _rc = rc;
            _rc.X += 3 * drawRatio;
            _rc.Y += 3 * drawRatio;
            _rc.Width -= 6 * drawRatio;
            _rc.Height -= 6 * drawRatio;

            LinearGradientBrush br2 = new LinearGradientBrush(_rc,
                                                               cDark,
                                                               bodyColor,
                                                               45);
            Gr.FillEllipse(br2, _rc);

            br1.Dispose();
            br2.Dispose();
            return true;
        }
        /// <summary>
        /// 画刻度值
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawThresholds(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            RectangleF _rc = rc;
            _rc.Inflate(-18F * drawRatio, -18F * drawRatio);

            double w = _rc.Width;
            double radius = w / 2 - (w * 0.075);

            float startAngle = this.AnalogMeter.GetStartAngle();
            float endAngle = this.AnalogMeter.GetEndAngle();
            float rangeAngle = endAngle - startAngle;
            float minValue = (float)this.AnalogMeter.MinValue;
            float maxValue = (float)this.AnalogMeter.MaxValue;

            double stepVal = rangeAngle / (maxValue - minValue);

            foreach (MeterThreshold sect in this.AnalogMeter.Thresholds)
            {

                float startPathAngle = ((float)(startAngle + (stepVal * sect.StartValue)));
                float endPathAngle = ((float)((stepVal * (sect.EndValue - sect.StartValue))));

                GraphicsPath pth = new GraphicsPath();
                pth.AddArc(_rc, startPathAngle, endPathAngle);

                Pen pen = new Pen(sect.Color, 4.5F * drawRatio);

                Gr.DrawPath(pen, pth);

                pen.Dispose();
                pth.Dispose();
            }

            return false;
        }
        /// <summary>
        /// 画刻度
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawDivisions(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            float startAngle = this.AnalogMeter.GetStartAngle();
            float endAngle = this.AnalogMeter.GetEndAngle();
            float scaleDivisions = this.AnalogMeter.ScaleDivisions;
            float scaleSubDivisions = this.AnalogMeter.ScaleSubDivisions;
            double minValue = this.AnalogMeter.MinValue;
            double maxValue = this.AnalogMeter.MaxValue;
            Color scaleColor = this.AnalogMeter.ScaleColor;

            float cx = needleCenter.X;
            float cy = needleCenter.Y;
            float w = rc.Width;
            float h = rc.Height;

            float incr = HMIMath.GetRadian((endAngle - startAngle) / ((scaleDivisions - 1) * (scaleSubDivisions + 1)));
            float currentAngle = HMIMath.GetRadian(startAngle);
            float radius = (float)(w / 2 - (w * 0.08));//半径
            float rulerValue = (float)minValue;

            Pen pen = new Pen(scaleColor, (1 * drawRatio));
            SolidBrush br = new SolidBrush(scaleColor);

            PointF ptStart = new PointF(0, 0);
            PointF ptEnd = new PointF(0, 0);
            int n = 0;
            for (; n < scaleDivisions; n++)
            {
                //画大刻度
                ptStart.X = (float)(cx + radius * Math.Cos(currentAngle));
                ptStart.Y = (float)(cy + radius * Math.Sin(currentAngle));
                ptEnd.X = (float)(cx + (radius - w / 20) * Math.Cos(currentAngle));
                ptEnd.Y = (float)(cy + (radius - w / 20) * Math.Sin(currentAngle));
                Gr.DrawLine(pen, ptStart, ptEnd);

                //画文本
                Font font = new Font(this.AnalogMeter.Font.FontFamily, (float)(6F * drawRatio));

                float tx = (float)(cx + (radius - (20 * drawRatio)) * Math.Cos(currentAngle));
                float ty = (float)(cy + (radius - (20 * drawRatio)) * Math.Sin(currentAngle));
                double val = Math.Round(rulerValue);
                String str = String.Format("{0,0:D}", (int)val);

                SizeF size = Gr.MeasureString(str, font);
                Gr.DrawString(str,
                                font,
                                br,
                                tx - (float)(size.Width * 0.5),
                                ty - (float)(size.Height * 0.5));

                rulerValue += (float)((maxValue - minValue) / (scaleDivisions - 1));

                if (n == scaleDivisions - 1)
                {
                    font.Dispose();
                    break;
                }

                if (scaleDivisions <= 0)
                    currentAngle += incr;
                else
                {
                    for (int j = 0; j <= scaleSubDivisions; j++)
                    {
                        currentAngle += incr;
                        ptStart.X = (float)(cx + radius * Math.Cos(currentAngle));
                        ptStart.Y = (float)(cy + radius * Math.Sin(currentAngle));
                        ptEnd.X = (float)(cx + (radius - w / 50) * Math.Cos(currentAngle));
                        ptEnd.Y = (float)(cy + (radius - w / 50) * Math.Sin(currentAngle));
                        Gr.DrawLine(pen, ptStart, ptEnd);
                    }
                }

                font.Dispose();
            }

            pen.Dispose();
            br.Dispose();
            return true;
        }
        /// <summary>
        /// 画报警线和正常线
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawUM(Graphics gr, RectangleF rc)
        {
            float startAngle = this.AnalogMeter.GetStartAngle();
            float endAngle = this.AnalogMeter.GetEndAngle();
            double minValue = this.AnalogMeter.MinValue;
            double maxValue = this.AnalogMeter.MaxValue;
            double minNorValue = this.AnalogMeter.MinNValueNor;
            double maxNorValue = this.AnalogMeter.MaxValueNor;
            Color NorColor = this.AnalogMeter.ScaleColor;
            Color UnNorColor = this.AnalogMeter.UnNormalColor;

            float minNorAngle = (float)(endAngle - startAngle)/(float)(maxValue - minValue)*(float)(minNorValue-minValue)+startAngle;
            float maxNorAngle = (float)(endAngle - startAngle) / (float)(maxValue - minValue) * (float)(maxNorValue - minValue)+startAngle;
            RectangleF _rc = new RectangleF();
            _rc.Height = (float)0.92 * rc.Height;
            _rc.Width = (float)0.92 * rc.Width;
            _rc.X = rc.X + (rc.Width - _rc.Width) / (float)2.0;
            _rc.Y = rc.Y + (rc.Height - _rc.Height) / (float)2.0;

            SolidBrush br1 = new SolidBrush(UnNorColor);
            Pen pen1 = new Pen(br1, 5 * drawRatio);
            gr.DrawArc(pen1, _rc, startAngle, minNorAngle-startAngle);
            gr.DrawArc(pen1, _rc, maxNorAngle, endAngle-maxNorAngle);

            SolidBrush br2 = new SolidBrush(NorColor);
            Pen pen2 = new Pen(br2, 5 * drawRatio);
            gr.DrawArc(pen2, _rc, minNorAngle, maxNorAngle-minNorAngle);

            br1.Dispose();
            br2.Dispose();
            pen1.Dispose();
            pen2.Dispose();
            return true;
        }
        /// <summary>
        /// 画显示值
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawValue(Graphics Gr, RectangleF rc)
        {
            Color scaleColor = this.AnalogMeter.ScaleColor;
            if(this.AnalogMeter.Value < this.AnalogMeter.MinNValueNor
                || this.AnalogMeter.Value > this.AnalogMeter.MaxValueNor)
            {
                scaleColor = this.AnalogMeter.UnNormalColor;
            }
            SolidBrush br = new SolidBrush(scaleColor);
            float cx = needleCenter.X;
            float cy = needleCenter.Y*1.6F;
            Font font = new Font(this.AnalogMeter.Font.FontFamily, (float)(20F * drawRatio));

            String str = this.AnalogMeter.Value.ToString("0.###"); 

            SizeF size = Gr.MeasureString(str, font);
            Gr.DrawString(str,
                            font,
                            br,
                            cx - (float)(size.Width * 0.5),
                            cy - (float)(size.Height * 0.5));
            font.Dispose();
            br.Dispose();
            return true;
        }
        /// <summary>
        /// 画指针
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawNeedle(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            float w, h;
            w = rc.Width;
            h = rc.Height;

            double minValue = this.AnalogMeter.MinValue;
            double maxValue = this.AnalogMeter.MaxValue;
            double currValue = this.AnalogMeter.Value;
            float startAngle = this.AnalogMeter.GetStartAngle();
            float endAngle = this.AnalogMeter.GetEndAngle();

            float radius = (float)(w / 2 - (w * 0.12));
            float val = (float)(maxValue - minValue);

            val = (float)((100 * (currValue - minValue)) / val);
            val = ((endAngle - startAngle) * val) / 100;
            val += startAngle;

            float angle = HMIMath.GetRadian(val);

            float cx = needleCenter.X;
            float cy = needleCenter.Y;

            PointF ptStart = new PointF(0, 0);
            PointF ptEnd = new PointF(0, 0);

            GraphicsPath pth1 = new GraphicsPath();

            ptStart.X = cx;
            ptStart.Y = cy;
            angle = HMIMath.GetRadian(val + 10);
            ptEnd.X = (float)(cx + (w * .09F) * Math.Cos(angle));
            ptEnd.Y = (float)(cy + (w * .09F) * Math.Sin(angle));
            pth1.AddLine(ptStart, ptEnd);

            ptStart = ptEnd;
            angle = HMIMath.GetRadian(val);
            ptEnd.X = (float)(cx + radius * Math.Cos(angle));
            ptEnd.Y = (float)(cy + radius * Math.Sin(angle));
            pth1.AddLine(ptStart, ptEnd);

            ptStart = ptEnd;
            angle = HMIMath.GetRadian(val - 10);
            ptEnd.X = (float)(cx + (w * .09F) * Math.Cos(angle));
            ptEnd.Y = (float)(cy + (w * .09F) * Math.Sin(angle));
            pth1.AddLine(ptStart, ptEnd);

            pth1.CloseFigure();
            Color clr = this.AnalogMeter.NeedleColor;
            if (this.AnalogMeter.Value < this.AnalogMeter.MinNValueNor
                || this.AnalogMeter.Value > this.AnalogMeter.MaxValueNor)
            {
                clr = this.AnalogMeter.UnNormalColor;
            }
            SolidBrush br = new SolidBrush(clr);
            Pen pen = new Pen(clr);
            Gr.DrawPath(pen, pth1);
            Gr.FillPath(br, pth1);

            pth1.Dispose();
            br.Dispose();
            pen.Dispose();
            return true;
        }
        /// <summary>
        /// 画指针的圆
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawNeedleCover(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            Color clr = this.AnalogMeter.NeedleColor;
            if (this.AnalogMeter.Value < this.AnalogMeter.MinNValueNor
                || this.AnalogMeter.Value > this.AnalogMeter.MaxValueNor)
            {
                clr = this.AnalogMeter.UnNormalColor;
            }
            RectangleF _rc = rc;

            Color clr1 = Color.FromArgb(70, clr);

            _rc.Inflate(5 * drawRatio, 5 * drawRatio);

            SolidBrush brTransp = new SolidBrush(clr1);
            Gr.FillEllipse(brTransp, _rc);

            clr1 = clr;
            Color clr2 = HMIColorManager.StepColor(clr, 75);
            LinearGradientBrush br1 = new LinearGradientBrush(rc,
                                                               clr1,
                                                               clr2,
                                                               45);
            Gr.FillEllipse(br1, rc);

            brTransp.Dispose();
            br1.Dispose();
            return true;
        }

        public virtual bool DrawGlass(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            if (this.AnalogMeter.ViewGlass == false)
                return true;

            Color clr1 = Color.FromArgb(40, 200, 200, 200);

            Color clr2 = Color.FromArgb(0, 200, 200, 200);
            LinearGradientBrush br1 = new LinearGradientBrush(rc,
                                                               clr1,
                                                               clr2,
                                                               45);
            Gr.FillEllipse(br1, rc);

            br1.Dispose();
            return true;
        }
        #endregion
    }
}
