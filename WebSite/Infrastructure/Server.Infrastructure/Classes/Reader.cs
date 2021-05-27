﻿namespace Server.Infrastructure.Classes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ZedGraph;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class Reader
    {

        /// <summary>
        /// Метод фильтрациии сигнала
        /// </summary>
        /// <param name="indata">Массив координат Y</param>
        /// <param name="deltaTimeinsec"></param>
        /// <param name="CutOff"></param>
        /// <returns>Сглашенный массив Y</returns>
        public static double[] Butterworth(double[] indata, double deltaTimeinsec, double CutOff)
        {
            if (indata == null) return null;
            if (CutOff == 0) return indata;

            double Samplingrate = 1 / deltaTimeinsec;
            long dF2 = indata.Length - 1;        // The data range is set with dF2
            double[] Dat2 = new double[dF2 + 4]; // Array with 4 extra points front and back
            double[] data = indata; // Ptr., changes passed data

            // Copy indata to Dat2
            for (long r = 0; r < dF2; r++)
            {
                Dat2[2 + r] = indata[r];
            }
            Dat2[1] = Dat2[0] = indata[0];
            Dat2[dF2 + 3] = Dat2[dF2 + 2] = indata[dF2];
            double wc = Math.Tan(CutOff * Math.PI / Samplingrate);
            double k1 = 1.414213562 * wc; // Sqrt(2) * wc
            double k2 = wc * wc;
            double a = k2 / (1 + k1 + k2);
            double b = 2 * a;
            double c = a;
            double k3 = b / k2;
            double d = -2 * a + k3;
            double e = 1 - (2 * a) - k3;

            // RECURSIVE TRIGGERS - ENABLE filter is performed (first, last points constant)
            double[] DatYt = new double[dF2 + 4];
            DatYt[1] = DatYt[0] = indata[0];
            for (long s = 2; s < dF2 + 2; s++)
            {
                DatYt[s] = a * Dat2[s] + b * Dat2[s - 1] + c * Dat2[s - 2]
                           + d * DatYt[s - 1] + e * DatYt[s - 2];
            }
            DatYt[dF2 + 3] = DatYt[dF2 + 2] = DatYt[dF2 + 1];

            // FORWARD filter
            double[] DatZt = new double[dF2 + 2];
            DatZt[dF2] = DatYt[dF2 + 2];
            DatZt[dF2 + 1] = DatYt[dF2 + 3];
            for (long t = -dF2 + 1; t <= 0; t++)
            {
                DatZt[-t] = a * DatYt[-t + 2] + b * DatYt[-t + 3] + c * DatYt[-t + 4]
                            + d * DatZt[-t + 1] + e * DatZt[-t + 2];
            }

            // Calculated points copied for return
            for (long p = 0; p < dF2; p++)
            {
                data[p] = DatZt[p];
            }

            return data;
        }

        /// <summary>
        /// Получение точек
        /// </summary>
        /// <param name="path">Путь файла .dat</param>
        /// <returns>Список точек X, Y</returns>
        public static List<string> GetPoints(string path)
        {
            List<string> fil = new List<string>(File.ReadAllLines(path));
            List<double> values = new List<double>();
            List<string> valuesString = new List<string>();
            foreach (string str in fil)
            {
                    values.Add(Convert.ToDouble(str));
            }
            values = Butterworth(values.ToArray(), 0.004, 10).ToList();
            foreach (double item in values)
            {
                valuesString.Add(item.ToString());
            }
            return valuesString;
        }

        public static PointPairList StringToPointPair(List<string> values)
        {
            PointPairList points = new PointPairList();
            for (int i = 0; i < values.Count; i++)
            {
                points.Add(i, Convert.ToDouble(values[i]));
            }

            return points;
        }
    }
}
