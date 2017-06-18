namespace OptimalPartitioning
{
    partial class ParametersSettings
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
            this.RoParent = new System.Windows.Forms.Panel();
            this.DParent = new System.Windows.Forms.Panel();
            this.CParent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BParent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // RoParent
            // 
            this.RoParent.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.RoParent.Location = new System.Drawing.Point(931, 41);
            this.RoParent.Name = "RoParent";
            this.RoParent.Size = new System.Drawing.Size(931, 70);
            this.RoParent.TabIndex = 0;
            // 
            // DParent
            // 
            this.DParent.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DParent.Location = new System.Drawing.Point(931, 175);
            this.DParent.Name = "DParent";
            this.DParent.Size = new System.Drawing.Size(931, 420);
            this.DParent.TabIndex = 1;
            // 
            // CParent
            // 
            this.CParent.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CParent.Location = new System.Drawing.Point(23, 175);
            this.CParent.Name = "CParent";
            this.CParent.Size = new System.Drawing.Size(300, 420);
            this.CParent.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(926, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Метрики:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(926, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Додатковi обмежання на потужнiсть:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Щiльностi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Умови у виглядi рiвн. i нерiвн.:";
            // 
            // BParent
            // 
            this.BParent.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BParent.Location = new System.Drawing.Point(472, 175);
            this.BParent.Name = "BParent";
            this.BParent.Size = new System.Drawing.Size(300, 420);
            this.BParent.TabIndex = 5;
            // 
            // ParametersSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1874, 1029);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BParent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CParent);
            this.Controls.Add(this.DParent);
            this.Controls.Add(this.RoParent);
            this.Name = "ParametersSettings";
            this.Text = "ParametersSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel RoParent;
        private System.Windows.Forms.Panel DParent;
        private System.Windows.Forms.Panel CParent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel BParent;
    }
}