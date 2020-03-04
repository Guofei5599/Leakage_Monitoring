namespace 照明模块软件
{
    partial class 开关模块界面
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
            this.btn_脱扣 = new System.Windows.Forms.Button();
            this.btn_复位 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.通信状态1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_模块地址 = new System.Windows.Forms.Label();
            this.Led_消防联动 = new System.Windows.Forms.Label();
            this.lab_提示 = new System.Windows.Forms.Label();
            this.btn_刷新 = new System.Windows.Forms.Button();
            this.model_Panel = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.通道 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.当前数值 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.报警时间 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_消声 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_安装位置 = new System.Windows.Forms.Label();
            this.lab_模块名称 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.model_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_脱扣
            // 
            this.btn_脱扣.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_脱扣.FlatAppearance.BorderSize = 0;
            this.btn_脱扣.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_脱扣.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_脱扣.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_脱扣.Location = new System.Drawing.Point(55, 4);
            this.btn_脱扣.Name = "btn_脱扣";
            this.btn_脱扣.Size = new System.Drawing.Size(51, 30);
            this.btn_脱扣.TabIndex = 9;
            this.btn_脱扣.Text = "脱 扣";
            this.btn_脱扣.UseVisualStyleBackColor = false;
            // 
            // btn_复位
            // 
            this.btn_复位.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_复位.FlatAppearance.BorderSize = 0;
            this.btn_复位.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_复位.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_复位.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_复位.Location = new System.Drawing.Point(3, 4);
            this.btn_复位.Name = "btn_复位";
            this.btn_复位.Size = new System.Drawing.Size(51, 30);
            this.btn_复位.TabIndex = 8;
            this.btn_复位.Text = "复 位";
            this.btn_复位.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(211, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 30);
            this.button3.TabIndex = 10;
            this.button3.Text = "退 出";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // 通信状态1
            // 
            this.通信状态1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.通信状态1.AutoSize = true;
            this.通信状态1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.通信状态1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.通信状态1.Location = new System.Drawing.Point(808, 15);
            this.通信状态1.Name = "通信状态1";
            this.通信状态1.Size = new System.Drawing.Size(65, 19);
            this.通信状态1.TabIndex = 12;
            this.通信状态1.Text = "通信正常";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(11, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "模块地址：";
            // 
            // lab_模块地址
            // 
            this.lab_模块地址.AutoSize = true;
            this.lab_模块地址.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_模块地址.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lab_模块地址.Location = new System.Drawing.Point(86, 13);
            this.lab_模块地址.Name = "lab_模块地址";
            this.lab_模块地址.Size = new System.Drawing.Size(37, 19);
            this.lab_模块地址.TabIndex = 14;
            this.lab_模块地址.Text = "地址";
            // 
            // Led_消防联动
            // 
            this.Led_消防联动.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Led_消防联动.AutoSize = true;
            this.Led_消防联动.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Led_消防联动.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Led_消防联动.Location = new System.Drawing.Point(730, 15);
            this.Led_消防联动.Name = "Led_消防联动";
            this.Led_消防联动.Size = new System.Drawing.Size(65, 19);
            this.Led_消防联动.TabIndex = 15;
            this.Led_消防联动.Text = "消防联动";
            // 
            // lab_提示
            // 
            this.lab_提示.AutoSize = true;
            this.lab_提示.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_提示.ForeColor = System.Drawing.Color.Red;
            this.lab_提示.Location = new System.Drawing.Point(394, 15);
            this.lab_提示.Name = "lab_提示";
            this.lab_提示.Size = new System.Drawing.Size(91, 19);
            this.lab_提示.TabIndex = 17;
            this.lab_提示.Text = "模块刷新中...";
            // 
            // btn_刷新
            // 
            this.btn_刷新.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_刷新.FlatAppearance.BorderSize = 0;
            this.btn_刷新.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_刷新.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_刷新.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_刷新.Location = new System.Drawing.Point(107, 4);
            this.btn_刷新.Name = "btn_刷新";
            this.btn_刷新.Size = new System.Drawing.Size(51, 30);
            this.btn_刷新.TabIndex = 18;
            this.btn_刷新.Text = "刷 新";
            this.btn_刷新.UseVisualStyleBackColor = false;
            this.btn_刷新.Click += new System.EventHandler(this.btn_刷新_Click);
            // 
            // model_Panel
            // 
            this.model_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.model_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.model_Panel.Controls.Add(this.lab_模块名称);
            this.model_Panel.Controls.Add(this.label5);
            this.model_Panel.Controls.Add(this.lab_安装位置);
            this.model_Panel.Controls.Add(this.listView1);
            this.model_Panel.Controls.Add(this.lab_模块地址);
            this.model_Panel.Controls.Add(this.label2);
            this.model_Panel.Controls.Add(this.label1);
            this.model_Panel.Location = new System.Drawing.Point(0, 37);
            this.model_Panel.Name = "model_Panel";
            this.model_Panel.Size = new System.Drawing.Size(884, 575);
            this.model_Panel.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.通道,
            this.当前数值,
            this.报警时间});
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 35);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(879, 539);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // 通道
            // 
            this.通道.Text = "通道";
            // 
            // 当前数值
            // 
            this.当前数值.Text = "当前数值";
            this.当前数值.Width = 80;
            // 
            // 报警时间
            // 
            this.报警时间.Text = "报警时间";
            this.报警时间.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.报警时间.Width = 200;
            // 
            // btn_消声
            // 
            this.btn_消声.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_消声.FlatAppearance.BorderSize = 0;
            this.btn_消声.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_消声.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_消声.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_消声.Location = new System.Drawing.Point(159, 4);
            this.btn_消声.Name = "btn_消声";
            this.btn_消声.Size = new System.Drawing.Size(51, 30);
            this.btn_消声.TabIndex = 19;
            this.btn_消声.Text = "消 声";
            this.btn_消声.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(304, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "安装位置：";
            // 
            // lab_安装位置
            // 
            this.lab_安装位置.AutoSize = true;
            this.lab_安装位置.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_安装位置.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lab_安装位置.Location = new System.Drawing.Point(381, 13);
            this.lab_安装位置.Name = "lab_安装位置";
            this.lab_安装位置.Size = new System.Drawing.Size(65, 19);
            this.lab_安装位置.TabIndex = 16;
            this.lab_安装位置.Text = "安装位置";
            // 
            // lab_模块名称
            // 
            this.lab_模块名称.AutoSize = true;
            this.lab_模块名称.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_模块名称.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lab_模块名称.Location = new System.Drawing.Point(217, 13);
            this.lab_模块名称.Name = "lab_模块名称";
            this.lab_模块名称.Size = new System.Drawing.Size(65, 19);
            this.lab_模块名称.TabIndex = 18;
            this.lab_模块名称.Text = "模块名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(140, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "模块名称：";
            // 
            // 开关模块界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 612);
            this.Controls.Add(this.btn_消声);
            this.Controls.Add(this.btn_刷新);
            this.Controls.Add(this.lab_提示);
            this.Controls.Add(this.Led_消防联动);
            this.Controls.Add(this.通信状态1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_脱扣);
            this.Controls.Add(this.btn_复位);
            this.Controls.Add(this.model_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "开关模块界面";
            this.Text = "开关模块";
            this.Load += new System.EventHandler(this.开关模块_Load);
            this.SizeChanged += new System.EventHandler(this.开关模块界面_SizeChanged);
            this.model_Panel.ResumeLayout(false);
            this.model_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_脱扣;
        private System.Windows.Forms.Button btn_复位;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label 通信状态1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_模块地址;
        private System.Windows.Forms.Label Led_消防联动;
        private System.Windows.Forms.Label lab_提示;
        private System.Windows.Forms.Button btn_刷新;
        private System.Windows.Forms.Panel model_Panel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 通道;
        private System.Windows.Forms.ColumnHeader 当前数值;
        private System.Windows.Forms.ColumnHeader 报警时间;
        private System.Windows.Forms.Label lab_安装位置;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_消声;
        private System.Windows.Forms.Label lab_模块名称;
        private System.Windows.Forms.Label label5;
    }
}