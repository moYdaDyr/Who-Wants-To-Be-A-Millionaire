using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            App.cn.ConnectionString = @"Data Source=C:\Users\potor\source\repos\WpfApp3\WpfApp3\bin\WhoWantsToBeAMillionaire.db;";

            App.cn.Open();

            this.Closing += MainWindow_Closing;

            MainFrame.Navigate(new Uri("MenuPage.xaml", UriKind.Relative));

            App.rnd = new Random();

            App.mediaPlayer = new MediaPlayer();

            App.PlaySound("C:\\Users\\potor\\source\\repos\\WpfApp3\\WpfApp3\\Sounds\\hello-new-punter-2008-long.mp3");
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.StopSound();
            App.cn.Close();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
