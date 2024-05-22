using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        List<App.Player> players;

        public MenuPage()
        {
            InitializeComponent();

            players = new List<App.Player>();

            using (var cmd = new SQLiteCommand("SELECT * FROM Players_Score ORDER BY Score DESC LIMIT 10", App.cn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        App.Player p = new App.Player();
                        p.Name = (string)reader["Name"];
                        p.Score = (int)(long)reader["Score"];
                        players.Add(p);
                    }
                }
            }

            TableRecord.ItemsSource = players;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("GamePage.xaml", UriKind.Relative));
        }
    }
}
