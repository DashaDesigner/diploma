namespace OptimalPartitioning
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_start = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lbl_numberOfCenters = new System.Windows.Forms.Label();
            this.lbl_stepOfGrid = new System.Windows.Forms.Label();
            this.txtb_stepOfGridX = new System.Windows.Forms.TextBox();
            this.txtb_stepOfGridY = new System.Windows.Forms.TextBox();
            this.cb_draw = new System.Windows.Forms.CheckBox();
            this.lbl_x = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_clearDgv = new System.Windows.Forms.Button();
            this.rtb_centers = new System.Windows.Forms.RichTextBox();
            this.cb_centers = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_A1 = new System.Windows.Forms.TabPage();
            this.btn_generateRandomCenters = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nud_numberOfCenters = new System.Windows.Forms.NumericUpDown();
            this.lbl_resFunc = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_gamma = new System.Windows.Forms.Label();
            this.nud_gamma = new System.Windows.Forms.NumericUpDown();
            this.panel_line = new System.Windows.Forms.Panel();
            this.lbl_ro1 = new System.Windows.Forms.Label();
            this.cb_ro1 = new System.Windows.Forms.ComboBox();
            this.lbl_c1 = new System.Windows.Forms.Label();
            this.cb_ro2 = new System.Windows.Forms.ComboBox();
            this.lbl_c2 = new System.Windows.Forms.Label();
            this.cb_c2 = new System.Windows.Forms.ComboBox();
            this.cb_c1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ProductCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage_A1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_numberOfCenters)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_gamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_start.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_start.Location = new System.Drawing.Point(4, 844);
            this.btn_start.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(206, 58);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "РОЗВ\'ЯЗАТИ";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(592, 23);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(998, 960);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // lbl_numberOfCenters
            // 
            this.lbl_numberOfCenters.AutoSize = true;
            this.lbl_numberOfCenters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_numberOfCenters.Location = new System.Drawing.Point(16, 17);
            this.lbl_numberOfCenters.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_numberOfCenters.Name = "lbl_numberOfCenters";
            this.lbl_numberOfCenters.Size = new System.Drawing.Size(212, 26);
            this.lbl_numberOfCenters.TabIndex = 0;
            this.lbl_numberOfCenters.Text = "Кількість центрів:";
            // 
            // lbl_stepOfGrid
            // 
            this.lbl_stepOfGrid.AutoSize = true;
            this.lbl_stepOfGrid.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbl_stepOfGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_stepOfGrid.Location = new System.Drawing.Point(46, 863);
            this.lbl_stepOfGrid.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_stepOfGrid.Name = "lbl_stepOfGrid";
            this.lbl_stepOfGrid.Size = new System.Drawing.Size(157, 26);
            this.lbl_stepOfGrid.TabIndex = 4;
            this.lbl_stepOfGrid.Text = "Розмір сітки:";
            // 
            // txtb_stepOfGridX
            // 
            this.txtb_stepOfGridX.Location = new System.Drawing.Point(226, 792);
            this.txtb_stepOfGridX.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtb_stepOfGridX.Name = "txtb_stepOfGridX";
            this.txtb_stepOfGridX.Size = new System.Drawing.Size(100, 31);
            this.txtb_stepOfGridX.TabIndex = 1;
            this.txtb_stepOfGridX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtb_stepOfGridY
            // 
            this.txtb_stepOfGridY.Location = new System.Drawing.Point(394, 792);
            this.txtb_stepOfGridY.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtb_stepOfGridY.Name = "txtb_stepOfGridY";
            this.txtb_stepOfGridY.Size = new System.Drawing.Size(100, 31);
            this.txtb_stepOfGridY.TabIndex = 2;
            this.txtb_stepOfGridY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_draw
            // 
            this.cb_draw.AutoSize = true;
            this.cb_draw.Location = new System.Drawing.Point(220, 860);
            this.cb_draw.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cb_draw.Name = "cb_draw";
            this.cb_draw.Size = new System.Drawing.Size(268, 29);
            this.cb_draw.TabIndex = 7;
            this.cb_draw.Text = "Відображати розбиття";
            this.cb_draw.UseVisualStyleBackColor = true;
            // 
            // lbl_x
            // 
            this.lbl_x.AutoSize = true;
            this.lbl_x.Location = new System.Drawing.Point(350, 798);
            this.lbl_x.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_x.Name = "lbl_x";
            this.lbl_x.Size = new System.Drawing.Size(23, 25);
            this.lbl_x.TabIndex = 8;
            this.lbl_x.Text = "х";
            // 
            // dgv
            // 
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgv.GridColor = System.Drawing.SystemColors.Control;
            this.dgv.Location = new System.Drawing.Point(52, 350);
            this.dgv.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(482, 425);
            this.dgv.TabIndex = 13;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "X";
            this.Column1.Name = "Column1";
            this.Column1.Width = 97;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Y";
            this.Column2.Name = "Column2";
            this.Column2.Width = 97;
            // 
            // btn_clearDgv
            // 
            this.btn_clearDgv.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_clearDgv.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_clearDgv.Location = new System.Drawing.Point(250, 785);
            this.btn_clearDgv.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_clearDgv.Name = "btn_clearDgv";
            this.btn_clearDgv.Size = new System.Drawing.Size(282, 58);
            this.btn_clearDgv.TabIndex = 12;
            this.btn_clearDgv.Text = "Очистити";
            this.btn_clearDgv.UseVisualStyleBackColor = false;
            this.btn_clearDgv.Click += new System.EventHandler(this.btn_clearDgv_Click);
            // 
            // rtb_centers
            // 
            this.rtb_centers.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_centers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_centers.Location = new System.Drawing.Point(54, 471);
            this.rtb_centers.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rtb_centers.Name = "rtb_centers";
            this.rtb_centers.Size = new System.Drawing.Size(476, 302);
            this.rtb_centers.TabIndex = 1;
            this.rtb_centers.Text = "";
            // 
            // cb_centers
            // 
            this.cb_centers.AutoSize = true;
            this.cb_centers.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cb_centers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_centers.Location = new System.Drawing.Point(50, 798);
            this.cb_centers.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cb_centers.Name = "cb_centers";
            this.cb_centers.Size = new System.Drawing.Size(193, 30);
            this.cb_centers.TabIndex = 12;
            this.cb_centers.Text = "Ввести центри";
            this.cb_centers.UseVisualStyleBackColor = false;
            this.cb_centers.CheckedChanged += new System.EventHandler(this.cb_centers_CheckedChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_A1);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(24, 19);
            this.tabControl.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(538, 962);
            this.tabControl.TabIndex = 13;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage_A1
            // 
            this.tabPage_A1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage_A1.Controls.Add(this.lbl_numberOfCenters);
            this.tabPage_A1.Controls.Add(this.btn_generateRandomCenters);
            this.tabPage_A1.Controls.Add(this.button1);
            this.tabPage_A1.Controls.Add(this.nud_numberOfCenters);
            this.tabPage_A1.Controls.Add(this.btn_start);
            this.tabPage_A1.Controls.Add(this.lbl_resFunc);
            this.tabPage_A1.Controls.Add(this.txtb_stepOfGridY);
            this.tabPage_A1.Controls.Add(this.lbl_x);
            this.tabPage_A1.Controls.Add(this.cb_draw);
            this.tabPage_A1.Controls.Add(this.txtb_stepOfGridX);
            this.tabPage_A1.Location = new System.Drawing.Point(8, 39);
            this.tabPage_A1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage_A1.Name = "tabPage_A1";
            this.tabPage_A1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage_A1.Size = new System.Drawing.Size(522, 915);
            this.tabPage_A1.TabIndex = 0;
            this.tabPage_A1.Text = "Однопродуктова";
            // 
            // btn_generateRandomCenters
            // 
            this.btn_generateRandomCenters.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_generateRandomCenters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_generateRandomCenters.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_generateRandomCenters.Location = new System.Drawing.Point(212, 723);
            this.btn_generateRandomCenters.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_generateRandomCenters.Name = "btn_generateRandomCenters";
            this.btn_generateRandomCenters.Size = new System.Drawing.Size(290, 58);
            this.btn_generateRandomCenters.TabIndex = 26;
            this.btn_generateRandomCenters.Text = "Сгенерувати центри";
            this.btn_generateRandomCenters.UseVisualStyleBackColor = false;
            this.btn_generateRandomCenters.Click += new System.EventHandler(this.btn_generateRandomCenters_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(432, 294);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 44);
            this.button1.TabIndex = 27;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // nud_numberOfCenters
            // 
            this.nud_numberOfCenters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nud_numberOfCenters.Location = new System.Drawing.Point(272, 12);
            this.nud_numberOfCenters.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nud_numberOfCenters.Name = "nud_numberOfCenters";
            this.nud_numberOfCenters.Size = new System.Drawing.Size(132, 35);
            this.nud_numberOfCenters.TabIndex = 15;
            // 
            // lbl_resFunc
            // 
            this.lbl_resFunc.AutoSize = true;
            this.lbl_resFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_resFunc.Location = new System.Drawing.Point(16, 248);
            this.lbl_resFunc.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_resFunc.Name = "lbl_resFunc";
            this.lbl_resFunc.Size = new System.Drawing.Size(281, 26);
            this.lbl_resFunc.TabIndex = 17;
            this.lbl_resFunc.Text = "Значення функціоналу: ";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage1.Controls.Add(this.ProductCount);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Size = new System.Drawing.Size(522, 915);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Багатопродуктова";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.button3.Location = new System.Drawing.Point(6, 842);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(208, 63);
            this.button3.TabIndex = 11;
            this.button3.Text = "РОЗВ\'ЯЗАТИ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(392, 792);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 31);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 798);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "х";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(220, 862);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(268, 29);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Відображати розбиття";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(224, 792);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 31);
            this.textBox2.TabIndex = 9;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(22, 67);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(480, 54);
            this.button2.TabIndex = 0;
            this.button2.Text = "Задати вхiднi параметри";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_gamma
            // 
            this.lbl_gamma.AutoSize = true;
            this.lbl_gamma.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbl_gamma.Location = new System.Drawing.Point(102, 131);
            this.lbl_gamma.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_gamma.Name = "lbl_gamma";
            this.lbl_gamma.Size = new System.Drawing.Size(29, 25);
            this.lbl_gamma.TabIndex = 14;
            this.lbl_gamma.Text = "γ:";
            // 
            // nud_gamma
            // 
            this.nud_gamma.DecimalPlaces = 1;
            this.nud_gamma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nud_gamma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_gamma.Location = new System.Drawing.Point(158, 125);
            this.nud_gamma.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nud_gamma.Name = "nud_gamma";
            this.nud_gamma.Size = new System.Drawing.Size(280, 35);
            this.nud_gamma.TabIndex = 14;
            // 
            // panel_line
            // 
            this.panel_line.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_line.Location = new System.Drawing.Point(24, 65);
            this.panel_line.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel_line.Name = "panel_line";
            this.panel_line.Size = new System.Drawing.Size(0, 921);
            this.panel_line.TabIndex = 16;
            // 
            // lbl_ro1
            // 
            this.lbl_ro1.AutoSize = true;
            this.lbl_ro1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbl_ro1.Location = new System.Drawing.Point(102, 185);
            this.lbl_ro1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_ro1.Name = "lbl_ro1";
            this.lbl_ro1.Size = new System.Drawing.Size(30, 25);
            this.lbl_ro1.TabIndex = 18;
            this.lbl_ro1.Text = "ρ:";
            // 
            // cb_ro1
            // 
            this.cb_ro1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_ro1.FormattingEnabled = true;
            this.cb_ro1.Location = new System.Drawing.Point(158, 177);
            this.cb_ro1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cb_ro1.Name = "cb_ro1";
            this.cb_ro1.Size = new System.Drawing.Size(276, 37);
            this.cb_ro1.TabIndex = 19;
            // 
            // lbl_c1
            // 
            this.lbl_c1.AutoSize = true;
            this.lbl_c1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbl_c1.Location = new System.Drawing.Point(102, 237);
            this.lbl_c1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_c1.Name = "lbl_c1";
            this.lbl_c1.Size = new System.Drawing.Size(33, 25);
            this.lbl_c1.TabIndex = 21;
            this.lbl_c1.Text = "C:";
            // 
            // cb_ro2
            // 
            this.cb_ro2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_ro2.FormattingEnabled = true;
            this.cb_ro2.Location = new System.Drawing.Point(158, 229);
            this.cb_ro2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cb_ro2.Name = "cb_ro2";
            this.cb_ro2.Size = new System.Drawing.Size(276, 37);
            this.cb_ro2.TabIndex = 23;
            this.cb_ro2.Visible = false;
            this.cb_ro2.SelectedIndexChanged += new System.EventHandler(this.cb_ro2_SelectedIndexChanged);
            // 
            // lbl_c2
            // 
            this.lbl_c2.AutoSize = true;
            this.lbl_c2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbl_c2.Location = new System.Drawing.Point(102, 356);
            this.lbl_c2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_c2.Name = "lbl_c2";
            this.lbl_c2.Size = new System.Drawing.Size(45, 25);
            this.lbl_c2.TabIndex = 25;
            this.lbl_c2.Text = "C2:";
            this.lbl_c2.Visible = false;
            // 
            // cb_c2
            // 
            this.cb_c2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_c2.FormattingEnabled = true;
            this.cb_c2.Location = new System.Drawing.Point(158, 350);
            this.cb_c2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cb_c2.Name = "cb_c2";
            this.cb_c2.Size = new System.Drawing.Size(276, 37);
            this.cb_c2.TabIndex = 24;
            this.cb_c2.Visible = false;
            // 
            // cb_c1
            // 
            this.cb_c1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_c1.FormattingEnabled = true;
            this.cb_c1.Location = new System.Drawing.Point(158, 229);
            this.cb_c1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cb_c1.Name = "cb_c1";
            this.cb_c1.Size = new System.Drawing.Size(276, 37);
            this.cb_c1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Кiлькiсть типiв продуктiв:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Центри:";
            // 
            // ProductCount
            // 
            this.ProductCount.Location = new System.Drawing.Point(289, 212);
            this.ProductCount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ProductCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ProductCount.Name = "ProductCount";
            this.ProductCount.Size = new System.Drawing.Size(120, 31);
            this.ProductCount.TabIndex = 15;
            this.ProductCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1630, 1031);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lbl_stepOfGrid);
            this.Controls.Add(this.cb_centers);
            this.Controls.Add(this.btn_clearDgv);
            this.Controls.Add(this.lbl_gamma);
            this.Controls.Add(this.lbl_c2);
            this.Controls.Add(this.cb_c2);
            this.Controls.Add(this.cb_ro2);
            this.Controls.Add(this.lbl_c1);
            this.Controls.Add(this.cb_c1);
            this.Controls.Add(this.cb_ro1);
            this.Controls.Add(this.lbl_ro1);
            this.Controls.Add(this.panel_line);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.nud_gamma);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.rtb_centers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оптимальне розбиття множин";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage_A1.ResumeLayout(false);
            this.tabPage_A1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_numberOfCenters)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_gamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lbl_numberOfCenters;
        private System.Windows.Forms.Label lbl_stepOfGrid;
        private System.Windows.Forms.TextBox txtb_stepOfGridX;
        private System.Windows.Forms.TextBox txtb_stepOfGridY;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.CheckBox cb_draw;
        private System.Windows.Forms.Label lbl_x;
        private System.Windows.Forms.RichTextBox rtb_centers;
        private System.Windows.Forms.CheckBox cb_centers;
        private System.Windows.Forms.Button btn_clearDgv;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_A1;
        private System.Windows.Forms.NumericUpDown nud_gamma;
        private System.Windows.Forms.Label lbl_gamma;
        private System.Windows.Forms.NumericUpDown nud_numberOfCenters;
        private System.Windows.Forms.Panel panel_line;
        private System.Windows.Forms.Label lbl_resFunc;
        private System.Windows.Forms.Label lbl_ro1;
        private System.Windows.Forms.ComboBox cb_ro1;
        private System.Windows.Forms.Label lbl_c1;
        private System.Windows.Forms.ComboBox cb_ro2;
        private System.Windows.Forms.Label lbl_c2;
        private System.Windows.Forms.ComboBox cb_c2;
        private System.Windows.Forms.Button btn_generateRandomCenters;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox cb_c1;
        private System.Windows.Forms.NumericUpDown ProductCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

