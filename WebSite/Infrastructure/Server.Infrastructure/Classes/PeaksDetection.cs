﻿namespace Server.Infrastructure.Classes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZedGraph;

    //подгружаем либы которые  позволят использовать ранее скомпилированную матлабовскую функцию
    using MathWorks.MATLAB.NET.Arrays;
    using MathWorks.MATLAB.NET.Utility;
    //using qrs;

    public static class PeaksDetection
    {

        static public List<string> GetRPeaks(PointPairList points)
        {
            double maxval = double.MinValue;
            foreach (PointPair pointe in points)
            {
                if (pointe.Y > maxval)
                {
                    maxval = pointe.Y;
                }
            }
            double Rcutter = maxval * 0.9;
            List<string> rpeaks = new List<string>();
            double Ry = 0, Rx = 0;
            bool IsUp = false;
            foreach (PointPair pointe in points)
            {
                if (pointe.Y > Rcutter)
                {
                    if (pointe.Y > Ry)
                    {
                        Ry = pointe.Y;
                        Rx = pointe.X;
                        IsUp = true;
                    }
                    else
                    {
                        if (IsUp)
                        {
                            rpeaks.Add(Rx.ToString());
                            IsUp = false;
                        }
                    }
                }
                else
                {
                    Ry = 0;
                }
            }
            return rpeaks;
        }

        ////создаем обьект функции матлаба
        ////private static RPeaksDetection detector = new RPeaksDetection();
        //private static MatlabRPeaksRecognizer detectorV2 = new MatlabRPeaksRecognizer();

        //public static void GetRPeaks(string path, string path2)
        //{
        //        //вызываем алгоритм обнаружения пиков, пики заносятся в файл RPeaks.txt
        //        //detector.qrs(path);

        //    try
        //    {
        //        detectorV2.RpeaksRecognize(path, path2);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.InnerException.Message, ex.InnerException.InnerException);
        //    }
        //}

        ////читает значения пиков из файла RPeaks.txt и заносит в список
        //public static List<string> RPeaksToList(string path2)
        //{

        //        string result = "";

        //        using (StreamReader stream = new StreamReader(path2))
        //        {
        //            result = stream.ReadToEnd();
        //        }

        //        return result.Split(' ').ToList<string>();


        //}
    }
}
