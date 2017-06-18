using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OptimalPartitioning
{
    public partial class Ogranicheniya : Form
    {
        private List<comboBox_and_numericUpDown> list;
        private int last_h;
        private int shift_for_comboBox = 25, shift_for_numericUpDown = 84, space, delta_size;

        public List<comboBox_and_numericUpDown> List{
            get { return list; }
            set {
                if (value != this.list) {
                    if (list != null){
                        while (list.Count != 0) pop_comboBox_and_numericUpDown();
                    }
                    list = value;
                    if (list != null) {
                        foreach (var obj in list) {
                            add_comboBox_and_numericUpDown_to_form(obj);
                        }
                        numericUpDown1.Value = list.Count;
                    } else numericUpDown1.Value = 0;
                }
            }
        }

        public Ogranicheniya()
        {
            InitializeComponent();
            space = numericUpDown1.Location.Y;
            delta_size = space + numericUpDown1.Size.Height;
            last_h = delta_size + space;
        }

        private void add_comboBox_and_numericUpDown_to_form(comboBox_and_numericUpDown cb_and_nud)
        {
            cb_and_nud.cb.Location = new Point(shift_for_comboBox, last_h);
            cb_and_nud.nud.Location = new Point(shift_for_numericUpDown, last_h);
            last_h += delta_size;
            this.Size = new Size(this.Size.Width, this.Size.Height + delta_size);
            this.Controls.Add(cb_and_nud.cb);
            this.Controls.Add(cb_and_nud.nud);
        }

        public void push_comboBox_and_numericUpDown(comboBox_and_numericUpDown cb_and_nud) {
            if (list != null) {
                list.Add(cb_and_nud);
                add_comboBox_and_numericUpDown_to_form(cb_and_nud);
            }
        }

        private void del_comboBox_and_numericUpDown_from_form(comboBox_and_numericUpDown cb_and_nud)
        {
            last_h -= delta_size;
            this.Size = new Size(this.Size.Width, this.Size.Height - delta_size);
            this.Controls.Remove(cb_and_nud.cb);
            this.Controls.Remove(cb_and_nud.nud);
        }

        public void pop_comboBox_and_numericUpDown()
        {
            if (list != null && List.Count != 0){
                var cb_and_nud = List[List.Count - 1];
                del_comboBox_and_numericUpDown_from_form(cb_and_nud);
                list.Remove(cb_and_nud);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (list != null){
                while (list.Count != numericUpDown1.Value){
                    if (list.Count < numericUpDown1.Value)
                    {
                        comboBox_and_numericUpDown cb_and_nud = new comboBox_and_numericUpDown();
                        push_comboBox_and_numericUpDown(cb_and_nud);
                    }
                    else pop_comboBox_and_numericUpDown();
                }
            }
        }


    }
}
