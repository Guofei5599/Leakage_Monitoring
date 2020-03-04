namespace 照明模块软件
{
    partial class 场景调试模块编辑
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.开关状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.亮度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_调试模块)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_开关模块)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.btn_M删除);
            this.splitContainer1.Panel1.Controls.Add(this.btn_M添加);
            this.splitContainer1.Panel1.Controls.Add(this.dgv_调试模块);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Close);
            this.splitContainer1.Panel2.Controls.Add(this.button10);
            this.splitContainer1.Panel2.Controls.Add(this.dgv_开关模块);
            this.splitContainer1.Size = new System.Drawing.Size(438, 390);
            this.splitContainer1.SplitterDistance = 203;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_M删除
            // 
            this.btn_M删除.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_M删除.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_M删除.Location = new System.Drawing.Point(109, 351);
            this.btn_M删除.Name = "btn_M删除";
            this.btn_M删除.Size = new System.Drawing.Size(68, 28);
            this.btn_M删除.TabIndex = 23;
            this.btn_M删除.Text = "删  除";
            this.btn_M删除.UseVisualStyleBackColor = true;
            this.btn_M删除.Click += new System.EventHandler(this.btn_M删除_Click);
            // 
            // btn_M添加
            // 
            this.btn_M添加.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_M添加.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_M添加.Location = new System.Drawing.Point(23, 351);
            this.btn_M添加.Name = "btn_M添加";
            this.btn_M添加.Size = new System.Drawing.Size(68, 28);
            this.btn_M添加.TabIndex = 22;
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
            this.dgv_调试模块.Location = new System.Drawing.Point(0, -1);
            this.dgv_调试模块.Name = "dgv_调试模块";
            this.dgv_调试模块.ReadOnly = true;
            this.dgv_调试模块.RowHeadersVisible = false;
            this.dgv_调试模块.RowTemplate.Height = 23;
            this.dgv_调试模块.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_调试模块.Size = new System.Drawing.Size(198, 345);
            this.dgv_调试模块.TabIndex = 18;
            this.dgv_调试模块.SelectionChanged += new System.EventHandler(this.dgv_调试模块_SelectionChanged);
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
            this.btn_Close.Location = new System.Drawing.Point(130, 350);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(60, 30);
            this.btn_Close.TabIndex = 21;
            this.btn_Close.Text = "退  出";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button10.Location = new System.Drawing.Point(43, 350);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(60, 30);
            this.button10.TabIndex = 20;
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
            this.dgv_开关模块.Location = new System.Drawing.Point(3, 0);
            this.dgv_开关模块.MultiSelect = false;
            this.dgv_开关模块.Name = "dgv_开关模块";
            this.dgv_开关模块.RowHeadersVisible = false;
            this.dgv_开关模块.RowTemplate.Height = 23;
            this.dgv_开关模块.Size = new System.Drawing.Size(239, 344);
            this.dgv_开关模块.TabIndex = 19;
            this.dgv_开关模块.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_开关模块_CellContentDoubleClick);
            this.dgv_开关模块.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_开关模块_CellDoubleClick);
            this.dgv_开关模块.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_开关模块_CellValidating);
            this.dgv_开关模块.Validating += new System.ComponentModel.CancelEventHandler(this.dgv_开关模块_Validating);
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
            this.开关状态.HeaderText = "是否动作";
            this.开关状态.Name = "开关状态";
            this.开关状态.ReadOnly = true;
            this.开关状态.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.开关状态.Width = 78;
            // 
            // 亮度
            // 
            this.亮度.HeaderText = "亮度";
            this.亮度.Name = "亮度";
            this.亮度.Width = 54;
            // 
            // 场景调试模块编辑
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 390);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "场景调试模块编辑";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "场景调试模块编辑";
            this.Load += new System.EventHandler(this.场景调试模块编辑_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_调试模块)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_开关模块)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_调试模块;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模块地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模块名称;
        private System.Windows.Forms.DataGridView dgv_开关模块;
        private System.Windows.Forms.Button btn_M删除;
        private System.Windows.Forms.Button btn_M添加;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开关通道;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开关名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开关状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 亮度;
    }
}