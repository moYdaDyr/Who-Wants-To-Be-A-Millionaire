using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для CallFriendWindow.xaml
    /// </summary>
    public partial class CallFriendWindow : Window
    {
        string GenerateNumber()
        {
            string result="";
            for (int i = 0; i < 11; i++)
            {
                int n = App.rnd.Next(0, 10);
                result += n.ToString();
            }
            return result;
        }

        string number;

        int countdown=30;

        string rightAnswer;

        bool countdownStarted = false;

        bool CheckNumber()
        {
            return number.StartsWith(NumberBox.Text);
        }

        System.Windows.Threading.DispatcherTimer dispatcherTimer;

        public CallFriendWindow(string answer)
        {
            InitializeComponent();

            App.PlaySoundCycle("C:\\Users\\potor\\source\\repos\\WpfApp3\\WpfApp3\\Sounds\\khsm_phone_countdown.mp3");

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            number = GenerateNumber();
            NumberText.Content = number;
            CountdownText.Text = countdown.ToString();

            rightAnswer = answer;

            this.Closing += CallFriendWindow_Closing;
        }

        private void CallFriendWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.StopSoundCycle();
        }

        void CloseCustom()
        {
            dispatcherTimer.Tick -= Tick;
            this.Close();
        }

        private void Tick(object sender, EventArgs e)
        {
            if (countdown == 0)
            {
                dispatcherTimer.Stop();

                App.PlaySound("C:\\Users\\potor\\source\\repos\\WpfApp3\\WpfApp3\\Sounds\\time_freeze.mp3");

                var result = CheckNumber();
                if (result)
                {
                    MessageBox.Show("Вам удалось связаться с другом и он подсказал вам правильный ответ: " + rightAnswer, "Звонок другу", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    CloseCustom();
                    return;
                }
                MessageBox.Show("Вы не успели дозвониться в назначенный срок", "Звонок другу", MessageBoxButton.OK, MessageBoxImage.Error);
                this.DialogResult = false;
                CloseCustom();
                return;
            }
            countdown--;
            CountdownText.Text = countdown.ToString();
        }

        private void CallButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            var result = CheckNumber();
            if (result)
            {
                MessageBox.Show("Вам удалось связаться с другом и он подсказал вам правильный ответ: " + rightAnswer, "Звонок другу", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                CloseCustom();
                return;
            }
            MessageBox.Show("Неправильный номер!", "Звонок другу", MessageBoxButton.OK, MessageBoxImage.Error);
            if (countdown < 0)
            {
                this.DialogResult = false;
                CloseCustom();
                return;
            }
        }

        private void NumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!countdownStarted)
            {
                countdownStarted = true;
                dispatcherTimer.Start();
            }
        }
    }
}
