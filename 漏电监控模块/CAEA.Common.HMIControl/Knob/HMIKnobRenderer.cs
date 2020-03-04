//=================================================================
//
//文件名:HMIKnobRenderer
//
//Framework版本:4.0
//
//描述:旋钮控件渲染器
//
//创建人:刘健
//
//创建日期:2016-11-14 11:04:45
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using CAEA.Common.HMIControl.Base;
using CAEA.Common.HMIControl.Utils;

namespace CAEA.Common.HMIControl.Knob
{
    public class HMIKnobRenderer : HMIRenderBase
    {
        #region (* 变量 *)
        private RectangleF drawRect;
        private RectangleF derectionRect;
        private RectangleF rectScale;
        private RectangleF rectKnob;
        private PointF knobCenter;
        private PointF knobIndicatorPos;
        private float drawRatio;
        #endregion

        #region (* 属性 *)
        public HMIKnob Knob
        {
            get { return this.Control as HMIKnob; }
        }
        #endregion

        #region (* 重写函数 *)
        public override bool Update()
        {
            if (this.Knob == null)
                throw new NullReferenceException("Invalid 'Knob' object");

            float x, y, w, h;
            x = 0;
            y = 0;
            w = this.Knob.Size.Width;
            h = this.Knob.Size.Height;

            drawRatio = (Math.Min(w, h)) / 200;
            if (drawRatio == 0.0)
                drawRatio = 1;

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
            if (this.Knob.Display8DerectionFlag)
            {
                this.derectionRect = this.drawRect;
                this.rectScale = new RectangleF(this.drawRect.X + this.Knob.Knob8DerectionWight* drawRatio, this.drawRect.Y + this.Knob.Knob8DerectionWight* drawRatio,
                    this.drawRect.Width - 2 * this.Knob.Knob8DerectionWight* drawRatio, this.drawRect.Height - 2 * this.Knob.Knob8DerectionWight* drawRatio);
                this.rectKnob = this.rectScale;
            }
            else
            {
                this.derectionRect = this.drawRect;
                this.rectScale = this.drawRect;
                this.rectKnob = this.drawRect;
            }
            this.rectKnob.Inflate(-25 * this.drawRatio, -25 * this.drawRatio);

            this.knobCenter.X = this.rectKnob.Left + (this.rectKnob.Width * 0.5F);
            this.knobCenter.Y = this.rectKnob.Top + (this.rectKnob.Height * 0.5F);

            this.knobIndicatorPos = this.Knob.GetPositionFromValue(this.Knob.Value);

            this.Knob.DerectionRect = this.derectionRect;
            this.Knob.KnobRect = this.rectKnob;
            this.Knob.KnobCenter = this.knobCenter;
            this.Knob.DrawRatio = this.drawRatio;
            return true;
        }

        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            HMIKnob ctrl = this.Knob;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            this.DrawBackground(Gr, ctrl.Bounds);
            this.DrawDerection(Gr, this.derectionRect);
            if (Knob.KnobScaleStyle == HMIKnob.ScaleStyle.Scale)
                this.DrawScale(Gr, this.rectScale);
            else
                this.DrawCircularScale(Gr, this.rectScale);
            this.DrawKnob(Gr, this.rectKnob);
            if(Knob.KnobScaleStyle == HMIKnob.ScaleStyle.Scale)
                this.DrawKnobIndicator(Gr, this.rectKnob, this.knobIndicatorPos);
            this.DrawKnobArrow(Gr, this.rectKnob);
        }
        #endregion

        #region (* 虚方法 *)
        /// <summary>
        /// 画控件背景
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawBackground(Graphics Gr, RectangleF rc)
        {
            if (this.Knob == null)
                return false;

            Color c = this.Knob.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.Knob.Width, this.Knob.Height);
            Gr.DrawRectangle(pen, _rcTmp);
            Gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }
        /// <summary>
        /// 画外圈8向指示
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawDerection(Graphics Gr,RectangleF rc)
        {
            if (this.Knob == null)
                return false;
            if (!this.Knob.Display8DerectionFlag)
                return true;

            PointF[] points = this.Knob.GetDerectionPoints();

            //上方
            Color tempColor = this.Knob.TopColor;
            if (this.Knob.KnobDerectionType != HMIKnob.Knob8DerectionType.Top)
                tempColor = HMIColorManager.StepColor(tempColor, this.Knob.DerectionColorStep);
            GraphicsPath pth = new GraphicsPath();
            pth.AddLine(points[0], points[1]);
            pth.AddArc(this.derectionRect.X, this.derectionRect.Y, this.derectionRect.Width, this.derectionRect.Height, 247.5F, 45F);
            pth.AddLine(points[2], points[3]);
            pth.AddArc(this.derectionRect.X + this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Y + this.Knob.Knob8DerectionWight * drawRatio,
                this.derectionRect.Width - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Height - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, 292.5F, -45F);
            SolidBrush br = new SolidBrush(tempColor);
            Pen pen = new Pen(tempColor);
            Gr.DrawPath(pen, pth);
            Gr.FillPath(br, pth);
            br.Dispose();
            pen.Dispose();
            pth.Dispose();

            //右上
            tempColor = this.Knob.Top_Right_Color;
            if (this.Knob.KnobDerectionType != HMIKnob.Knob8DerectionType.Top_Right)
                tempColor = HMIColorManager.StepColor(tempColor, this.Knob.DerectionColorStep);
            pth = new GraphicsPath();
            pth.AddLine(points[3], points[2]);
            pth.AddArc(this.derectionRect.X, this.derectionRect.Y, this.derectionRect.Width, this.derectionRect.Height, 292.5F, 45F);
            pth.AddLine(points[5], points[4]);
            pth.AddArc(this.derectionRect.X + this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Y + this.Knob.Knob8DerectionWight * drawRatio,
                this.derectionRect.Width - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Height - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, 337.5F, -45F);
            br = new SolidBrush(tempColor);
            pen = new Pen(tempColor);
            Gr.DrawPath(pen, pth);
            Gr.FillPath(br, pth);
            br.Dispose();
            pen.Dispose();
            pth.Dispose();

            //右
            tempColor = this.Knob.RightColor;
            if (this.Knob.KnobDerectionType != HMIKnob.Knob8DerectionType.Right)
                tempColor = HMIColorManager.StepColor(tempColor, this.Knob.DerectionColorStep);
            pth = new GraphicsPath();
            pth.AddLine(points[4], points[5]);
            pth.AddArc(this.derectionRect.X, this.derectionRect.Y, this.derectionRect.Width, this.derectionRect.Height, 337.5F, 45F);
            pth.AddLine(points[6], points[7]);
            pth.AddArc(this.derectionRect.X + this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Y + this.Knob.Knob8DerectionWight * drawRatio,
                this.derectionRect.Width - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Height - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, 22.5F, -45F);
            br = new SolidBrush(tempColor);
            pen = new Pen(tempColor);
            Gr.DrawPath(pen, pth);
            Gr.FillPath(br, pth);
            br.Dispose();
            pen.Dispose();
            pth.Dispose();

            //右下
            tempColor = this.Knob.Buttom_Right_Color;
            if (this.Knob.KnobDerectionType != HMIKnob.Knob8DerectionType.Buttom_Right)
                tempColor = HMIColorManager.StepColor(tempColor, this.Knob.DerectionColorStep);
            pth = new GraphicsPath();
            pth.AddLine(points[7], points[6]);
            pth.AddArc(this.derectionRect.X, this.derectionRect.Y, this.derectionRect.Width, this.derectionRect.Height, 22.5F, 45F);
            pth.AddLine(points[9], points[8]);
            pth.AddArc(this.derectionRect.X + this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Y + this.Knob.Knob8DerectionWight * drawRatio,
                this.derectionRect.Width - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Height - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, 67.5F, -45F);
            br = new SolidBrush(tempColor);
            pen = new Pen(tempColor);
            Gr.DrawPath(pen, pth);
            Gr.FillPath(br, pth);
            br.Dispose();
            pen.Dispose();
            pth.Dispose();

            //下
            tempColor = this.Knob.ButtomColor;
            if (this.Knob.KnobDerectionType != HMIKnob.Knob8DerectionType.Buttom)
                tempColor = HMIColorManager.StepColor(tempColor, this.Knob.DerectionColorStep);
            pth = new GraphicsPath();
            pth.AddLine(points[8], points[9]);
            pth.AddArc(this.derectionRect.X, this.derectionRect.Y, this.derectionRect.Width, this.derectionRect.Height, 67.5F, 45F);
            pth.AddLine(points[10], points[11]);
            pth.AddArc(this.derectionRect.X + this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Y + this.Knob.Knob8DerectionWight * drawRatio,
                this.derectionRect.Width - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Height - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, 112.5F, -45F);
            br = new SolidBrush(tempColor);
            pen = new Pen(tempColor);
            Gr.DrawPath(pen, pth);
            Gr.FillPath(br, pth);
            br.Dispose();
            pen.Dispose();
            pth.Dispose();

            //左下
            tempColor = this.Knob.Buttom_Left_Color;
            if (this.Knob.KnobDerectionType != HMIKnob.Knob8DerectionType.Buttom_Left)
                tempColor = HMIColorManager.StepColor(tempColor, this.Knob.DerectionColorStep);
            pth = new GraphicsPath();
            pth.AddLine(points[11], points[10]);
            pth.AddArc(this.derectionRect.X, this.derectionRect.Y, this.derectionRect.Width, this.derectionRect.Height, 112.5F, 45F);
            pth.AddLine(points[13], points[12]);
            pth.AddArc(this.derectionRect.X + this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Y + this.Knob.Knob8DerectionWight * drawRatio,
                this.derectionRect.Width - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Height - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, 157.5F, -45F);
            br = new SolidBrush(tempColor);
            pen = new Pen(tempColor);
            Gr.DrawPath(pen, pth);
            Gr.FillPath(br, pth);
            br.Dispose();
            pen.Dispose();
            pth.Dispose();

            //左
            tempColor = this.Knob.LeftColor;
            if (this.Knob.KnobDerectionType != HMIKnob.Knob8DerectionType.Left)
                tempColor = HMIColorManager.StepColor(tempColor, this.Knob.DerectionColorStep);
            pth = new GraphicsPath();
            pth.AddLine(points[12], points[13]);
            pth.AddArc(this.derectionRect.X, this.derectionRect.Y, this.derectionRect.Width, this.derectionRect.Height, 157.5F, 45F);
            pth.AddLine(points[14], points[15]);
            pth.AddArc(this.derectionRect.X + this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Y + this.Knob.Knob8DerectionWight * drawRatio,
                this.derectionRect.Width - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Height - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, 202.5F, -45F);
            br = new SolidBrush(tempColor);
            pen = new Pen(tempColor);
            Gr.DrawPath(pen, pth);
            Gr.FillPath(br, pth);
            br.Dispose();
            pen.Dispose();
            pth.Dispose();

            //左上
            tempColor = this.Knob.Top_Left_Color;
            if (this.Knob.KnobDerectionType != HMIKnob.Knob8DerectionType.Top_Left)
                tempColor = HMIColorManager.StepColor(tempColor, this.Knob.DerectionColorStep);
            pth = new GraphicsPath();
            pth.AddLine(points[15], points[14]);
            pth.AddArc(this.derectionRect.X, this.derectionRect.Y, this.derectionRect.Width, this.derectionRect.Height, 202.5F, 45F);
            pth.AddLine(points[1], points[0]);
            pth.AddArc(this.derectionRect.X + this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Y + this.Knob.Knob8DerectionWight * drawRatio,
                this.derectionRect.Width - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, this.derectionRect.Height - 2.0F * this.Knob.Knob8DerectionWight * drawRatio, 247.5F, -45F);
            br = new SolidBrush(tempColor);
            pen = new Pen(tempColor);
            Gr.DrawPath(pen, pth);
            Gr.FillPath(br, pth);
            br.Dispose();
            pen.Dispose();
            pth.Dispose();

            return true;
        }
        /// <summary>
        /// 画刻度
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawScale(Graphics Gr, RectangleF rc)
        {
            if (this.Knob == null)
                return false;

            Color cKnob = this.Knob.ScaleColor;
            Color cKnobDark = HMIColorManager.StepColor(cKnob, 60);

            LinearGradientBrush br = new LinearGradientBrush(rc, cKnobDark, cKnob, 45);
            Gr.FillEllipse(br, rc);

            PointF pf = new PointF(0.0F, 0.0F);
            Font ft = new Font(this.Knob.Font.FontFamily, (float)15F * drawRatio);
            SolidBrush sb = new SolidBrush(this.Knob.ScaleValueColor);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            if (this.Knob.MaxValue - this.Knob.MinValue != 0)
            {
                for (float i = this.Knob.MinValue; i <= this.Knob.MaxValue; i += this.Knob.StepValue)
                {
                    float degree = 270F * (i-this.Knob.MinValue) / (this.Knob.MaxValue - this.Knob.MinValue);
                    degree = (degree + 135F) * (float)Math.PI / 180F;
                    
                    pf.X = (int)(Math.Cos(degree) * ((rc.Width * 0.5F) - 10F * drawRatio) + rc.X + (rc.Width * 0.5F));
                    pf.Y = (int)(Math.Sin(degree) * ((rc.Width * 0.5F) - 10F * drawRatio) + rc.Y + (rc.Height * 0.5F));

                    string str = i.ToString();
                    SizeF size = Gr.MeasureString(str, ft);

                    RectangleF _rc = rc;
                    _rc.X = pf.X - size.Width/2F;
                    _rc.Y = pf.Y - size.Height/2F;
                    _rc.Width = size.Width;
                    _rc.Height = size.Height;

                    Gr.DrawString(str, ft, sb, _rc, format);
                }
            }
            ft.Dispose();
            sb.Dispose();
            format.Dispose();
            br.Dispose();

            return true;
        }
        /// <summary>
        /// 画环形刻度指示
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawCircularScale(Graphics Gr,RectangleF rc)
        {
            if (this.Knob == null)
                return false;

            Color cKnob = this.Knob.ScaleColor;
            Color cKnobDark = HMIColorManager.StepColor(cKnob, 60);

            LinearGradientBrush br1 = new LinearGradientBrush(rc, cKnobDark, cKnob, 45);
            Gr.FillEllipse(br1, rc);

            Color cKnob1 = this.Knob.ScaleColor;
            Color cKnob2 = this.Knob.ScaleOtherColor;
            Color cKnobDark1 = HMIColorManager.StepColor(cKnob1, this.Knob.ScaleColorStep);
            Color cKnobDark2 = HMIColorManager.StepColor(cKnob2, this.Knob.ScaleColorStep);
            Color tempColor = cKnobDark2;

            GraphicsPath pth = new GraphicsPath();
            SolidBrush br = new SolidBrush(tempColor);
            Pen pen = new Pen(tempColor);
            if (this.Knob.MaxValue - this.Knob.MinValue != 0)
            {
                float startDegree = 90F;
                if (this.Knob.ScaleInterverlFlag)
                    startDegree = 89F;
                PointF[] points = new PointF[(int)(this.Knob.MaxValue - this.Knob.MinValue+ this.Knob.StepValue)];
                points[0] = new PointF();
                float degree = 360F * (0 - this.Knob.MinValue) / (this.Knob.MaxValue - this.Knob.MinValue + this.Knob.StepValue);
                float begindegree = (degree + startDegree) * (float)Math.PI / 180F;
                degree = (degree + 90F) * (float)Math.PI / 180F;
                points[0].X = (float)(Math.Cos(degree) * (this.derectionRect.Width * 0.5F - this.drawRatio * this.Knob.Knob8DerectionWight) + this.derectionRect.Width * 0.5F);
                points[0].Y = (float)(Math.Sin(degree) * (this.derectionRect.Width * 0.5F - this.drawRatio * this.Knob.Knob8DerectionWight) + this.derectionRect.Height * 0.5F);
                PointF realBeginPoint = new PointF();
                realBeginPoint.X = (float)(Math.Cos(begindegree) * (this.derectionRect.Width * 0.5F - this.drawRatio * this.Knob.Knob8DerectionWight) + this.derectionRect.Width * 0.5F);
                realBeginPoint.Y = (float)(Math.Sin(begindegree) * (this.derectionRect.Width * 0.5F - this.drawRatio * this.Knob.Knob8DerectionWight) + this.derectionRect.Height * 0.5F);
                for (float i = this.Knob.MinValue; i <= this.Knob.MaxValue; i += this.Knob.StepValue)
                {
                    PointF realEndPoint = new PointF();
                    if (i < this.Knob.MaxValue)
                    {
                        points[(int)(i + this.Knob.StepValue)] = new PointF();

                        degree = 360F * (i + this.Knob.StepValue - this.Knob.MinValue) / (this.Knob.MaxValue - this.Knob.MinValue + this.Knob.StepValue);
                        float degree2 = (degree + startDegree) * (float)Math.PI / 180F;
                        degree = (degree + 90F) * (float)Math.PI / 180F;
                        points[(int)(i + this.Knob.StepValue)].X = (float)(Math.Cos(degree) * (this.derectionRect.Width * 0.5F - this.drawRatio * this.Knob.Knob8DerectionWight) + this.derectionRect.Width * 0.5F);
                        points[(int)(i + this.Knob.StepValue)].Y = (float)(Math.Sin(degree) * (this.derectionRect.Width * 0.5F - this.drawRatio * this.Knob.Knob8DerectionWight) + this.derectionRect.Height * 0.5F);
                        realEndPoint.X = (float)(Math.Cos(degree2) * (this.derectionRect.Width * 0.5F - this.drawRatio * this.Knob.Knob8DerectionWight) + this.derectionRect.Width * 0.5F);
                        realEndPoint.Y = (float)(Math.Sin(degree2) * (this.derectionRect.Width * 0.5F - this.drawRatio * this.Knob.Knob8DerectionWight) + this.derectionRect.Height * 0.5F);
                        //points[(int)(i + this.Knob.StepValue)].X = (float)(Math.Cos(degree) * ((this.drawRect.Width * 0.5F)) + (this.drawRect.Width * 0.5F));
                        //points[(int)(i + this.Knob.StepValue)].Y = (float)(Math.Sin(degree) * ((this.drawRect.Height * 0.5F)) + (this.drawRect.Height * 0.5F));
                    }
                    //if (i % 2 == 0)
                    //{
                        if (Knob.Value >= i) tempColor = cKnob2;
                        else tempColor = cKnobDark1;
                    //}
                    //else
                    //{
                    //    if (Knob.Value >= i) tempColor = cKnob1;
                    //    else tempColor = cKnobDark1;
                    //}

                    float degreeBegin = 360F * (i - this.Knob.MinValue) / (this.Knob.MaxValue - this.Knob.MinValue + this.Knob.StepValue) + 90;
                    float degreeEnd = 360F * (i+1 - this.Knob.MinValue) / (this.Knob.MaxValue - this.Knob.MinValue + this.Knob.StepValue) + 90;
                    pth = new GraphicsPath();
                    pth.AddLine(this.knobCenter, points[(int)i]);
                    pth.AddArc(rc.X, rc.Y, rc.Width, rc.Height, degreeBegin, degreeEnd - degreeBegin);
                    if (i == this.Knob.MaxValue)
                        pth.AddLine(realBeginPoint, this.knobCenter);
                    else
                        pth.AddLine(realEndPoint, this.knobCenter);
                    //pth.AddArc(rectKnob.X, rectKnob.Y, rectKnob.Width, rectKnob.Height, degreeEnd, degreeBegin - degreeEnd);
                    br = new SolidBrush(tempColor);
                    pen = new Pen(tempColor);
                    Gr.DrawPath(pen, pth);
                    Gr.FillPath(br, pth);
                    //br.Dispose();
                    //pen.Dispose();
                    //pth.Dispose();
                }
            }
            
            
            return true;
        }
        /// <summary>
        /// 画空间体
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawKnob(Graphics Gr, RectangleF rc)
        {
            if (this.Knob == null)
                return false;

            Color cKnob = this.Knob.KnobColor;
            Color cKnobDark = HMIColorManager.StepColor(cKnob, 60);

            LinearGradientBrush br = new LinearGradientBrush(rc, cKnob, cKnobDark, 45);

            Gr.FillEllipse(br, rc);

            if(this.Knob.State == HMIKnob.ButtonState.Pressed)
            {
                RectangleF _rc = rc;
                _rc.Inflate(-15F * this.drawRatio, -15F * drawRatio);
                LinearGradientBrush br2 = new LinearGradientBrush(_rc,
                                                                   cKnobDark,
                                                                   cKnob,
                                                                   45);
                Gr.FillEllipse(br2, _rc);
                br2.Dispose();
            }

            br.Dispose();

            return true;
        }
        /// <summary>
        /// 画位置点和当前值
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual bool DrawKnobIndicator(Graphics Gr, RectangleF rc, PointF pos)
        {
            if (this.Knob == null)
                return false;

            RectangleF _rc = rc;
            _rc.X = pos.X - 4;
            _rc.Y = pos.Y - 4;
            _rc.Width = 8;
            _rc.Height = 8;

            Color cKnob = this.Knob.IndicatorColor;
            Color cKnobDark = HMIColorManager.StepColor(cKnob, 60);

            LinearGradientBrush br = new LinearGradientBrush(_rc, cKnobDark, cKnob, 45);

            Gr.FillEllipse(br, _rc);

            SolidBrush sb = new SolidBrush(this.Knob.ValueColor);
            Font f = new Font(this.Knob.Font.FontFamily, (float)40F * drawRatio);
            string str = this.Knob.Value.ToString();

            SizeF size = Gr.MeasureString(str,f);

            Gr.DrawString(str,
                            f,
                            sb,
                            this.knobCenter.X - (float)(size.Width * 0.5),
                            this.knobCenter.Y - (float)(size.Height * 0.5));
            sb.Dispose();
            f.Dispose();
            br.Dispose();

            return true;
        }
        /// <summary>
        /// 画箭头指示
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawKnobArrow(Graphics Gr, RectangleF rc)
        {
            if (this.Knob == null)
                return false;
            if (this.Knob.ArrowStyle == HMIKnob.KnobArrowStyle.None)
                return true;

            Color ArrowColor = this.Knob.ArrowColor;
            GraphicsPath pth1 = new GraphicsPath();
            PointF ptStart = new PointF(0, 0);
            PointF ptEnd = new PointF(0, 0);

            ptStart.X = this.knobCenter.X;
            ptStart.Y = this.knobCenter.Y - (40 * drawRatio);
            ptEnd.X = this.knobCenter.X;
            ptEnd.Y = this.knobCenter.Y - (50 * drawRatio);
            pth1.AddLine(ptStart, ptEnd);

            if(this.Knob.ArrowStyle == HMIKnob.KnobArrowStyle.Eastern)
            {//逆时针                
                pth1.AddArc(this.knobCenter.X - (50 * drawRatio), this.knobCenter.Y - (50 * drawRatio), 100 * drawRatio, 100 * drawRatio, 270, -90);                
                
                ptStart.X = this.knobCenter.X - 50 * drawRatio;
                ptStart.Y = this.knobCenter.Y;
                ptEnd.X = ptStart.X - 5 * drawRatio;
                ptEnd.Y = this.knobCenter.Y;
                pth1.AddLine(ptStart, ptEnd);

                ptStart = ptEnd;
                ptEnd.X = this.knobCenter.X - 45 * drawRatio;
                ptEnd.Y = this.knobCenter.Y + 10 * drawRatio;
                pth1.AddLine(ptStart, ptEnd);

                ptStart = ptEnd;
                ptEnd.X = this.knobCenter.X - 35 * drawRatio;
                ptEnd.Y = this.knobCenter.Y;
                pth1.AddLine(ptStart, ptEnd);

                ptStart = ptEnd;
                ptEnd.X = this.knobCenter.X - 40 * drawRatio;
                ptEnd.Y = this.knobCenter.Y;
                pth1.AddLine(ptStart, ptEnd);

                pth1.AddArc(this.knobCenter.X - (40 * drawRatio), this.knobCenter.Y - (40 * drawRatio), 80 * drawRatio, 80 * drawRatio, 180, 90);
            }
            else
            {//顺时针
                pth1.AddArc(this.knobCenter.X - (50 * drawRatio), this.knobCenter.Y - (50 * drawRatio), 100 * drawRatio, 100 * drawRatio, 270, 90);

                ptStart.X = this.knobCenter.X + 50 * drawRatio;
                ptStart.Y = this.knobCenter.Y;
                ptEnd.X = ptStart.X + 5 * drawRatio;
                ptEnd.Y = this.knobCenter.Y;
                pth1.AddLine(ptStart, ptEnd);

                ptStart = ptEnd;
                ptEnd.X = this.knobCenter.X + 45 * drawRatio;
                ptEnd.Y = this.knobCenter.Y + 10 * drawRatio;
                pth1.AddLine(ptStart, ptEnd);

                ptStart = ptEnd;
                ptEnd.X = this.knobCenter.X + 35 * drawRatio;
                ptEnd.Y = this.knobCenter.Y;
                pth1.AddLine(ptStart, ptEnd);

                ptStart = ptEnd;
                ptEnd.X = this.knobCenter.X + 40 * drawRatio;
                ptEnd.Y = this.knobCenter.Y;
                pth1.AddLine(ptStart, ptEnd);

                pth1.AddArc(this.knobCenter.X - (40 * drawRatio), this.knobCenter.Y - (40 * drawRatio), 80 * drawRatio, 80 * drawRatio, 0, -90);
            }

            SolidBrush br = new SolidBrush(ArrowColor);
            Pen pen = new Pen(ArrowColor);
            Gr.DrawPath(pen, pth1);
            Gr.FillPath(br, pth1);

            br.Dispose();
            pen.Dispose();
            pth1.Dispose();
            return true;
        }
        #endregion
    }
}
