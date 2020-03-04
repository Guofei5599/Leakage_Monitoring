//=================================================================
//
//文件名:CtrlBase
//
//描述:自定义控件的基类和渲染器基类
//
//创建人:刘健
//
//创建日期:2016-09-08 13:42:23
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CAEA.Common.HMIControl.Base
{
    public partial class HMICtrlBase : UserControl
    {
        public enum eAddrType
        {
            none = 0,
            D = 1,
            D_double = 2,
            M = 3
        }
        public enum eDisplayType
        {
            none = 0,
            visable,
            enable,
        }
        public bool isrelate = false;
        private eAddrType addrType = eAddrType.none;
        private uint startAddr = 0;
        private uint addrLen = 0;
        private bool updateToSqlFlag = false;
        private string updateTips = "";
        private string updateValue = "";
        private string updateUnit = "";
        private string variablename = "";
        
        [
          Category("Modbus"),
          Description("自动关联上传")
        ]
        public bool IsRelate
        {
            set
            {
                if (isrelate == value) return;
                isrelate = value;
            }
            get { return isrelate; }
        }
        [
            Category("Modbus"),
            Description("上传值单位")
        ]
        public string UpdateUnit
        {
            set
            {
                if (updateUnit == value) return;
                updateUnit = value;
            }
            get { return updateUnit; }
        }
        [
            Category("Modbus"),
            Description("上传值")
        ]
        public string UpdateValue
        {
            set
            {
                if (updateValue == value) return;
                updateValue = value;
            }
            get { return updateValue; }
        }
        [
            Category("Modbus"),
            Description("上传提示")
        ]
        public string UpdateTips
        {
            set
            {
                if (updateTips == value) return;
                updateTips = value;
            }
            get { return updateTips; }
        }
        [
            Category("Modbus"),
            Description("上传标志")
        ]
        public bool UpdateToSqlFlag
        {
            set
            {
                if (updateToSqlFlag == value) return;
                updateToSqlFlag = value;
            }
            get { return updateToSqlFlag; }
        }
        [
            Category("Modbus"),
            Description("Modbus地址类型")
        ]
        public eAddrType AddrType
        {
            set
            {
                if (addrType == value) return;
                addrType = value;
            }
            get { return this.addrType; }
        }
        [
            Category("Modbus"),
            Description("起始地址")
        ]
        public uint StartAddr
        {
            set
            {
                if (startAddr == value) return;
                startAddr = value;
            }
            get { return this.startAddr; }
        }

        [
            Category("Modbus"),
            Description("地址长度")
        ]
        public uint AddrLen
        {
            set
            {
                if (addrLen == value) return;
                addrLen = value;
            }
            get { return this.addrLen; }
        }

        [
           Category("变量关联"),
           Description("根据变量名获取变量，更新控件")
       ]
        public string VariableName
        {
            set
            {
                if (variablename == value) return;
                variablename = value;
            }
            get { return this.variablename; }
        }

        private eAddrType dispalyAddrType = eAddrType.none;
        private uint dispalyAddr = 0;
        private bool enableDispaly = false;
        private eDisplayType displaytype = eDisplayType.none;
        private string dispalycondition = "";
        [
         Category("显示条件"),
         Description("显示条件使能")
       ]
        public bool EnableDispaly
        {
            set
            {
                if (enableDispaly == value) return;
                enableDispaly = value;
            }
            get { return this.enableDispaly; }
        }
        [
          Category("显示条件"),
          Description("显示条件地址类型")
        ]
        public eAddrType DispalyAddrType
        {
            set
            {
                if (dispalyAddrType == value) return;
                dispalyAddrType = value;
            }
            get { return this.dispalyAddrType; }
        }
        [
         Category("显示条件"),
         Description("显示条件地址")
       ]
        public uint DispalyAddr
        {
            set
            {
                if (dispalyAddr == value) return;
                dispalyAddr = value;
            }
            get { return this.dispalyAddr; }
        }
        [
         Category("显示条件"),
         Description("显示类型")
        ]
        public eDisplayType ControlDisplayType
        {
            set
            {
                if (displaytype == value) return;
                displaytype = value;
            }
            get { return this.displaytype; }
        }
        [
         Category("显示条件"),
         Description("显示条件")
        ]
        public string DispalyCondition
        {
            set
            {
                if (dispalycondition == value) return;
                dispalycondition = value;
            }
            get { return this.dispalycondition; }
        }

        #region (*构造函数*)
        public HMICtrlBase()
        {
            InitializeComponent();

            //设置样式
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            //背景
            this.BackColor = Color.Transparent;

            // 默认渲染器
            this._defaultRenderer = CreateDefaultRenderer();
            if (this._defaultRenderer != null)
                this._defaultRenderer.Control = this;
        }
        #endregion

        #region (*属性*)
        /// <summary>
        /// 控件的默认渲染器
        /// </summary>
        private IRenderer _defaultRenderer = null;
        [Browsable(false)]
        public IRenderer DefaultRenderer
        {
            get { return this._defaultRenderer; }
        }
        /// <summary>
        /// 用户定义渲染器
        /// </summary>
        private IRenderer _renderer = null;
        [Browsable(false)]
        public IRenderer Renderer
        {
            set 
            {
                // 设置渲染器
                this._renderer = value;
                if (this._renderer != null)
                {
                    // 关联控件到渲染器
                    this._renderer.Control = this;
                    // 更新渲染器
                    this._renderer.Update();
                }

                // 渲染器重画
                Invalidate();
            }
            get { return this._renderer; }
        }
        #endregion

        #region (*事件委托*)
        /// <summary>
        /// 字体改变事件
        /// </summary>
        /// <param name="e"></param>
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnFontChanged(EventArgs e)
        {
            // 计算尺寸
            this.CalculateDimensions();
        }
        /// <summary>
        /// 大小改变事件
        /// </summary>
        /// <param name="e"></param>
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnSizeChanged(EventArgs e)
        {
            // 默认
            base.OnSizeChanged(e);
            // 计算控件尺寸
            this.CalculateDimensions();
            // 重画
            this.Invalidate();
        }

        /// <summary>
        /// Resize 事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.CalculateDimensions();
            this.Invalidate();
        }
        /// <summary>
        /// Paint 事件
        /// </summary>
        /// <param name="e"></param>
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnPaint(PaintEventArgs e)
        {
            //控件的矩阵
            RectangleF _rc = new RectangleF(0, 0, this.Width, this.Height);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            // 如果用户自定义渲染器为空则使用默认渲染器
            if (this.Renderer == null)
            {
                this.DefaultRenderer.Draw(e.Graphics);
                return;
            }
            
            // 渲染器重画
            this.Renderer.Draw(e.Graphics);
        }
        #endregion

        #region (*虚函数*)
        /// <summary>
        /// 构造函数中调用，创建默认渲染器
        /// </summary>
        /// <returns></returns>
        protected virtual IRenderer CreateDefaultRenderer()
        {
            return new HMIRenderBase();
        }

        /// <summary>
        /// 计算控件的尺寸
        /// </summary>
        protected virtual void CalculateDimensions()
        {
            this.DefaultRenderer.Update();

            // 更新渲染器
            if (this.Renderer != null)
                this.Renderer.Update();

            this.Invalidate();
        }
        #endregion

        private void HMICtrlBase_Load(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
    /// 控件渲染器基类
    /// </summary>
    public class HMIRenderBase : IRenderer
    {
        #region (* 构造函数 *)
        public HMIRenderBase()
        {
        }
        #endregion

        #region (*垃圾回收接口*)
        public void Dispose()
        {
            this.OnDispose();
        }
        #endregion

        #region (* 属性 *)
        /// <summary>
        /// 
        /// </summary>
        protected object _control = null;
        public object Control
        {
            set { this._control = value; }
            get { return this._control; }
        }
        #endregion

        #region (* 虚函数 *)
        /// <summary>
        /// 垃圾回收
        /// </summary>
        public virtual void OnDispose()
        {
        }

        /// <summary>
        /// 更新渲染器
        /// </summary>
        /// <returns></returns>
        public virtual bool Update()
        {
            return false;
        }

        /// <summary>
        /// 渲染函数
        /// </summary>
        /// <param name="Gr"></param>
        public virtual void Draw(Graphics Gr)
        {
            // 检查GDI+传入
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            //检查控件
            Control ctrl = this.Control as Control;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            // 默认渲染效果
            Rectangle rc = ctrl.Bounds;

            Gr.FillRectangle(Brushes.White, ctrl.Bounds);
            Gr.DrawRectangle(Pens.Black, ctrl.Bounds);

            Gr.DrawLine(Pens.Red,
                          ctrl.Left,
                          ctrl.Top,
                          ctrl.Right,
                          ctrl.Bottom);

            Gr.DrawLine(Pens.Red,
                          ctrl.Right,
                          ctrl.Top,
                          ctrl.Left,
                          ctrl.Bottom);
        }
        #endregion
    }
}
