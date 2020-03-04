namespace 照明模块软件
{
    partial class 模块管理界面
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.为空 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.模块地址 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.模块名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.模块类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.开关路数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.安装位置 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tip_Lable = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.num_addr1 = new System.Windows.Forms.NumericUpDown();
            this.num_addr2 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.check_为空 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_模块地址 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_安装位置 = new System.Windows.Forms.TextBox();
            this.txt_模块名称 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开关编辑 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_addr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_addr2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tip_Lable);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Size = new System.Drawing.Size(760, 395);
            this.splitContainer1.SplitterDistance = 543;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.为空,
            this.模块地址,
            this.模块名称,
            this.模块类型,
            this.开关路数,
            this.安装位置});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(543, 395);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // 为空
            // 
            this.为空.HeaderText = "为空";
            this.为空.MinimumWidth = 40;
            this.为空.Name = "为空";
            this.为空.ReadOnly = true;
            this.为空.Width = 40;
            // 
            // 模块地址
            // 
            this.模块地址.HeaderText = "模块地址";
            this.模块地址.Name = "模块地址";
            this.模块地址.ReadOnly = true;
            this.模块地址.Width = 78;
            // 
            // 模块名称
            // 
            this.模块名称.HeaderText = "模块名称";
            this.模块名称.MinimumWidth = 120;
            this.模块名称.Name = "模块名称";
            this.模块名称.ReadOnly = true;
            this.模块名称.Width = 120;
            // 
            // 模块类型
            // 
            this.模块类型.HeaderText = "模块类型";
            this.模块类型.Name = "模块类型";
            this.模块类型.ReadOnly = true;
            this.模块类型.Width = 78;
            // 
            // 开关路数
            // 
            this.开关路数.HeaderText = "开关路数";
            this.开关路数.Name = "开关路数";
            this.开关路数.ReadOnly = true;
            this.开关路数.Width = 78;
            // 
            // 安装位置
            // 
            this.安装位置.HeaderText = "安装位置";
            this.安装位置.MinimumWidth = 150;
            this.安装位置.Name = "安装位置";
            this.安装位置.ReadOnly = true;
            this.安装位置.Width = 150;
            // 
            // tip_Lable
            // 
            this.tip_Lable.AutoSize = true;
            this.tip_Lable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tip_Lable.ForeColor = System.Drawing.Color.Red;
            this.tip_Lable.Location = new System.Drawing.Point(5, 372);
            this.tip_Lable.Name = "tip_Lable";
            this.tip_Lable.Size = new System.Drawing.Size(43, 17);
            this.tip_Lable.TabIndex = 18;
            this.tip_Lable.Text = "label6";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btn_Delete);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btn_Add);
            this.groupBox2.Controls.Add(this.num_addr1);
            this.groupBox2.Controls.Add(this.num_addr2);
            this.groupBox2.Location = new System.Drawing.Point(5, 237);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 130);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "批量操作";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(49, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 29);
            this.button1.TabIndex = 17;
            this.button1.Text = "清空数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Delete.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delete.Location = new System.Drawing.Point(112, 61);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(50, 25);
            this.btn_Delete.TabIndex = 16;
            this.btn_Delete.Text = "批删";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(97, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "到";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "从";
            // 
            // btn_Add
            // 
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.Location = new System.Drawing.Point(38, 61);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(50, 25);
            this.btn_Add.TabIndex = 15;
            this.btn_Add.Text = "批增";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // num_addr1
            // 
            this.num_addr1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_addr1.Location = new System.Drawing.Point(32, 29);
            this.num_addr1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_addr1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_addr1.Name = "num_addr1";
            this.num_addr1.Size = new System.Drawing.Size(59, 23);
            this.num_addr1.TabIndex = 6;
            this.num_addr1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_addr2
            // 
            this.num_addr2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_addr2.Location = new System.Drawing.Point(123, 29);
            this.num_addr2.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_addr2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_addr2.Name = "num_addr2";
            this.num_addr2.Size = new System.Drawing.Size(63, 23);
            this.num_addr2.TabIndex = 7;
            this.num_addr2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.check_为空);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_模块地址);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_安装位置);
            this.groupBox1.Controls.Add(this.txt_模块名称);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(5, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 222);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息修改";
            // 
            // check_为空
            // 
            this.check_为空.AutoSize = true;
            this.check_为空.Location = new System.Drawing.Point(72, 120);
            this.check_为空.Name = "check_为空";
            this.check_为空.Size = new System.Drawing.Size(15, 14);
            this.check_为空.TabIndex = 18;
            this.check_为空.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(3, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "模块为空：";
            // 
            // txt_模块地址
            // 
            this.txt_模块地址.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_模块地址.Location = new System.Drawing.Point(73, 22);
            this.txt_模块地址.Name = "txt_模块地址";
            this.txt_模块地址.ReadOnly = true;
            this.txt_模块地址.Size = new System.Drawing.Size(116, 23);
            this.txt_模块地址.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "模块地址：";
            // 
            // btn_Save
            // 
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Save.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.Location = new System.Drawing.Point(72, 146);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(50, 25);
            this.btn_Save.TabIndex = 14;
            this.btn_Save.Text = "保 存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "模块名称：";
            // 
            // txt_安装位置
            // 
            this.txt_安装位置.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_安装位置.Location = new System.Drawing.Point(72, 89);
            this.txt_安装位置.Name = "txt_安装位置";
            this.txt_安装位置.Size = new System.Drawing.Size(116, 23);
            this.txt_安装位置.TabIndex = 13;
            // 
            // txt_模块名称
            // 
            this.txt_模块名称.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_模块名称.Location = new System.Drawing.Point(73, 60);
            this.txt_模块名称.Name = "txt_模块名称";
            this.txt_模块名称.Size = new System.Drawing.Size(116, 23);
            this.txt_模块名称.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(2, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "安装位置：";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开关编辑});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // 开关编辑
            // 
            this.开关编辑.Name = "开关编辑";
            this.开关编辑.Size = new System.Drawing.Size(124, 22);
            this.开关编辑.Text = "开关编辑";
            // 
            // 模块管理界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 395);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "模块管理界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "模块管理界面";
            this.Load += new System.EventHandler(this.模块管理界面_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_addr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_addr2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.NumericUpDown num_addr1;
        private System.Windows.Forms.NumericUpDown num_addr2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_模块地址;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_安装位置;
        private System.Windows.Forms.TextBox txt_模块名称;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label tip_Lable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开关编辑;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox check_为空;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 为空;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模块地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模块名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模块类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开关路数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 安装位置;
    }
}