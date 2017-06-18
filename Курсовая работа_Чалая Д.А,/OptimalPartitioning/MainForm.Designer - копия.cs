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
            this.txtb_numberOfCenters = new System.Windows.Forms.TextBox();
            this.lbl_numberOfCenters = new System.Windows.Forms.Label();
            this.lbl_stepOfGrid = new System.Windows.Forms.Label();
            this.txtb_stepOfGridX = new System.Windows.Forms.TextBox();
            this.txtb_stepOfGridY = new System.Windows.Forms.TextBox();
            this.cb_draw = new System.Windows.Forms.CheckBox();
            this.lbl_x = new System.Windows.Forms.Label();
            this.gb_centers = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_clearDgv = new System.Windows.Forms.Button();
            this.rtb_centers = new System.Windows.Forms.RichTextBox();
            this.gb_steps = new System.Windows.Forms.GroupBox();
            this.cb_centers = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.gb_centers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gb_steps.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(534, 465);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "Разбить";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(500, 500);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // txtb_numberOfCenters
            // 
            this.txtb_numberOfCenters.Location = new System.Drawing.Point(130, 27);
            this.txtb_numberOfCenters.Name = "txtb_numberOfCenters";
            this.txtb_numberOfCenters.Size = new System.Drawing.Size(43, 20);
            this.txtb_numberOfCenters.TabIndex = 0;
            this.txtb_numberOfCenters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_numberOfCenters
            // 
            this.lbl_numberOfCenters.AutoSize = true;
            this.lbl_numberOfCenters.Location = new System.Drawing.Point(15, 30);
            this.lbl_numberOfCenters.Name = "lbl_numberOfCenters";
            this.lbl_numberOfCenters.Size = new System.Drawing.Size(113, 13);
            this.lbl_numberOfCenters.TabIndex = 0;
            this.lbl_numberOfCenters.Text = "Количество центров:";
            // 
            // lbl_stepOfGrid
            // 
            this.lbl_stepOfGrid.AutoSize = true;
            this.lbl_stepOfGrid.Location = new System.Drawing.Point(15, 28);
            this.lbl_stepOfGrid.Name = "lbl_stepOfGrid";
            this.lbl_stepOfGrid.Size = new System.Drawing.Size(81, 13);
            this.lbl_stepOfGrid.TabIndex = 4;
            this.lbl_stepOfGrid.Text = "Размер сетки:";
            // 
            // txtb_stepOfGridX
            // 
            this.txtb_stepOfGridX.Location = new System.Drawing.Point(101, 25);
            this.txtb_stepOfGridX.Name = "txtb_stepOfGridX";
            this.txtb_stepOfGridX.Size = new System.Drawing.Size(52, 20);
            this.txtb_stepOfGridX.TabIndex = 1;
            this.txtb_stepOfGridX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtb_stepOfGridY
            // 
            this.txtb_stepOfGridY.Location = new System.Drawing.Point(177, 25);
            this.txtb_stepOfGridY.Name = "txtb_stepOfGridY";
            this.txtb_stepOfGridY.Size = new System.Drawing.Size(52, 20);
            this.txtb_stepOfGridY.TabIndex = 2;
            this.txtb_stepOfGridY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_draw
            // 
            this.cb_draw.AutoSize = true;
            this.cb_draw.Location = new System.Drawing.Point(531, 372);
            this.cb_draw.Name = "cb_draw";
            this.cb_draw.Size = new System.Drawing.Size(74, 17);
            this.cb_draw.TabIndex = 7;
            this.cb_draw.Text = "Рисовать";
            this.cb_draw.UseVisualStyleBackColor = true;
            // 
            // lbl_x
            // 
            this.lbl_x.AutoSize = true;
            this.lbl_x.Location = new System.Drawing.Point(159, 28);
            this.lbl_x.Name = "lbl_x";
            this.lbl_x.Size = new System.Drawing.Size(12, 13);
            this.lbl_x.TabIndex = 8;
            this.lbl_x.Text = "х";
            // 
            // gb_centers
            // 
            this.gb_centers.Controls.Add(this.dgv);
            this.gb_centers.Controls.Add(this.btn_clearDgv);
            this.gb_centers.Controls.Add(this.rtb_centers);
            this.gb_centers.Controls.Add(this.txtb_numberOfCenters);
            this.gb_centers.Controls.Add(this.lbl_numberOfCenters);
            this.gb_centers.Location = new System.Drawing.Point(516, 12);
            this.gb_centers.Name = "gb_centers";
            this.gb_centers.Size = new System.Drawing.Size(244, 354);
            this.gb_centers.TabIndex = 9;
            this.gb_centers.TabStop = false;
            this.gb_centers.Text = "Центры";
            // 
            // dgv
            // 
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgv.GridColor = System.Drawing.SystemColors.Control;
            this.dgv.Location = new System.Drawing.Point(18, 27);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(214, 292);
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
            this.btn_clearDgv.Location = new System.Drawing.Point(157, 325);
            this.btn_clearDgv.Name = "btn_clearDgv";
            this.btn_clearDgv.Size = new System.Drawing.Size(75, 23);
            this.btn_clearDgv.TabIndex = 12;
            this.btn_clearDgv.Text = "Очистить";
            this.btn_clearDgv.UseVisualStyleBackColor = true;
            this.btn_clearDgv.Click += new System.EventHandler(this.btn_clearDgv_Click);
            // 
            // rtb_centers
            // 
            this.rtb_centers.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_centers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_centers.Location = new System.Drawing.Point(18, 56);
            this.rtb_centers.Name = "rtb_centers";
            this.rtb_centers.Size = new System.Drawing.Size(206, 281);
            this.rtb_centers.TabIndex = 1;
            this.rtb_centers.Text = "";
            // 
            // gb_steps
            // 
            this.gb_steps.Controls.Add(this.lbl_stepOfGrid);
            this.gb_steps.Controls.Add(this.txtb_stepOfGridX);
            this.gb_steps.Controls.Add(this.lbl_x);
            this.gb_steps.Controls.Add(this.txtb_stepOfGridY);
            this.gb_steps.Location = new System.Drawing.Point(516, 395);
            this.gb_steps.Name = "gb_steps";
            this.gb_steps.Size = new System.Drawing.Size(244, 64);
            this.gb_steps.TabIndex = 10;
            this.gb_steps.TabStop = false;
            this.gb_steps.Text = "Сетка";
            // 
            // cb_centers
            // 
            this.cb_centers.AutoSize = true;
            this.cb_centers.Location = new System.Drawing.Point(646, 372);
            this.cb_centers.Name = "cb_centers";
            this.cb_centers.Size = new System.Drawing.Size(94, 17);
            this.cb_centers.TabIndex = 12;
            this.cb_centers.Text = "Ввести лично";
            this.cb_centers.UseVisualStyleBackColor = true;
            this.cb_centers.CheckedChanged += new System.EventHandler(this.cb_centers_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 500);
            this.Controls.Add(this.cb_centers);
            this.Controls.Add(this.gb_steps);
            this.Controls.Add(this.gb_centers);
            this.Controls.Add(this.cb_draw);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btn_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Optimal Partitioning";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.gb_centers.ResumeLayout(false);
            this.gb_centers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.gb_steps.ResumeLayout(false);
            this.gb_steps.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox txtb_numberOfCenters;
        private System.Windows.Forms.Label lbl_numberOfCenters;
        private System.Windows.Forms.Label lbl_stepOfGrid;
        private System.Windows.Forms.TextBox txtb_stepOfGridX;
        private System.Windows.Forms.TextBox txtb_stepOfGridY;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.CheckBox cb_draw;
        private System.Windows.Forms.Label lbl_x;
        private System.Windows.Forms.GroupBox gb_centers;
        private System.Windows.Forms.GroupBox gb_steps;
        private System.Windows.Forms.RichTextBox rtb_centers;
        private System.Windows.Forms.CheckBox cb_centers;
        private System.Windows.Forms.Button btn_clearDgv;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

