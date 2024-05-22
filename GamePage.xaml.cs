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
using static WpfApp3.App;
using static WpfApp3.SafeLevelWindow;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        int level;
        int safeLevel;
        App.Question currentQuestion;
        List<int> prices;
        string player = "";
        bool secondLife = false;

        App.Question GetLevelQuestion(int level)
        {
            App.Question q = new App.Question();

            using (var cmd = new SQLiteCommand("SELECT Question, Variant1, Variant2, Variant3, Variant4, Answer FROM Questions WHERE Level = @level ORDER BY Random() LIMIT 1", App.cn))
            {
                cmd.Parameters.AddWithValue("@level", level);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        q.Text = (string)reader["Question"];
                        for (int i = 0; i < 4; i++)
                        {
                            q.Variants[i] = (string)reader["Variant" + (i + 1)];
                        }
                        q.Answer = (int)(long)reader["Answer"];
                    }
                }
            }

            return q;
        }

        string GetVariantLetter(int variant)
        {
            char c = (char)((int)'А' + variant);
            return new string(c, 1) + ": ";
        }

        void SetQuestion(App.Question q)
        {
            
            currentQuestion = q;
            QuestionText.Text = q.Text;
            Variant1Button.Content = GetVariantLetter(0) + q.Variants[0];
            Variant2Button.Content = GetVariantLetter(1) + q.Variants[1];
            Variant3Button.Content = GetVariantLetter(2) + q.Variants[2];
            Variant4Button.Content = GetVariantLetter(3) + q.Variants[3];
        }

        void BuildLevels()
        {
            List<Label> levels = new List<Label>();

            for (int i = 0; i < prices.Count; i++)
            {
                Label l = new Label();
                l.Content = prices[i].ToString();
                l.HorizontalAlignment = HorizontalAlignment.Stretch;
                l.VerticalAlignment = VerticalAlignment.Stretch;
                l.HorizontalContentAlignment = HorizontalAlignment.Right;
                levels.Add(l);
            }

            levels[level - 1].Background = new SolidColorBrush(Colors.Yellow);
            levels[safeLevel - 1].Background = new SolidColorBrush(Colors.Blue);

            levels.Reverse();

            CurrentLevelList.ItemsSource = levels;
        }

        void ResetButtonsColor()
        {
            Variant1Button.SetResourceReference(Button.BackgroundProperty, SystemColors.ControlBrushKey);
            Variant2Button.SetResourceReference(Button.BackgroundProperty, SystemColors.ControlBrushKey);
            Variant3Button.SetResourceReference(Button.BackgroundProperty, SystemColors.ControlBrushKey);
            Variant4Button.SetResourceReference(Button.BackgroundProperty, SystemColors.ControlBrushKey);
        }

        /*
         "Замена вопроса" 0
         "Помощь зала" 1
         "50 на 50" 2
         "Право на ошибку" 3
         "Звонок другу" 4
        */

        string[] hintNames = new string[]{"Замена вопроса","Помощь зала","50 на 50", "Право на ошибку", "Звонок другу"};

        void BuildHints(List<int> hints)
        {
            List<Button> buttons = new List<Button>();

            for (int i=0;i < hints.Count; i++)
            {
                Button B = new Button();
                B.Content = hintNames[hints[i]];
                B.CommandParameter = hints[i];
                B.Click += B_Click;
                buttons.Add(B);
            }

            Hints.ItemsSource = buttons;
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            int result = (int)((sender as Button).CommandParameter);

            var conf = MessageBox.Show("Вы точно хотите потратить подсказку " + hintNames[result] +"?", "Использование подсказки", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (conf == MessageBoxResult.No) return;

            (sender as Button).Background = new SolidColorBrush(Colors.Red);
            (sender as Button).Click -= B_Click;

            switch (result)
            {
                case 0:

                    HintChangeQuestion();

                    break;
                case 1:
                    HintViewersSupport();
                    break;
                case 2:
                    HintHalfAnswers();
                    break;
                case 3:
                    secondLife = true;
                    break;
                case 4:
                    HintCallFriend();
                    break;
            }
        }

        void HintChangeQuestion()
        {
            string oldQuestion = currentQuestion.Text;

            do
            {
                currentQuestion = GetLevelQuestion(level);
            } while (oldQuestion == currentQuestion.Text);
            SetQuestion(currentQuestion);
        }

        void HintViewersSupport()
        {
            ViewersHelpWindow vw = new ViewersHelpWindow(currentQuestion.Variants, currentQuestion.Answer);
            vw.ShowDialog();
            (this.FindName("Variant" + (currentQuestion.Answer) + "Button") as Button).Background = new SolidColorBrush(Colors.Green);
        }

        void HintHalfAnswers()
        {
            App.PlaySound("C:\\Users\\potor\\source\\repos\\WpfApp3\\WpfApp3\\Sounds\\khsm_50-50.mp3");
            int t1;
            do
            {
                t1 = App.rnd.Next(0, 4);
            } while (t1 == currentQuestion.Answer);

            int t2;
            do
            {
                t2 = App.rnd.Next(0, 4);
            } while (t2 == currentQuestion.Answer || t2 == t1);

            (this.FindName("Variant" + (t1 + 1) + "Button") as Button).Background = new SolidColorBrush(Colors.Red);
            (this.FindName("Variant" + (t2 + 1) + "Button") as Button).Background = new SolidColorBrush(Colors.Red);
        }

        void HintCallFriend()
        {
            CallFriendWindow cw = new CallFriendWindow((string)(this.FindName("Variant" + (currentQuestion.Answer) + "Button") as Button).Content);
            bool res = (bool)cw.ShowDialog();

            if (res)
            {
                (this.FindName("Variant" + (currentQuestion.Answer) + "Button") as Button).Background = new SolidColorBrush(Colors.Green);
            }
        }

        void SetLevels()
        {
            List<Label> levels;
            levels = (List < Label > )CurrentLevelList.ItemsSource;
            levels.Reverse();
            for (int i = 0; i < level - 1; i++)
            {
                levels[i].Background = new SolidColorBrush(Colors.Green);
            }
            levels[level-1].Background = new SolidColorBrush(Colors.Yellow);

            levels.Reverse();

            CurrentLevelList.ItemsSource = levels;
        }

        void EndGame()
        {
            int result;

            if (level<safeLevel)
            {
                result = 0;
            }
            else
            {
                result = prices[safeLevel-1];
            }

            try
            {
                using (var cmd = new SQLiteCommand("INSERT INTO Players_Score VALUES (@name, @score);", App.cn))
                {
                    cmd.Parameters.AddWithValue("@name", player);
                    cmd.Parameters.AddWithValue("@score", result);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                using (var cmd = new SQLiteCommand("UPDATE Players_Score SET Score = max(Score, @score) WHERE Name = @name;", App.cn))
                {
                    cmd.Parameters.AddWithValue("@name", player);
                    cmd.Parameters.AddWithValue("@score", result);

                    cmd.ExecuteNonQuery();
                }
            }

            this.NavigationService.Navigate(new Uri("MenuPage.xaml", UriKind.Relative));
        }

        public GamePage()
        {
            InitializeComponent();

            List<int> hints=new List<int>();

            void GetName(string name)
            {
                player = name;
            }
            void GetHints(List<int> h)
            {
                hints = h;
            }
            void GetSafeLevel(int l)
            {
                safeLevel = l;
            }

            level = 1;

            NameWindow nm = new NameWindow();
            nm.GetNameEvent += GetName;
            nm.ShowDialog();
            nm.GetNameEvent -= GetName;

            HintChooseWindow hw = new HintChooseWindow();
            hw.GetHintsEvent += GetHints;
            hw.ShowDialog();
            hw.GetHintsEvent -= GetHints;

            BuildHints(hints);

            prices = new List<int>();

            using (var cmd = new SQLiteCommand("SELECT Price FROM Level_Prices ORDER BY Level ASC", App.cn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        prices.Add((int)(long)reader["Price"]);
                    }
                }
            }

            SafeLevelWindow sw = new SafeLevelWindow(prices);
            sw.GetSafeLevelEvent += GetSafeLevel;
            sw.ShowDialog();
            sw.GetSafeLevelEvent -= GetSafeLevel;

            App.PlaySound("C:\\Users\\potor\\source\\repos\\WpfApp3\\WpfApp3\\Sounds\\khsm_ld.mp3");

            BuildLevels();

            currentQuestion = GetLevelQuestion(1);

            SetQuestion(currentQuestion);

            //App.PlaySoundCycle("C:\\Users\\potor\\source\\repos\\WpfApp3\\WpfApp3\\Sounds\\q1-5-bed-2008.mp3");
        }

        private void VariantButton_Click(object sender, RoutedEventArgs e)
        {
            int answer = Int32.Parse((string)(sender as Button).CommandParameter);

            //App.StopSoundCycle();

            if (answer == currentQuestion.Answer)
            {
                if (level >= prices.Count)
                {
                    MessageBox.Show("Поздравляем, вы ответили на все вопросы!", "Победа", MessageBoxButton.OK, MessageBoxImage.Information);
                    safeLevel = level;
                    EndGame();
                }
                MessageBox.Show("И это правильный ответ!", "Правильный ответ", MessageBoxButton.OK, MessageBoxImage.Information);

                App.PlaySound("C:\\Users\\potor\\source\\repos\\WpfApp3\\WpfApp3\\Sounds\\khsm_q1-5-correct-o.mp3");

                level++;
                SetLevels();
                ResetButtonsColor();
                currentQuestion = GetLevelQuestion(level);
                SetQuestion(currentQuestion);
            }
            else
            {
                App.PlaySound("C:\\Users\\potor\\source\\repos\\WpfApp3\\WpfApp3\\Sounds\\khsm_q1-5-wrong.mp3");

                if (secondLife)
                {
                    MessageBox.Show("Увы, ответ неверный. Вы воспользовались \"Правом на ошибку\", поэтому у вас есть второй шанс выбрать правильный ответ", "Неправильный ответ", MessageBoxButton.OK, MessageBoxImage.Warning);
                    (sender as Button).Background = new SolidColorBrush(Colors.Red);
                    secondLife = false;
                    return;
                }
                MessageBox.Show("Увы, ответ не верный. Правильный ответ: " + "\n" + "Ваш результат: " + "\nНажмите \"ОК\" чтобы вернуться в меню", "Неправильный ответ", MessageBoxButton.OK, MessageBoxImage.Error);
                EndGame();
            }
        }
    }
}
