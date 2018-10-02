using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;

namespace MemoMan2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private int Number; 

        public MainWindow() : this(0)
        {

        }

        public MainWindow(int number)
        {
            InitializeComponent();
            this.Number = number;

            //初期起動状態
            if (number == 0)
            {
                
                //フォルダがあるかどうか--新規作成
                if (!Directory.Exists(App.PATH)) Directory.CreateDirectory(App.PATH);
                else
                {
                    int filecount;
                    if( (filecount = Directory.GetFiles(App.PATH,"memo*",SearchOption.TopDirectoryOnly).Length) > 1){
                        for (int i = 1; i < filecount; i++)
                        {
                            if (File.Exists(App.Filepath + i))
                            {
                                var newmemo = new MainWindow(i);
                                newmemo.Show();
                            }
                        }
                    }
                }
            }

            //ファイルが見つかるか確認
            if(File.Exists(App.Filepath + this.Number))
            {
                this.MoonLight.Text = App.FileRead(this.Number);
            }
            else
            {
                File.CreateText(App.Filepath + this.Number);
            }
            this.MoonLight.TextChanged += MoonLight_TextChanged;

            if (!PointReader())
            {
                App.PointWrite(this.Left, this.Top, this.Number);
            }

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if(File.Exists(App.Filepath + this.Number)) File.Delete(App.Filepath + this.Number);
            if (File.Exists(App._Filepath + this.Number)) File.Delete(App._Filepath + this.Number);
            this.Close();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            int num = 1;
            int filecount = Directory.GetFiles(App.PATH, "*", SearchOption.TopDirectoryOnly).Length;
            if (filecount > 0) num = filecount;
            var newmemo = new MainWindow(filecount);
            newmemo.Show();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            App.PointWrite(this.Left, this.Top, this.Number);
        }

        private void MoonLight_TextChanged(object sender, TextChangedEventArgs e)
        {
            App.FileWrite(this.Number, this.MoonLight.Text);
        }

        private bool PointReader()
        {
            if (File.Exists(App._Filepath + this.Number))
            {
                using (StreamReader sr = new StreamReader(App._Filepath + this.Number, Encoding.GetEncoding("utf-8")))
                {
                    string data;
                    while ((data = sr.ReadLine()) != null)
                    {
                        if (data.IndexOf("Left:") != -1) this.Left = double.Parse(data.Replace("Left:", ""));
                        if (data.IndexOf("Top:") != -1) this.Top = double.Parse(data.Replace("Top:", ""));
                    }
                }
            }
            else return false;

            return true;
        }
    }

}