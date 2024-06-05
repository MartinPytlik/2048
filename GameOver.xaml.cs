using System.Collections.Generic;
using System.IO;
using System;
using System.Windows;
using System.Windows.Media;
using static Projekt_2048.MainWindow;

namespace Projekt_2048
{
    public partial class GameOver : Window
    {
        private int score { get; set; }

        private int nejvetsiCislo { get; set; }

        private bool prohra { get; set; }
        public GameOver(int score, int nejvetsiCislo, bool prohra)
        {
            this.score = score;
            this.nejvetsiCislo = nejvetsiCislo;
            this.prohra = prohra;
            InitializeComponent();
            UpdateScore();
        }
        private void UpdateScore()
        {
            if (prohra == true)
            {
                WL.Content = "Prohráli jste!";
                WL.Foreground = Brushes.Red;
            }
            else
            {
                WL.Content = "Vyhrali jste!";
                WL.Foreground = Brushes.Green;
            }
            //string filePathScoreCelkem = "C:\\Users\\Pytlík Martin\\source\\repos\\Projekt_2048\\Score.txt";
            //List<string> nacteneZaznamy = new List<string>();
            //using (StreamReader reader = new StreamReader(filePathScoreCelkem))
            //{
            //    string line;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        nacteneZaznamy.Add(line);
            //    }
            //}
            //    string tretiOdKonce = nacteneZaznamy[nacteneZaznamy.Count - 3];
            //    Console.WriteLine("Třetí záznam od konce je: " + tretiOdKonce);

            Score2.Content = "Scóre: " + score;
            MaxScore.Content = "Největší číslo: " + nejvetsiCislo;

        }

        private void PlayAgainBtn(object sender, RoutedEventArgs e)
        {

            UpdateScore();
            MainWindow window = new MainWindow();
            window.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void ZavritOknoBtn(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }

}