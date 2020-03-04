namespace 照明模块软件
{
    partial class 软件注册
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
            this.btnReg = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_机器码 = new System.Windows.Forms.TextBox();
            this.txt_注册码 = new System.Windows.Forms.TextBox();
            this.lab_提示 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(45, 97);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 23);
            this.btnReg.TabIndex = 1;
            this.btnReg.Text = "注  册";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(180, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "退  出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "机 器 码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "注 册 码：";
            // 
            // txt_机器码
            // 
            this.txt_机器码.Location = new System.Drawing.Point(74, 22);
            this.txt_机器码.Name = "txt_机器码";
            this.txt_机器码.ReadOnly = true;
            this.txt_机器码.Size = new System.Drawing.Size(220, 21);
            this.txt_机器码.TabIndex = 5;
            // 
            // txt_注册码
            // 
            this.txt_注册码.Location = new System.Drawing.Point(74, 54);
            this.txt_注册码.Name = "txt_注册码";
            this.txt_注册码.Size = new System.Drawing.Size(220, 21);
            this.txt_注册码.TabIndex = 6;
            // 
            // lab_提示
            // 
            this.lab_提示.AutoSize = true;
            this.lab_提示.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_提示.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lab_提示.Location = new System.Drawing.Point(90, 41);
            this.lab_提示.Name = "lab_提示";
            this.lab_提示.Size = new System.Drawing.Size(126, 25);
            this.lab_提示.TabIndex = 7;
            this.lab_提示.Text = "软件已注册！";
            // 
            // 软件注册
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 132);
            this.Controls.Add(this.lab_提示);
            this.Controls.Add(this.txt_注册码);
            this.Controls.Add(this.txt_机器码);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnReg);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "软件注册";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "软件注册";
            this.Load += new System.EventHandler(this.软件注册_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_机器码;
        private System.Windows.Forms.TextBox txt_注册码;
        private System.Windows.Forms.Label lab_提示;
    }
}