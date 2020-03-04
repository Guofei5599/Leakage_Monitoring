//=================================================================
//
//文件名:HMIArrowRenderer
//
//Framework版本:4.0
//
//描述:箭头控件渲染器
//
//创建人:刘健
//
//创建日期:2016-11-14 13:49:28
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using CAEA.Common.HMIControl.Base;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CAEA.Common.HMIControl.Arrow
{
    class HMIArrowRenderer : HMIRenderBase
    {
        #region (* 变量 *)
        private RectangleF drawRect;
        protected float drawRatio = 1.0F;
        #endregion

        #region (*属性*)
        /// <summary>
        /// 获取对象
        /// </summary>
        public HMIArrow Arrow
        {
            get { return this.Control as HMIArrow; }
        }
        #endregion

        #region (*重写函数*)
        /// <summary>
        /// 重写更新重画函数
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            if(this.Arrow == null)
                throw new NullReferenceException("Invalid 'Arrow' object");
            float x, y, w, h;
            x = 0;
            y = 0;
            w = this.Arrow.Width;
            h = this.Arrow.Height;

            drawRect.X = x;
            drawRect.Y = y;
            drawRect.Height = h - 2;
            drawRect.Width = w - 2;
            if (drawRect.Width <= 0)
                drawRect.Width = 20;
            if (drawRect.Height <= 0)
                drawRect.Height = 20;
            drawRatio = (Math.Min(drawRect.Width, drawRect.Height)) / 200;
            if (drawRatio == 0.0)
                drawRatio = 1;
            return true;
        }
        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr");
            if (!this.Arrow.DisplayFlag)
                return;
            HMIArrow ctrl = this.Arrow;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            Rectangle rc = new Rectangle(0,0,(int)this.drawRect.Width,(int)this.drawRect.Height);

            this.DrawBackground(Gr, rc);
            this.DrawArrow(Gr, rc);
            this.DrawText(Gr, rc);
        }
        #endregion

        #region(*虚函数*)
        /// <summary>
        /// 画控件背景
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawBackground(Graphics Gr, RectangleF rc)
        {
            if (this.Arrow == null)
                return false;     

            Color c = this.Arrow.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = this.Arrow.Bounds; 
            Gr.DrawRectangle(pen, _rcTmp);
            Gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }
        /// <summary>
        /// 画箭头
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawArrow(Graphics Gr,RectangleF rc)
        {
            if (this.Arrow == null)
                return false;
            if (!this.Arrow.BlinkIsOn)
                return true;
            if (this.Arrow.State == HMIArrow.ArrowState.Off)
                return true;

            Color ArrowColor = this.Arrow.ArrowColor;
            GraphicsPath pth1 = new GraphicsPath();
            PointF ptStart = new PointF(0, 0);
            PointF ptEnd = new PointF(0, 0);

            switch(this.Arrow.Direction)
            {
                case HMIArrow.ArrowDirection.Buttom:
                    ptStart.X = (float)(2.0 * rc.Width / 3.0);
                    ptStart.Y = 0;
                    ptEnd.X = (float)(rc.Width / 3.0);
                    ptEnd.Y = 0;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.Y = (float)(rc.Height / 2.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = 0;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = (float)(rc.Width / 2.0);
                    ptEnd.Y = rc.Height;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = rc.Width;
                    ptEnd.Y = (float)(rc.Height / 2.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = (float)(2.0 * rc.Width / 3.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.Y = 0;
                    pth1.AddLine(ptStart, ptEnd);
                    break;
                case HMIArrow.ArrowDirection.Top:
                    ptStart.X = (float)(2.0 * rc.Width / 3.0);
                    ptStart.Y = rc.Height;
                    ptEnd.X = ptStart.X;
                    ptEnd.Y = (float)(rc.Height / 2.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = rc.Width;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = (float)(rc.Width / 2.0);
                    ptEnd.Y = 0;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = 0;
                    ptEnd.Y = (float)(rc.Height / 2.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = (float)(rc.Width / 3.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.Y = rc.Height;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = (float)(2.0 * rc.Width / 3.0);
                    pth1.AddLine(ptStart, ptEnd);
                    break;
                case HMIArrow.ArrowDirection.Left:
                    ptStart.X = rc.Width;
                    ptStart.Y = (float)(rc.Height / 3.0);
                    ptEnd.X = (float)(rc.Width / 2.0);
                    ptEnd.Y = ptStart.Y;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.Y = 0;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = 0;
                    ptEnd.Y = (float)(rc.Height / 2.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = (float)(rc.Width / 2.0);
                    ptEnd.Y = rc.Height;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.Y = (float)(2.0 * rc.Height / 3.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = rc.Width;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.Y = (float)(rc.Height / 3.0);
                    pth1.AddLine(ptStart, ptEnd);
                    break;
                case HMIArrow.ArrowDirection.Right:
                    ptStart.X = 0;
                    ptStart.Y = (float)(2.0 * rc.Height / 3.0);
                    ptEnd.X = (float)(rc.Width / 2.0);
                    ptEnd.Y = ptStart.Y;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.Y = rc.Height;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = rc.Width;
                    ptEnd.Y = (float)(rc.Height / 2.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = (float)(rc.Width / 2.0);
                    ptEnd.Y = 0;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.Y = (float)(rc.Height / 3.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = 0;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.Y = (float)(2.0 * rc.Height / 3.0);
                    pth1.AddLine(ptStart, ptEnd);
                    break;
                case HMIArrow.ArrowDirection.TopLeft:
                    ptStart.X = (float)(2.0 * rc.Width / 3.0);
                    ptStart.Y = rc.Height;
                    ptEnd.X = ptStart.X;
                    ptEnd.Y = (float)(rc.Height / 2.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = rc.Width;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = (float)(rc.Width / 2.0);
                    ptEnd.Y = 0;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = 0;
                    ptEnd.Y = (float)(rc.Height / 2.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = (float)(rc.Width / 3.0);
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.Y = rc.Height;
                    pth1.AddLine(ptStart, ptEnd);
                    ptStart = ptEnd;
                    ptEnd.X = (float)(2.0 * rc.Width / 3.0);
                    pth1.AddLine(ptStart, ptEnd);
                    Matrix temp = new Matrix();
                    temp.Rotate(-45);
                    pth1.Transform(temp);
                    break;
                case HMIArrow.ArrowDirection.LeftButtom:
                    break;
                case HMIArrow.ArrowDirection.ButtomRight:
                    break;
                case HMIArrow.ArrowDirection.RightTop:
                    break;
                default:
                    break;
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
        /// <summary>
        /// 画文本
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawText(Graphics Gr, RectangleF rc)
        {
            if (this.Arrow == null)
                return false;
            if (!this.Arrow.BlinkIsOn)
                return true;
            if (this.Arrow.State == HMIArrow.ArrowState.Off)
                return true;

            //画字符串
            Font font = new Font(this.Arrow.Font.FontFamily,
                                   this.Arrow.Font.Size * this.drawRatio,
                                   this.Arrow.Font.Style);

            String str = this.Arrow.ArrowLable;

            Color bodyColor = this.Arrow.ForeColor;
            Color cDark = Utils.HMIColorManager.StepColor(bodyColor, 20);

            SizeF size = Gr.MeasureString(str, font);

            SolidBrush br1 = new SolidBrush(bodyColor);
            SolidBrush br2 = new SolidBrush(cDark);

            Gr.DrawString(str,
                            font,
                            br1,
                            rc.Left + ((rc.Width * 0.5F) - (float)(size.Width * 0.5F)) + (float)(1 * this.drawRatio),
                            rc.Top + ((rc.Height * 0.5F) - (float)(size.Height * 0.5F)) + (float)(1 * this.drawRatio));

            Gr.DrawString(str,
                            font,
                            br2,
                            rc.Left + ((rc.Width * 0.5F) - (float)(size.Width * 0.5F)),
                            rc.Top + ((rc.Height * 0.5F) - (float)(size.Height * 0.5F)));

            br1.Dispose();
            br2.Dispose();
            font.Dispose();

            return false;
        }
        #endregion
    }
}
