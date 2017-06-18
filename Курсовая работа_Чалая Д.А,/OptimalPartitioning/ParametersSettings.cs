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
    public partial class ParametersSettings : Form
    {
        private int centers;
        private int products;

        private Size box_size = new Size(150, 20);
        private Size box_margin_size = new Size(30, 30);
        private Size box_area_size = new Size(150 + 30, 20 + 30);

        private Control get_box() {
            Panel res = new Panel();
            res.Size = box_size;

            return res;
        }

        private Control set_box_pos(Control box, int i, int j) {
            box.Location = new Point((int)(box_margin_size.Width * (j + 0.5) + box_size.Width * j), (int)(box_margin_size.Height * (i + 0.5) + box_size.Height * i));
            return box;
        }

        private Control get_box_with_pos(int i, int j) {
            return set_box_pos(get_box(), i, j);
        }

        private Functions funcs = new Functions();

        private Control createRo(int j) {
            var res = get_box_with_pos(0, j);
            {
                Label lbl = new Label();
                lbl.Text = "ρ" + (j + 1).ToString() + ":";

                ComboBox cb = new ComboBox();
                foreach (var item in funcs.roFuncs) { cb.Items.Add(item.Key); }
                cb.SelectedIndex = 0;
                cb.Location = new Point(20, 0);
                //cb.Size = new Size(100, 20);
            res.Controls.Add(cb);
            res.Controls.Add(lbl);
            }
            return res;
        }

        private Control createC(int i) {
            var res = get_box_with_pos(i, 0);
            {
                Label lbl = new Label();
                lbl.Text = "C" + (i + 1).ToString() + ":";

                ComboBox cb = new ComboBox();
                foreach (var item in funcs.cFuncs) { cb.Items.Add(item.Key); }
                cb.SelectedIndex = 3;
                cb.Location = new Point(20, 0);
                //cb.Size = new Size(100, 20);
            res.Controls.Add(cb);
            res.Controls.Add(lbl);
            }
            return res;
        }

        private Control createB(int i) {
            var res = get_box_with_pos(i, 0);
            {
                var cb = new ComboBox();
                cb.FormattingEnabled = true;
                cb.Items.AddRange(new object[] { "=", "<=" });
                cb.Location = new Point(0, 0);
                cb.Size = new System.Drawing.Size(38, 21);
                cb.SelectedIndex = 0;
                cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

                Label lbl = new Label();
                lbl.Text = "b" + (i + 1).ToString() + ":";
                lbl.Location = new Point(45, 0);

                var nud = new NumericUpDown();
                nud.Location = new System.Drawing.Point(65, 0);
                nud.Size = new System.Drawing.Size(65, 20);
                nud.Maximum = 10000000;
                nud.Minimum = 0;
                nud.DecimalPlaces = 1;
                nud.Increment = Convert.ToDecimal(0.1);

            res.Controls.Add(cb);
            res.Controls.Add(nud);
            res.Controls.Add(lbl);
            }
            return res;
        }

        private Control createD(int i, int j) {
            var res = get_box_with_pos(i, j);
            {
                Label lbl = new Label();
                lbl.Text = "b" + (i + 1).ToString() + "," + (j + 1).ToString() + ":";

                var nud = new NumericUpDown();
                nud.Location = new System.Drawing.Point(45, 0);
                nud.Size = new System.Drawing.Size(65, 20);
                nud.Maximum = 10000000;
                nud.Minimum = 0;
                nud.DecimalPlaces = 1;
                nud.Increment = Convert.ToDecimal(0.1);
            
            res.Controls.Add(nud);
            res.Controls.Add(lbl);
            }
            return res;
        }

        private Control[] Ro = new Control[0], C = new Control[0], B = new Control[0];
        private Control[,] D = new Control[0, 0];

        private void update() {
            {
                int old_Ro_size = Ro.Length;
                int old_C_size = C.Length;
                int old_B_size = B.Length;
            
                System.Array.Resize(ref Ro, ProductsCount);
                System.Array.Resize(ref C, CentersCount);
                System.Array.Resize(ref B, CentersCount);

                for (int i = old_Ro_size; i < Ro.Length; i++) {
                    Ro[i] = createRo(i);
                }
                for (int i = old_C_size; i < C.Length; i++) {
                    C[i] = createC(i);
                }
                for (int i = old_B_size; i < B.Length; i++) {
                    B[i] = createB(i);
                }
            }
            
            {
                int old_D_width = D.GetLength(1);
                int old_D_height = D.GetLength(0);
                Control[,] new_D = new Control[CentersCount, ProductsCount];
                for (int i = 0; i < CentersCount; i++) {
                    for (int j = 0; j < ProductsCount; j++) {
                        if (i < old_D_height && j < old_D_width) {
                            new_D[i, j] = D[i, j];
                        } else {
                            new_D[i, j] = createD(i, j);
                        }
                    }
                }

                D = new_D;
            }

            RoParent.Controls.Clear();
            RoParent.Size = new Size(box_area_size.Width * ProductsCount, box_area_size.Height);
            CParent.Controls.Clear();
            CParent.Size = new Size(box_area_size.Width, box_area_size.Height * CentersCount);
            BParent.Controls.Clear();
            BParent.Size = new Size(box_area_size.Width, box_area_size.Height * CentersCount);
            DParent.Controls.Clear();
            DParent.Size = new Size(box_area_size.Width * ProductsCount, box_area_size.Height * CentersCount);

            for (int i = 0; i < Ro.Length; i++) {
                RoParent.Controls.Add(Ro[i]);
            }
            for (int i = 0; i < C.Length; i++) {
                CParent.Controls.Add(C[i]);
            }
            for (int i = 0; i < B.Length; i++) {
                BParent.Controls.Add(B[i]);
            }

            for (int i = 0; i < D.GetLength(0); i++) {
                for (int j = 0; j < D.GetLength(1); j++) {
                    DParent.Controls.Add(D[i, j]);
                }
            }
        }

        public int CentersCount {
            get { return centers; }
            set {
                if (value == centers) return;
                centers = value;
                update();
            }
        }

        public int ProductsCount {
            get { return products; }
            set {
                if (value == products) return;
                products = value;
                update();
            }
        }

        public ParametersSettings()
        {
            InitializeComponent();
        }
    }
}
