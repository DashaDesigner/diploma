//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace OptimalPartitioning
//{
//    class fun
//    {
//        /*Нахождение градиента для соответствующего типа задачи*/

////---------------------------------------------------------------------------
//double Fun_A4(int n, double[] g, double[] x) {
//   double[]  TauX = x;
//   double[]  TauY = x + NumCenters;
//   double rd = 0.0;
//   for (int i = 0; i < 2 * NumCenters; i++) {
//      g[i] = 0;
//   }
//   for (int m = 0; m < NumCenters; m++) {
//      if (TauX[m] < CoverRect[0][0]) {
//         TauX[m] = CoverRect[0][0];
//      }
//      if (TauX[m] > CoverRect[1][0]) {
//         TauX[m] = CoverRect[1][0];
//      }
//   }
//   for (int m = 0; m < NumCenters; m++) {
//      if (TauY[m] < CoverRect[0][1]) {
//         TauY[m] = CoverRect[0][1];
//      }
//      if (TauY[m] > CoverRect[1][1]) {
//         TauY[m] = CoverRect[1][1];
//      }
//   }
//   double Hx = (CoverRect[1][0] - CoverRect[0][0]) / ((double)MeshNodeX - 1);
//   double Hy = (CoverRect[1][1] - CoverRect[0][1]) / ((double)MeshNodeY - 1);
//   double SQM = Hx * Hy;
//   for (int i1 = 0; i1 < MeshNodeX; i1++) {
//      for (int j1 = 0; j1 < MeshNodeY; j1++) {
//         double x, y;
//         x = CoverRect[0][0] + i1 * Hx;
//         y = CoverRect[0][1] + j1 * Hy;
//         double dTrapezoidKoefficient = 1;
//         if ((i1 == 0) || (i1 == MeshNodeX-1)) {
//            dTrapezoidKoefficient *= 0.5;
//         }
//         if ((j1 == 0) || (j1 == MeshNodeY - 1)) {
//            dTrapezoidKoefficient *= 0.5;
//         }
//         for (int i = 0; i < NumProducts; i++) {
//            double min = 0.5*(metrika(x, y, TauX[0], TauY[0])-delta_c_left[0][i] + Aij_left[0][i] + metrika(x, y, TauX[0], TauY[0]) + delta_c_right[0][i] + Aij_right[0][i]) + gamma*(metrika(x, y, TauX[0], TauY[0]) + delta_c_right[0][i] + Aij_right[0][i] - metrika(x, y, TauX[0], TauY[0]) + delta_c_left[0][i] - Aij_left[0][i]);
//            double newmin = min;
//            int iPlaceOfMinimum = 0;
//            for (int k = 1; k < NumCenters; k++) {
//               newmin = (metrika(x, y, TauX[k], TauY[k])-delta_c_left[k][i] + Aij_left[k][i] + metrika(x, y, TauX[k], TauY[k]) + delta_c_right[k][i] + Aij_right[k][i])/2 + gamma*(metrika(x, y, TauX[k], TauY[k]) + delta_c_right[k][i] + Aij_right[k][i] - metrika(x, y, TauX[k], TauY[k]) + delta_c_left[k][i] - Aij_left[k][i]);
//               if (min >= newmin) {
//                  min = newmin;
//                  iPlaceOfMinimum = k;
//               }
//            }
//            ResSubsets[i][i1][j1] = iPlaceOfMinimum;
//            rd += dTrapezoidKoefficient * RoTable[i1][j1] * SQM * min;
//            double dx = 0, dy = 0;
//            dx = dTrapezoidKoefficient * DXmetrika(x, y, TauX[iPlaceOfMinimum], TauY[iPlaceOfMinimum]);
//            dy = dTrapezoidKoefficient * DYmetrika(x, y, TauX[iPlaceOfMinimum], TauY[iPlaceOfMinimum]);
//            g[iPlaceOfMinimum] -= dx * SQM * RoTable[i1][j1];
//            g[NumCenters + iPlaceOfMinimum] -= dy * SQM * RoTable[i1][j1];
//         }
//      }
//   }
//   return rd;                
//}
//double Functional() {
//   double res = 0.0;
//   double Hx = (CoverRect[1][0] - CoverRect[0][0]) / ((double)MeshNodeX - 1);
//   double Hy = (CoverRect[1][1] - CoverRect[0][1]) / ((double)MeshNodeY - 1);
//   double SQM = Hx * Hy;
//   for (int i1 = 0; i1 < MeshNodeX; i1++) {
//      for (int j1 = 0; j1 < MeshNodeY; j1++) {
//         double x, y;
//         x = CoverRect[0][0] + i1 * Hx;
//         y = CoverRect[0][1] + j1 * Hy;
//         double dTrapezoidKoefficient = 1;
//         if ((i1 == 0) || (i1 == MeshNodeX - 1)) {
//            dTrapezoidKoefficient *= 0.5;
//         }
//         if ((j1 == 0) || (j1 == MeshNodeY - 1)) {
//            dTrapezoidKoefficient *= 0.5;
//         }
//         for (int i = 0; i < NumProducts; i++) {
//            double min = (metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1])-delta_c_left[0][i] + Aij_left[0][i] + metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1])  + delta_c_right[0][i] + Aij_right[0][i])/2 + gamma*(metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1]) + delta_c_right[0][i] + Aij_right[0][i] - metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1]) + delta_c_left[0][i] - Aij_left[0][i]);
//            double newmin = min;
//            for (int k = 1; k < NumCenters; k++) {
//               newmin = (metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1])-delta_c_left[k][i] + Aij_left[k][i] + metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1])  + delta_c_right[k][i] + Aij_right[k][i])/2 + gamma*(metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1]) + delta_c_right[k][i] + Aij_right[k][i] - metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1]) + delta_c_left[k][i] - Aij_left[k][i]);  

//        if (min >= newmin) {
//                  min = newmin;
//               }
//            }
//            res += dTrapezoidKoefficient * RoTable[i1][j1] * SQM * min;
//        }
//      }
//   }
//   return res;
//}
//double FunctionalR() {
//   double res = 0.0;
//   double Hx = (CoverRect[1][0] - CoverRect[0][0]) / ((double)MeshNodeX - 1);
//   double Hy = (CoverRect[1][1] - CoverRect[0][1]) / ((double)MeshNodeY - 1);
//   double SQM = Hx * Hy;
//   for (int i1 = 0; i1 < MeshNodeX; i1++) {
//      for (int j1 = 0; j1 < MeshNodeY; j1++) {
//         double x, y;
//         x = CoverRect[0][0] + i1 * Hx;
//         y = CoverRect[0][1] + j1 * Hy;
//         double dTrapezoidKoefficient = 1;
//         if ((i1 == 0) || (i1 == MeshNodeX - 1)) {
//            dTrapezoidKoefficient *= 0.5;
//         }
//         if ((j1 == 0) || (j1 == MeshNodeY - 1)) {
//            dTrapezoidKoefficient *= 0.5;
//         }
//         for (int i = 0; i < NumProducts; i++) {
//            double min = ( metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1])  + delta_c_right[0][i] + Aij_right[0][i]) + gamma*(metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1]) + delta_c_right[0][i] + Aij_right[0][i] );
//            double newmin = min;
//            for (int k = 1; k < NumCenters; k++) {
//               newmin = ( metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1])  + delta_c_right[k][i] + Aij_right[k][i]) + gamma*(metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1]) + delta_c_right[k][i] + Aij_right[k][i] );  

//        if (min >= newmin) {
//                  min = newmin;
//               }
//            }
//            res += dTrapezoidKoefficient * RoTable[i1][j1] * SQM * min;
//        }
//      }
//   }
//   return res;
//}
//double FunctionalL() {
//   double res = 0.0;
//   double Hx = (CoverRect[1][0] - CoverRect[0][0]) / ((double)MeshNodeX - 1);
//   double Hy = (CoverRect[1][1] - CoverRect[0][1]) / ((double)MeshNodeY - 1);
//   double SQM = Hx * Hy;
//   for (int i1 = 0; i1 < MeshNodeX; i1++) {
//      for (int j1 = 0; j1 < MeshNodeY; j1++) {
//         double x, y;
//         x = CoverRect[0][0] + i1 * Hx;
//         y = CoverRect[0][1] + j1 * Hy;
//         double dTrapezoidKoefficient = 1;
//         if ((i1 == 0) || (i1 == MeshNodeX - 1)) {
//            dTrapezoidKoefficient *= 0.5;
//         }
//         if ((j1 == 0) || (j1 == MeshNodeY - 1)) {
//            dTrapezoidKoefficient *= 0.5;
//         }
//         for (int i = 0; i < NumProducts; i++) {
//             double min = (metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1])-delta_c_left[0][i] + Aij_left[0][i]) + gamma*( - metrika(x, y, ResCenCoord[0][0], ResCenCoord[0][1]) + delta_c_left[0][i] - Aij_left[0][i]);
//            double newmin = min;
//            for (int k = 1; k < NumCenters; k++) {
//               newmin = (metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1])-delta_c_left[k][i] + Aij_left[k][i])  + gamma*(- metrika(x, y, ResCenCoord[k][0], ResCenCoord[k][1]) + delta_c_left[k][i] - Aij_left[k][i]);  

//        if (min >= newmin) {
//                  min = newmin;
//               }
//            }
//            res += dTrapezoidKoefficient * RoTable[i1][j1] * SQM * min;
//        }
//      }
//   }
//   return res;
//}
//    }
//}
