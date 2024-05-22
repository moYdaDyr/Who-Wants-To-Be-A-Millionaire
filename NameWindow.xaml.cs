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
    /// Логика взаимодействия для NameWindow.xaml
    /// </summary>
    public partial class NameWindow : Window
    {
        public delegate void GetName(string name);
        public event GetName GetNameEvent;

        public NameWindow()
        {
            InitializeComponent();
        }

        string name;

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            name = NameBox.Text;
        }

        private void SaveNameButton_Click(object sender, RoutedEventArgs e)
        {
            if (name.Length == 0)
            {
                MessageBox.Show("Имя не может быть пустым!", "Неправильное имя", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            GetNameEvent(name);
            this.Close();
        }
    }
}
