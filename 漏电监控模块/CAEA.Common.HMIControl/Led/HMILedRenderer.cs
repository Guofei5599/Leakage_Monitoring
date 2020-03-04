//=================================================================
//
//文件名:HMILedRenderer
//
//Framework版本:4.0
//
//描述:LED控件渲染器
//
//创建人:刘健
//
//创建日期:2016-09-09 09:15:30
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using CAEA.Common.HMIControl.Base;
using CAEA.Common.HMIControl.Utils;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CAEA.Common.HMIControl.Led
{
    public class HMILedRenderer : HMIRenderBase
    {
        #region (* 变量 *)
        private RectangleF drawRect;
        private RectangleF rectLed;
        private RectangleF rectLabel;
        #endregion

        #region (* 属性 *)
        /// <summary>
        /// 获取对象
        /// </summary>
        public HMILed Led
        {
            get { return this.Control as HMILed; }
        }
        #endregion

        #region (* 重写函数*)
        /// <summary>
        /// 更新重画
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            //检查对象
            if (this.Led == null)
                throw new NullReferenceException("Invalid 'Led' object");

            //
            float x, y, w, h;
            x = 0;
            y = 0;
            w = this.Led.Size.Width;
            h = this.Led.Size.Height;

            //
            drawRect.X = x;
            drawRect.Y = y;
            drawRect.Width = w - 2;
            drawRect.Height = h - 2;
            if (drawRect.Width <= 0)
                drawRect.Width = 20;
            if (drawRect.Height <= 0)
                drawRect.Height = 20;

            this.rectLed = drawRect;
            this.rectLabel = drawRect;

            if (this.Led.LabelPosition == HMILed.LedLabelPosition.Bottom)
            {
                this.rectLed.X = (this.rectLed.Width * 0.5F) - (this.Led.LedSize.Width * 0.5F);
                this.rectLed.Width = this.Led.LedSize.Width;
                this.rectLed.Height = this.Led.LedSize.Height;

                this.rectLabel.Y = this.rectLed.Bottom;
            }

            else if (this.Led.LabelPosition == HMILed.LedLabelPosition.Top)
            {
                this.rectLed.X = (this.rectLed.Width * 0.5F) - (this.Led.LedSize.Width * 0.5F);
                this.rectLed.Y = this.rectLed.Height - this.Led.LedSize.Height;
                this.rectLed.Width = this.Led.LedSize.Width;
                this.rectLed.Height = this.Led.LedSize.Height;

                this.rectLabel.Height = this.rectLed.Top;
            }

            else if (this.Led.LabelPosition == HMILed.LedLabelPosition.Left)
            {
                this.rectLed.X = this.rectLed.Width - this.Led.LedSize.Width;
                this.rectLed.Width = this.Led.LedSize.Width;
                this.rectLed.Height = this.Led.LedSize.Height;

                this.rectLabel.Width = this.rectLabel.Width - this.rectLed.Width;
            }

            else if (this.Led.LabelPosition == HMILed.LedLabelPosition.Right)
            {
                this.rectLed.Width = this.Led.LedSize.Width;
                this.rectLed.Height = this.Led.LedSize.Height;

                this.rectLabel.X = this.rectLed.Right;
            }

            return true;
        }

        /// <summary>
        /// 画Led
        /// </summary>
        /// <param name="Gr"></param>
        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            HMILed ctrl = this.Led;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            Rectangle rc = ctrl.Bounds;

            this.DrawBackground(Gr, rc);

            if (this.rectLed.Width <= 0)
                this.rectLed.Width = rectLabel.Width;
            if (this.rectLed.Height <= 0)
                this.rectLed.Height = ctrl.LedSize.Height;

            this.DrawLed(Gr, this.rectLed);

            this.DrawLabel(Gr, this.rectLabel);
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
            if (this.Led == null)
                return false;

            Color c = this.Led.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.Led.Width, this.Led.Height);
            Gr.DrawRectangle(pen, _rcTmp);
            Gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }

        /// <summary>
        /// 画控件体
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawLed(Graphics Gr, RectangleF rc)
        {
            if (this.Led == null)
                return false;

            Color cDarkOff = HMIColorManager.StepColor(Color.LightGray, 20);
            Color cDarkOn = HMIColorManager.StepColor(this.Led.LedColor, 60);

            LinearGradientBrush brOff = new LinearGradientBrush(rc,
                                                                  Color.Gray,
                                                                  cDarkOff,
                                                                  45);

            LinearGradientBrush brOn = new LinearGradientBrush(rc,
                                                                 this.Led.LedColor,
                                                                 cDarkOn,
                                                                 45);
            if (this.Led.State == HMILed.LedState.Blink)
            {
                if (this.Led.BlinkIsOn == false)
                {
                    if (this.Led.Style == HMILed.LedStyle.Circular)
                        Gr.FillEllipse(brOff, rc);
                    else if (this.Led.Style == HMILed.LedStyle.Rectangular)
                        Gr.FillRectangle(brOff, rc);
                }
                else
                {
                    if (this.Led.Style == HMILed.LedStyle.Circular)
                        Gr.FillEllipse(brOn, rc);
                    else if (this.Led.Style == HMILed.LedStyle.Rectangular)
                        Gr.FillRectangle(brOn, rc);
                }
            }
            else
            {
                if (this.Led.State == HMILed.LedState.Off)
                {
                    if (this.Led.Style == HMILed.LedStyle.Circular)
                        Gr.FillEllipse(brOff, rc);
                    else if (this.Led.Style == HMILed.LedStyle.Rectangular)
                        Gr.FillRectangle(brOff, rc);
                }
                else
                {
                    if (this.Led.Style == HMILed.LedStyle.Circular)
                        Gr.FillEllipse(brOn, rc);
                    else if (this.Led.Style == HMILed.LedStyle.Rectangular)
                        Gr.FillRectangle(brOn, rc);
                }
            }

            brOff.Dispose();
            brOn.Dispose();

            return true;
        }

        /// <summary>
        /// 画文本
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawLabel(Graphics Gr, RectangleF rc)
        {
            if (this.Led == null)
                return false;

            if (this.Led.Label == String.Empty)
                return false;

            SizeF size = Gr.MeasureString(this.Led.Label, this.Led.Font);

            SolidBrush br1 = new SolidBrush(this.Led.ForeColor);

            float hPos = 0;
            float vPos = 0;
            switch (this.Led.LabelPosition)
            {
                case HMILed.LedLabelPosition.Top:
                    hPos = (float)(rc.Width * 0.5F) - (float)(size.Width * 0.5F);
                    vPos = rc.Bottom - size.Height;
                    break;

                case HMILed.LedLabelPosition.Bottom:
                    hPos = (float)(rc.Width * 0.5F) - (float)(size.Width * 0.5F);
                    break;

                case HMILed.LedLabelPosition.Left:
                    hPos = rc.Width - size.Width;
                    vPos = (float)(rc.Height * 0.5F) - (float)(size.Height * 0.5F);
                    break;

                case HMILed.LedLabelPosition.Right:
                    vPos = (float)(rc.Height * 0.5F) - (float)(size.Height * 0.5F);
                    break;
            }

            Gr.DrawString(this.Led.Label,
                            this.Led.Font,
                            br1,
                            rc.Left + hPos,
                            rc.Top + vPos);

            br1.Dispose();
            return true;
        }
        #endregion
    }
}
