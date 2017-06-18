using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace OptimalPartitioning
{
    struct MyPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    class Algorithm
    {
        public int numberOfCenters;
        public MyPoint[] centers;
        public double[] f;
        public int M, M1;
        int minIndex;
        public int[,] lambda;
        double ro = 1;
        public double gamma = 0;
        double ai = 0;

        public Algorithm(int M, int M1, int numberOfCenters, double gamma, string cfunc1, string cfunc2, string rofunc1, string rofunc2, Functions funcs)
        {
            this.M = M;
            this.M1 = M1;
            this.numberOfCenters = numberOfCenters;
            this.gamma = gamma;
            C1 = new CFunc(funcs.cFuncs[cfunc1]);
            C2 = new CFunc(funcs.cFuncs[cfunc2]);
            Ro1 = new RoFunc(funcs.roFuncs[rofunc1]);
            Ro2 = new RoFunc(funcs.roFuncs[rofunc2]);
        }

        delegate double CFunc(double x, double y, double i, double j);
        delegate double RoFunc(double x, double y);
        CFunc C1;
        CFunc C2;
        RoFunc Ro1;
        RoFunc Ro2;

        double C(double x, double y, double i, double j)
        {
            return Math.Sqrt((x - i) * (x - i) + (y - j) * (y - j));
        }

        int FindMin()
        {
            return f.ToList().LastIndexOf(f.Min());
        }

        public double A1()
        {
            lambda = new int[numberOfCenters, M * M1];
            f = new double[numberOfCenters];
            int u = 0;
            double Hx = (1.0 / (double)(M - 1));
            double Hy = (1.0 / (double)(M1 - 1));
            double h1h2 = Hx * Hy;
            double ResFunctional = 0;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M1; j++)
                {
                    double x = i * Hx;
                    double y = j * Hy;
                    double trapKoef = 1;
                    if ((i == 0) || (i == M - 1))
                        trapKoef *= 0.5;
                    if ((j == 0) || (j == M1 - 1))
                        trapKoef *= 0.5;

                    for (int k = 0; k < numberOfCenters; k++)
                        f[k] = C(x, y, centers[k].X, centers[k].Y) + ai;//) * (Math.Exp(2 * (centers[k].X+ centers[k].Y) * (centers[k].X+ centers[k].Y)));
                    minIndex = FindMin();
                    ResFunctional += trapKoef * ro * h1h2 * f.Min();

                    for (int m = 0; m < numberOfCenters; m++)
                        lambda[m, u] = m == minIndex ? 1 : 0;
                    u++;
                }
            }
            return ResFunctional;
        }

        public double A1i()
        {
            lambda = new int[numberOfCenters, M * M1];
            f = new double[numberOfCenters];
            int u = 0;
            double Hx = (1.0 / (double)(M - 1));
            double Hy = (1.0 / (double)(M1 - 1));
            double h1h2 = Hx * Hy;
            double ResFunctional = 0;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M1; j++)
                {
                    double x = i * Hx;
                    double y = j * Hy;
                    double trapKoef = 1;
                    if ((i == 0) || (i == M - 1))
                        trapKoef *= 0.5;
                    if ((j == 0) || (j == M1 - 1))
                        trapKoef *= 0.5;

                    for (int k = 0; k < numberOfCenters; k++)
                        f[k] = (0.5 * (C1(x, y, centers[k].X, centers[k].Y) + C2(x, y, centers[k].X, centers[k].Y)) + ai) *
                               (0.5 * (Ro1(centers[k].X, centers[k].Y) + Ro2(centers[k].X, centers[k].Y)));
                    minIndex = FindMin();
                    ResFunctional += trapKoef * h1h2 * f.Min();

                    for (int m = 0; m < numberOfCenters; m++)
                        lambda[m, u] = m == minIndex ? 1 : 0;
                    u++;
                }
            }
            return ResFunctional;
        }

        public double A2i()
        {
            lambda = new int[numberOfCenters, M * M1];
            f = new double[numberOfCenters];
            int u = 0;
            double Hx = (1.0 / (double)(M - 1));
            double Hy = (1.0 / (double)(M1 - 1));
            double h1h2 = Hx * Hy;
            double ResFunctional = 0;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M1; j++)
                {
                    double x = i * Hx;
                    double y = j * Hy;
                    double trapKoef = 1;
                    if ((i == 0) || (i == M - 1))
                        trapKoef *= 0.5;
                    if ((j == 0) || (j == M1 - 1))
                        trapKoef *= 0.5;

                    for (int k = 0; k < numberOfCenters; k++)
                        f[k] = (0.5 * (C1(x, y, centers[k].X, centers[k].Y) + C2(x, y, centers[k].X, centers[k].Y)) +
                               gamma * Math.Abs(C2(x, y, centers[k].X, centers[k].Y) - C1(x, y, centers[k].X, centers[k].Y)) + ai) *
                               (0.5 * (Ro1(centers[k].X, centers[k].Y) + Ro2(centers[k].X, centers[k].Y)) +
                               gamma * Math.Abs(Ro2(centers[k].X, centers[k].Y) - Ro1(centers[k].X, centers[k].Y)));
                    minIndex = FindMin();
                    ResFunctional += trapKoef * h1h2 * f.Min();

                    for (int m = 0; m < numberOfCenters; m++)
                        lambda[m, u] = m == minIndex ? 1 : 0;
                    u++;
                }
            }
            return ResFunctional;
        }

        #region A4

        #region properties

        double[][] CoverRect; // границы прямоугольника
        int MeshNodeX; // количество узлов сетки по Ox
        int MeshNodeY; // количество узлов сетки по Oy
        int NumProducts; // кол-во продуктов
        double[][] CentersCoord; // координаты центров (начальные)
        double[][] ResCenCoord; // координаты центров (конечные)

        //double[][] delta_c_left;
        //double[][] delta_c_right;
        //double[][] Aij_left;
        //double[][] Aij_right;
        double gammmmma;

        //double[] ResPsi;
        double[][][] ResSubsets;

        //double[][] RoTable;
        //Func<double, double, double> _ro;
        //double Roooo(double x, double y)
        //{
        //    return 1.0;
        //}

        //double Roooo1(double x, double y)
        //{
        //    return x * x / 9 + y * y / 100 - 100;
        //}

        Func<double, double, double, double, double> metrika;
        Func<double, double, double, double, double> DXmetrika;
        Func<double, double, double, double, double> DYmetrika;

        double Evklid(double x, double y, double x1, double y1)
        {
            return Math.Sqrt(Math.Pow(x - x1, 2) + Math.Pow(y - y1, 2));
        }
        double dEx(double x, double y, double x1, double y1)
        {
            if (Evklid(x, y, x1, y1) == 0.0)
                return 0;
            return ((x1 - x) / Evklid(x, y, x1, y1));
        }
        double dEy(double x, double y, double x1, double y1)
        {
            if (Evklid(x, y, x1, y1) == 0.0)
                return 0;
            return ((y1 - y) / Evklid(x, y, x1, y1));
        }

        #endregion

        #region props2

        double RAccuracy;
        double ResDFunctional;
        int MaxIterNum;
        int ResIterNum; // значение количесвa проведенных итераций
        double ResGradient; // значение градиетна

        int[,] _lambda;
        int _u;

        #endregion

        void Inits(out double[] psixy, out double[] g)
        {
            _lambda = new int[numberOfCenters, M * M1];
            _u = 0;

            CoverRect = new double[2][];
            CoverRect[0] = new double[2];
            CoverRect[0][0] = 0;
            CoverRect[0][1] = 0;
            CoverRect[1] = new double[2];
            CoverRect[1][0] = 1;
            CoverRect[1][1] = 1;

            MeshNodeX = M;
            MeshNodeY = M1;

            NumProducts = 1;

            CentersCoord = new double[numberOfCenters][];
            for (int i = 0; i < numberOfCenters; i++)
            {
                CentersCoord[i] = new double[2];
                CentersCoord[i][0] = centers[i].X;
                CentersCoord[i][1] = centers[i].Y;
            }

            gammmmma = 1.0;

            metrika = Evklid;
            DXmetrika = dEx;
            DYmetrika = dEy;

            ResSubsets = new double[NumProducts][][];
            for (int i = 0; i < NumProducts; i++)
            {
                ResSubsets[i] = new double[MeshNodeX][];
                for (int j = 0; j < MeshNodeX; j++)
                {
                    ResSubsets[i][j] = new double[MeshNodeY];
                }
            }

            //double[] g;
            g = new double[2 * numberOfCenters];

            //double[] psixy;
            psixy = new double[2 * numberOfCenters];
            for (int i = 0; i < numberOfCenters; i++)
            {
                psixy[i] = CentersCoord[i][0];
                psixy[i + numberOfCenters] = CentersCoord[i][1];
            }

            RAccuracy = 0.001;
            MaxIterNum = 100000; // максимальное количество узлов сетки по Ох

            //int n = 10;
            //double[][] b = new double[100][];
            //for (int i = 0; i < 100; i++)
            //{
            //    b[i] = new double[n];
            //}
        }

        public double A4()
        {
            double[] psixy, g;
            Inits(out psixy, out g);

            ralgb4(1, 2 * numberOfCenters, psixy, g, RAccuracy, 3, 1, 0.9, 1.1, 1);

            //const int n = 2;
            //int ln = n * numberOfCenters;
            //double[] x = new double[ln];
            //int num = 0;
            //for (int i = 0; i < ln; i += 2)
            //{
            //    x[i] = centers[num].X;
            //    x[i + 1] = centers[num].Y;
            //    num++;
            //}
            //double alp = 2.0, h0 = 1.0, nh = 3.0, q1 = 0.9, q2 = 1.1, epsx = 0.000001, epsg = 0.000001, fr = 0.0;
            //int maxiternum = 2000, intp = 20, itn = 0, istop = 0;
            //double[] xr = new double[ln];
            //double[][] b = new double[ln][];
            //double[] _g = new double[ln];
            //double[] _g1 = new double[ln];
            //double[] _g2 = new double[ln];
            //ralgb4(ln, ref x, alp, h0, nh, q1, q2, maxiternum, epsx, epsg, intp, fr, ref xr, itn, istop, ref b, ref _g, ref _g1, ref _g2);

            ResCenCoord = new double[numberOfCenters][];
            for (int i = 0; i < numberOfCenters; i++)
            {
                ResCenCoord[i] = new double[2];
                ResCenCoord[i][0] = psixy[i];
                ResCenCoord[i][1] = psixy[i + numberOfCenters];
            }

            var ResFunctional = Functional();
            var ResFunctionalR = FunctionalR();
            var ResFunctionalL = FunctionalL();

            // for drawing
            for (int i = 0; i < numberOfCenters; i++)
            {
                centers[i].X = ResCenCoord[i][0];
                centers[i].Y = ResCenCoord[i][1];
            }
            lambda = _lambda;

            return ResFunctional;
        }

        void ralgb4(
                double Ii, int Lr, double[] Psi, double[] G, double Sg, double Alp,
                double Nh, double Q1, double Q2, double Is)
        {
            int i, j, k1, k2;
            double h1, sx1, sg1, w, f = 0, d, d1;
            double[] g1, g2, z;
            double[] h;
            double[] hh;
            int itn = 0;
            ResDFunctional = 0;
            h1 = Ii;
            sx1 = Sg;
            sg1 = 10 * Sg;
            w = 1.0 / (Alp * Alp) - 1.0;
            z = new double[Lr];
            g1 = new double[Lr];
            g2 = new double[Lr];
            hh = new double[Lr * Lr];

            #region while (true)
            while (true)
            {
            Label_100:
                h = ReinitH(hh);
                for (i = 0; i < Lr; i++)
                {
                    for (j = 0; j < Lr; j++)
                    {
                        h[j] = 0.0;
                    }
                    hh[i * (Lr + 1)] = 1.0;
                }
                //Fun_A5(Lr, ref f, ref G, ref Psi);
                Fun_A4(Lr, ref f, ref G, ref Psi);
                //Fun_A4(Lr, f, ref G, Psi);
                for (i = 0, d = 0.0; i < Lr; i++)
                {
                    d += G[i] * G[i];
                    g1[i] = G[i];
                    z[i] = Psi[i];
                }
                if (d < sg1)
                {
                    goto r_Exit;
                }
                #region do
                do
                {
                    itn++;
                    for (i = 0, d = 0.0; i < Lr; i++)
                    {
                        g2[i] = g1[i] - G[i];
                        d += g2[i] * g2[i];
                    }
                    if (d > 1.0E-18)
                    {
                        h = ReinitH(hh);
                        int cccc = 0;
                        for (i = 0, d = 0.0; i < Lr; i++)
                        {
                            g1[i] = 0.0;
                            for (j = 0; j < Lr; j++)
                            {
                                g1[i] += h[cccc++] * g2[j];
                            }
                            d += g2[i] * g1[i];
                        }
                        d = w / d;
                        h = ReinitH(hh);
                        int cc_ = 0;
                        for (i = 0; i < Lr; i++)
                        {
                            d1 = d * g1[i];
                            for (j = 0; j < Lr; j++)
                            {
                                hh[cc_] += d1 * g1[j];
                                cc_++;
                            }
                        }
                    }
                    for (i = 0; i < Lr; i++)
                    {
                        g1[i] = G[i];
                    }
                    h = ReinitH(hh);
                    int ccc = 0;
                    for (i = 0, d = 0.0; i < Lr; i++)
                    {
                        G[i] = 0.0;
                        for (j = 0; j < Lr; j++)
                        {
                            G[i] += h[ccc++] * g1[j];
                        }
                        d += g1[i] * G[i];
                    }
                    if (d < 1.0E-18)
                    {
                        for (i = 0, d = 0.0; i < Lr; i++)
                        {
                            d += (Psi[i] - z[i]) * (Psi[i] - z[i]);
                        }
                        d = Math.Sqrt(d);
                        h1 = Ii * d / Nh;
                        itn--;
                        goto Label_100;
                    }
                    d = Math.Sqrt(d);
                    for (i = 0; i < Lr; i++)
                    {
                        G[i] /= d;
                        z[i] = Psi[i];
                    }
                    k1 = 0;
                    k2 = 20;
                    #region do
                    do
                    {
                        for (i = 0; i < Lr; i++)
                        {
                            Psi[i] += h1 * G[i];
                        }
                        //Fun_A4(Lr, ref f, g2, Psi);
                        Fun_A4(Lr, ref f, ref g2, ref Psi);
                        //Fun_A5(Lr, ref f, ref g2, ref Psi);
                        k1++;
                        if ((Is != 0) && (k1 >= k2))
                        {
                            k2 += 20;
                            if (k1 == 60)
                            {
                                goto r_Exit;
                            }
                        }
                        if (k1 >= Nh)
                        {
                            h1 *= Q2;
                        }
                        for (i = 0, d = 0.0; i < Lr; i++)
                        {
                            d += G[i] * g2[i];
                        }
                    }
                    while (d > 0.0);
                    #endregion
                    //if ((itn % SaveIterNum) == 0) {
                    //   ff << "Итерация №";
                    //   ff << itn << " ";
                    //   ff << "Значение двоественного функционала = " << f << "\n";
                    //   ff << "Переменные | Градиент \n";
                    //   for (int it = 0; it < Lr; it++) {
                    //      ff << Psi[it] << " | " << g2[it];
                    //      ff << "\n";
                    //   }
                    //}
                    if (k1 <= 1)
                    {
                        h1 *= Q1;
                    }
                    for (i = 0; i < Lr; i++)
                    {
                        G[i] = g2[i];
                    }
                    if (itn >= MaxIterNum)
                    {
                        goto r_Exit;
                    }
                    for (i = 0, d = 0.0; i < Lr; i++)
                    {
                        d += G[i] * G[i];
                    }
                    if (d < sg1)
                    {
                        goto r_Exit;
                    }
                    for (i = 0, d = 0.0; i < Lr; i++)
                    {
                        d += (Psi[i] - z[i]) * (Psi[i] - z[i]);
                    }
                    if (d < sx1)
                    {
                        goto r_Exit;
                    }
                }
                while (Math.Abs(h1) <= 1.0E10);
                #endregion
                d = Math.Sqrt(d);
                h1 = Ii * d / Nh;
            }
            #endregion
        r_Exit:
            //ff << "Значение двойственного функционала на последней итерации = "  << f;
            ResDFunctional = f;
            ResIterNum = itn;
            ResGradient = 0;
            for (int it = 0; it < Lr; it++)
            {
                ResGradient += g2[it] * g2[it];
            }
            ResGradient = Math.Sqrt(ResGradient);
        }

        void Fun_A4(int n, ref double rd, ref double[] g, ref double[] xx)
        {
            double[] TauX = new double[numberOfCenters];
            double[] TauY = new double[numberOfCenters];
            for (int i = 0; i < numberOfCenters; i++)
            {
                TauX[i] = xx[i];
                TauY[i] = xx[i + numberOfCenters];
            }
            //int ii = 0;
            //for (int i = 0; i < numberOfCenters; i++)
            //{
            //    TauX[i] = xx[ii];
            //    TauY[i] = xx[ii+1];
            //    ii += 2;
            //}

            //double penalty=100.0;
            rd = 0.0;

            ////if with_accomodation then
            ////begin
            ////for m:=NC+1 to (Dimensions+2)*NC do
            ////begin
            ////  if (Point[m-1]<0) then
            ////      begin
            ////       Gradient[m-1]:=Gradient[m-1]+penalty;
            ////       TargetFunctional:=TargetFunctional+(Point[m-1]-0)*penalty;
            ////       TargetFunctionalPr:=TargetFunctionalPr+(Point[m-1]-0)*penalty;
            ////      end;
            ////end;
            //for (int i = 0; i < numberOfCenters; i++)
            //{
            //    if (TauX[i] < 0)
            //    {
            //        g[i * numberOfCenters] += penalty;
            //        rd += (TauX[i] - 0) * penalty;
            //    }
            //    if (TauY[i] < 0)
            //    {
            //        g[i * numberOfCenters] += penalty;
            //        rd += (TauY[i] - 0) * penalty;
            //    }
            //}
            ////for m:=NC+1 to (Dimensions+1)*NC do
            ////begin
            //// if (Point[m-1]>grMax[1]) then
            ////        begin
            ////          TargetFunctional:=TargetFunctional-penalty*(Point[m-1]-grMax[1]);
            ////          TargetFunctionalPr:=TargetFunctionalPr-penalty*(Point[m-1]-grMax[1]);
            ////          Gradient[m-1]:=Gradient[m-1]-penalty;
            ////        end;
            //// if (Point[m+nc-1]>grMax[2]) then
            ////        begin
            ////           TargetFunctionalPr:=TargetFunctionalPr-penalty*(Point[m+nc-1]-grMax[2]);
            ////           TargetFunctional:=TargetFunctional-penalty*(Point[m+nc-1]-grMax[2]);
            ////           Gradient[m+nc-1]:=Gradient[m+nc-1]-penalty;
            ////        end;
            ////end;
            //for (int i = 0; i < numberOfCenters; i++)
            //{
            //    if (TauX[i] > 1)
            //    {
            //        rd -= (TauX[i] - 1) * penalty;
            //        g[i * numberOfCenters] -= penalty;
            //    }
            //    if (TauY[i] > 1)
            //    {
            //        rd -= (TauY[i] - 1) * penalty;
            //        g[i * numberOfCenters] -= penalty;
            //    }
            //}
            ////end;

            for (int i = 0; i < 2 * numberOfCenters; i++)
            {
                g[i] = 0;
            }
            for (int m = 0; m < numberOfCenters; m++)
            {
                if (TauX[m] < CoverRect[0][0])
                {
                    TauX[m] = CoverRect[0][0];
                }
                if (TauX[m] > CoverRect[1][0])
                {
                    TauX[m] = CoverRect[1][0];
                }
            }
            for (int m = 0; m < numberOfCenters; m++)
            {
                if (TauY[m] < CoverRect[0][1])
                {
                    TauY[m] = CoverRect[0][1];
                }
                if (TauY[m] > CoverRect[1][1])
                {
                    TauY[m] = CoverRect[1][1];
                }
            }
            double Hx = (CoverRect[1][0] - CoverRect[0][0]) / ((double)MeshNodeX - 1);
            double Hy = (CoverRect[1][1] - CoverRect[0][1]) / ((double)MeshNodeY - 1);
            double SQM = Hx * Hy;
            for (int i1 = 0; i1 < MeshNodeX; i1++)
            {
                for (int j1 = 0; j1 < MeshNodeY; j1++)
                {
                    double x, y;
                    x = CoverRect[0][0] + i1 * Hx;
                    y = CoverRect[0][1] + j1 * Hy;
                    double dTrapezoidKoefficient = 1;
                    if ((i1 == 0) || (i1 == MeshNodeX - 1))
                    {
                        dTrapezoidKoefficient *= 0.5;
                    }
                    if ((j1 == 0) || (j1 == MeshNodeY - 1))
                    {
                        dTrapezoidKoefficient *= 0.5;
                    }
                    for (int i = 0; i < NumProducts; i++)
                    {
                        double min = 0.5 * (
                            metrika(x, y, TauX[0], TauY[0])
                            //- delta_c_left[0][i] + Aij_left[0][i]
                            + metrika(x, y, TauX[0], TauY[0])
                            //+ delta_c_right[0][i] + Aij_right[0][i]
                            )
                            + gammmmma * (
                            metrika(x, y, TauX[0], TauY[0])
                            //+ delta_c_right[0][i] + Aij_right[0][i]
                            - metrika(x, y, TauX[0], TauY[0])
                            //+ delta_c_left[0][i] - Aij_left[0][i]
                            );
                        double newmin = min;
                        int iPlaceOfMinimum = 0;
                        for (int k = 1; k < numberOfCenters; k++)
                        {
                            newmin = (metrika(x, y, TauX[k], TauY[k])
                                //- delta_c_left[k][i] + Aij_left[k][i]
                                + metrika(x, y, TauX[k], TauY[k])
                                //+ delta_c_right[k][i] + Aij_right[k][i]
                                ) / 2 + gammmmma * (
                                metrika(x, y, TauX[k], TauY[k])
                                //+ delta_c_right[k][i] + Aij_right[k][i]
                                - metrika(x, y, TauX[k], TauY[k])
                                //+ delta_c_left[k][i] - Aij_left[k][i]
                                );
                            if (min >= newmin)
                            {
                                min = newmin;
                                iPlaceOfMinimum = k;
                            }
                        }
                        ResSubsets[i][i1][j1] = iPlaceOfMinimum;
                        //rd += dTrapezoidKoefficient * RoTable[i1][j1] * SQM * min;
                        rd += dTrapezoidKoefficient * 1 * SQM * min;
                        double dx = 0, dy = 0;
                        dx = dTrapezoidKoefficient * DXmetrika(x, y, TauX[iPlaceOfMinimum], TauY[iPlaceOfMinimum]);
                        dy = dTrapezoidKoefficient * DYmetrika(x, y, TauX[iPlaceOfMinimum], TauY[iPlaceOfMinimum]);
                        //g[iPlaceOfMinimum] -= dx * SQM * RoTable[i1][j1];
                        g[iPlaceOfMinimum] -= dx * SQM * 1;
                        //g[numberOfCenters + iPlaceOfMinimum] -= dy * SQM * RoTable[i1][j1];
                        g[numberOfCenters + iPlaceOfMinimum] -= dy * SQM * 1;

                        //// for drawing
                        //for (int m = 0; m < numberOfCenters; m++)
                        //    _lambda[m, _u] = m == iPlaceOfMinimum ? 1 : 0;
                        //_u++;
                    }
                }
            }
        }

        double[] ReinitH(double[] hh)
        {
            double[] h;
            h = new double[hh.Length];
            for (int ii = 0; ii < hh.Length; ii++)
            {
                h[ii] = hh[ii];
            }
            return h;
        }

        double Functional()
        {
            f = new double[numberOfCenters];

            double res = 0.0;
            double Hx = (CoverRect[1][0] - CoverRect[0][0]) / ((double)MeshNodeX - 1);
            double Hy = (CoverRect[1][1] - CoverRect[0][1]) / ((double)MeshNodeY - 1);
            double SQM = Hx * Hy;
            for (int i1 = 0; i1 < MeshNodeX; i1++)
            {
                for (int j1 = 0; j1 < MeshNodeY; j1++)
                {
                    double x, y;
                    x = CoverRect[0][0] + i1 * Hx;
                    y = CoverRect[0][1] + j1 * Hy;
                    double dTrapezoidKoefficient = 1;
                    if ((i1 == 0) || (i1 == MeshNodeX - 1))
                    {
                        dTrapezoidKoefficient *= 0.5;
                    }
                    if ((j1 == 0) || (j1 == MeshNodeY - 1))
                    {
                        dTrapezoidKoefficient *= 0.5;
                    }
                    for (int i = 0; i < NumProducts; i++)
                    {
                        double min = (metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1])
                            //- delta_c_left[0][i] + Aij_left[0][i]
                            + metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1])
                            //+ delta_c_right[0][i] + Aij_right[0][i]
                            ) / 2 + gamma * (
                            metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1])
                            //+ delta_c_right[0][i] + Aij_right[0][i]
                            - metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1])
                            //+ delta_c_left[0][i] - Aij_left[0][i]
                            );
                        f[0] = min;
                        double newmin = min;
                        for (int k = 1; k < numberOfCenters; k++)
                        {
                            newmin = (metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1])
                                //- delta_c_left[k][i] + Aij_left[k][i]
                                + metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1])
                                //+ delta_c_right[k][i] + Aij_right[k][i]
                                ) / 2 + gamma * (
                                metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1])
                                //+ delta_c_right[k][i] + Aij_right[k][i]
                                - metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1])
                                //+ delta_c_left[k][i] - Aij_left[k][i]
                                );

                            if (min >= newmin)
                            {
                                min = newmin;
                            }

                            f[k] = min;
                        }
                        //res += dTrapezoidKoefficient * RoTable[i1][j1] * SQM * min;
                        res += dTrapezoidKoefficient * 1 * SQM * min;

                        minIndex = FindMin();

                        for (int m = 0; m < numberOfCenters; m++)
                            _lambda[m, _u] = m == minIndex ? 1 : 0;
                        _u++;
                    }
                }
            }
            return res;
        }

        double FunctionalR()
        {
            double res = 0.0;
            double Hx = (CoverRect[1][0] - CoverRect[0][0]) / ((double)MeshNodeX - 1);
            double Hy = (CoverRect[1][1] - CoverRect[0][1]) / ((double)MeshNodeY - 1);
            double SQM = Hx * Hy;
            for (int i1 = 0; i1 < MeshNodeX; i1++)
            {
                for (int j1 = 0; j1 < MeshNodeY; j1++)
                {
                    double x, y;
                    x = CoverRect[0][0] + i1 * Hx;
                    y = CoverRect[0][1] + j1 * Hy;
                    double dTrapezoidKoefficient = 1;
                    if ((i1 == 0) || (i1 == MeshNodeX - 1))
                    {
                        dTrapezoidKoefficient *= 0.5;
                    }
                    if ((j1 == 0) || (j1 == MeshNodeY - 1))
                    {
                        dTrapezoidKoefficient *= 0.5;
                    }
                    for (int i = 0; i < NumProducts; i++)
                    {
                        double min = //(
                            metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1])
                            //+ delta_c_right[0][i] + Aij_right[0][i])
                            + gamma * (
                            metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1])
                            //+ delta_c_right[0][i] + Aij_right[0][i]
                            );
                        double newmin = min;
                        for (int k = 1; k < numberOfCenters; k++)
                        {
                            newmin = //(
                                metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1])
                                //+ delta_c_right[k][i] + Aij_right[k][i])
                                + gamma * (metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1])
                                //+ delta_c_right[k][i] + Aij_right[k][i]
                                );

                            if (min >= newmin)
                            {
                                min = newmin;
                            }
                        }
                        //res += dTrapezoidKoefficient * RoTable[i1][j1] * SQM * min;
                        res += dTrapezoidKoefficient * 1 * SQM * min;
                    }
                }
            }
            return res;
        }

        double FunctionalL()
        {
            double res = 0.0;
            double Hx = (CoverRect[1][0] - CoverRect[0][0]) / ((double)MeshNodeX - 1);
            double Hy = (CoverRect[1][1] - CoverRect[0][1]) / ((double)MeshNodeY - 1);
            double SQM = Hx * Hy;
            for (int i1 = 0; i1 < MeshNodeX; i1++)
            {
                for (int j1 = 0; j1 < MeshNodeY; j1++)
                {
                    double x, y;
                    x = CoverRect[0][0] + i1 * Hx;
                    y = CoverRect[0][1] + j1 * Hy;
                    double dTrapezoidKoefficient = 1;
                    if ((i1 == 0) || (i1 == MeshNodeX - 1))
                    {
                        dTrapezoidKoefficient *= 0.5;
                    }
                    if ((j1 == 0) || (j1 == MeshNodeY - 1))
                    {
                        dTrapezoidKoefficient *= 0.5;
                    }
                    for (int i = 0; i < NumProducts; i++)
                    {
                        double min = //(
                            metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1])
                            //- delta_c_left[0][i] + Aij_left[0][i])
                            + gamma * (-metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1])
                            //+ delta_c_left[0][i] - Aij_left[0][i]
                            );
                        double newmin = min;
                        for (int k = 1; k < numberOfCenters; k++)
                        {
                            newmin = //(
                                metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1])
                                //- delta_c_left[k][i] + Aij_left[k][i])
                                + gamma * (-metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1])
                                //+ delta_c_left[k][i] - Aij_left[k][i]
                                );

                            if (min >= newmin)
                            {
                                min = newmin;
                            }
                        }
                        //res += dTrapezoidKoefficient * RoTable[i1][j1] * SQM * min;
                        res += dTrapezoidKoefficient * 1 * SQM * min;
                    }
                }
            }
            return res;
        }

        #endregion

        #region A5
        void ralgb4_(
         int n, // размерность пространства переменных
         ref double[] x, // начальная точка
          double alp,// коэфф растяжения пр-ва
          double h0,// параметры адаптивной регулировки шагового множителя
          double nh,// --//--
          double q1,// --//--
          double q2,// --//--
          int maxitn,// критерии остановки
          double epsx,// --//--
          double epsg,// --//--
          int intp, // управление печатью
          double fr,// значение ф-ции в точке минимума
         ref double[] xr, // найденная точка минимума ф-ции
          int itn,// число затраченных итераций
          int istop,// код остановки
         ref double[][] b,// матрица обратного преобразования пр-ва
         ref double[] g,//
         ref double[] g1,// исп для хранения промежуточных векторов
         ref double[] g2// --//--
         )
        {
            int i, j, nls, nlsa, ls;
            double dg, f = 0.0, d, d1, dx;

            //Установка нуля и начальных параметров
            double dzero = 0.0001; //Math.Pow(1.0, -20);
            //FILE *iprint=fopen(fname,"w");
            double w = 1.0 / alp - 1;
            double hs = h0;

            int lp = itn + intp;
            for (i = 0; i < n; i++)
            {
                b[i] = new double[n];//
                for (j = 0; j < n; j++)
                    b[i][j] = 0;//
                b[i][i] = 1;
            }

            //fun(n,&f,g,x);
            //Fun_A4(n, ref f, g, x);
            //Fun_A44(n, ref f, ref g, ref x);
            Fun_A5(n, ref f, ref g, ref x);

            fr = f;
            for (i = 0; i < n; i++)
            {
                g1[i] = g[i];
                xr[i] = x[i];
            }
            nls = 0;
            nlsa = 0;
            if (intp >= 0)
            {
                //fprintf(iprint,"");
                Debug.WriteLine(String.Format("itn={0}, f={1}, fr={2}, nlsa={3}, nls={4}", itn, f, fr, nlsa, nls));
            }
            //Основное тело программы, реализующей алгоритм
            for (itn = 1; itn <= maxitn; itn++)
            {
                //Критерий останова по норме градиента
                dg = 0.0;
                for (i = 0; i < n; i++)
                    dg = dg + g[i] * g[i];
                istop = 2;
                if (Math.Sqrt(dg) <= epsg) goto L100;
                //Вычислить субградиент в преобразованном пространстве
                for (i = 0; i < n; i++)
                {
                    d = 0.0;
                    for (j = 0; j < n; j++)
                        d += b[j][i] * g[j];
                    g2[i] = d;
                }
                //Вычислить и нормировать разность субградиентов
                dg = 0.0;
                for (i = 0; i < n; i++)
                {
                    g[i] = g2[i] - g1[i];
                    dg += g[i] * g[i];
                }
                dg = Math.Sqrt(dg);
                if (dg > dzero)
                {
                    dg = 1.0 / dg;
                    for (i = 0; i < n; i++)
                        g[i] = dg * g[i];
                }
                //Вычислить нормированный субградиент в преобразованном пространстве
                d = 0.0; //
                for (i = 0; i < n; i++)
                    d += g[i] * g2[i];
                d = w * d;
                d1 = 0;
                for (i = 0; i < n; i++)
                {
                    g1[i] = g2[i] + d * g[i];
                    d1 = d1 + g1[i] * g1[i];
                }
                d1 = 1.0 / Math.Sqrt(d1);
                for (i = 0; i < n; i++)
                    g2[i] = d1 * g1[i];

                //Пересчитать матрицу В
                for (i = 0; i < n; i++)
                {
                    d = 0.0;
                    for (j = 0; j < n; j++)
                        d = d + b[i][j] * g[j];
                    d = w * d;
                    for (j = 0; j < n; j++)
                        b[i][j] = b[i][j] + d * g[j];
                }

                //Вычислить направление движения
                dg = 0.0;
                for (i = 0; i < n; i++)
                {
                    d = 0.0;
                    for (j = 0; j < n; j++)
                        d = d + b[i][j] * g2[j];
                    g[i] = d;
                    dg = dg + d * d;
                }
                dg = Math.Sqrt(dg);
                //Одномерный спуск по направлению
                ls = 0;
                dx = 0.0;
                istop = 5;

            L20: ls = ls + 1;
                dx = dx + hs * dg;
                for (i = 0; i < n; i++)
                    x[i] = x[i] - hs * g[i];
                // calcfg(n,f,g2,x);
                //fun(n,&f,g2,x);
                //Fun_A4(n, ref f, g2, x);
                //Fun_A44(n, ref f, ref g2, ref x);
                Fun_A5(n, ref f, ref g2, ref x);
                if (f < fr)
                {
                    fr = f;
                    for (i = 0; i < n; i++)
                        xr[i] = x[i];
                }
                d = 0.0;
                for (i = 0; i < n; i++)
                    d = d + g[i] * g2[i];

                if (ls > 25)
                    goto L100;
                if (ls > nh)
                    hs = hs * q2;
                //notice  - чтобы continue не выполнялось, когда это не нужно
                if (d > 0.0)
                    goto L20;

                if (ls == 1)
                    hs = hs * q1;
                nls = nls + ls;
                nlsa = nlsa + ls;
                if (itn == lp)
                {
                    Debug.WriteLine(String.Format("int={0}, f={1}, fr={2}, nlsa={3}, nls={4}", itn, f, fr, nlsa, nls));
                    nlsa = 0;
                    lp = lp + intp;
                }
                for (i = 0; i < n; i++)
                    g[i] = g2[i];

                istop = 3;
                if (Math.Abs(dx) < epsx)
                    goto L100;
            }
            itn = itn - 1;
            istop = 4;
        L100: if (intp >= 0)
                Debug.WriteLine(String.Format("itn={0}, f={1}, fr={2}, nlsa={3}, nls={4}", itn, f, fr, nlsa, nls));
            //fclose(iprint);
            return;
        }
        void Fun_A5(int n, ref double rd, ref double[] g, ref double[] xx)
        {    //Fun_A5
            double[] RPsi = xx;
            double s0 = 0.0;
            rd = 0.0;
            for (int i = 0; i < numberOfCenters; i++)
            {
                g[i] = 0;
            }
            //for (int m=0; m<numberOfCenters; m++)
            //{

            //     g[m] -= MLimits[m].Bi; //граница
            //         s0 += MLimits[m].Bi * RPsi[m]; // тип ограничения
            //         if ((MLimits[m].Ltype) && (RPsi[m]<0.))
            //         {*rd += RDeduction*RPsi[m];//хран.цел.функц.
            //         g[m] += RDeduction;//??????????????????????
            //        // RPsi[m] = 0.0;//????????????????????????
            //         }
            //}


            double Hx = (CoverRect[1][0] - CoverRect[0][0]) / ((float)MeshNodeX - 1);
            double Hy = (CoverRect[1][1] - CoverRect[0][1]) / ((float)MeshNodeY - 1);
            double SQM = Hx * Hy;
            for (int i1 = 0; i1 < MeshNodeX; i1++)
                for (int j1 = 0; j1 < MeshNodeY; j1++)
                {
                    double x, y;
                    x = CoverRect[0][0] + i1 * Hx;
                    y = CoverRect[0][1] + j1 * Hy;
                    double dTrapezoidKoefficient = 1;
                    if ((i1 == 0) || (i1 == MeshNodeX - 1)) dTrapezoidKoefficient *= 0.5;
                    if ((j1 == 0) || (j1 == MeshNodeY - 1)) dTrapezoidKoefficient *= 0.5;

                    for (int i = 0; i < NumProducts; i++)
                    {
                        double min = metrika(x, y, CentersCoord[0][0], CentersCoord[0][1]) + /*Aij[0][i]*/ +RPsi[0];
                        double newmin = min;
                        int iPlaceOfMinimum = 0;
                        for (int k = 1; k < numberOfCenters; k++)
                        {
                            newmin = metrika(x, y, CentersCoord[k][0], CentersCoord[k][1]) + /*Aij[k][i]*/ +RPsi[k];
                            if (min >= newmin) { min = newmin; iPlaceOfMinimum = k; }
                        };
                        //вычисление градиента по psi
                        //g[iPlaceOfMinimum] += dTrapezoidKoefficient * RoTable[i1][j1]*SQM;
                        g[iPlaceOfMinimum] += dTrapezoidKoefficient * 1 * SQM;
                        ResSubsets[i][i1][j1] = iPlaceOfMinimum; //какому центру принадлежит-массив разбиения
                        //rd += dTrapezoidKoefficient * RoTable[i1][j1] * SQM * min;
                        rd += dTrapezoidKoefficient * 1 * SQM * min;
                        //ResDFunctional

                    }
                }
            rd -= s0;
        }


        public double A5()
        {
            /*
            double[] psixy, g;
            Inits(out psixy, out g);

            const int n = 2;
            int ln = n * numberOfCenters;
            double[] xx = new double[ln];
            int num = 0;
            for (int i = 0; i < ln; i += 2)
            {
                xx[i] = centers[num].X;
                xx[i + 1] = centers[num].Y;
                num++;
            }
            double alp = 2.0, h0 = 1.0, nh = 3.0, q1 = 0.9, q2 = 1.1, epsx = 0.000001, epsg = 0.000001, fr = 0.0;
            int maxiternum = 2000, intp = 20, itn = 0, istop = 0;
            double[] xr = new double[ln];
            double[][] b = new double[ln][];
            double[] _g = new double[ln];
            double[] _g1 = new double[ln];
            double[] _g2 = new double[ln];
            ralgb4_(ln, ref xx, alp, h0, nh, q1, q2, maxiternum, epsx, epsg, intp, fr, ref xr, itn, istop, ref b, ref _g, ref _g1, ref _g2);
            */

            lambda = new int[numberOfCenters, M * M1];
            f = new double[numberOfCenters];
            int u = 0;
            double Hx = (1.0 / (double)(M - 1));
            double Hy = (1.0 / (double)(M1 - 1));
            double h1h2 = Hx * Hy;
            double ResFunctional = 0;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M1; j++)
                {
                    double x = i * Hx;
                    double y = j * Hy;
                    double trapKoef = 1;
                    if ((i == 0) || (i == M - 1))
                        trapKoef *= 0.5;
                    if ((j == 0) || (j == M1 - 1))
                        trapKoef *= 0.5;

                    for (int k = 0; k < numberOfCenters; k++)
                        f[k] = (0.5 * (C1(x, y, centers[k].X, centers[k].Y) + C2(x, y, centers[k].X, centers[k].Y)) + ai) *
                               (0.5 * (Ro1(centers[k].X, centers[k].Y) + Ro2(centers[k].X, centers[k].Y)));
                    minIndex = FindMin();
                    ResFunctional += trapKoef * h1h2 * f.Min();

                    for (int m = 0; m < numberOfCenters; m++)
                        lambda[m, u] = m == minIndex ? 1 : 0;
                    u++;
                }
            }
            return ResFunctional;
        }

        #endregion

        #region A42

        void ralgb4(
         int n, // размерность пространства переменных
         ref double[] x, // начальная точка
          double alp,// коэфф растяжения пр-ва
          double h0,// параметры адаптивной регулировки шагового множителя
          double nh,// --//--
          double q1,// --//--
          double q2,// --//--
          int maxitn,// критерии остановки
          double epsx,// --//--
          double epsg,// --//--
          int intp, // управление печатью
          double fr,// значение ф-ции в точке минимума
         ref double[] xr, // найденная точка минимума ф-ции
          int itn,// число затраченных итераций
          int istop,// код остановки
         ref double[][] b,// матрица обратного преобразования пр-ва
         ref double[] g,//
         ref double[] g1,// исп для хранения промежуточных векторов
         ref double[] g2// --//--
         )
        {
            int i, j, nls, nlsa, ls;
            double dg, f = 0.0, d, d1, dx;

            //Установка нуля и начальных параметров
            double dzero = 0.0001; //Math.Pow(1.0, -20);
            //FILE *iprint=fopen(fname,"w");
            double w = 1.0 / alp - 1;
            double hs = h0;

            int lp = itn + intp;
            for (i = 0; i < n; i++)
            {
                b[i] = new double[n];//
                for (j = 0; j < n; j++)
                    b[i][j] = 0;//
                b[i][i] = 1;
            }

            //fun(n,&f,g,x);
            //Fun_A4(n, ref f, g, x);
            Fun_A44(n, ref f, ref g, ref x);

            fr = f;
            for (i = 0; i < n; i++)
            {
                g1[i] = g[i];
                xr[i] = x[i];
            }
            nls = 0;
            nlsa = 0;
            if (intp >= 0)
            {
                //fprintf(iprint,"");
                Debug.WriteLine(String.Format("itn={0}, f={1}, fr={2}, nlsa={3}, nls={4}", itn, f, fr, nlsa, nls));
            }
            //Основное тело программы, реализующей алгоритм
            for (itn = 1; itn <= maxitn; itn++)
            {
                //Критерий останова по норме градиента
                dg = 0.0;
                for (i = 0; i < n; i++)
                    dg = dg + g[i] * g[i];
                istop = 2;
                if (Math.Sqrt(dg) <= epsg) goto L100;
                //Вычислить субградиент в преобразованном пространстве
                for (i = 0; i < n; i++)
                {
                    d = 0.0;
                    for (j = 0; j < n; j++)
                        d += b[j][i] * g[j];
                    g2[i] = d;
                }
                //Вычислить и нормировать разность субградиентов
                dg = 0.0;
                for (i = 0; i < n; i++)
                {
                    g[i] = g2[i] - g1[i];
                    dg += g[i] * g[i];
                }
                dg = Math.Sqrt(dg);
                if (dg > dzero)
                {
                    dg = 1.0 / dg;
                    for (i = 0; i < n; i++)
                        g[i] = dg * g[i];
                }
                //Вычислить нормированный субградиент в преобразованном пространстве
                d = 0.0; //
                for (i = 0; i < n; i++)
                    d += g[i] * g2[i];
                d = w * d;
                d1 = 0;
                for (i = 0; i < n; i++)
                {
                    g1[i] = g2[i] + d * g[i];
                    d1 = d1 + g1[i] * g1[i];
                }
                d1 = 1.0 / Math.Sqrt(d1);
                for (i = 0; i < n; i++)
                    g2[i] = d1 * g1[i];

                //Пересчитать матрицу В
                for (i = 0; i < n; i++)
                {
                    d = 0.0;
                    for (j = 0; j < n; j++)
                        d = d + b[i][j] * g[j];
                    d = w * d;
                    for (j = 0; j < n; j++)
                        b[i][j] = b[i][j] + d * g[j];
                }

                //Вычислить направление движения
                dg = 0.0;
                for (i = 0; i < n; i++)
                {
                    d = 0.0;
                    for (j = 0; j < n; j++)
                        d = d + b[i][j] * g2[j];
                    g[i] = d;
                    dg = dg + d * d;
                }
                dg = Math.Sqrt(dg);
                //Одномерный спуск по направлению
                ls = 0;
                dx = 0.0;
                istop = 5;

            L20: ls = ls + 1;
                dx = dx + hs * dg;
                for (i = 0; i < n; i++)
                    x[i] = x[i] - hs * g[i];
                // calcfg(n,f,g2,x);
                //fun(n,&f,g2,x);
                //Fun_A4(n, ref f, g2, x);
                Fun_A44(n, ref f, ref g2, ref x);
                if (f < fr)
                {
                    fr = f;
                    for (i = 0; i < n; i++)
                        xr[i] = x[i];
                }
                d = 0.0;
                for (i = 0; i < n; i++)
                    d = d + g[i] * g2[i];

                if (ls > 25)
                    goto L100;
                if (ls > nh)
                    hs = hs * q2;
                //notice  - чтобы continue не выполнялось, когда это не нужно
                if (d > 0.0)
                    goto L20;

                if (ls == 1)
                    hs = hs * q1;
                nls = nls + ls;
                nlsa = nlsa + ls;
                if (itn == lp)
                {
                    Debug.WriteLine(String.Format("int={0}, f={1}, fr={2}, nlsa={3}, nls={4}", itn, f, fr, nlsa, nls));
                    nlsa = 0;
                    lp = lp + intp;
                }
                for (i = 0; i < n; i++)
                    g[i] = g2[i];

                istop = 3;
                if (Math.Abs(dx) < epsx)
                    goto L100;
            }
            itn = itn - 1;
            istop = 4;
        L100: if (intp >= 0)
                Debug.WriteLine(String.Format("itn={0}, f={1}, fr={2}, nlsa={3}, nls={4}", itn, f, fr, nlsa, nls));
            //fclose(iprint);
            return;
        }

        void Fun_A44(int n, ref double rd, ref double[] g, ref double[] xx)
        {
            double[] TauX = new double[numberOfCenters];
            double[] TauY = new double[numberOfCenters];
            int ii = 0;
            for (int i = 0; i < numberOfCenters; i++)
            {
                TauX[i] = xx[ii];
                TauY[i] = xx[ii + 1];
                ii += 2;
            }

            rd = 0.0;

            for (int i = 0; i < 2 * numberOfCenters; i++)
            {
                g[i] = 0;
            }
            //for (int m = 0; m < numberOfCenters; m++)
            //{
            //    if (TauX[m] < CoverRect[0][0])
            //    {
            //        TauX[m] = CoverRect[0][0];
            //    }
            //    if (TauX[m] > CoverRect[1][0])
            //    {
            //        TauX[m] = CoverRect[1][0];
            //    }
            //}
            //for (int m = 0; m < numberOfCenters; m++)
            //{
            //    if (TauY[m] < CoverRect[0][1])
            //    {
            //        TauY[m] = CoverRect[0][1];
            //    }
            //    if (TauY[m] > CoverRect[1][1])
            //    {
            //        TauY[m] = CoverRect[1][1];
            //    }
            //}
            //double RDeduction = 100.0;
            //for (int m = 0; m < numberOfCenters; m++)
            //{
            //    if (TauX[m] < CoverRect[0][0])
            //    {
            //        rd += RDeduction * (TauX[m] - CoverRect[0][0]);
            //        TauX[m] = CoverRect[0][0];
            //        g[m] += RDeduction;
            //    }
            //    if (TauX[m] > CoverRect[1][0])
            //    {
            //        rd += RDeduction * (CoverRect[0][0] - TauX[m]);
            //        TauX[m] = CoverRect[1][0];
            //        g[m] -= RDeduction;
            //    }
            //}
            //for (int m = 0; m < numberOfCenters; m++)
            //{
            //    if (TauY[m] < CoverRect[0][1])
            //    {
            //        rd += RDeduction * (TauY[m] - CoverRect[0][1]);
            //        TauY[m] = CoverRect[0][1];
            //        g[numberOfCenters + m] += RDeduction;
            //    }
            //    if (TauY[m] > CoverRect[1][1])
            //    {
            //        rd += RDeduction * (CoverRect[0][1] - TauY[m]);
            //        TauY[m] = CoverRect[1][1];
            //        g[numberOfCenters + m] -= RDeduction;
            //    }
            //}
            double penalty = 100.0;
            for (int i = 0; i < xx.Count(); i++)
            {
                if (xx[i] < 0)
                {
                    g[i] += penalty;
                    if (i % 2 == 0)
                        rd += (xx[i] - 0) * penalty;
                    else
                        rd += (xx[i] - 0) * penalty;
                }
                //if (TauX[i] < 0)
                //{
                //    g[i * numberOfCenters] += penalty;
                //    rd += (TauX[i] - 0) * penalty;
                //}
                //if (TauY[i] < 0)
                //{
                //    g[i * numberOfCenters] += penalty;
                //    rd += (TauY[i] - 0) * penalty;
                //}
            }
            for (int i = 0; i < numberOfCenters; i++)
            {
                if (xx[i] > 1)
                {
                    g[i] -= penalty;
                    if (i % 2 == 0)
                        rd -= (xx[i] - 1) * penalty;
                    else
                        rd -= (xx[i] - 1) * penalty;
                }
                //if (TauX[i] > 1)
                //{
                //    rd -= (TauX[i] - 1) * penalty;
                //    g[i * numberOfCenters] -= penalty;
                //}
                //if (TauY[i] > 1)
                //{
                //    rd -= (TauY[i] - 1) * penalty;
                //    g[i * numberOfCenters] -= penalty;
                //}
            }
            double Hx = (CoverRect[1][0] - CoverRect[0][0]) / ((double)MeshNodeX - 1);
            double Hy = (CoverRect[1][1] - CoverRect[0][1]) / ((double)MeshNodeY - 1);
            double SQM = Hx * Hy;
            for (int i1 = 0; i1 < MeshNodeX; i1++)
            {
                for (int j1 = 0; j1 < MeshNodeY; j1++)
                {
                    double x, y;
                    x = CoverRect[0][0] + i1 * Hx;
                    y = CoverRect[0][1] + j1 * Hy;
                    double dTrapezoidKoefficient = 1;
                    if ((i1 == 0) || (i1 == MeshNodeX - 1))
                    {
                        dTrapezoidKoefficient *= 0.5;
                    }
                    if ((j1 == 0) || (j1 == MeshNodeY - 1))
                    {
                        dTrapezoidKoefficient *= 0.5;
                    }
                    for (int i = 0; i < NumProducts; i++)
                    {
                        double min = 0.5 * (
                            metrika(x, y, TauX[0], TauY[0])
                            //- delta_c_left[0][i] + Aij_left[0][i]
                            + metrika(x, y, TauX[0], TauY[0])
                            //+ delta_c_right[0][i] + Aij_right[0][i]
                            )
                            + gammmmma * (
                            metrika(x, y, TauX[0], TauY[0])
                            //+ delta_c_right[0][i] + Aij_right[0][i]
                            - metrika(x, y, TauX[0], TauY[0])
                            //+ delta_c_left[0][i] - Aij_left[0][i]
                            );
                        double newmin = min;
                        int iPlaceOfMinimum = 0;
                        for (int k = 1; k < numberOfCenters; k++)
                        {
                            newmin = (metrika(x, y, TauX[k], TauY[k])
                                //- delta_c_left[k][i] + Aij_left[k][i]
                                + metrika(x, y, TauX[k], TauY[k])
                                //+ delta_c_right[k][i] + Aij_right[k][i]
                                ) / 2 + gammmmma * (
                                metrika(x, y, TauX[k], TauY[k])
                                //+ delta_c_right[k][i] + Aij_right[k][i]
                                - metrika(x, y, TauX[k], TauY[k])
                                //+ delta_c_left[k][i] - Aij_left[k][i]
                                );
                            if (min >= newmin)
                            {
                                min = newmin;
                                iPlaceOfMinimum = k;
                            }
                        }
                        ResSubsets[i][i1][j1] = iPlaceOfMinimum;
                        //rd += dTrapezoidKoefficient * RoTable[i1][j1] * SQM * min;
                        rd += dTrapezoidKoefficient * 1 * SQM * min;
                        double dx = 0, dy = 0;
                        dx = dTrapezoidKoefficient * DXmetrika(x, y, TauX[iPlaceOfMinimum], TauY[iPlaceOfMinimum]);
                        dy = dTrapezoidKoefficient * DYmetrika(x, y, TauX[iPlaceOfMinimum], TauY[iPlaceOfMinimum]);
                        //g[iPlaceOfMinimum] -= dx * SQM * RoTable[i1][j1];
                        g[iPlaceOfMinimum] -= dx * SQM * 1;
                        //g[numberOfCenters + iPlaceOfMinimum] -= dy * SQM * RoTable[i1][j1];
                        g[numberOfCenters + iPlaceOfMinimum] -= dy * SQM * 1;
                    }
                }
            }
        }

        #endregion
    }
}