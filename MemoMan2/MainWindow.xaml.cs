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
using Newtonsoft.Json;

namespace MemoMan2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<SaveData> datas = new List<SaveData>();

        private SaveData Data;

        //最初に呼び出される
        public MainWindow() : this(new SaveData())
        {
            
        }
        public MainWindow(SaveData data)
        {
            InitializeComponent();
            Data = data;
            datas.Add(Data);

            this.MoonLight.TextChanged += MoonLight_TextChanged;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            datas.Remove(Data);
            this.Close();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            var newmemo = new MainWindow(new SaveData());
            newmemo.Show();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MoonLight_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}