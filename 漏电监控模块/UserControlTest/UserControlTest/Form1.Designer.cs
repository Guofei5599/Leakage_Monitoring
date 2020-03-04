namespace UserControlTest
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.个人中心ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numColor1 = new System.Windows.Forms.NumericUpDown();
            this.numColor2 = new System.Windows.Forms.NumericUpDown();
            this.numColor3 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.panelMonth1 = new UserControlTest.controls.PanelMonth();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColor3)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人中心ToolStripMenuItem,
            this.系统设置ToolStripMenuItem,
            this.退出系统ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 个人中心ToolStripMenuItem
            // 
            this.个人中心ToolStripMenuItem.Image = global::UserControlTest.Properties.Resources.个人中心_标题;
            this.个人中心ToolStripMenuItem.Name = "个人中心ToolStripMenuItem";
            this.个人中心ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.个人中心ToolStripMenuItem.Text = "个人中心";
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.Image = global::UserControlTest.Properties.Resources.系统设置;
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Image = global::UserControlTest.Properties.Resources.退出登录;
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "边框宽度：";
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(420, 31);
            this.numWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(60, 23);
            this.numWidth.TabIndex = 3;
            this.numWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.numBordWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "边框颜色：";
            // 
            // numColor1
            // 
            this.numColor1.Location = new System.Drawing.Point(420, 67);
            this.numColor1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numColor1.Name = "numColor1";
            this.numColor1.Size = new System.Drawing.Size(60, 23);
            this.numColor1.TabIndex = 5;
            this.numColor1.Value = new decimal(new int[] {
            82,
            0,
            0,
            0});
            this.numColor1.ValueChanged += new System.EventHandler(this.BorderColor_Change);
            // 
            // numColor2
            // 
            this.numColor2.Location = new System.Drawing.Point(486, 67);
            this.numColor2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numColor2.Name = "numColor2";
            this.numColor2.Size = new System.Drawing.Size(60, 23);
            this.numColor2.TabIndex = 6;
            this.numColor2.Value = new decimal(new int[] {
            196,
            0,
            0,
            0});
            this.numColor2.ValueChanged += new System.EventHandler(this.BorderColor_Change);
            // 
            // numColor3
            // 
            this.numColor3.Location = new System.Drawing.Point(552, 67);
            this.numColor3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numColor3.Name = "numColor3";
            this.numColor3.Size = new System.Drawing.Size(60, 23);
            this.numColor3.TabIndex = 7;
            this.numColor3.Value = new decimal(new int[] {
            188,
            0,
            0,
            0});
            this.numColor3.ValueChanged += new System.EventHandler(this.BorderColor_Change);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(632, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "（请输入三个0-255的数字）";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(196)))), ((int)(((byte)(188)))));
            this.panel1.Location = new System.Drawing.Point(800, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(52, 23);
            this.panel1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "边框样式：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(420, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(126, 25);
            this.comboBox1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(420, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "选中日期：";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(135, 349);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(186, 23);
            this.txtDate.TabIndex = 21;
            // 
            // panelMonth1
            // 
            this.panelMonth1.BackColor = System.Drawing.Color.White;
            this.panelMonth1.BordColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(196)))), ((int)(((byte)(188)))));
            this.panelMonth1.BordStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.panelMonth1.BordWidth = 1;
            this.panelMonth1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelMonth1.Location = new System.Drawing.Point(42, 31);
            this.panelMonth1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMonth1.Name = "panelMonth1";
            this.panelMonth1.Padding = new System.Windows.Forms.Padding(1);
            this.panelMonth1.Size = new System.Drawing.Size(260, 287);
            this.panelMonth1.TabIndex = 22;
            this.panelMonth1.OnClick += new UserControlTest.controls.PanelMonth.ClickDateCallBack(this.panelMonth1_OnClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(868, 750);
            this.Controls.Add(this.panelMonth1);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numColor3);
            this.Controls.Add(this.numColor2);
            this.Controls.Add(this.numColor1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "自定义控件";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColor3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 个人中心ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numColor1;
        private System.Windows.Forms.NumericUpDown numColor2;
        private System.Windows.Forms.NumericUpDown numColor3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDate;
        private controls.PanelMonth panelMonth1;
    }
}

