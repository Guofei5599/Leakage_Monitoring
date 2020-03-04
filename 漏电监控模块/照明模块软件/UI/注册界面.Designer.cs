namespace 照明模块软件
{
    partial class 注册界面
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
            this.label2 = new System.Windows.Forms.Label();
            this.txt_机器码 = new System.Windows.Forms.TextBox();
            this.txt_注册码 = new System.Windows.Forms.TextBox();
            this.btn_注册 = new System.Windows.Forms.Button();
            this.btn_取消 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "机 器 码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "注 册 码：";
            // 
            // txt_机器码
            // 
            this.txt_机器码.Location = new System.Drawing.Point(79, 21);
            this.txt_机器码.Name = "txt_机器码";
            this.txt_机器码.Size = new System.Drawing.Size(271, 21);
            this.txt_机器码.TabIndex = 2;
            // 
            // txt_注册码
            // 
            this.txt_注册码.Location = new System.Drawing.Point(79, 50);
            this.txt_注册码.Name = "txt_注册码";
            this.txt_注册码.Size = new System.Drawing.Size(271, 21);
            this.txt_注册码.TabIndex = 3;
            // 
            // btn_注册
            // 
            this.btn_注册.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_注册.Location = new System.Drawing.Point(100, 83);
            this.btn_注册.Name = "btn_注册";
            this.btn_注册.Size = new System.Drawing.Size(64, 23);
            this.btn_注册.TabIndex = 4;
            this.btn_注册.Text = "注  册";
            this.btn_注册.UseVisualStyleBackColor = true;
            // 
            // btn_取消
            // 
            this.btn_取消.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_取消.Location = new System.Drawing.Point(201, 83);
            this.btn_取消.Name = "btn_取消";
            this.btn_取消.Size = new System.Drawing.Size(65, 23);
            this.btn_取消.TabIndex = 5;
            this.btn_取消.Text = "取  消";
            this.btn_取消.UseVisualStyleBackColor = true;
            this.btn_取消.Click += new System.EventHandler(this.btn_取消_Click);
            // 
            // 注册界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 118);
            this.Controls.Add(this.btn_取消);
            this.Controls.Add(this.btn_注册);
            this.Controls.Add(this.txt_注册码);
            this.Controls.Add(this.txt_机器码);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "注册界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "注册界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_机器码;
        private System.Windows.Forms.TextBox txt_注册码;
        private System.Windows.Forms.Button btn_注册;
        private System.Windows.Forms.Button btn_取消;
    }
}