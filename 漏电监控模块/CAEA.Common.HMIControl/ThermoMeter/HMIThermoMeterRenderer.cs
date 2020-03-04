//=================================================================
//
//文件名:HMIThermoMeterRenderer
//
//Framework版本:4.0
//
//描述:温度计控件渲染器
//
//创建人:刘健
//
//创建日期:2016-09-13 14:19:35
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using System.Drawing;
using CAEA.Common.HMIControl.Base;

namespace CAEA.Common.HMIControl.ThermoMeter
{
    class HMIThermoMeterRenderer : HMIRenderBase 
    {
        #region (* 属性 *)
        public HMIThermoMeter ThermoMeter
        {
            get { return this.Control as HMIThermoMeter; }
        }
        #endregion

        #region(*变量*)
        protected RectangleF drawRect;//绘图区域
        protected float drawRatio;//绘图比率
        #endregion

        #region(*重写方法*)
        public override bool Update()
        {
            if (this.ThermoMeter == null)
                throw new NullReferenceException("Invalid 'ThermoMeter' object");

            // 矩形范围
            float x, y, w, h;
            x = 0F;
            y = 0F;
            w = this.ThermoMeter.Size.Width;
            h = this.ThermoMeter.Size.Height;

            // 计算比率
            drawRatio = (Math.Min(w, h)) / 200F;
            if (drawRatio == 0.0)
                drawRatio = 1;

            //作业区域
            drawRect.X = x;
            drawRect.Y = y;
            drawRect.Width = w - 2F;
            drawRect.Height = h - 2F;

            if (drawRect.Width < 10F)
                drawRect.Width = 10F;
            if (drawRect.Height < 50F)
                drawRect.Height = 50F;
            return false;
        }
        public override void Draw(Graphics Gr)
        {
            DrawBackground(Gr, drawRect);
            DrawMerury(Gr, drawRect);
            DrawScale(Gr,drawRect);
            DrawValue(Gr, drawRect);
        }
        #endregion

        #region(*虚方法*)
        /// <summary>
        /// 画背景和外边框
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawBackground(Graphics gr, RectangleF rc)
        {
            if (this.ThermoMeter == null)
                return false;

            Color c = this.ThermoMeter.DialBackColor;
            SolidBrush br = new SolidBrush(c);
            //绘制背景
            gr.FillRectangle(br, 0F, rc.Width / 2F, rc.Width, (rc.Height - rc.Width));
            gr.FillEllipse(br, 0F, 0F, rc.Width, rc.Width);
            gr.FillEllipse(br, 0F, (rc.Height - rc.Width), rc.Width, rc.Width);

            //绘制外边框
            Pen pen1 = new Pen(this.ThermoMeter.DialOutLineColor,2);
            gr.DrawLine(pen1, rc.X, rc.Y+rc.Width/2F, rc.X, rc.Y+(rc.Height - rc.Width/2F));
            gr.DrawLine(pen1, rc.X + rc.Width, rc.Y+rc.Width/2F, rc.X+rc.Width, rc.Y+(rc.Height - rc.Width/2F));
            gr.DrawArc(pen1, rc.X, rc.Y, rc.Width, rc.Width, 180F, 180F);
            gr.DrawArc(pen1, rc.X, rc.Y + (rc.Height - rc.Width), rc.Width, rc.Width, 0F, 180F);

            pen1.Dispose();
            br.Dispose();

            return true;
        }
        /// <summary>
        /// 画指示柱
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawMerury(Graphics gr, RectangleF rc)
        {
            float X = rc.Width;
            float Y = rc.Height;
            SolidBrush br = new SolidBrush(this.ThermoMeter.MercuryBackColor);
            gr.FillEllipse(br, X * 2F / 5F, (X / 2F - X / 10F), X / 5F, X / 5F);
            br.Dispose();
            br = new SolidBrush(this.ThermoMeter.MercuryColor);
            gr.FillEllipse(br, X / 4F, (Y - X * 9F / 16), X / 2F, X / 2F);
            gr.FillRectangle(br, X * 2F / 5F, (X / 2F + 1F), X / 5F, (Y - X));
            br.Dispose();
            return true;
        }
        /// <summary>
        /// 画刻度
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawScale(Graphics gr, RectangleF rc)
        {
            float X = rc.Width;
            float Y = rc.Height;
            // 绘制大刻度线,线宽为2
            // 绘制小刻度线,线宽为1
            // 绘制刻度数字,字体,字号,字的颜色在属性中可改
            Pen p = new Pen(this.ThermoMeter.BigScaleColor, 2);// 设置大刻度线的颜色,线粗
            Pen s_p = new Pen(this.ThermoMeter.SmallScaleColor, 1); // 设置小刻度线的颜色,线粗
            SolidBrush drawBrush = new SolidBrush(this.ThermoMeter.DrawColor);  // 设置绘制数字的颜色
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;// 设置数字水平对齐为中间,垂直对其为左边
            // 计算要绘制数字的数值
            int interval = (int)(this.ThermoMeter.HighTemperature - this.ThermoMeter.LowTemperature) / this.ThermoMeter.BigScale;
            int tempNum = (int)this.ThermoMeter.HighTemperature;
            for (int i = 0; i <= this.ThermoMeter.BigScale; i++)
            {
                float b_s_y = X / 2 + i * ((Y - X - X / 2) / this.ThermoMeter.BigScale);       // 绘制大刻度线的垂直位置
                gr.DrawLine(p, X / 5, b_s_y, (X * 2 / 5 - 2), b_s_y); // 绘制大刻度线
                gr.DrawString(tempNum.ToString(), this.ThermoMeter.DrawFont, drawBrush, X * 3 / 5,
                                b_s_y - this.ThermoMeter.DrawFont.Size/(float)1.5, format);   // 绘制刻度数字
                tempNum -= interval;    // 计算下一次要绘制的数值

                // 绘制小刻度线
                if (i < this.ThermoMeter.BigScale)
                {
                    for (int j = 1; j < this.ThermoMeter.SmallScale; j++)
                    {
                        float s_s_y = b_s_y + ((X / 2 + (i + 1) * ((Y - X - X / 2) / this.ThermoMeter.BigScale) - b_s_y) / this.ThermoMeter.SmallScale) * j;
                        gr.DrawLine(s_p, (X * 3 / 10), s_s_y, (X * 2 / 5 - 2), s_s_y);
                    }
                }
            }
            p.Dispose();
            s_p.Dispose();
            drawBrush.Dispose();
            format.Dispose();
            return true;
        }
        /// <summary>
        /// 画值
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawValue(Graphics gr, RectangleF rc)
        {
            // 在温度计底部,绘制当前温度数值
            float X = rc.Width;
            float Y = rc.Height;
            SolidBrush br = new SolidBrush(this.ThermoMeter.TempColor);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            gr.DrawString((this.ThermoMeter.Temperature.ToString("0.#")), this.ThermoMeter.TempFont, br, X / 2 , (Y - X / 4), format);
            // 计算当前温度的位置            
            float L = Y - X * 3 / 2;
            float H = L * (this.ThermoMeter.Temperature - this.ThermoMeter.LowTemperature) 
                        / (this.ThermoMeter.HighTemperature - this.ThermoMeter.LowTemperature);
            // 绘制当前温度的位置
            br.Dispose();
            br = new SolidBrush(this.ThermoMeter.MercuryBackColor);
            gr.FillRectangle(br, X * 2 / 5, X / 2, X / 5, (L - H));
            br.Color = Color.Wheat; ;
            gr.FillPolygon(br,new PointF[] {new PointF(X * 2 / 5, X / 2 + (L - H)), new PointF(X * 2 / 5-4, X / 2 + (L - H) + 4f), new PointF(X * 2 / 5 - 12, X / 2 + (L - H) + 4f), new PointF(X * 2 / 5 - 12, X / 2 + (L - H) - 4f), new PointF(X * 2 / 5 - 4, X / 2 + (L - H) - 4f) });
            //gr.FillRectangle(br, X * 2 / 5 - 3, X / 2 + (L - H) - 6, X / 5 + 4, 8);
            br.Dispose();
            format.Dispose();
            return true;
        }
        #endregion
    }
}
