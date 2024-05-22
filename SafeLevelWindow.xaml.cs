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
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для SafeLevelWindow.xaml
    /// </summary>
    public partial class SafeLevelWindow : Window
    {
        public delegate void GetSafeLevel(int level);
        public event GetSafeLevel GetSafeLevelEvent;

        public SafeLevelWindow(List<int> prices)
        {
            InitializeComponent();

            LevelSelector.ItemsSource = prices;
            LevelSelector.SelectedIndex = 0;
        }

        private void ApplyLevelButton_Click(object sender, RoutedEventArgs e)
        {
            GetSafeLevelEvent(LevelSelector.SelectedIndex + 1);
            this.Close();
        }
    }
}
