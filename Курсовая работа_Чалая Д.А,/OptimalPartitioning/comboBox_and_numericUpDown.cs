using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OptimalPartitioning
{
    public class comboBox_and_numericUpDown
    {
        public ComboBox cb;
        public NumericUpDown nud;
        public comboBox_and_numericUpDown()
        {
            cb = new ComboBox();
            nud = new NumericUpDown();
            this.cb.FormattingEnabled = true;
            this.cb.Items.AddRange(new object[] { "=", "<=" });
            //this.comboBox1.Location = new System.Drawing.Point(25, 33);
            this.cb.Size = new System.Drawing.Size(38, 21);

            //this.nud.Location = new System.Drawing.Point(84, 34);
            this.nud.Size = new System.Drawing.Size(116, 20);

            cb.SelectedIndex = 0;
            cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            nud.Maximum = 10000000;
            nud.Minimum = -10000000;
            nud.DecimalPlaces = 9;
        }
    }
}
