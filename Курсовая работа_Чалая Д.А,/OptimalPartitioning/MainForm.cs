using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace OptimalPartitioning
{
    public partial class MainForm : Form
    {
        Algorithm alg;
        Functions funcs;
        DrawingTools dt;
        MyPoint[] centers;
        List<comboBox_and_numericUpDown> list;

        public MainForm()
        {
            InitializeComponent();
            list = new List<comboBox_and_numericUpDown>();
            nud_numberOfCenters.Value = 4;
            nud_gamma.Value = 0.3m;
            txtb_stepOfGridX.Text = "500";
            txtb_stepOfGridY.Text = "500";
            cb_draw.Checked = true;
            cb_centers.Checked = false;
            dgv.Visible = false;
            btn_clearDgv.Visible = false;
            rtb_centers.Enabled = false;
            btn_generateRandomCenters.Visible = false;

            lbl_gamma.Visible = false;
            nud_gamma.Visible = false;

            button1.Visible = false;

            cb_centers.Checked = true;
            dgv.Rows.Add(4);

            //dgv.Rows[0].Cells[0].Value = 0.33;
            //dgv.Rows[0].Cells[1].Value = 0.25;
            //dgv.Rows[1].Cells[0].Value = 0.33;
            //dgv.Rows[1].Cells[1].Value = 0.5;
            //dgv.Rows[2].Cells[0].Value = 0.33;
            //dgv.Rows[2].Cells[1].Value = 0.75;
            //dgv.Rows[3].Cells[0].Value = 0.66;
            //dgv.Rows[3].Cells[1].Value = 0.25;

            //dgv.Rows[0].Cells[0].Value = 0.25;
            //dgv.Rows[0].Cells[1].Value = 0.25;
            //dgv.Rows[1].Cells[0].Value = 0.75;
            //dgv.Rows[1].Cells[1].Value = 0.75;
            //dgv.Rows[2].Cells[0].Value = 0.75;
            //dgv.Rows[2].Cells[1].Value = 0.75;
            //dgv.Rows[3].Cells[0].Value = 0.25;
            //dgv.Rows[3].Cells[1].Value = 0.75;

            dgv.Rows[0].Cells[0].Value = 0.1;
            dgv.Rows[0].Cells[1].Value = 0.1;
            dgv.Rows[1].Cells[0].Value = 0.1;
            dgv.Rows[1].Cells[1].Value = 0.9;
            dgv.Rows[2].Cells[0].Value = 0.9;
            dgv.Rows[2].Cells[1].Value = 0.9;
            dgv.Rows[3].Cells[0].Value = 0.9;
            dgv.Rows[3].Cells[1].Value = 0.1;

            //dgv.Rows[0].Cells[0].Value = 0.1;
            //dgv.Rows[0].Cells[1].Value = 0.9;
            //dgv.Rows[1].Cells[0].Value = 0.5;
            //dgv.Rows[1].Cells[1].Value = 0.3;
            //dgv.Rows[2].Cells[0].Value = 0.7;
            //dgv.Rows[2].Cells[1].Value = 0.2;

            //dgv.Rows[0].Cells[0].Value = 0.1;
            //dgv.Rows[0].Cells[1].Value = 0.1;
            //dgv.Rows[1].Cells[0].Value = 0.15;
            //dgv.Rows[1].Cells[1].Value = 0.15;
            //dgv.Rows[2].Cells[0].Value = 0.2;
            //dgv.Rows[2].Cells[1].Value = 0.2;
            //dgv.Rows[3].Cells[0].Value = 0.25;
            //dgv.Rows[3].Cells[1].Value = 0.25;
            //dgv.Rows[4].Cells[0].Value = 0.3;
            //dgv.Rows[4].Cells[1].Value = 0.3;

            funcs = new Functions();
            foreach (KeyValuePair<string, Func<double, double, double>> item in funcs.roFuncs)
            {
                cb_ro1.Items.Add(item.Key);
                cb_ro2.Items.Add(item.Key);
            }
            cb_ro1.SelectedIndex = 0;
            cb_ro2.SelectedIndex = 0;
            foreach (KeyValuePair<string, Func<double, double, double, double, double>> item in funcs.cFuncs)
            {
                cb_c1.Items.Add(item.Key);
                cb_c2.Items.Add(item.Key);
            }
            cb_c1.SelectedIndex = 3;
            cb_c2.SelectedIndex = 3;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            lbl_resFunc.Text = "Значение функционала: ";

            alg = new Algorithm(Convert.ToInt32(txtb_stepOfGridX.Text),
                                Convert.ToInt32(txtb_stepOfGridY.Text),
                                cb_centers.Checked ? dgv.RowCount - 1 : centers.Length,
                                (double)nud_gamma.Value,
                                (string)cb_c1.SelectedItem,
                                (string)cb_c2.SelectedItem,
                                (string)cb_ro1.SelectedItem,
                                (string)cb_ro2.SelectedItem,
                                funcs);
            if (centers != null)
            {
                alg.centers = centers;
            }
            else
            {
                alg.centers = new MyPoint[alg.numberOfCenters];
            }

            if (cb_centers.Checked)
            {
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    alg.centers[i].X = float.Parse(dgv.Rows[i].Cells[0].Value.ToString());
                    alg.centers[i].Y = float.Parse(dgv.Rows[i].Cells[1].Value.ToString());
                }
            }

            //rtb_centers.Text += String.Format("\nA1:  {0}", alg.A1());
            //rtb_centers.Text += String.Format("\nA1i: {0}", alg.A1i());
            if(tabControl.SelectedIndex == 0) lbl_resFunc.Text += alg.A2i().ToString();
            else lbl_resFunc.Text += alg.A5().ToString();

            if (cb_draw.Checked)
            {
                dt = new DrawingTools();
                dt.DrawPartitioning(pictureBox, alg.numberOfCenters, alg.M, alg.M1, alg.lambda, alg.centers);
            }

            rtb_centers.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dt != null && dt.bmp != null)
                dt.bmp.Dispose();
            pictureBox.Dispose();
        }

        private void cb_centers_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_centers.Checked)
            {
                dgv.Visible = true;
                btn_clearDgv.Visible = true;
                rtb_centers.Visible = false;
                btn_generateRandomCenters.Visible = false;
                lbl_numberOfCenters.Visible = false;
                nud_numberOfCenters.Visible = false;
            }
            else
            {
                dgv.Visible = false;
                btn_clearDgv.Visible = false;
                rtb_centers.Visible = true;
                btn_generateRandomCenters.Visible = true;
                lbl_numberOfCenters.Visible = true;
                nud_numberOfCenters.Visible = true;
            }
        }

        private void btn_clearDgv_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
        }

        private void btn_generateRandomCenters_Click(object sender, EventArgs e)
        {
            rtb_centers.Text = null;
            rtb_centers.BringToFront();
            centers = new MyPoint[(int)nud_numberOfCenters.Value];
            Random r = new Random();
            for (int i = 0; i < (int)nud_numberOfCenters.Value; i++)
            {
                centers[i].X = Math.Round(r.NextDouble(), 2);
                centers[i].Y = Math.Round(r.NextDouble(), 2);
                rtb_centers.Text += String.Format("({0:0.00}; {1:0.00})\n", centers[i].X, centers[i].Y);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                lbl_gamma.Visible = false;
                nud_gamma.Visible = false;
                
                //cb_ro2.Visible = true;
                lbl_c2.Visible = true;
                //cb_c2.Visible = true;

                cb_ro1.Visible = true;
                //cb_ro2.Visible = true;
                cb_c1.Visible = true;
                lbl_c1.Visible = true;
                lbl_ro1.Visible = true;
            } else {
              
                cb_ro2.Visible = false;
                lbl_c2.Visible = false;
                cb_c2.Visible = false;
                //lbl_gamma.Visible = true;
                //nud_gamma.Visible = true;

                lbl_gamma.Visible = false;
                nud_gamma.Visible = false;

                cb_ro1.Visible = false;
                cb_ro2.Visible = false;
                cb_c1.Visible = false;
                lbl_c1.Visible = false;
                lbl_ro1.Visible = false;
            }
        }

        ParametersSettings paramsSettings;

        private void button2_Click(object sender, EventArgs e)
        {
            if (paramsSettings == null) paramsSettings = new ParametersSettings();
            paramsSettings.CentersCount = dgv.RowCount - 1;
            paramsSettings.ProductsCount = Convert.ToInt32(ProductCount.Value);
            paramsSettings.ShowDialog();

            //Ogranicheniya form = new Ogranicheniya();
            //form.List = list;
            //form.ShowDialog();
        }

        private void cb_ro2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            btn_start_Click(sender, e);
        }
    }
}