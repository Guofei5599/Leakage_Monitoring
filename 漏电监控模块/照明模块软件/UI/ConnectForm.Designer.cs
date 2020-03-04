namespace 照明模块软件
{
    partial class ConnectForm
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
            this.comb_Serial = new System.Windows.Forms.ComboBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.comb_Baud = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串  口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // comb_Serial
            // 
            this.comb_Serial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_Serial.FormattingEnabled = true;
            this.comb_Serial.Location = new System.Drawing.Point(93, 22);
            this.comb_Serial.Name = "comb_Serial";
            this.comb_Serial.Size = new System.Drawing.Size(121, 20);
            this.comb_Serial.TabIndex = 2;
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(93, 86);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 4;
            this.btn_Connect.Text = "连  接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // comb_Baud
            // 
            this.comb_Baud.FormattingEnabled = true;
            this.comb_Baud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "115200"});
            this.comb_Baud.Location = new System.Drawing.Point(93, 53);
            this.comb_Baud.Name = "comb_Baud";
            this.comb_Baud.Size = new System.Drawing.Size(84, 20);
            this.comb_Baud.TabIndex = 5;
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 119);
            this.Controls.Add(this.comb_Baud);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.comb_Serial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "连接";
            this.Load += new System.EventHandler(this.ConnectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comb_Serial;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.ComboBox comb_Baud;
    }
}