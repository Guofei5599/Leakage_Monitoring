namespace 照明模块软件
{
    partial class 主模块
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
            this.btn_模块管理 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_提示 = new System.Windows.Forms.Label();
            this.MainModelPanel_1 = new System.Windows.Forms.Panel();
            this.lab_日出日落 = new System.Windows.Forms.Label();
            this.通信状态1 = new CAEA.Common.HMIControl.Led.HMILed();
            this.lab_地址重复 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_模块管理
            // 
            this.btn_模块管理.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_模块管理.FlatAppearance.BorderSize = 0;
            this.btn_模块管理.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_模块管理.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_模块管理.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_模块管理.Location = new System.Drawing.Point(2, 5);
            this.btn_模块管理.Name = "btn_模块管理";
            this.btn_模块管理.Size = new System.Drawing.Size(75, 30);
            this.btn_模块管理.TabIndex = 5;
            this.btn_模块管理.Text = "模块管理";
            this.btn_模块管理.UseVisualStyleBackColor = false;
            this.btn_模块管理.Click += new System.EventHandler(this.btn_模块管理_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(780, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "通信状态：";
            // 
            // lab_提示
            // 
            this.lab_提示.AutoSize = true;
            this.lab_提示.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_提示.ForeColor = System.Drawing.Color.Red;
            this.lab_提示.Location = new System.Drawing.Point(348, 18);
            this.lab_提示.Name = "lab_提示";
            this.lab_提示.Size = new System.Drawing.Size(77, 17);
            this.lab_提示.TabIndex = 18;
            this.lab_提示.Text = "模块刷新中...";
            // 
            // MainModelPanel_1
            // 
            this.MainModelPanel_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainModelPanel_1.AutoScroll = true;
            this.MainModelPanel_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainModelPanel_1.Location = new System.Drawing.Point(0, 37);
            this.MainModelPanel_1.Name = "MainModelPanel_1";
            this.MainModelPanel_1.Size = new System.Drawing.Size(884, 575);
            this.MainModelPanel_1.TabIndex = 0;
            this.MainModelPanel_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainModelPanel_MouseDown);
            // 
            // lab_日出日落
            // 
            this.lab_日出日落.AutoSize = true;
            this.lab_日出日落.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_日出日落.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lab_日出日落.Location = new System.Drawing.Point(538, 17);
            this.lab_日出日落.Name = "lab_日出日落";
            this.lab_日出日落.Size = new System.Drawing.Size(96, 17);
            this.lab_日出日落.TabIndex = 20;
            this.lab_日出日落.Text = "日出：    日落：";
            // 
            // 通信状态1
            // 
            this.通信状态1.AddrLen = ((uint)(0u));
            this.通信状态1.AddrType = CAEA.Common.HMIControl.Base.HMICtrlBase.eAddrType.none;
            this.通信状态1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.通信状态1.BackColor = System.Drawing.Color.Transparent;
            this.通信状态1.BlinkInterval = 500;
            this.通信状态1.ControlDisplayType = CAEA.Common.HMIControl.Base.HMICtrlBase.eDisplayType.none;
            this.通信状态1.DispalyAddr = ((uint)(0u));
            this.通信状态1.DispalyAddrType = CAEA.Common.HMIControl.Base.HMICtrlBase.eAddrType.none;
            this.通信状态1.DispalyCondition = "";
            this.通信状态1.EnableDispaly = false;
            this.通信状态1.IsRelate = false;
            this.通信状态1.Label = "";
            this.通信状态1.LabelPosition = CAEA.Common.HMIControl.Led.HMILed.LedLabelPosition.Top;
            this.通信状态1.LedColor = System.Drawing.Color.Red;
            this.通信状态1.LedSize = new System.Drawing.SizeF(30F, 12F);
            this.通信状态1.Location = new System.Drawing.Point(851, 21);
            this.通信状态1.Name = "通信状态1";
            this.通信状态1.Renderer = null;
            this.通信状态1.Size = new System.Drawing.Size(26, 13);
            this.通信状态1.StartAddr = ((uint)(0u));
            this.通信状态1.State = CAEA.Common.HMIControl.Led.HMILed.LedState.Off;
            this.通信状态1.Style = CAEA.Common.HMIControl.Led.HMILed.LedStyle.Rectangular;
            this.通信状态1.TabIndex = 0;
            this.通信状态1.UpdateTips = "";
            this.通信状态1.UpdateToSqlFlag = false;
            this.通信状态1.UpdateUnit = "";
            this.通信状态1.UpdateValue = "";
            this.通信状态1.Value = 0;
            this.通信状态1.VariableName = "";
            // 
            // lab_地址重复
            // 
            this.lab_地址重复.AutoSize = true;
            this.lab_地址重复.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_地址重复.ForeColor = System.Drawing.Color.Red;
            this.lab_地址重复.Location = new System.Drawing.Point(348, 1);
            this.lab_地址重复.Name = "lab_地址重复";
            this.lab_地址重复.Size = new System.Drawing.Size(65, 17);
            this.lab_地址重复.TabIndex = 22;
            this.lab_地址重复.Text = "地址重复...";
            // 
            // 主模块
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 612);
            this.Controls.Add(this.lab_提示);
            this.Controls.Add(this.lab_地址重复);
            this.Controls.Add(this.通信状态1);
            this.Controls.Add(this.lab_日出日落);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_模块管理);
            this.Controls.Add(this.MainModelPanel_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "主模块";
            this.Text = "主模块";
            this.Load += new System.EventHandler(this.主模块_Load);
            this.SizeChanged += new System.EventHandler(this.主模块_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_模块管理;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_提示;
        private System.Windows.Forms.Panel MainModelPanel_1;
        private System.Windows.Forms.Label lab_日出日落;
        private CAEA.Common.HMIControl.Led.HMILed 通信状态1;
        private System.Windows.Forms.Label lab_地址重复;
    }
}