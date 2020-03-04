namespace 照明模块软件
{
    partial class 场景模块添加界面
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
            this.combo_Addr = new System.Windows.Forms.ComboBox();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btn_全选 = new System.Windows.Forms.Button();
            this.btn_反选 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(49, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "模块地址";
            // 
            // combo_Addr
            // 
            this.combo_Addr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Addr.FormattingEnabled = true;
            this.combo_Addr.Location = new System.Drawing.Point(12, 3);
            this.combo_Addr.Name = "combo_Addr";
            this.combo_Addr.Size = new System.Drawing.Size(24, 20);
            this.combo_Addr.TabIndex = 1;
            this.combo_Addr.Visible = false;
            // 
            // btn_Sure
            // 
            this.btn_Sure.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Sure.Location = new System.Drawing.Point(42, 157);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(79, 32);
            this.btn_Sure.TabIndex = 2;
            this.btn_Sure.Text = "确  定";
            this.btn_Sure.UseVisualStyleBackColor = true;
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "4"});
            this.checkedListBox1.Location = new System.Drawing.Point(5, 29);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(157, 100);
            this.checkedListBox1.TabIndex = 3;
            // 
            // btn_全选
            // 
            this.btn_全选.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_全选.Location = new System.Drawing.Point(5, 129);
            this.btn_全选.Name = "btn_全选";
            this.btn_全选.Size = new System.Drawing.Size(40, 23);
            this.btn_全选.TabIndex = 4;
            this.btn_全选.Text = "全选";
            this.btn_全选.UseVisualStyleBackColor = true;
            this.btn_全选.Click += new System.EventHandler(this.btn_全选_Click);
            // 
            // btn_反选
            // 
            this.btn_反选.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_反选.Location = new System.Drawing.Point(51, 129);
            this.btn_反选.Name = "btn_反选";
            this.btn_反选.Size = new System.Drawing.Size(40, 23);
            this.btn_反选.TabIndex = 5;
            this.btn_反选.Text = "反选";
            this.btn_反选.UseVisualStyleBackColor = true;
            this.btn_反选.Click += new System.EventHandler(this.btn_反选_Click);
            // 
            // 场景模块添加界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(166, 195);
            this.Controls.Add(this.btn_反选);
            this.Controls.Add(this.btn_全选);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btn_Sure);
            this.Controls.Add(this.combo_Addr);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "场景模块添加界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "场景模块添加界面";
            this.Load += new System.EventHandler(this.场景模块添加界面_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_Addr;
        private System.Windows.Forms.Button btn_Sure;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btn_全选;
        private System.Windows.Forms.Button btn_反选;
    }
}