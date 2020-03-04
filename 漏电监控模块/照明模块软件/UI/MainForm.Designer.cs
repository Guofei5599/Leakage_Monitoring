namespace 照明模块软件
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.当前时间 = new System.Windows.Forms.Label();
            this.btn_关于 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_软件注册 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_退出 = new System.Windows.Forms.Button();
            this.btn_参数设置 = new System.Windows.Forms.Button();
            this.btn_场景设置 = new System.Windows.Forms.Button();
            this.btn_模块监控 = new System.Windows.Forms.Button();
            this.btn_开关监控 = new System.Windows.Forms.Button();
            this.btn_故障查询 = new System.Windows.Forms.Button();
            this.WorkSpace = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerWrite = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.当前时间);
            this.splitContainer1.Panel1.Controls.Add(this.btn_关于);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_软件注册);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_退出);
            this.splitContainer1.Panel1.Controls.Add(this.btn_参数设置);
            this.splitContainer1.Panel1.Controls.Add(this.btn_场景设置);
            this.splitContainer1.Panel1.Controls.Add(this.btn_模块监控);
            this.splitContainer1.Panel1.Controls.Add(this.btn_开关监控);
            this.splitContainer1.Panel1.Controls.Add(this.btn_故障查询);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.WorkSpace);
            this.splitContainer1.Size = new System.Drawing.Size(967, 612);
            this.splitContainer1.SplitterDistance = 136;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // 当前时间
            // 
            this.当前时间.AutoSize = true;
            this.当前时间.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.当前时间.ForeColor = System.Drawing.Color.DodgerBlue;
            this.当前时间.Location = new System.Drawing.Point(3, 582);
            this.当前时间.Name = "当前时间";
            this.当前时间.Size = new System.Drawing.Size(43, 17);
            this.当前时间.TabIndex = 10;
            this.当前时间.Text = "label3";
            // 
            // btn_关于
            // 
            this.btn_关于.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_关于.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_关于.FlatAppearance.BorderSize = 0;
            this.btn_关于.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_关于.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_关于.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_关于.Location = new System.Drawing.Point(3, 474);
            this.btn_关于.Name = "btn_关于";
            this.btn_关于.Size = new System.Drawing.Size(128, 38);
            this.btn_关于.TabIndex = 9;
            this.btn_关于.Text = "关    于";
            this.btn_关于.UseVisualStyleBackColor = false;
            this.btn_关于.Visible = false;
            this.btn_关于.Click += new System.EventHandler(this.btn_关于_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_软件注册
            // 
            this.btn_软件注册.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_软件注册.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_软件注册.FlatAppearance.BorderSize = 0;
            this.btn_软件注册.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_软件注册.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_软件注册.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_软件注册.Location = new System.Drawing.Point(3, 228);
            this.btn_软件注册.Name = "btn_软件注册";
            this.btn_软件注册.Size = new System.Drawing.Size(128, 38);
            this.btn_软件注册.TabIndex = 8;
            this.btn_软件注册.Text = "软件注册";
            this.btn_软件注册.UseVisualStyleBackColor = false;
            this.btn_软件注册.Click += new System.EventHandler(this.btn_软件注册_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "模块应用";
            // 
            // btn_退出
            // 
            this.btn_退出.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_退出.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_退出.FlatAppearance.BorderSize = 0;
            this.btn_退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_退出.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_退出.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_退出.Location = new System.Drawing.Point(3, 272);
            this.btn_退出.Name = "btn_退出";
            this.btn_退出.Size = new System.Drawing.Size(128, 38);
            this.btn_退出.TabIndex = 7;
            this.btn_退出.Text = "退    出";
            this.btn_退出.UseVisualStyleBackColor = false;
            this.btn_退出.Click += new System.EventHandler(this.btn_退出_Click);
            // 
            // btn_参数设置
            // 
            this.btn_参数设置.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_参数设置.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_参数设置.FlatAppearance.BorderSize = 0;
            this.btn_参数设置.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_参数设置.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_参数设置.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_参数设置.Location = new System.Drawing.Point(3, 140);
            this.btn_参数设置.Name = "btn_参数设置";
            this.btn_参数设置.Size = new System.Drawing.Size(128, 38);
            this.btn_参数设置.TabIndex = 6;
            this.btn_参数设置.Tag = "2";
            this.btn_参数设置.Text = "参数设置";
            this.btn_参数设置.UseVisualStyleBackColor = false;
            this.btn_参数设置.Click += new System.EventHandler(this.btn_参数设置_Click);
            // 
            // btn_场景设置
            // 
            this.btn_场景设置.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_场景设置.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_场景设置.FlatAppearance.BorderSize = 0;
            this.btn_场景设置.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_场景设置.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_场景设置.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_场景设置.Location = new System.Drawing.Point(3, 94);
            this.btn_场景设置.Name = "btn_场景设置";
            this.btn_场景设置.Size = new System.Drawing.Size(128, 38);
            this.btn_场景设置.TabIndex = 5;
            this.btn_场景设置.Tag = "2";
            this.btn_场景设置.Text = "场景设置";
            this.btn_场景设置.UseVisualStyleBackColor = false;
            this.btn_场景设置.Click += new System.EventHandler(this.btn_场景设置_Click);
            // 
            // btn_模块监控
            // 
            this.btn_模块监控.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_模块监控.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_模块监控.FlatAppearance.BorderSize = 0;
            this.btn_模块监控.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_模块监控.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_模块监控.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_模块监控.Location = new System.Drawing.Point(3, 52);
            this.btn_模块监控.Name = "btn_模块监控";
            this.btn_模块监控.Size = new System.Drawing.Size(128, 36);
            this.btn_模块监控.TabIndex = 4;
            this.btn_模块监控.Text = "模块监控";
            this.btn_模块监控.UseVisualStyleBackColor = false;
            this.btn_模块监控.Click += new System.EventHandler(this.btn_模块监控_Click);
            // 
            // btn_开关监控
            // 
            this.btn_开关监控.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_开关监控.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_开关监控.FlatAppearance.BorderSize = 0;
            this.btn_开关监控.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_开关监控.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_开关监控.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_开关监控.Location = new System.Drawing.Point(3, 518);
            this.btn_开关监控.Name = "btn_开关监控";
            this.btn_开关监控.Size = new System.Drawing.Size(128, 36);
            this.btn_开关监控.TabIndex = 3;
            this.btn_开关监控.Text = "调  试";
            this.btn_开关监控.UseVisualStyleBackColor = false;
            this.btn_开关监控.Visible = false;
            this.btn_开关监控.Click += new System.EventHandler(this.btn_开关监控_Click);
            // 
            // btn_故障查询
            // 
            this.btn_故障查询.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_故障查询.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_故障查询.FlatAppearance.BorderSize = 0;
            this.btn_故障查询.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_故障查询.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_故障查询.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_故障查询.Location = new System.Drawing.Point(3, 184);
            this.btn_故障查询.Name = "btn_故障查询";
            this.btn_故障查询.Size = new System.Drawing.Size(128, 38);
            this.btn_故障查询.TabIndex = 2;
            this.btn_故障查询.Text = "故障查询";
            this.btn_故障查询.UseVisualStyleBackColor = false;
            this.btn_故障查询.Click += new System.EventHandler(this.btn_故障查询_Click);
            // 
            // WorkSpace
            // 
            this.WorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkSpace.Location = new System.Drawing.Point(0, 0);
            this.WorkSpace.Name = "WorkSpace";
            this.WorkSpace.Size = new System.Drawing.Size(828, 610);
            this.WorkSpace.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerWrite
            // 
            this.timerWrite.Tick += new System.EventHandler(this.timerWrite_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 612);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(983, 650);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_退出;
        private System.Windows.Forms.Button btn_参数设置;
        private System.Windows.Forms.Button btn_场景设置;
        private System.Windows.Forms.Button btn_模块监控;
        private System.Windows.Forms.Button btn_开关监控;
        private System.Windows.Forms.Button btn_故障查询;
        private System.Windows.Forms.Panel WorkSpace;
        private System.Windows.Forms.Button btn_软件注册;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerWrite;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_关于;
        private System.Windows.Forms.Label 当前时间;
    }
}

