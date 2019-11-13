using System.Windows.Forms;

namespace koigoe_over_rap
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EQ1 = new System.Windows.Forms.Label();
            this.EQset4 = new System.Windows.Forms.ComboBox();
            this.EQset2 = new System.Windows.Forms.ComboBox();
            this.EQset1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.koigoe_set_path = new System.Windows.Forms.TextBox();
            this.koigoe_path = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inputDevice = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.koigoe_output = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label6 = new System.Windows.Forms.Label();
            this.reset_interval = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.shortcat4 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.shortcat3 = new System.Windows.Forms.TextBox();
            this.shortcat2 = new System.Windows.Forms.TextBox();
            this.shortcat1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EQset3 = new System.Windows.Forms.ComboBox();
            this.EQsetting = new System.Windows.Forms.GroupBox();
            this.deliteGame = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.delite = new System.Windows.Forms.Button();
            this.gamefile = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reset_interval)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.EQsetting.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox1.Location = new System.Drawing.Point(23, 17);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(172, 18);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "EQチェックを有効にする";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(96, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "4 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(5, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "2 :";
            // 
            // EQ1
            // 
            this.EQ1.AutoSize = true;
            this.EQ1.BackColor = System.Drawing.Color.Transparent;
            this.EQ1.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EQ1.Location = new System.Drawing.Point(5, 35);
            this.EQ1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.EQ1.Name = "EQ1";
            this.EQ1.Size = new System.Drawing.Size(27, 14);
            this.EQ1.TabIndex = 4;
            this.EQ1.Text = "1 :";
            // 
            // EQset4
            // 
            this.EQset4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EQset4.Font = new System.Drawing.Font("ふい字Ｐ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EQset4.FormattingEnabled = true;
            this.EQset4.Location = new System.Drawing.Point(129, 81);
            this.EQset4.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.EQset4.Name = "EQset4";
            this.EQset4.Size = new System.Drawing.Size(48, 20);
            this.EQset4.TabIndex = 10;
            // 
            // EQset2
            // 
            this.EQset2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EQset2.Font = new System.Drawing.Font("ふい字Ｐ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EQset2.FormattingEnabled = true;
            this.EQset2.Location = new System.Drawing.Point(38, 81);
            this.EQset2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.EQset2.Name = "EQset2";
            this.EQset2.Size = new System.Drawing.Size(48, 20);
            this.EQset2.TabIndex = 8;
            // 
            // EQset1
            // 
            this.EQset1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EQset1.Font = new System.Drawing.Font("ふい字Ｐ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EQset1.FormattingEnabled = true;
            this.EQset1.Location = new System.Drawing.Point(38, 33);
            this.EQset1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.EQset1.Name = "EQset1";
            this.EQset1.Size = new System.Drawing.Size(48, 20);
            this.EQset1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.koigoe_set_path);
            this.groupBox1.Controls.Add(this.koigoe_path);
            this.groupBox1.Font = new System.Drawing.Font("ふい字Ｐ", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(20, 235);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox1.Size = new System.Drawing.Size(538, 96);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "パス設定";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(9, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "koigoe_set";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(26, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "恋声";
            // 
            // koigoe_set_path
            // 
            this.koigoe_set_path.AllowDrop = true;
            this.koigoe_set_path.Font = new System.Drawing.Font("ふい字Ｐ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.koigoe_set_path.Location = new System.Drawing.Point(95, 65);
            this.koigoe_set_path.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.koigoe_set_path.Name = "koigoe_set_path";
            this.koigoe_set_path.Size = new System.Drawing.Size(428, 19);
            this.koigoe_set_path.TabIndex = 14;
            this.koigoe_set_path.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.koigoe_set_path.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // koigoe_path
            // 
            this.koigoe_path.AllowDrop = true;
            this.koigoe_path.Font = new System.Drawing.Font("ふい字Ｐ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.koigoe_path.Location = new System.Drawing.Point(95, 28);
            this.koigoe_path.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.koigoe_path.Name = "koigoe_path";
            this.koigoe_path.Size = new System.Drawing.Size(428, 19);
            this.koigoe_path.TabIndex = 13;
            this.koigoe_path.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.koigoe_path.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.inputDevice);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.koigoe_output);
            this.groupBox2.Font = new System.Drawing.Font("ふい字Ｐ", 11F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(229, 103);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox2.Size = new System.Drawing.Size(329, 122);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入出力設定";
            // 
            // inputDevice
            // 
            this.inputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputDevice.Font = new System.Drawing.Font("ふい字Ｐ", 8F);
            this.inputDevice.FormattingEnabled = true;
            this.inputDevice.Location = new System.Drawing.Point(69, 83);
            this.inputDevice.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.inputDevice.Name = "inputDevice";
            this.inputDevice.Size = new System.Drawing.Size(245, 19);
            this.inputDevice.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("ふい字Ｐ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(2, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "入力機器:";
            this.toolTip1.SetToolTip(this.label8, "恋声で変換した音が入ってくるデバイスを選択します。");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("ふい字Ｐ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(2, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "出力先:";
            this.toolTip1.SetToolTip(this.label7, "恋声が出力する先のデバイスを選択します。");
            // 
            // koigoe_output
            // 
            this.koigoe_output.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.koigoe_output.Font = new System.Drawing.Font("ふい字Ｐ", 8F);
            this.koigoe_output.FormattingEnabled = true;
            this.koigoe_output.Location = new System.Drawing.Point(69, 35);
            this.koigoe_output.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.koigoe_output.Name = "koigoe_output";
            this.koigoe_output.Size = new System.Drawing.Size(245, 19);
            this.koigoe_output.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(18, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 14);
            this.label6.TabIndex = 100;
            this.label6.Text = "リセット間隔:";
            this.toolTip1.SetToolTip(this.label6, "0は無効");
            // 
            // reset_interval
            // 
            this.reset_interval.Font = new System.Drawing.Font("ふい字Ｐ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.reset_interval.Location = new System.Drawing.Point(115, 72);
            this.reset_interval.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.reset_interval.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.reset_interval.Name = "reset_interval";
            this.reset_interval.Size = new System.Drawing.Size(45, 22);
            this.reset_interval.TabIndex = 2;
            this.toolTip1.SetToolTip(this.reset_interval, "リセットをする間隔を変更します。\r\n0：無効");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(5, 38);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 14);
            this.label10.TabIndex = 8;
            this.label10.Text = "変更";
            this.toolTip1.SetToolTip(this.label10, "声のセットを次のプロファイルにする。");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(73, 38);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 14);
            this.label11.TabIndex = 10;
            this.label11.Text = "リセット";
            this.toolTip1.SetToolTip(this.label11, "声のセットを次のプロファイルにする。");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(159, 38);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 14);
            this.label12.TabIndex = 11;
            this.label12.Text = "再起動";
            this.toolTip1.SetToolTip(this.label12, "声のセットを次のプロファイルにする。");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(26, 32);
            this.label13.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 14);
            this.label13.TabIndex = 16;
            this.label13.Text = "登録";
            this.toolTip1.SetToolTip(this.label13, "ゲームの実行ファイルを登録します（.exeファイル）");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(26, 64);
            this.label14.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 14);
            this.label14.TabIndex = 21;
            this.label14.Text = "削除";
            this.toolTip1.SetToolTip(this.label14, "登録したゲームを解除します");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.shortcat4);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.shortcat3);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.shortcat2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.shortcat1);
            this.groupBox3.Font = new System.Drawing.Font("ふい字Ｐ", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(229, 17);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox3.Size = new System.Drawing.Size(329, 77);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ショートカットキー";
            this.toolTip1.SetToolTip(this.groupBox3, "ショートカットキーを変更します");
            // 
            // shortcat4
            // 
            this.shortcat4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.shortcat4.Font = new System.Drawing.Font("ふい字Ｐ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.shortcat4.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.shortcat4.Location = new System.Drawing.Point(295, 37);
            this.shortcat4.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.shortcat4.MaxLength = 1;
            this.shortcat4.Name = "shortcat4";
            this.shortcat4.Size = new System.Drawing.Size(26, 18);
            this.shortcat4.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.Location = new System.Drawing.Point(241, 38);
            this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 14);
            this.label15.TabIndex = 19;
            this.label15.Text = "テキスト";
            this.toolTip1.SetToolTip(this.label15, "声のセットを次のプロファイルにする。");
            // 
            // shortcat3
            // 
            this.shortcat3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.shortcat3.Font = new System.Drawing.Font("ふい字Ｐ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.shortcat3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.shortcat3.Location = new System.Drawing.Point(212, 37);
            this.shortcat3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.shortcat3.MaxLength = 1;
            this.shortcat3.Name = "shortcat3";
            this.shortcat3.Size = new System.Drawing.Size(26, 18);
            this.shortcat3.TabIndex = 5;
            // 
            // shortcat2
            // 
            this.shortcat2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.shortcat2.Font = new System.Drawing.Font("ふい字Ｐ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.shortcat2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.shortcat2.Location = new System.Drawing.Point(130, 37);
            this.shortcat2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.shortcat2.MaxLength = 1;
            this.shortcat2.Name = "shortcat2";
            this.shortcat2.Size = new System.Drawing.Size(26, 18);
            this.shortcat2.TabIndex = 4;
            // 
            // shortcat1
            // 
            this.shortcat1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.shortcat1.Font = new System.Drawing.Font("ふい字Ｐ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.shortcat1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.shortcat1.Location = new System.Drawing.Point(44, 37);
            this.shortcat1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.shortcat1.MaxLength = 1;
            this.shortcat1.Name = "shortcat1";
            this.shortcat1.Size = new System.Drawing.Size(26, 18);
            this.shortcat1.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(165, 76);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 14);
            this.label9.TabIndex = 10;
            this.label9.Text = "分";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(579, 477);
            this.button1.TabIndex = 12;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(96, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "3 :";
            // 
            // EQset3
            // 
            this.EQset3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EQset3.Font = new System.Drawing.Font("ふい字Ｐ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EQset3.FormattingEnabled = true;
            this.EQset3.Location = new System.Drawing.Point(129, 33);
            this.EQset3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.EQset3.Name = "EQset3";
            this.EQset3.Size = new System.Drawing.Size(48, 20);
            this.EQset3.TabIndex = 9;
            // 
            // EQsetting
            // 
            this.EQsetting.BackColor = System.Drawing.Color.White;
            this.EQsetting.Controls.Add(this.EQset4);
            this.EQsetting.Controls.Add(this.EQset2);
            this.EQsetting.Controls.Add(this.label1);
            this.EQsetting.Controls.Add(this.EQset3);
            this.EQsetting.Controls.Add(this.label2);
            this.EQsetting.Controls.Add(this.EQset1);
            this.EQsetting.Controls.Add(this.EQ1);
            this.EQsetting.Controls.Add(this.label3);
            this.EQsetting.Font = new System.Drawing.Font("ふい字Ｐ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EQsetting.ForeColor = System.Drawing.SystemColors.MenuText;
            this.EQsetting.Location = new System.Drawing.Point(20, 103);
            this.EQsetting.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.EQsetting.Name = "EQsetting";
            this.EQsetting.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.EQsetting.Size = new System.Drawing.Size(186, 122);
            this.EQsetting.TabIndex = 1;
            this.EQsetting.TabStop = false;
            this.EQsetting.Text = "イコライザー設定";
            // 
            // deliteGame
            // 
            this.deliteGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deliteGame.Font = new System.Drawing.Font("ふい字Ｐ", 9F);
            this.deliteGame.FormattingEnabled = true;
            this.deliteGame.Location = new System.Drawing.Point(95, 64);
            this.deliteGame.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.deliteGame.Name = "deliteGame";
            this.deliteGame.Size = new System.Drawing.Size(348, 20);
            this.deliteGame.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.delite);
            this.groupBox4.Controls.Add(this.gamefile);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.deliteGame);
            this.groupBox4.Font = new System.Drawing.Font("ふい字Ｐ", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox4.Location = new System.Drawing.Point(20, 348);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox4.Size = new System.Drawing.Size(538, 95);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ゲーム";
            // 
            // delite
            // 
            this.delite.Font = new System.Drawing.Font("ふい字Ｐ", 9F);
            this.delite.Location = new System.Drawing.Point(463, 64);
            this.delite.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.delite.Name = "delite";
            this.delite.Size = new System.Drawing.Size(54, 20);
            this.delite.TabIndex = 17;
            this.delite.Text = "削除";
            this.delite.UseVisualStyleBackColor = true;
            // 
            // gamefile
            // 
            this.gamefile.AllowDrop = true;
            this.gamefile.Font = new System.Drawing.Font("ふい字Ｐ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gamefile.Location = new System.Drawing.Point(95, 31);
            this.gamefile.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.gamefile.Name = "gamefile";
            this.gamefile.Size = new System.Drawing.Size(428, 19);
            this.gamefile.TabIndex = 15;
            this.gamefile.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.gamefile.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("ふい字Ｐ", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox2.Location = new System.Drawing.Point(23, 47);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(185, 18);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "出力チェックを有効にする";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(579, 453);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.reset_interval);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.EQsetting);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "koigoe_over_rap";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reset_interval)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.EQsetting.ResumeLayout(false);
            this.EQsetting.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CheckBox checkBox1;
        private ComboBox EQset1;
        private ComboBox EQset4;
        private ComboBox EQset2;
        private Label label3;
        private Label label1;
        private Label EQ1;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private TextBox koigoe_set_path;
        private TextBox koigoe_path;
        private ComboBox koigoe_output;
        private GroupBox groupBox2;
        private ComboBox inputDevice;
        private Label label8;
        private ToolTip toolTip1;
        private Label label7;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label6;
        private NumericUpDown reset_interval;
        private Label label9;
        private GroupBox groupBox3;
        private TextBox shortcat3;
        private Label label12;
        private Label label11;
        private TextBox shortcat2;
        private Label label10;
        private TextBox shortcat1;
        private Button button1;
        private Label label2;
        private ComboBox EQset3;
        private GroupBox EQsetting;
        private ComboBox deliteGame;
        private Label label13;
        private GroupBox groupBox4;
        private Button delite;
        private TextBox gamefile;
        private Label label14;
        private TextBox shortcat4;
        private Label label15;
        public CheckBox checkBox2;
    }
}