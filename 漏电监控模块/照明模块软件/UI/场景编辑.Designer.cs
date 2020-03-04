namespace 照明模块软件
{
    partial class 场景编辑
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.radio_Close = new System.Windows.Forms.RadioButton();
            this.radio_open = new System.Windows.Forms.RadioButton();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_获取日落时间 = new System.Windows.Forms.Button();
            this.btn_删除 = new System.Windows.Forms.Button();
            this.btn_获取日出时间 = new System.Windows.Forms.Button();
            this.btn_修改 = new System.Windows.Forms.Button();
            this.btn_添加 = new System.Windows.Forms.Button();
            this.txt_名称 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_日落时间 = new System.Windows.Forms.RadioButton();
            this.radio_日出时间 = new System.Windows.Forms.RadioButton();
            this.radio_普通定时 = new System.Windows.Forms.RadioButton();
            this.time_开启时间 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.动作类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.定时方式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.动作时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btn_Exit);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.btn_获取日落时间);
            this.panel1.Controls.Add(this.btn_删除);
            this.panel1.Controls.Add(this.btn_获取日出时间);
            this.panel1.Controls.Add(this.btn_修改);
            this.panel1.Controls.Add(this.btn_添加);
            this.panel1.Controls.Add(this.txt_名称);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(476, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 433);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.radio_Close);
            this.panel4.Controls.Add(this.radio_open);
            this.panel4.Location = new System.Drawing.Point(3, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(269, 38);
            this.panel4.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(10, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "开关动作：";
            // 
            // radio_Close
            // 
            this.radio_Close.AutoSize = true;
            this.radio_Close.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radio_Close.Location = new System.Drawing.Point(152, 12);
            this.radio_Close.Name = "radio_Close";
            this.radio_Close.Size = new System.Drawing.Size(49, 16);
            this.radio_Close.TabIndex = 15;
            this.radio_Close.Text = "关闭";
            this.radio_Close.UseVisualStyleBackColor = true;
            // 
            // radio_open
            // 
            this.radio_open.AutoSize = true;
            this.radio_open.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radio_open.Location = new System.Drawing.Point(92, 12);
            this.radio_open.Name = "radio_open";
            this.radio_open.Size = new System.Drawing.Size(49, 16);
            this.radio_open.TabIndex = 14;
            this.radio_open.Text = "开启";
            this.radio_open.UseVisualStyleBackColor = true;
            // 
            // btn_Exit
            // 
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Exit.Location = new System.Drawing.Point(146, 215);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(65, 31);
            this.btn_Exit.TabIndex = 15;
            this.btn_Exit.Text = "退  出";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Save.Location = new System.Drawing.Point(52, 215);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(65, 31);
            this.btn_Save.TabIndex = 14;
            this.btn_Save.Text = "保  存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_获取日落时间
            // 
            this.btn_获取日落时间.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_获取日落时间.Location = new System.Drawing.Point(24, 384);
            this.btn_获取日落时间.Name = "btn_获取日落时间";
            this.btn_获取日落时间.Size = new System.Drawing.Size(53, 23);
            this.btn_获取日落时间.TabIndex = 11;
            this.btn_获取日落时间.Text = "获取日落时间";
            this.btn_获取日落时间.UseVisualStyleBackColor = true;
            this.btn_获取日落时间.Visible = false;
            this.btn_获取日落时间.Click += new System.EventHandler(this.btn_获取日落时间_Click);
            // 
            // btn_删除
            // 
            this.btn_删除.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_删除.Location = new System.Drawing.Point(189, 169);
            this.btn_删除.Name = "btn_删除";
            this.btn_删除.Size = new System.Drawing.Size(65, 31);
            this.btn_删除.TabIndex = 13;
            this.btn_删除.Text = "删 除";
            this.btn_删除.UseVisualStyleBackColor = true;
            this.btn_删除.Click += new System.EventHandler(this.btn_删除_Click);
            // 
            // btn_获取日出时间
            // 
            this.btn_获取日出时间.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_获取日出时间.Location = new System.Drawing.Point(25, 355);
            this.btn_获取日出时间.Name = "btn_获取日出时间";
            this.btn_获取日出时间.Size = new System.Drawing.Size(57, 23);
            this.btn_获取日出时间.TabIndex = 0;
            this.btn_获取日出时间.Text = "获取日出时间";
            this.btn_获取日出时间.UseVisualStyleBackColor = true;
            this.btn_获取日出时间.Visible = false;
            this.btn_获取日出时间.Click += new System.EventHandler(this.btn_获取日出时间_Click);
            // 
            // btn_修改
            // 
            this.btn_修改.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_修改.Location = new System.Drawing.Point(98, 169);
            this.btn_修改.Name = "btn_修改";
            this.btn_修改.Size = new System.Drawing.Size(65, 31);
            this.btn_修改.TabIndex = 12;
            this.btn_修改.Text = "修 改";
            this.btn_修改.UseVisualStyleBackColor = true;
            this.btn_修改.Click += new System.EventHandler(this.btn_修改_Click);
            // 
            // btn_添加
            // 
            this.btn_添加.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_添加.Location = new System.Drawing.Point(7, 169);
            this.btn_添加.Name = "btn_添加";
            this.btn_添加.Size = new System.Drawing.Size(65, 31);
            this.btn_添加.TabIndex = 11;
            this.btn_添加.Text = "添 加";
            this.btn_添加.UseVisualStyleBackColor = true;
            this.btn_添加.Click += new System.EventHandler(this.btn_添加_Click);
            // 
            // txt_名称
            // 
            this.txt_名称.Location = new System.Drawing.Point(82, 8);
            this.txt_名称.Name = "txt_名称";
            this.txt_名称.Size = new System.Drawing.Size(172, 21);
            this.txt_名称.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(11, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "名  称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio_日落时间);
            this.groupBox1.Controls.Add(this.radio_日出时间);
            this.groupBox1.Controls.Add(this.radio_普通定时);
            this.groupBox1.Controls.Add(this.time_开启时间);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(2, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // radio_日落时间
            // 
            this.radio_日落时间.AutoSize = true;
            this.radio_日落时间.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radio_日落时间.Location = new System.Drawing.Point(177, 20);
            this.radio_日落时间.Name = "radio_日落时间";
            this.radio_日落时间.Size = new System.Drawing.Size(75, 16);
            this.radio_日落时间.TabIndex = 15;
            this.radio_日落时间.Text = "日落时间";
            this.radio_日落时间.UseVisualStyleBackColor = true;
            // 
            // radio_日出时间
            // 
            this.radio_日出时间.AutoSize = true;
            this.radio_日出时间.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radio_日出时间.Location = new System.Drawing.Point(96, 20);
            this.radio_日出时间.Name = "radio_日出时间";
            this.radio_日出时间.Size = new System.Drawing.Size(75, 16);
            this.radio_日出时间.TabIndex = 14;
            this.radio_日出时间.Text = "日出时间";
            this.radio_日出时间.UseVisualStyleBackColor = true;
            // 
            // radio_普通定时
            // 
            this.radio_普通定时.AutoSize = true;
            this.radio_普通定时.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radio_普通定时.Location = new System.Drawing.Point(9, 20);
            this.radio_普通定时.Name = "radio_普通定时";
            this.radio_普通定时.Size = new System.Drawing.Size(75, 16);
            this.radio_普通定时.TabIndex = 13;
            this.radio_普通定时.Text = "普通定时";
            this.radio_普通定时.UseVisualStyleBackColor = true;
            // 
            // time_开启时间
            // 
            this.time_开启时间.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time_开启时间.Location = new System.Drawing.Point(78, 42);
            this.time_开启时间.Name = "time_开启时间";
            this.time_开启时间.ShowUpDown = true;
            this.time_开启时间.Size = new System.Drawing.Size(93, 21);
            this.time_开启时间.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "动作时间：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.名称,
            this.动作类型,
            this.定时方式,
            this.动作时间});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(467, 433);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // 名称
            // 
            this.名称.HeaderText = "名称";
            this.名称.MinimumWidth = 120;
            this.名称.Name = "名称";
            this.名称.ReadOnly = true;
            this.名称.Width = 120;
            // 
            // 动作类型
            // 
            this.动作类型.HeaderText = "动作类型";
            this.动作类型.MinimumWidth = 70;
            this.动作类型.Name = "动作类型";
            this.动作类型.ReadOnly = true;
            this.动作类型.Width = 78;
            // 
            // 定时方式
            // 
            this.定时方式.HeaderText = "定时方式";
            this.定时方式.Name = "定时方式";
            this.定时方式.ReadOnly = true;
            this.定时方式.Width = 78;
            // 
            // 动作时间
            // 
            this.动作时间.HeaderText = "动作时间";
            this.动作时间.Name = "动作时间";
            this.动作时间.ReadOnly = true;
            this.动作时间.Width = 78;
            // 
            // 场景编辑
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 437);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "场景编辑";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "u";
            this.Load += new System.EventHandler(this.场景编辑_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_名称;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_获取日落时间;
        private System.Windows.Forms.Button btn_获取日出时间;
        private System.Windows.Forms.DateTimePicker time_开启时间;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_删除;
        private System.Windows.Forms.Button btn_修改;
        private System.Windows.Forms.Button btn_添加;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.RadioButton radio_日落时间;
        private System.Windows.Forms.RadioButton radio_日出时间;
        private System.Windows.Forms.RadioButton radio_普通定时;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radio_Close;
        private System.Windows.Forms.RadioButton radio_open;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 动作类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 定时方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 动作时间;
    }
}