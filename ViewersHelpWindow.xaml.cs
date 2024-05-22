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
    /// Логика взаимодействия для ViewersHelpWindow.xaml
    /// </summary>
    public partial class ViewersHelpWindow : Window
    {
        int[] chartsData = new int[4];


        void GenerateRandomCharts(int rightAnswer)
        {
            int max=0, maxIndex=0;

            for (int i = 0; i < 4; i++)
            {
                chartsData[i] = App.rnd.Next(1, 50);
                if (chartsData[i] > max)
                {
                    max = chartsData[i];
                    maxIndex = i;
                }
            }

            if (maxIndex != rightAnswer - 1)
            {
                chartsData[rightAnswer - 1] = max + 15;
            }
            
        }

        void BuildCharts(string[] answers)
        {
            double height = Variant1Chart.ActualHeight;
            double width = Variant1Chart.ActualWidth;

            int sum = 0;
            for (int i = 0; i < 4; i++)
            {
                sum+=chartsData[i];
            }

            double[] chartsHeight = new double[4];

            for (int i = 0; i < 4; i++)
            {
                chartsHeight[i] = (((double)chartsData[i]) / sum) * height;
            }

            for (int i = 0; i < 4; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Width = 50;
                rect.Height = chartsHeight[i];
                rect.Fill = new SolidColorBrush(Colors.Blue);

                Canvas.SetLeft(rect, (width-50)/2);
                Canvas.SetTop(rect, height- chartsHeight[i]);

                (this.FindName("Variant" + (i + 1) + "Chart") as Canvas).Children.Add(rect);

                (this.FindName("Variant" + (i + 1) + "Text") as TextBlock).Text = answers[i];
            }

            
        }

        string[] answers;
        int rightAnswer;

        public ViewersHelpWindow(string[] answers, int rightAnswer)
        {
            InitializeComponent();

            this.Loaded += ViewersHelpWindow_Loaded;

            this.answers = answers;
            this.rightAnswer = rightAnswer;

            this.Closing += ViewersHelpWindow_Closing;

            App.PlaySoundCycle("C:\\Users\\potor\\source\\repos\\WpfApp3\\WpfApp3\\Sounds\\khsm_aud_voting.mp3");
        }

        private void ViewersHelpWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.StopSoundCycle();
        }

        private void ViewersHelpWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GenerateRandomCharts(rightAnswer);

            BuildCharts(answers);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
