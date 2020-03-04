namespace 照明模块软件
{
    partial class 参数设置
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_TcpCheck = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.num_Port = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.comb_IP = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radio_SerialCheck = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.num_Baud = new System.Windows.Forms.ComboBox();
            this.comb_SerialPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioB_广播 = new System.Windows.Forms.RadioButton();
            this.radio_巡检 = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.num_SceneCheck = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.num_sendSpeed = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.num_ReceiveSpeed = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_获取经纬度 = new System.Windows.Forms.Button();
            this.num_维度 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.num_经度 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txt_QQ掩码 = new System.Windows.Forms.TextBox();
            this.txt_电话掩码 = new System.Windows.Forms.TextBox();
            this.txt_网址掩码 = new System.Windows.Forms.TextBox();
            this.txt_公司掩码 = new System.Windows.Forms.TextBox();
            this.txt_标题掩码 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Check_Auto = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Port)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_SceneCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_sendSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ReceiveSpeed)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_维度)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_经度)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radio_TcpCheck);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.radio_SerialCheck);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通信";
            // 
            // radio_TcpCheck
            // 
            this.radio_TcpCheck.AutoSize = true;
            this.radio_TcpCheck.Location = new System.Drawing.Point(256, 22);
            this.radio_TcpCheck.Name = "radio_TcpCheck";
            this.radio_TcpCheck.Size = new System.Drawing.Size(97, 24);
            this.radio_TcpCheck.TabIndex = 7;
            this.radio_TcpCheck.TabStop = true;
            this.radio_TcpCheck.Text = "以太网通信";
            this.radio_TcpCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.num_Port);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.comb_IP);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(215, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(241, 91);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // num_Port
            // 
            this.num_Port.Location = new System.Drawing.Point(62, 55);
            this.num_Port.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.num_Port.Name = "num_Port";
            this.num_Port.Size = new System.Drawing.Size(82, 23);
            this.num_Port.TabIndex = 7;
            this.num_Port.Value = new decimal(new int[] {
            4001,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "端    口：";
            // 
            // comb_IP
            // 
            this.comb_IP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comb_IP.FormattingEnabled = true;
            this.comb_IP.Location = new System.Drawing.Point(62, 19);
            this.comb_IP.Name = "comb_IP";
            this.comb_IP.Size = new System.Drawing.Size(162, 25);
            this.comb_IP.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "IP地址：";
            // 
            // radio_SerialCheck
            // 
            this.radio_SerialCheck.AutoSize = true;
            this.radio_SerialCheck.Location = new System.Drawing.Point(56, 22);
            this.radio_SerialCheck.Name = "radio_SerialCheck";
            this.radio_SerialCheck.Size = new System.Drawing.Size(83, 24);
            this.radio_SerialCheck.TabIndex = 5;
            this.radio_SerialCheck.TabStop = true;
            this.radio_SerialCheck.Text = "串口通信";
            this.radio_SerialCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.num_Baud);
            this.groupBox2.Controls.Add(this.comb_SerialPort);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(15, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 91);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // num_Baud
            // 
            this.num_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.num_Baud.FormattingEnabled = true;
            this.num_Baud.Items.AddRange(new object[] {
            "9600",
            "115200"});
            this.num_Baud.Location = new System.Drawing.Point(79, 52);
            this.num_Baud.Name = "num_Baud";
            this.num_Baud.Size = new System.Drawing.Size(83, 25);
            this.num_Baud.TabIndex = 3;
            // 
            // comb_SerialPort
            // 
            this.comb_SerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_SerialPort.FormattingEnabled = true;
            this.comb_SerialPort.Location = new System.Drawing.Point(79, 22);
            this.comb_SerialPort.Name = "comb_SerialPort";
            this.comb_SerialPort.Size = new System.Drawing.Size(83, 25);
            this.comb_SerialPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "波 特 率：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(12, 159);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 206);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "开关设置";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.Check_Auto);
            this.groupBox6.Controls.Add(this.radioB_广播);
            this.groupBox6.Controls.Add(this.radio_巡检);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.num_SceneCheck);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.num_sendSpeed);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.num_ReceiveSpeed);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox6.Location = new System.Drawing.Point(15, 25);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(232, 175);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            // 
            // radioB_广播
            // 
            this.radioB_广播.AutoSize = true;
            this.radioB_广播.Location = new System.Drawing.Point(78, 26);
            this.radioB_广播.Name = "radioB_广播";
            this.radioB_广播.Size = new System.Drawing.Size(50, 21);
            this.radioB_广播.TabIndex = 13;
            this.radioB_广播.TabStop = true;
            this.radioB_广播.Text = "广播";
            this.radioB_广播.UseVisualStyleBackColor = true;
            // 
            // radio_巡检
            // 
            this.radio_巡检.AutoSize = true;
            this.radio_巡检.Location = new System.Drawing.Point(26, 26);
            this.radio_巡检.Name = "radio_巡检";
            this.radio_巡检.Size = new System.Drawing.Size(50, 21);
            this.radio_巡检.TabIndex = 12;
            this.radio_巡检.TabStop = true;
            this.radio_巡检.Text = "巡检";
            this.radio_巡检.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(166, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "分钟/次";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(166, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "ms/次";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(166, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "ms/次";
            // 
            // num_SceneCheck
            // 
            this.num_SceneCheck.Location = new System.Drawing.Point(81, 120);
            this.num_SceneCheck.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.num_SceneCheck.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_SceneCheck.Name = "num_SceneCheck";
            this.num_SceneCheck.Size = new System.Drawing.Size(82, 23);
            this.num_SceneCheck.TabIndex = 7;
            this.num_SceneCheck.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "自动刷新：";
            // 
            // num_sendSpeed
            // 
            this.num_sendSpeed.Location = new System.Drawing.Point(79, 61);
            this.num_sendSpeed.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.num_sendSpeed.Name = "num_sendSpeed";
            this.num_sendSpeed.Size = new System.Drawing.Size(82, 23);
            this.num_sendSpeed.TabIndex = 5;
            this.num_sendSpeed.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "发送速度：";
            // 
            // num_ReceiveSpeed
            // 
            this.num_ReceiveSpeed.Location = new System.Drawing.Point(80, 90);
            this.num_ReceiveSpeed.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.num_ReceiveSpeed.Name = "num_ReceiveSpeed";
            this.num_ReceiveSpeed.Size = new System.Drawing.Size(82, 23);
            this.num_ReceiveSpeed.TabIndex = 3;
            this.num_ReceiveSpeed.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "接受速度：";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(113, 561);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "保  存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(288, 561);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 31);
            this.button2.TabIndex = 10;
            this.button2.Text = "退  出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_获取经纬度);
            this.groupBox5.Controls.Add(this.num_维度);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.num_经度);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(289, 159);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(301, 206);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "经纬度";
            // 
            // btn_获取经纬度
            // 
            this.btn_获取经纬度.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_获取经纬度.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_获取经纬度.Location = new System.Drawing.Point(70, 122);
            this.btn_获取经纬度.Name = "btn_获取经纬度";
            this.btn_获取经纬度.Size = new System.Drawing.Size(184, 31);
            this.btn_获取经纬度.TabIndex = 11;
            this.btn_获取经纬度.Text = "获取经纬度";
            this.btn_获取经纬度.UseVisualStyleBackColor = true;
            this.btn_获取经纬度.Click += new System.EventHandler(this.btn_获取经纬度_Click);
            // 
            // num_维度
            // 
            this.num_维度.DecimalPlaces = 9;
            this.num_维度.Location = new System.Drawing.Point(70, 75);
            this.num_维度.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.num_维度.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.num_维度.Name = "num_维度";
            this.num_维度.Size = new System.Drawing.Size(184, 26);
            this.num_维度.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "维  度：";
            // 
            // num_经度
            // 
            this.num_经度.DecimalPlaces = 9;
            this.num_经度.Location = new System.Drawing.Point(70, 41);
            this.num_经度.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.num_经度.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.num_经度.Name = "num_经度";
            this.num_经度.Size = new System.Drawing.Size(184, 26);
            this.num_经度.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "经  度：";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.txt_QQ掩码);
            this.groupBox7.Controls.Add(this.txt_电话掩码);
            this.groupBox7.Controls.Add(this.txt_网址掩码);
            this.groupBox7.Controls.Add(this.txt_公司掩码);
            this.groupBox7.Controls.Add(this.txt_标题掩码);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox7.Location = new System.Drawing.Point(12, 375);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(860, 171);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "系统信息设置";
            this.groupBox7.Visible = false;
            // 
            // txt_QQ掩码
            // 
            this.txt_QQ掩码.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_QQ掩码.Location = new System.Drawing.Point(82, 130);
            this.txt_QQ掩码.Name = "txt_QQ掩码";
            this.txt_QQ掩码.Size = new System.Drawing.Size(501, 23);
            this.txt_QQ掩码.TabIndex = 9;
            this.txt_QQ掩码.Visible = false;
            // 
            // txt_电话掩码
            // 
            this.txt_电话掩码.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_电话掩码.Location = new System.Drawing.Point(82, 105);
            this.txt_电话掩码.Name = "txt_电话掩码";
            this.txt_电话掩码.Size = new System.Drawing.Size(501, 23);
            this.txt_电话掩码.TabIndex = 8;
            this.txt_电话掩码.Visible = false;
            // 
            // txt_网址掩码
            // 
            this.txt_网址掩码.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_网址掩码.Location = new System.Drawing.Point(82, 80);
            this.txt_网址掩码.Name = "txt_网址掩码";
            this.txt_网址掩码.Size = new System.Drawing.Size(501, 23);
            this.txt_网址掩码.TabIndex = 7;
            this.txt_网址掩码.Visible = false;
            // 
            // txt_公司掩码
            // 
            this.txt_公司掩码.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_公司掩码.Location = new System.Drawing.Point(82, 55);
            this.txt_公司掩码.Name = "txt_公司掩码";
            this.txt_公司掩码.Size = new System.Drawing.Size(501, 23);
            this.txt_公司掩码.TabIndex = 6;
            this.txt_公司掩码.Visible = false;
            // 
            // txt_标题掩码
            // 
            this.txt_标题掩码.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_标题掩码.Location = new System.Drawing.Point(82, 30);
            this.txt_标题掩码.Name = "txt_标题掩码";
            this.txt_标题掩码.Size = new System.Drawing.Size(501, 23);
            this.txt_标题掩码.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 131);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 20);
            this.label19.TabIndex = 4;
            this.label19.Text = "QQ掩码：";
            this.label19.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 106);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 20);
            this.label17.TabIndex = 3;
            this.label17.Text = "电话掩码：";
            this.label17.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 81);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 20);
            this.label18.TabIndex = 2;
            this.label18.Text = "网址掩码：";
            this.label18.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "公司掩码：";
            this.label16.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "标题掩码：";
            // 
            // Check_Auto
            // 
            this.Check_Auto.AutoSize = true;
            this.Check_Auto.Location = new System.Drawing.Point(151, 26);
            this.Check_Auto.Name = "Check_Auto";
            this.Check_Auto.Size = new System.Drawing.Size(75, 21);
            this.Check_Auto.TabIndex = 11;
            this.Check_Auto.Text = "自动刷新";
            this.Check_Auto.UseVisualStyleBackColor = true;
            // 
            // 参数设置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 612);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "参数设置";
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.参数设置_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Port)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_SceneCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_sendSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ReceiveSpeed)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_维度)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_经度)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio_TcpCheck;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown num_Port;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comb_IP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radio_SerialCheck;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comb_SerialPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_SceneCheck;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown num_sendSpeed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown num_ReceiveSpeed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox num_Baud;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_获取经纬度;
        private System.Windows.Forms.NumericUpDown num_维度;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_经度;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txt_QQ掩码;
        private System.Windows.Forms.TextBox txt_电话掩码;
        private System.Windows.Forms.TextBox txt_网址掩码;
        private System.Windows.Forms.TextBox txt_公司掩码;
        private System.Windows.Forms.TextBox txt_标题掩码;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton radioB_广播;
        private System.Windows.Forms.RadioButton radio_巡检;
        private System.Windows.Forms.CheckBox Check_Auto;
    }
}