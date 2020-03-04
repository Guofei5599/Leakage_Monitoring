//=================================================================
//
//文件名:HMILedDigitalRenderer
//
//Framework版本:4.0
//
//描述:动态数码管控件渲染器
//
//创建人:刘健
//
//创建日期:2016-09-09 14:50:11
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using CAEA.Common.HMIControl.Base;
using System.Drawing;

namespace CAEA.Common.HMIControl.Led
{
    public class HMILedDigitalRenderer : HMIRenderBase
    {
        #region (* 构造函数 *)
        public HMILedDigitalRenderer()
        {
        }
        #endregion

        #region (* 重写方法 *)
        public override void Draw(Graphics Gr)
        {
            if (this.Meter == null)
                return;

            RectangleF _rc = new RectangleF(0, 0, this.Meter.Width, this.Meter.Height);
            Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            this.DrawBackground(Gr, _rc);
            this.DrawBorder(Gr, _rc);
        }
        #endregion

        #region (* 属性 *)
        public HMILedDigital Meter
        {
            get { return this.Control as HMILedDigital; }
        }
        #endregion

        #region (* 虚方法*)
        public virtual bool DrawBackground(Graphics gr, RectangleF rc)
        {
            if (this.Meter == null)
                return false;

            Color c = this.Meter.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.Meter.Width, this.Meter.Height);
            gr.DrawRectangle(pen, _rcTmp);
            gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }

        public virtual bool DrawBorder(Graphics gr, RectangleF rc)
        {
            if (this.Meter == null)
                return false;

            return true;
        }
        #endregion
    }
}
