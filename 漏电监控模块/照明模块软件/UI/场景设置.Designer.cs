namespace 照明模块软件
{
    partial class 场景设置
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_保存 = new System.Windows.Forms.Button();
            this.btn_修改 = new System.Windows.Forms.Button();
            this.btn_删除 = new System.Windows.Forms.Button();
            this.btn_添加 = new System.Windows.Forms.Button();
            this.btn_禁用 = new System.Windows.Forms.Button();
            this.btn_启用 = new System.Windows.Forms.Button();
            this.dgv_场景模块 = new System.Windows.Forms.DataGridView();
            this.名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.启用 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.场景模式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.开始时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.结束时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.描述 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_M删除 = new System.Windows.Forms.Button();
            this.btn_M添加 = new System.Windows.Forms.Button();
            this.dgv_调试模块 = new System.Windows.Forms.DataGridView();
            this.模块地址 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.模块名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Close = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.dgv_开关模块 = new System.Windows.Forms.DataGridView();
            this.开关通道 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.开关名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.开关状态 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.亮度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_场景模块)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_调试模块)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_开关模块)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.btn_保存);
            this.splitContainer1.Panel1.Controls.Add(this.btn_修改);
            this.splitContainer1.Panel1.Controls.Add(this.btn_删除);
            this.splitContainer1.Panel1.Controls.Add(this.btn_添加);
            this.splitContainer1.Panel1.Controls.Add(this.btn_禁用);
            this.splitContainer1.Panel1.Controls.Add(this.btn_启用);
            this.splitContainer1.Panel1.Controls.Add(this.dgv_场景模块);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(750, 612);
            this.splitContainer1.SplitterDistance = 415;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_保存
            // 
            this.btn_保存.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_保存.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_保存.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_保存.Location = new System.Drawing.Point(659, 250);
            this.btn_保存.Name = "btn_保存";
            this.btn_保存.Size = new System.Drawing.Size(80, 35);
            this.btn_保存.TabIndex = 20;
            this.btn_保存.Text = "保  存";
            this.btn_保存.UseVisualStyleBackColor = true;
            this.btn_保存.Click += new System.EventHandler(this.btn_保存_Click);
            // 
            // btn_修改
            // 
            this.btn_修改.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_修改.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_修改.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_修改.Location = new System.Drawing.Point(659, 74);
            this.btn_修改.Name = "btn_修改";
            this.btn_修改.Size = new System.Drawing.Size(80, 35);
            this.btn_修改.TabIndex = 19;
            this.btn_修改.Text = "编  辑";
            this.btn_修改.UseVisualStyleBackColor = true;
            this.btn_修改.Click += new System.EventHandler(this.btn_修改_Click);
            // 
            // btn_删除
            // 
            this.btn_删除.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_删除.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_删除.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_删除.Location = new System.Drawing.Point(659, 118);
            this.btn_删除.Name = "btn_删除";
            this.btn_删除.Size = new System.Drawing.Size(80, 35);
            this.btn_删除.TabIndex = 18;
            this.btn_删除.Text = "删  除";
            this.btn_删除.UseVisualStyleBackColor = true;
            this.btn_删除.Click += new System.EventHandler(this.btn_删除_Click);
            // 
            // btn_添加
            // 
            this.btn_添加.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_添加.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_添加.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_添加.Location = new System.Drawing.Point(659, 30);
            this.btn_添加.Name = "btn_添加";
            this.btn_添加.Size = new System.Drawing.Size(80, 35);
            this.btn_添加.TabIndex = 17;
            this.btn_添加.Text = "添  加";
            this.btn_添加.UseVisualStyleBackColor = true;
            this.btn_添加.Click += new System.EventHandler(this.btn_添加_Click);
            // 
            // btn_禁用
            // 
            this.btn_禁用.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_禁用.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_禁用.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_禁用.Location = new System.Drawing.Point(659, 206);
            this.btn_禁用.Name = "btn_禁用";
            this.btn_禁用.Size = new System.Drawing.Size(80, 35);
            this.btn_禁用.TabIndex = 16;
            this.btn_禁用.Text = "禁  用";
            this.btn_禁用.UseVisualStyleBackColor = true;
            this.btn_禁用.Click += new System.EventHandler(this.btn_禁用_Click);
            // 
            // btn_启用
            // 
            this.btn_启用.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_启用.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_启用.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_启用.Location = new System.Drawing.Point(659, 162);
            this.btn_启用.Name = "btn_启用";
            this.btn_启用.Size = new System.Drawing.Size(80, 35);
            this.btn_启用.TabIndex = 15;
            this.btn_启用.Text = "启  用";
            this.btn_启用.UseVisualStyleBackColor = true;
            this.btn_启用.Click += new System.EventHandler(this.btn_启用_Click);
            // 
            // dgv_场景模块
            // 
            this.dgv_场景模块.AllowUserToAddRows = false;
            this.dgv_场景模块.AllowUserToDeleteRows = false;
            this.dgv_场景模块.AllowUserToResizeRows = false;
            this.dgv_场景模块.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_场景模块.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_场景模块.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_场景模块.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.名称,
            this.启用,
            this.场景模式,
            this.开始时间,
            this.结束时间,
            this.描述});
            this.dgv_场景模块.Location = new System.Drawing.Point(3, 3);
            this.dgv_场景模块.MultiSelect = false;
            this.dgv_场景模块.Name = "dgv_场景模块";
            this.dgv_场景模块.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_场景模块.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_场景模块.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_场景模块.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_场景模块.RowTemplate.Height = 23;
            this.dgv_场景模块.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_场景模块.Size = new System.Drawing.Size(637, 604);
            this.dgv_场景模块.TabIndex = 0;
            this.dgv_场景模块.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_场景模块_CellClick);
            this.dgv_场景模块.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_场景模块_CellDoubleClick);
            this.dgv_场景模块.SelectionChanged += new System.EventHandler(this.dgv_场景模块_SelectionChanged);
            // 
            // 名称
            // 
            this.名称.HeaderText = "名称";
            this.名称.MinimumWidth = 100;
            this.名称.Name = "名称";
            this.名称.ReadOnly = true;
            // 
            // 启用
            // 
            this.启用.HeaderText = "启用";
            this.启用.MinimumWidth = 60;
            this.启用.Name = "启用";
            this.启用.ReadOnly = true;
            this.启用.Width = 60;
            // 
            // 场景模式
            // 
            this.场景模式.HeaderText = "场景模式";
            this.场景模式.Name = "场景模式";
            this.场景模式.ReadOnly = true;
            this.场景模式.Width = 78;
            // 
            // 开始时间
            // 
            this.开始时间.HeaderText = "开始时间";
            this.开始时间.Name = "开始时间";
            this.开始时间.ReadOnly = true;
            this.开始时间.Width = 78;
            // 
            // 结束时间
            // 
            this.结束时间.HeaderText = "结束时间";
            this.结束时间.Name = "结束时间";
            this.结束时间.ReadOnly = true;
            this.结束时间.Width = 78;
            // 
            // 描述
            // 
            this.描述.HeaderText = "描述";
            this.描述.MinimumWidth = 230;
            this.描述.Name = "描述";
            this.描述.ReadOnly = true;
            this.描述.Visible = false;
            this.描述.Width = 230;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_M删除);
            this.splitContainer2.Panel1.Controls.Add(this.btn_M添加);
            this.splitContainer2.Panel1.Controls.Add(this.dgv_调试模块);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btn_Close);
            this.splitContainer2.Panel2.Controls.Add(this.button10);
            this.splitContainer2.Panel2.Controls.Add(this.dgv_开关模块);
            this.splitContainer2.Size = new System.Drawing.Size(96, 100);
            this.splitContainer2.SplitterDistance = 67;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // btn_M删除
            // 
            this.btn_M删除.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_M删除.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_M删除.Location = new System.Drawing.Point(110, 45);
            this.btn_M删除.Name = "btn_M删除";
            this.btn_M删除.Size = new System.Drawing.Size(68, 28);
            this.btn_M删除.TabIndex = 21;
            this.btn_M删除.Text = "删  除";
            this.btn_M删除.UseVisualStyleBackColor = true;
            this.btn_M删除.Click += new System.EventHandler(this.btn_M删除_Click);
            // 
            // btn_M添加
            // 
            this.btn_M添加.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_M添加.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_M添加.Location = new System.Drawing.Point(24, 45);
            this.btn_M添加.Name = "btn_M添加";
            this.btn_M添加.Size = new System.Drawing.Size(68, 28);
            this.btn_M添加.TabIndex = 20;
            this.btn_M添加.Text = "添  加";
            this.btn_M添加.UseVisualStyleBackColor = true;
            this.btn_M添加.Click += new System.EventHandler(this.btn_M添加_Click);
            // 
            // dgv_调试模块
            // 
            this.dgv_调试模块.AllowUserToAddRows = false;
            this.dgv_调试模块.AllowUserToDeleteRows = false;
            this.dgv_调试模块.AllowUserToResizeRows = false;
            this.dgv_调试模块.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_调试模块.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_调试模块.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_调试模块.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.模块地址,
            this.模块名称});
            this.dgv_调试模块.Location = new System.Drawing.Point(3, 3);
            this.dgv_调试模块.Name = "dgv_调试模块";
            this.dgv_调试模块.ReadOnly = true;
            this.dgv_调试模块.RowHeadersVisible = false;
            this.dgv_调试模块.RowTemplate.Height = 23;
            this.dgv_调试模块.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_调试模块.Size = new System.Drawing.Size(191, 24);
            this.dgv_调试模块.TabIndex = 17;
            this.dgv_调试模块.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_调试模块_CellClick);
            // 
            // 模块地址
            // 
            this.模块地址.HeaderText = "模块地址";
            this.模块地址.MinimumWidth = 70;
            this.模块地址.Name = "模块地址";
            this.模块地址.ReadOnly = true;
            this.模块地址.Width = 78;
            // 
            // 模块名称
            // 
            this.模块名称.HeaderText = "模块名称";
            this.模块名称.MinimumWidth = 100;
            this.模块名称.Name = "模块名称";
            this.模块名称.ReadOnly = true;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.Location = new System.Drawing.Point(104, 45);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(60, 30);
            this.btn_Close.TabIndex = 18;
            this.btn_Close.Text = "退  出";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button10.Location = new System.Drawing.Point(17, 45);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(60, 30);
            this.button10.TabIndex = 17;
            this.button10.Text = "保  存";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // dgv_开关模块
            // 
            this.dgv_开关模块.AllowUserToAddRows = false;
            this.dgv_开关模块.AllowUserToDeleteRows = false;
            this.dgv_开关模块.AllowUserToResizeRows = false;
            this.dgv_开关模块.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_开关模块.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_开关模块.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_开关模块.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.开关通道,
            this.开关名称,
            this.开关状态,
            this.亮度});
            this.dgv_开关模块.Location = new System.Drawing.Point(3, 3);
            this.dgv_开关模块.MultiSelect = false;
            this.dgv_开关模块.Name = "dgv_开关模块";
            this.dgv_开关模块.RowHeadersVisible = false;
            this.dgv_开关模块.RowTemplate.Height = 23;
            this.dgv_开关模块.Size = new System.Drawing.Size(44, 24);
            this.dgv_开关模块.TabIndex = 18;
            this.dgv_开关模块.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_开关模块_CellValidating);
            // 
            // 开关通道
            // 
            this.开关通道.HeaderText = "开关通道";
            this.开关通道.MinimumWidth = 78;
            this.开关通道.Name = "开关通道";
            this.开关通道.ReadOnly = true;
            this.开关通道.Width = 78;
            // 
            // 开关名称
            // 
            this.开关名称.HeaderText = "开关名称";
            this.开关名称.MinimumWidth = 100;
            this.开关名称.Name = "开关名称";
            this.开关名称.ReadOnly = true;
            this.开关名称.Visible = false;
            // 
            // 开关状态
            // 
            this.开关状态.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.开关状态.HeaderText = "是否动作";
            this.开关状态.Items.AddRange(new object[] {
            "是",
            "否"});
            this.开关状态.Name = "开关状态";
            this.开关状态.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.开关状态.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.开关状态.Width = 78;
            // 
            // 亮度
            // 
            this.亮度.HeaderText = "亮度";
            this.亮度.Name = "亮度";
            this.亮度.Width = 54;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // 场景设置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 612);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "场景设置";
            this.Text = "场景设置";
            this.Load += new System.EventHandler(this.场景设置_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_场景模块)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_调试模块)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_开关模块)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgv_场景模块;
        private System.Windows.Forms.Button btn_禁用;
        private System.Windows.Forms.Button btn_启用;
        private System.Windows.Forms.DataGridView dgv_调试模块;
        private System.Windows.Forms.DataGridView dgv_开关模块;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btn_修改;
        private System.Windows.Forms.Button btn_删除;
        private System.Windows.Forms.Button btn_添加;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_M删除;
        private System.Windows.Forms.Button btn_M添加;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模块地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模块名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开关通道;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开关名称;
        private System.Windows.Forms.DataGridViewComboBoxColumn 开关状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 亮度;
        private System.Windows.Forms.Button btn_保存;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 启用;
        private System.Windows.Forms.DataGridViewTextBoxColumn 场景模式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开始时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 结束时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 描述;
    }
}