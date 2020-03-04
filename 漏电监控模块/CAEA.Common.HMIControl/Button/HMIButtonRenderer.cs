//=================================================================
//
//文件名:HMIButtonRenderer
//
//Framework版本:4.0
//
//描述:按钮控件渲染器
//
//创建人:刘健
//
//创建日期:2016-09-08 15:07:35
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using CAEA.Common.HMIControl.Base;
using CAEA.Common.HMIControl.Utils;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace CAEA.Common.HMIControl.Button
{
    public class HMIButtonRenderer : HMIRenderBase
    {
        #region (* 变量 *)
        protected RectangleF rectCtrl;
        protected RectangleF rectBody;
        protected RectangleF rectText;
        protected float drawRatio = 1.0F;
        #endregion

        #region (* 构造函数 *)
        public HMIButtonRenderer()
        {
            this.rectCtrl = new RectangleF(0, 0, 0, 0);
        }
        #endregion

        #region (* 重写方法 *)
        /// <summary>
        /// 重写Update 方法
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            // 检查控件
            if (this.Button == null)
                throw new NullReferenceException("Invalid 'Button' object");

            // 空间矩形区域
            this.rectCtrl.X = 0;
            this.rectCtrl.Y = 0;
            this.rectCtrl.Width = this.Button.Width;
            this.rectCtrl.Height = this.Button.Height;

            if (this.Button.Style == HMIButton.ButtonStyle.Circular)
            {
                if (rectCtrl.Width < rectCtrl.Height)
                    rectCtrl.Height = rectCtrl.Width;
                else if (rectCtrl.Width > rectCtrl.Height)
                    rectCtrl.Width = rectCtrl.Height;

                if (rectCtrl.Width < 10)
                    rectCtrl.Width = 10;
                if (rectCtrl.Height < 10)
                    rectCtrl.Height = 10;
            }

            this.rectBody = this.rectCtrl;
            this.rectBody.Width -= 1;
            this.rectBody.Height -= 1;

            this.rectText = this.rectCtrl;
            this.rectText.Width -= 2;
            this.rectText.Height -= 2;

            drawRatio = (Math.Min(rectCtrl.Width, rectCtrl.Height)) / 200;
            if (drawRatio == 0.0)
                drawRatio = 1;

            return true;
        }

        /// <summary>
        /// 画控件
        /// </summary>
        /// <param name="Gr"></param>
        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr", "Invalid Graphics object");

            if (this.Button == null)
                throw new NullReferenceException("Invalid 'Button' object");

            if (!this.Button.DisplayFlag)
                return;
            this.DrawBackground(Gr, this.rectCtrl);
            this.DrawBody(Gr, this.rectBody);
            this.DrawText(Gr, this.rectText);
        }
        #endregion

        #region (* 属性 *)
        /// <summary>
        /// 获取控件
        /// </summary>
        public HMIButton Button
        {
            get { return this.Control as HMIButton; }
        }
        #endregion

        #region (* 虚方法 *)
        /// <summary>
        /// 画背景
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawBackground(Graphics Gr, RectangleF rc)
        {
            if (this.Button == null)
                return false;

            Color c = this.Button.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.Button.Width, this.Button.Height);
            Gr.DrawRectangle(pen, _rcTmp);
            Gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }

        /// <summary>
        /// 画控件实体
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawBody(Graphics Gr, RectangleF rc)
        {
            if (this.Button == null)
                return false;

            Color bodyColor = this.Button.ButtonColor;
            Color cDark = HMIColorManager.StepColor(bodyColor, 20);

            LinearGradientBrush br1 = new LinearGradientBrush(rc,
                                                               bodyColor,
                                                               cDark,
                                                               45);

            if ((this.Button.Style == HMIButton.ButtonStyle.Circular) ||
                (this.Button.Style == HMIButton.ButtonStyle.Elliptical))
            {
                Gr.FillEllipse(br1, rc);
            }
            else
            {
                GraphicsPath path = this.RoundedRect(rc, 15F);
                Gr.FillPath(br1, path);
                path.Dispose();
            }

            if (this.Button.State == HMIButton.ButtonState.Pressed)
            {
                RectangleF _rc = rc;
                _rc.Inflate(-15F * this.drawRatio, -15F * drawRatio);
                LinearGradientBrush br2 = new LinearGradientBrush(_rc,
                                                                   cDark,
                                                                   bodyColor,
                                                                   45);
                if ((this.Button.Style == HMIButton.ButtonStyle.Circular) ||
                    (this.Button.Style == HMIButton.ButtonStyle.Elliptical))
                {
                    Gr.FillEllipse(br2, _rc);
                }
                else
                {
                    GraphicsPath path = this.RoundedRect(_rc, 10F);
                    Gr.FillPath(br2, path);
                    path.Dispose();
                }

                br2.Dispose();
            }

            br1.Dispose();
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
            if (this.Button == null)
                return false;
            switch(this.Button.LableStyl)
            {
                case HMIButton.ButtonLabelSylt.Text:
                    //画字符串
                    Font font = new Font(this.Button.Font.FontFamily,
                                           this.Button.Font.Size * this.drawRatio,
                                           this.Button.Font.Style);

                    String str = this.Button.Label;

                    Color bodyColor = this.Button.ForeColor;
                    Color cDark = HMIColorManager.StepColor(bodyColor, 20);

                    SizeF size = Gr.MeasureString(str, font);

                    SolidBrush br1 = new SolidBrush(bodyColor);
                    SolidBrush br2 = new SolidBrush(cDark);

                    Gr.DrawString(str,
                                    font,
                                    br1,
                                    rc.Left + ((rc.Width * 0.5F) - (float)(size.Width * 0.5F)) + (float)(1 * this.drawRatio),
                                    rc.Top + ((rc.Height * 0.5F) - (float)(size.Height * 0.5)) + (float)(1 * this.drawRatio));

                    Gr.DrawString(str,
                                    font,
                                    br2,
                                    rc.Left + ((rc.Width * 0.5F) - (float)(size.Width * 0.5F)),
                                    rc.Top + ((rc.Height * 0.5F) - (float)(size.Height * 0.5)));

                    br1.Dispose();
                    br2.Dispose();
                    font.Dispose();
                    break;
                case HMIButton.ButtonLabelSylt.Image:
                    if(this.Button.LableImage != null)
                    {
                        RectangleF temp = rc;
                        temp.Inflate(-25F * this.drawRatio, -25F * drawRatio);
                        Rectangle temprc = new Rectangle();
                        temprc.X = (int)temp.X;
                        temprc.Y = (int)temp.Y;
                        temprc.Height = (int)temp.Height;
                        temprc.Width = (int)temp.Width;
                        
                        Rectangle src = new Rectangle();
                        src.X = 0;
                        src.Y = 0;
                        src.Width = this.Button.LableImage.Width;
                        src.Height = this.Button.LableImage.Height;
                        Gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Gr.DrawImage(this.Button.LableImage, temprc, src, GraphicsUnit.Pixel);
                    }
                    break;
                default:
                    break;
            }
            

            return false;
        }
        #endregion

        #region (* 受保护的方法 *)
        protected GraphicsPath RoundedRect(RectangleF rect, float radius)
        {
            RectangleF baseRect = rect;
            float diameter = (radius * this.drawRatio) * 2.0f;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(baseRect.Location, sizeF);
            GraphicsPath path = new GraphicsPath();

            // 左上圆弧
            path.AddArc(arc, 180, 90);
            //右上圆弧
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);
            // 右下圆弧
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // 左下圆弧
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        #endregion
    }
}
