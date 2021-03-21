using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using Server.Infrastructure.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using ZedGraph;

namespace Server.Infrastructure.Logic
{
    public class GetData
    {
        
        public static PointPairList ReadFile(int id, IHostingEnvironment env)
        {
            string folderName = "Upload";
            string webRootPath = env.WebRootPath;
            string path = Path.Combine(webRootPath, folderName);
            //путь файла
            path = Path.Combine(path, id + ".dat");

            PointPairList list;

                try
                {
                    //читаем все точки из файла и заносим в список
                    list = Reader.StringToPointPair(Reader.GetPoints(path));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            return list;
        }

        public static List<string> ReadFileString(int id, IHostingEnvironment env)
        {
            string folderName = "Upload";
            string webRootPath = env.WebRootPath;
            string path = Path.Combine(webRootPath, folderName);
            //путь файла
            path = Path.Combine(path, id + ".dat");

            List<string> list = new List<string>();

            try
            {
                //читаем все точки из файла и заносим в список
                list = Reader.GetPoints(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static List<string> GetRPeaks(int id, IHostingEnvironment env)
        {
            string folderName = "Upload";
            string webRootPath = env.WebRootPath;
            string path = Path.Combine(webRootPath, folderName);
            path = Path.Combine(path, id + ".dat");
            string filename = Path.Combine(id + ".dat");
            string path2 = Path.Combine(env.ContentRootPath, "Rpeaks.txt");
            string peaksname = Path.Combine(id + ".txt");
            string pathPeaks = Path.Combine(env.ContentRootPath, peaksname);


            List<string> peaks = new List<string>();
            using (StreamReader stream = new StreamReader(path))
            {
                try
                {
                    //Получаем пики и заносим их в список
                    peaks = PeaksDetection.GetRPeaks(Reader.StringToPointPair(Reader.GetPoints(path)));
                    //peaks = PeaksDetection.RPeaksToList(pathPeaks);
                }
                catch (ThreadAbortException ex)
                {
                    throw new Exception(ex.InnerException.Message, ex.InnerException.InnerException);
                }
            }
            return peaks;
        }
    }
}
