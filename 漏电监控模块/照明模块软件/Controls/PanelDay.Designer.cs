namespace 照明模块软件
{
    partial class PanelDay
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置为假期 = new System.Windows.Forms.ToolStripMenuItem();
            this.roundPanel1 = new UserControlTest.controls.RoundPanel();
            this.lbDay = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.roundPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置为假期});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            // 
            // 设置为假期
            // 
            this.设置为假期.Name = "设置为假期";
            this.设置为假期.Size = new System.Drawing.Size(136, 22);
            this.设置为假期.Text = "设置为假期";
            this.设置为假期.Click += new System.EventHandler(this.设置为假期_Click);
            // 
            // roundPanel1
            // 
            this.roundPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.roundPanel1.BorderWidth = 2;
            this.roundPanel1.ButtonCenterColorEnd = System.Drawing.Color.White;
            this.roundPanel1.ButtonCenterColorStart = System.Drawing.Color.White;
            this.roundPanel1.Controls.Add(this.lbDay);
            this.roundPanel1.DistanceToBorder = 3;
            this.roundPanel1.FocusBorderColor = System.Drawing.Color.White;
            this.roundPanel1.GradientAngle = 0;
            this.roundPanel1.Location = new System.Drawing.Point(0, 0);
            this.roundPanel1.Name = "roundPanel1";
            this.roundPanel1.Size = new System.Drawing.Size(36, 36);
            this.roundPanel1.TabIndex = 0;
            this.roundPanel1.Click += new System.EventHandler(this.Day_Click);
            // 
            // lbDay
            // 
            this.lbDay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDay.AutoSize = true;
            this.lbDay.BackColor = System.Drawing.Color.Transparent;
            this.lbDay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDay.ForeColor = System.Drawing.Color.Black;
            this.lbDay.Location = new System.Drawing.Point(11, 10);
            this.lbDay.Name = "lbDay";
            this.lbDay.Size = new System.Drawing.Size(15, 17);
            this.lbDay.TabIndex = 0;
            this.lbDay.Text = "1";
            this.lbDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDay.Click += new System.EventHandler(this.Day_Click);
            this.lbDay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbDay_MouseDown);
            // 
            // PanelDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.roundPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(30, 30);
            this.MinimumSize = new System.Drawing.Size(36, 36);
            this.Name = "PanelDay";
            this.Size = new System.Drawing.Size(36, 36);
            this.Load += new System.EventHandler(this.PanelDay_Load);
            this.Click += new System.EventHandler(this.Day_Click);
            this.contextMenuStrip1.ResumeLayout(false);
            this.roundPanel1.ResumeLayout(false);
            this.roundPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundPanel roundPanel1;
        private System.Windows.Forms.Label lbDay;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置为假期;
    }
}
