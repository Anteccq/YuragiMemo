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

        //データ用リスト
        private static List<SaveData> datas = new List<SaveData>();

        private SaveData _datas;
        private double rightEnd;

        private SaveData Data
        {
            get
            {
                return _datas;
            }
            set
            {
                this._datas = value;
                this.Left = _datas.Left;
                this.Top = _datas.Top;
                this.Background = _datas.WorldColor.BackGroundColor;
                this.MoonLight.Foreground = _datas.WorldColor.ForeGroundColor;
                this.MoonLight.Text = _datas.Text;
            }
        }

        //初期状態での呼び出し
        public MainWindow()
        {
            if (!Directory.Exists(App.PATH)) Directory.CreateDirectory(App.PATH);
            InitializeComponent();
            rightEnd = SystemParameters.WorkArea.Width - this.Width;

            //ファイルが存在
            if (File.Exists(App.Filepath))
            {
                string Tako;
                using (var s = new StreamReader(App.Filepath, Encoding.UTF8))
                {
                    Tako = s.ReadToEnd();
                }

                var rawdatas = JsonConvert.DeserializeObject<List<LoadData>>(File.ReadAllText(App.Filepath));

                MessageBox.Show(File.ReadAllText(App.Filepath));

                foreach(var gyaku in rawdatas)
                {
                    MessageBox.Show(gyaku.WorldColor.BackGroundColor.ToString() + " : " + gyaku.Text);
                }
                if (rawdatas.Count == 0)
                {
                    Data = new SaveData();
                    datas.Add(Data);
                }
                var isFirst = true;
                foreach (var data in rawdatas)
                {
                    if (isFirst)
                    {
                        Data = data;
                        datas.Add(Data);
                        isFirst = false;
                        continue;
                    }
                    var newmemo = new MainWindow(data);
                    newmemo.Show();
                }
            }
            else
            {
                Data = new SaveData();
                datas.Add(Data);
            }
            this.MoonLight.TextChanged += MoonLight_TextChanged;

        }
        public MainWindow(SaveData data)
        {
            InitializeComponent();
            rightEnd = SystemParameters.WorkArea.Width - this.Width;
            Data = data;
            datas.Add(Data);
            this.MoonLight.TextChanged += MoonLight_TextChanged;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            datas.Remove(Data);
            DataWrite();
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
            if (this.Left >= rightEnd) this.Left = rightEnd;
            if (this.Left < 0) this.Left = 0;
            Data.Left = this.Left;
            Data.Top = this.Top;
            DataWrite();
        }

        private void MoonLight_TextChanged(object sender, TextChangedEventArgs e)
        {
            Data.Text = this.MoonLight.Text;
            DataWrite();
        }

        private static void DataWrite()
        {
            MessageBox.Show("ばちっ");
            var saves = new List<SaveData>(datas);
            var json = JsonConvert.SerializeObject(saves, Formatting.Indented);
            if (!Directory.Exists(App.PATH)) Directory.CreateDirectory(App.PATH);
            using (var stream = new StreamWriter(App.Filepath, false, Encoding.UTF8))
            {
                stream.Write(json);
            }
        }

        private void ColorChangeButton_Click(object sender, RoutedEventArgs e)
        {
            var color = ((ColorData)((Button)sender).DataContext);
            Data.WorldColor.BackGroundColor = color.BackGroundColor;
            Data.WorldColor.ForeGroundColor = color.ForeGroundColor;
            MessageBox.Show(Data.WorldColor.BackGroundColor.ToString() + "\n" + Data.WorldColor.ForeGroundColor.ToString());

            this.Background = color.BackGroundColor;
            this.MoonLight.Background = color.BackGroundColor;
            this.MoonLight.Foreground = color.ForeGroundColor;
            this.PanelPop.IsOpen = false;
            DataWrite();
        }
    }
    /*public class StackPanelViewModel : DependencyObject
    {
        public static readonly DependencyProperty StackPanelVisibility = DependencyProperty.Register("Visibility", typeof(Visibility), typeof(StackPanel));

        public Visibility GetVisibility
        {
            get { return (Visibility)this.GetValue(StackPanelVisibility); }
            set { this.SetValue(StackPanelVisibility, value); }
        }
    }*/
}