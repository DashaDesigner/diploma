using System;
using System.Drawing;
using System.Windows.Forms;

namespace OptimalPartitioning
{
    class DrawingTools
    {
        Graphics graphics; // создаем компонент, с помощью которого будем рисовать
        public Bitmap bmp;
        Brush[] brushes;
        float koef = 500.0f;

        void InitializeGraphics(PictureBox pb)
        {
            bmp = new Bitmap(pb.Width, pb.Height); // создаем рисунок
            graphics = Graphics.FromImage(bmp); // инициализируем компонент
        }

        public void DrawPartitioning(PictureBox pb, int numberOfCenters, int M, int M1, int[,] lambda, MyPoint[] centers)
        {
            InitializeGraphics(pb);
            CreateBrushes(numberOfCenters);

            int uu = 0;
            for (int k = 0; k < numberOfCenters; k++)
            {
                for (float i = 0f; i < koef; i += koef / M)
                {
                    if ((i + koef / M) > koef) break;
                    for (float j = 0f; j < koef; j += koef / M1)
                    {
                        if ((j + koef / M1) > koef) break;
                        if (lambda[k, uu] == 1)
                            graphics.FillRectangle(/*ChooseBrush(k)*/brushes[k], i, j, koef / M, koef / M1);
                        uu++;
                    }
                }
                uu = 0;
            }

            for (int i = 0; i < numberOfCenters; i++)
                graphics.FillEllipse(Brushes.Black, koef * (float)centers[i].X, koef * (float)centers[i].Y, 8F, 8F);

            pb.Image = bmp;
            graphics.Dispose();
        }

        void CreateBrushes(int numberOfCenters)
        {
            Random r = new Random();
            brushes = new Brush[numberOfCenters];
            for (int i = 0; i < numberOfCenters; i++)
            {
                SolidBrush br = new SolidBrush(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255), r.Next(255)));
                brushes[i] = br;
            }
        }

        Brush ChooseBrush(int minIndex_)
        {
            //Random r = new Random();
            //SolidBrush br = new SolidBrush(Color.FromArgb(r.Next(255),r.Next(255),r.Next(255),r.Next(255)));
            //return br;
            switch (minIndex_)
            {
                case 0: return Brushes.Yellow;
                case 1: return Brushes.Green;
                case 2: return Brushes.DeepSkyBlue;
                case 3: return Brushes.Tomato;
                case 4: return Brushes.MediumPurple;
                case 5: return Brushes.Orange;
                case 6: return Brushes.LightGray;
                case 7: return Brushes.BurlyWood;
                default:
                    {
                        System.Windows.Forms.MessageBox.Show("Need more colors");
                        return null;
                    }
            }
        }
    }
}
