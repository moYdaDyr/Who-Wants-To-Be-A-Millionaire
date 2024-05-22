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
    /// Логика взаимодействия для HintChooseWindow.xaml
    /// </summary>
    public partial class HintChooseWindow : Window
    {
        public delegate void GetHints(List<int> hints);
        public event GetHints GetHintsEvent;

        public HintChooseWindow()
        {
            InitializeComponent();
        }

        List<int> hints = new List<int>();

        private void HintSelection_Checked(object sender, RoutedEventArgs e)
        {
            App.PlaySound("C:\\Users\\potor\\source\\repos\\WpfApp3\\WpfApp3\\Sounds\\khsm_lifeline_1-.mp3");
            int result = Int32.Parse((string)(sender as CheckBox).CommandParameter);
            hints.Add(result);
        }

        private void HintSelection_Unchecked(object sender, RoutedEventArgs e)
        {
            App.PlaySound("C:\\Users\\potor\\source\\repos\\WpfApp3\\WpfApp3\\Sounds\\khsm_lifeline_1-.mp3");
            int result = Int32.Parse((string)(sender as CheckBox).CommandParameter);
            hints.Remove(result);
        }

        private void GetHintsButton_Click(object sender, RoutedEventArgs e)
        {
            

            if (hints.Count > 3)
            {
                MessageBox.Show("Выберите не больше 3 подсказок на игру. Сейчас вы выбрали " + hints.Count + ".", "Слишком много подсказок!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            GetHintsEvent(hints);
            this.Close();
        }
    }
}
