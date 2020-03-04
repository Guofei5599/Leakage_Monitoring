namespace 照明模块软件
{
    partial class 故障查询
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
            this.btn_退出 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_查询 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.模块地址 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.模块名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.模块位置 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.故障时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.故障描述 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.故障值 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_退出);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker2);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Clear);
            this.splitContainer1.Panel1.Controls.Add(this.btn_查询);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(884, 612);
            this.splitContainer1.SplitterDistance = 58;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_退出
            // 
            this.btn_退出.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_退出.Location = new System.Drawing.Point(646, 13);
            this.btn_退出.Name = "btn_退出";
            this.btn_退出.Size = new System.Drawing.Size(75, 31);
            this.btn_退出.TabIndex = 5;
            this.btn_退出.Text = "退  出";
            this.btn_退出.UseVisualStyleBackColor = true;
            this.btn_退出.Click += new System.EventHandler(this.btn_退出_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(311, 15);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(135, 26);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "结束日期：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(85, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(135, 26);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始日期：";
            // 
            // btn_Clear
            // 
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Clear.Location = new System.Drawing.Point(552, 13);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 31);
            this.btn_Clear.TabIndex = 3;
            this.btn_Clear.Text = "清  除";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_查询
            // 
            this.btn_查询.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_查询.Location = new System.Drawing.Point(461, 13);
            this.btn_查询.Name = "btn_查询";
            this.btn_查询.Size = new System.Drawing.Size(75, 31);
            this.btn_查询.TabIndex = 2;
            this.btn_查询.Text = "查  询";
            this.btn_查询.UseVisualStyleBackColor = true;
            this.btn_查询.Click += new System.EventHandler(this.btn_查询_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.模块地址,
            this.模块名称,
            this.模块位置,
            this.故障时间,
            this.故障描述,
            this.故障值});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 60;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(882, 551);
            this.dataGridView1.TabIndex = 0;
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
            this.模块名称.Name = "模块名称";
            this.模块名称.ReadOnly = true;
            this.模块名称.Width = 78;
            // 
            // 模块位置
            // 
            this.模块位置.HeaderText = "模块位置";
            this.模块位置.Name = "模块位置";
            this.模块位置.ReadOnly = true;
            this.模块位置.Width = 78;
            // 
            // 故障时间
            // 
            this.故障时间.HeaderText = "故障时间";
            this.故障时间.Name = "故障时间";
            this.故障时间.ReadOnly = true;
            this.故障时间.Width = 78;
            // 
            // 故障描述
            // 
            this.故障描述.HeaderText = "故障描述";
            this.故障描述.Name = "故障描述";
            this.故障描述.ReadOnly = true;
            this.故障描述.Width = 78;
            // 
            // 故障值
            // 
            this.故障值.HeaderText = "故障值";
            this.故障值.Name = "故障值";
            this.故障值.ReadOnly = true;
            this.故障值.Width = 66;
            // 
            // 故障查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 612);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "故障查询";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "故障查询";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_查询;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_退出;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模块地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模块名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模块位置;
        private System.Windows.Forms.DataGridViewTextBoxColumn 故障时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 故障描述;
        private System.Windows.Forms.DataGridViewTextBoxColumn 故障值;
    }
}