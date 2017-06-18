using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OptimalPartitioning
{
    class NewTest
    {
        #region properties

        int numberOfCenters;
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
        double Roooo(double x, double y)
        {
            return 1.0;
        }

        double Roooo1(double x, double y)
        {
            return x * x / 9 + y * y / 100 - 100;
        }

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

        #endregion

        //#region props3

        ////RStep

        //#endregion

        public NewTest()
        {
        }

        public double a4()
        {
            #region inits

            //numberOfCenters = 2;
            //numberOfCenters = 3;
            numberOfCenters = 4;

            CoverRect = new double[2][];
            CoverRect[0] = new double[2];
            CoverRect[0][0] = 0;
            CoverRect[0][1] = 0;
            CoverRect[1] = new double[2];
            CoverRect[1][0] = 1;
            CoverRect[1][1] = 1;

            MeshNodeX = 500;
            MeshNodeY = 500;

            NumProducts = 1;

            CentersCoord = new double[numberOfCenters][];
            for (int i = 0; i < numberOfCenters; i++)
            {
                CentersCoord[i] = new double[2];
            }
            //CentersCoord[0][0] = 0.25;
            //CentersCoord[0][1] = 0.25;
            //CentersCoord[1][0] = 0.75;
            //CentersCoord[1][1] = 0.75;

            //CentersCoord[0][0] = 0.1;
            //CentersCoord[0][1] = 0.9;
            //CentersCoord[1][0] = 0.5;
            //CentersCoord[1][1] = 0.3;
            //CentersCoord[2][0] = 0.7;
            //CentersCoord[2][1] = 0.2;

            CentersCoord[0][0] = 0.1;
            CentersCoord[0][1] = 0.1;
            CentersCoord[1][0] = 0.1;
            CentersCoord[1][1] = 0.9;
            CentersCoord[2][0] = 0.9;
            CentersCoord[2][1] = 0.9;
            CentersCoord[3][0] = 0.9;
            CentersCoord[3][1] = 0.1;

            //delta_c_left = new double[numberOfCenters][];
            //for (int i = 0; i < numberOfCenters; i++)
            //{
            //    delta_c_left[i] = new double[NumProducts];
            //}
            ////delta_c_left[0][0] = 0.0;
            //////delta_c_left[0][1] = 0.2;
            ////delta_c_left[1][0] = 0.5;
            //////delta_c_left[1][1] = 0.7;
            //delta_c_left[0][0] = 0.0;
            //delta_c_left[1][0] = 0.0;
            //delta_c_left[2][0] = 0.0;
            //delta_c_left[3][0] = 0.0;

            //delta_c_right = new double[numberOfCenters][];
            //for (int i = 0; i < numberOfCenters; i++)
            //{
            //    delta_c_right[i] = new double[NumProducts];
            //}
            ////delta_c_right[0][0] = 0.9;
            //////delta_c_right[0][1] = 0.8;
            ////delta_c_right[1][0] = 0.5;
            //////delta_c_right[1][1] = 0.3;
            //delta_c_right[0][0] = 0;
            //delta_c_right[1][0] = 0;
            //delta_c_right[2][0] = 0;
            //delta_c_right[3][0] = 0;

            //Aij_left = new double[numberOfCenters][];
            //for (int i = 0; i < numberOfCenters; i++)
            //{
            //    Aij_left[i] = new double[NumProducts];
            //}
            ////Aij_left[0][0] = 0.1;
            //////Aij_left[0][1] = 0.2;
            ////Aij_left[1][0] = 0.4;
            //////Aij_left[1][1] = 0.7;
            //Aij_left[0][0] = 0;
            //Aij_left[1][0] = 0;
            //Aij_left[2][0] = 0;
            //Aij_left[3][0] = 0;

            //Aij_right = new double[numberOfCenters][];
            //for (int i = 0; i < numberOfCenters; i++)
            //{
            //    Aij_right[i] = new double[NumProducts];
            //}
            ////Aij_right[0][0] = 0.3;
            //////Aij_right[0][1] = 0.2;
            ////Aij_right[1][0] = 0.8;
            //////Aij_right[1][1] = 0.7;
            //Aij_right[0][0] = 0;
            //Aij_right[1][0] = 0;
            //Aij_right[2][0] = 0;
            //Aij_right[3][0] = 0;

            gammmmma = 1.0;

            metrika = Evklid;
            DXmetrika = dEx;
            DYmetrika = dEy;

            //ResPsi = new double[2 * numberOfCenters];

            //// init ro-table
            //_ro = Roooo;
            //RoTable = new double[MeshNodeX][];
            //double stepX, stepY;
            //stepX = (CoverRect[1][0] - CoverRect[0][0]) / (MeshNodeX - 1);
            //stepY = (CoverRect[1][1] - CoverRect[0][1]) / (MeshNodeY - 1);
            //for (int i = 0; i < MeshNodeX; i++)
            //{
            //    RoTable[i] = new double[MeshNodeY];
            //    for (int j = 0; j < MeshNodeY; j++)
            //    {
            //        double k = RoTable[i][j];
            //        double c1 = CoverRect[0][0] + i * stepX;
            //        double c2 = CoverRect[0][1] + j * stepY;
            //        RoTable[i][j] = _ro(CoverRect[0][0] + i * stepX, CoverRect[0][1] + j * stepY);
            //    }
            //}
            //////////

            ResSubsets = new double[NumProducts][][];
            for (int i = 0; i < NumProducts; i++)
            {
                ResSubsets[i] = new double[MeshNodeX][];
                for (int j = 0; j < MeshNodeX; j++)
                {
                    ResSubsets[i][j] = new double[MeshNodeY];
                }
            }

            double[] g;
            g = new double[2 * numberOfCenters];

            double[] psixy;
            psixy = new double[2 * numberOfCenters];
            for (int i = 0; i < numberOfCenters; i++)
            {
                psixy[i] = CentersCoord[i][0];
                psixy[i + numberOfCenters] = CentersCoord[i][1]; // wtf - ok
            }

            #endregion

            RAccuracy = 0.001;
            MaxIterNum = 100000; // максимальное количество узлов сетки по Ох

            //ralgb4(Fun_A4, 1, 2 * NumCenters, psixy, g, RAccuracy, 3, 1, 0.9, 1.1, 1);
            int n = 10;
            double[][] b = new double[100][];
            for (int i = 0; i < 100; i++)
            {
                b[i] = new double[n];
            }

            //ralgb4(
            //    n: 10,
            //    x: new double[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            //    alp: 2.0,
            //    h0: 1.0,
            //    nh: 3.0,
            //    q1: 0.9,
            //    q2: 1.1,
            //    maxitn: 2000,
            //    epsx: 0.000001,
            //    epsg: 0.000001,
            //    intp: 20,
            //    fr: 1, //
            //    xr: new double[10],
            //    itn: 0,
            //    istop: 0,
            //    b: b,
            //    g: new double[10],
            //    g1: new double[10],
            //    g2: new double[10]
            //    );

            ralgb4(1, 2 * numberOfCenters, psixy, g, RAccuracy, 3, 1, 0.9, 1.1, 1);

            ResCenCoord = new double[numberOfCenters][];
            for (int i = 0; i < numberOfCenters; i++)
            {
                ResCenCoord[i] = new double[2];
                ResCenCoord[i][0] = psixy[i];
                ResCenCoord[i][1] = psixy[i + numberOfCenters]; // wtf - ok
            }

            //ResFunctional = Functional();
            //ResFunctionalR = FunctionalR();
            //ResFunctionalL = FunctionalL();	

            return 0;
        }

        void Fun_A4(int n, ref double rd, double[] g, double[] xx) // double[] xx = new double[4];
        {
            //double[] TauX = xx;
            //double[] TauY = xx + numberOfCenters; // wtf

            double[] TauX = new double[numberOfCenters];
            double[] TauY = new double[numberOfCenters];
            for (int i = 0; i < numberOfCenters; i++)
            {
                TauX[i] = xx[i];
                TauY[i] = xx[i + numberOfCenters];
            }

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
                    }
                }
            }
        }

        public void ralgb4(
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
            //ofstream ff(SaveFile);
            h1 = Ii;
            sx1 = Sg;
            sg1 = 10 * Sg;
            w = 1.0 / (Alp * Alp) - 1.0; // NE TAK V novom
            z = new double[Lr];
            g1 = new double[Lr];
            g2 = new double[Lr];
            hh = new double[Lr * Lr];

            //var fff = new fun();
            #region while (true)
            while (true)
            {
            Label_100:
                h = ReinitH(hh);
                for (i = 0/*, h = hh*/; i < Lr; i++)
                {
                    for (j = 0; j < Lr; j++)
                    {
                        h[j] = 0.0;//?
                    }
                    hh[i * (Lr + 1)] = 1.0;
                }
                Fun_A4(Lr, ref f, G, Psi);
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
                        for (i = 0, /*h = hh,*/ d = 0.0; i < Lr; i++)
                        {
                            g1[i] = 0.0;
                            for (j = 0; j < Lr; j++)
                            {
                                g1[i] += h[cccc++] * g2[j];//?
                            }
                            d += g2[i] * g1[i];
                        }
                        d = w / d;
                        h = ReinitH(hh);
                        int cc_ = 0;// h.Length;
                        for (i = 0/*, h = hh*/; i < Lr; i++)
                        {
                            d1 = d * g1[i];
                            for (j = 0; j < Lr; j++/*, h++*/)
                            {//?
                                hh[cc_] += d1 * g1[j];//?
                                cc_++;
                            }
                        }
                        ////////////////
                    }
                    for (i = 0; i < Lr; i++)
                    {
                        g1[i] = G[i];
                    }
                    h = ReinitH(hh);
                    int ccc = 0;
                    for (i = 0/*, h = hh*/, d = 0.0; i < Lr; i++)
                    {
                        G[i] = 0.0;
                        for (j = 0; j < Lr; j++)
                        {
                            G[i] += h[ccc++] * g1[j];//?
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
                        Fun_A4(Lr, ref f, g2, Psi);
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
            //ff.close();
            ResIterNum = itn;
            ResGradient = 0;
            for (int it = 0; it < Lr; it++)
            {
                ResGradient += g2[it] * g2[it];
            }
            ResGradient = Math.Sqrt(ResGradient);
            //delete []hh;
            //delete[]g2;
            //delete[]g1;
            //delete[]z;
        }

        private static double[] ReinitH(double[] hh)
        {
            double[] h;
            h = new double[hh.Length];
            for (int ii = 0; ii < hh.Length; ii++)
            {
                h[ii] = hh[ii];
            }
            return h;
        }
    }
}
