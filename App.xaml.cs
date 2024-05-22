using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;
using System.Windows.Media;
using System.Threading;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public class Question
        {
            string[] variants = new string[4];
            public string Text { get; set; }

            public string[] Variants
            {
                get
                {
                    return variants;
                }
                set
                {
                    variants = value;
                }
            }
            public int Answer { get; set; }
        }

        public class Player
        {
            public string Name { get; set; }

            public int Score { get; set; }
        }

        public static SQLiteConnection cn = new SQLiteConnection();

        public static Random rnd;

        public static MediaPlayer mediaPlayer;

        public static void PlaySound(string path)
        {
            App.mediaPlayer.Close();
            App.mediaPlayer.Open(new Uri(path));
            App.mediaPlayer.Play();
        }

        public static void PlaySoundCycle(string path)
        {
            App.mediaPlayer.Close();
            App.mediaPlayer.Open(new Uri(path));
            App.mediaPlayer.Play();

            App.mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        private static void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            (sender as MediaPlayer).Play();
        }

        public static void StopSound()
        {
            App.mediaPlayer.Close();
        }

        public static void StopSoundCycle()
        {
            App.mediaPlayer.MediaEnded -= MediaPlayer_MediaEnded;
            App.mediaPlayer.Close();
        }
    }
    
}
