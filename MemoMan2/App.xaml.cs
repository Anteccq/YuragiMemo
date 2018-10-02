using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MemoMan2
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        public static string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ProjectATR\MemoMan2";
        public static readonly string Filepath = PATH + @"\memo";
        public static readonly string _Filepath = PATH + @"\.memo";

        public static string FileRead(int number)
        {
            string text = "";
            if (File.Exists(App.Filepath + number))
            {
                using (var stream = new StreamReader(App.Filepath + number, Encoding.UTF8))
                {
                    text = stream.ReadToEnd();
                }
            }
            return text;
        }

        public static void FileWrite(int number, string text)
        {
            try
            {
                using (var stream = new StreamWriter(App.Filepath + number, false, Encoding.UTF8))
                {
                    stream.Write(text);
                }
            }
            catch { }
        }
        public static void PointWrite(double left, double top, int number)
        {
            using (StreamWriter sw = new StreamWriter(App._Filepath + number, false, Encoding.GetEncoding("utf-8")))
            {
                sw.WriteLine("DO_NOT_DELETE");
                sw.WriteLine("Left:" + left);
                sw.WriteLine("Top:" + top);
            }
        }
    }
}
