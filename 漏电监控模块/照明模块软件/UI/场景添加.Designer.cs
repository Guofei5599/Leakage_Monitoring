namespace 照明模块软件
{
    partial class 场景添加
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_场景名称 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.check_7 = new System.Windows.Forms.CheckBox();
            this.check_6 = new System.Windows.Forms.CheckBox();
            this.check_5 = new System.Windows.Forms.CheckBox();
            this.check_4 = new System.Windows.Forms.CheckBox();
            this.check_3 = new System.Windows.Forms.CheckBox();
            this.check_2 = new System.Windows.Forms.CheckBox();
            this.check_1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.radio普通定时 = new System.Windows.Forms.RadioButton();
            this.radio国家公休日 = new System.Windows.Forms.RadioButton();
            this.date_结束日期 = new System.Windows.Forms.DateTimePicker();
            this.date_开始日期 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "场景名称：";
            // 
            // txt_场景名称
            // 
            this.txt_场景名称.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_场景名称.Location = new System.Drawing.Point(107, 8);
            this.txt_场景名称.Name = "txt_场景名称";
            this.txt_场景名称.Size = new System.Drawing.Size(158, 26);
            this.txt_场景名称.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(108, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "确  定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.radio普通定时);
            this.panel2.Controls.Add(this.radio国家公休日);
            this.panel2.Location = new System.Drawing.Point(12, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 102);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.check_7);
            this.panel3.Controls.Add(this.check_6);
            this.panel3.Controls.Add(this.check_5);
            this.panel3.Controls.Add(this.check_4);
            this.panel3.Controls.Add(this.check_3);
            this.panel3.Controls.Add(this.check_2);
            this.panel3.Controls.Add(this.check_1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 49);
            this.panel3.TabIndex = 17;
            // 
            // check_7
            // 
            this.check_7.AutoSize = true;
            this.check_7.Location = new System.Drawing.Point(55, 25);
            this.check_7.Name = "check_7";
            this.check_7.Size = new System.Drawing.Size(48, 16);
            this.check_7.TabIndex = 37;
            this.check_7.Text = "周日";
            this.check_7.UseVisualStyleBackColor = true;
            // 
            // check_6
            // 
            this.check_6.AutoSize = true;
            this.check_6.Location = new System.Drawing.Point(4, 25);
            this.check_6.Name = "check_6";
            this.check_6.Size = new System.Drawing.Size(48, 16);
            this.check_6.TabIndex = 36;
            this.check_6.Text = "周六";
            this.check_6.UseVisualStyleBackColor = true;
            // 
            // check_5
            // 
            this.check_5.AutoSize = true;
            this.check_5.Location = new System.Drawing.Point(208, 3);
            this.check_5.Name = "check_5";
            this.check_5.Size = new System.Drawing.Size(48, 16);
            this.check_5.TabIndex = 35;
            this.check_5.Text = "周五";
            this.check_5.UseVisualStyleBackColor = true;
            // 
            // check_4
            // 
            this.check_4.AutoSize = true;
            this.check_4.Location = new System.Drawing.Point(157, 3);
            this.check_4.Name = "check_4";
            this.check_4.Size = new System.Drawing.Size(48, 16);
            this.check_4.TabIndex = 34;
            this.check_4.Text = "周四";
            this.check_4.UseVisualStyleBackColor = true;
            // 
            // check_3
            // 
            this.check_3.AutoSize = true;
            this.check_3.Location = new System.Drawing.Point(106, 3);
            this.check_3.Name = "check_3";
            this.check_3.Size = new System.Drawing.Size(48, 16);
            this.check_3.TabIndex = 33;
            this.check_3.Text = "周三";
            this.check_3.UseVisualStyleBackColor = true;
            // 
            // check_2
            // 
            this.check_2.AutoSize = true;
            this.check_2.Location = new System.Drawing.Point(55, 3);
            this.check_2.Name = "check_2";
            this.check_2.Size = new System.Drawing.Size(48, 16);
            this.check_2.TabIndex = 32;
            this.check_2.Text = "周二";
            this.check_2.UseVisualStyleBackColor = true;
            // 
            // check_1
            // 
            this.check_1.AutoSize = true;
            this.check_1.Location = new System.Drawing.Point(4, 3);
            this.check_1.Name = "check_1";
            this.check_1.Size = new System.Drawing.Size(48, 16);
            this.check_1.TabIndex = 31;
            this.check_1.Text = "周一";
            this.check_1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(93, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 20);
            this.button2.TabIndex = 16;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radio普通定时
            // 
            this.radio普通定时.AutoSize = true;
            this.radio普通定时.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radio普通定时.Location = new System.Drawing.Point(9, 33);
            this.radio普通定时.Name = "radio普通定时";
            this.radio普通定时.Size = new System.Drawing.Size(88, 16);
            this.radio普通定时.TabIndex = 1;
            this.radio普通定时.Text = "工作日定时";
            this.radio普通定时.UseVisualStyleBackColor = true;
            // 
            // radio国家公休日
            // 
            this.radio国家公休日.AutoSize = true;
            this.radio国家公休日.Checked = true;
            this.radio国家公休日.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radio国家公休日.Location = new System.Drawing.Point(9, 7);
            this.radio国家公休日.Name = "radio国家公休日";
            this.radio国家公休日.Size = new System.Drawing.Size(88, 16);
            this.radio国家公休日.TabIndex = 0;
            this.radio国家公休日.TabStop = true;
            this.radio国家公休日.Text = "国家公休日";
            this.radio国家公休日.UseVisualStyleBackColor = true;
            // 
            // date_结束日期
            // 
            this.date_结束日期.Location = new System.Drawing.Point(84, 32);
            this.date_结束日期.Name = "date_结束日期";
            this.date_结束日期.Size = new System.Drawing.Size(121, 21);
            this.date_结束日期.TabIndex = 21;
            // 
            // date_开始日期
            // 
            this.date_开始日期.Location = new System.Drawing.Point(84, 8);
            this.date_开始日期.Name = "date_开始日期";
            this.date_开始日期.Size = new System.Drawing.Size(121, 21);
            this.date_开始日期.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "结束日期：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "开始日期：";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.date_开始日期);
            this.panel1.Controls.Add(this.date_结束日期);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 63);
            this.panel1.TabIndex = 23;
            // 
            // 场景添加
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 277);
            this.Controls.Add(this.txt_场景名称);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "场景添加";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "场景";
            this.Load += new System.EventHandler(this.场景添加_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_场景名称;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox check_7;
        private System.Windows.Forms.CheckBox check_6;
        private System.Windows.Forms.CheckBox check_5;
        private System.Windows.Forms.CheckBox check_4;
        private System.Windows.Forms.CheckBox check_3;
        private System.Windows.Forms.CheckBox check_2;
        private System.Windows.Forms.CheckBox check_1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radio普通定时;
        private System.Windows.Forms.RadioButton radio国家公休日;
        private System.Windows.Forms.DateTimePicker date_结束日期;
        private System.Windows.Forms.DateTimePicker date_开始日期;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}