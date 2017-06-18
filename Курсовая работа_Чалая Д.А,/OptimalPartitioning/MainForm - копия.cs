using System;
using System.Windows.Forms;

namespace OptimalPartitioning
{
    public partial class MainForm : Form
    {
        Algorithm alg;
        DrawingTools dt;

        public MainForm()
        {
            InitializeComponent();
            txtb_numberOfCenters.Text = "4";
            txtb_stepOfGridX.Text = "100";
            txtb_stepOfGridY.Text = "100";
            cb_draw.Checked = true;
            cb_centers.Checked = false;
            dgv.Visible = false;
            btn_clearDgv.Visible = false;
            rtb_centers.Enabled = false;

            cb_centers.Checked = true;
            dgv.Rows.Add(4);
            dgv.Rows[0].Cells[0].Value = 0.33;
            dgv.Rows[0].Cells[1].Value = 0.25;
            dgv.Rows[1].Cells[0].Value = 0.33;
            dgv.Rows[1].Cells[1].Value = 0.5;
            dgv.Rows[2].Cells[0].Value = 0.33;
            dgv.Rows[2].Cells[1].Value = 0.75;
            dgv.Rows[3].Cells[0].Value = 0.66;
            dgv.Rows[3].Cells[1].Value = 0.25;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            alg = new Algorithm();
            alg.M = Convert.ToInt32(txtb_stepOfGridX.Text);
            alg.M1 = Convert.ToInt32(txtb_stepOfGridY.Text);
            alg.numberOfCenters = cb_centers.Checked ? dgv.RowCount - 1 : Convert.ToInt32(txtb_numberOfCenters.Text);
            alg.centers = new MyPoint[alg.numberOfCenters];
            rtb_centers.Text = null;

            if (!cb_centers.Checked)
            {
                Random r = new Random();
                for (int i = 0; i < alg.numberOfCenters; i++)
                {
                    alg.centers[i].X = (float)r.NextDouble();
                    alg.centers[i].Y = (float)r.NextDouble();
                    rtb_centers.Text += String.Format("({0:0.00}; {1:0.00})\n", alg.centers[i].X, alg.centers[i].Y);
                }
            }
            else
            {
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    alg.centers[i].X = float.Parse(dgv.Rows[i].Cells[0].Value.ToString());
                    alg.centers[i].Y = float.Parse(dgv.Rows[i].Cells[1].Value.ToString());
                }
            }

            //rtb_centers.Text += String.Format("\nA1: {0}\nTask_A2: {1}", alg.A1(), alg.Task_A2());
            rtb_centers.Text += String.Format("\nA1: {0}", alg.A1());
            rtb_centers.Text += String.Format("\nA1i: {0}", alg.A1i());
            rtb_centers.Text += String.Format("\nA2i: {0}", alg.A2i());
            if (cb_draw.Checked)
            {
                dt = new DrawingTools();
                dt.DrawPartitioning(pictureBox, alg.numberOfCenters, alg.M, alg.M1, alg.lambda, alg.centers);
            }

            rtb_centers.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dt.bmp != null) 
                dt.bmp.Dispose();
            pictureBox.Dispose();            
        }

        private void cb_centers_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_centers.Checked == true)
            {
                dgv.Visible = true;
                btn_clearDgv.Visible = true;
                rtb_centers.Visible = false;
            }
            else
            {
                dgv.Visible = false;
                btn_clearDgv.Visible = false;
                rtb_centers.Visible = true;
            }
        }

        private void btn_clearDgv_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
        }
    }
}