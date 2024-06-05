
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Projekt_2048
{

    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            VygenerujZacatek();
            ScoreDisplay();
            Vybarvy();
        }

        private int[,] HerniPole = new int[4, 4];
        Random random = new Random();
        bool JeVPoli = false;
        int ScoreCelkem = 0;
        int NejvetsiCislo = 0;
        bool Prohra = true;

        protected int Vygeneruj()
        {
            int RadnomCislo = random.Next(1, 9);
            if (RadnomCislo == 8)
            {
                return 4;
            }
            else
            {
                return 2;
            }

        }
        protected void VygenerujZacatek()
        {
            for (int i = 0; i < HerniPole.GetLength(0); i++)
            {
                for (int j = 0; j < HerniPole.GetLength(1); j++)
                {
                    HerniPole[i, j] += 0;
                }
            }
            VykresliPrazdnePole();
            int Cislo1 = Vygeneruj();
            int Cislo2 = Vygeneruj();

            int[] Pozice1 = VygenerujSouradnice();
            int PoziceX1 = Pozice1[0];
            int PoziceY1 = Pozice1[1];

            int[] Pozice2 = VygenerujSouradnice();
            if (Pozice1 == Pozice2)
            {
                Pozice2 = VygenerujSouradnice();
            }
            int PoziceX2 = Pozice2[0];
            int PoziceY2 = Pozice2[1];


            HerniPole[PoziceX1, PoziceY1] += Cislo1;
            HerniPole[PoziceX2, PoziceY2] += Cislo2;
            ZobrazPole();

        }
        private int[] VygenerujSouradnice()
        {
            int[] souradnice = new int[2];
            bool poziceNula = false;

            do
            {
                souradnice[0] = random.Next(0, 4);
                souradnice[1] = random.Next(0, 4);

                if (HerniPole[souradnice[0], souradnice[1]] == 0)
                {
                    poziceNula = true;
                }

            } while (!poziceNula);

            return souradnice;
        }

        public void ZobrazPole()
        {
            VykresliPrazdnePole();
            for (int i = 0; i < HerniPole.GetLength(0); i++)
            {
                for (int j = 0; j < HerniPole.GetLength(1); j++)
                {
                    if (HerniPole[i, j] != 0)
                    {
                        TextBox textBox = GetTextBoxByRowAndColumn(i, j);

                        if (textBox != null)
                        {
                            textBox.Text = HerniPole[i, j].ToString();
                        }
                    }
                }
            }
        }
        private TextBox GetTextBoxByRowAndColumn(int row, int column)
        {
            int textBoxIndex = row * 4 + column + 1;

            return FindName($"Pole{textBoxIndex}") as TextBox;
        }
        public void VykresliPrazdnePole()
        {
            for (int i = 0; i < HerniPole.GetLength(0); i++)
            {
                for (int j = 0; j < HerniPole.GetLength(1); j++)
                {
                    TextBox textBox = GetTextBoxByRowAndColumn(i, j);

                    textBox.Text = string.Empty;

                }
            }
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.Key)
            {
                case Key.Left:
                    MoveLeft();
                    break;
                case Key.Right:
                    MoveRight();
                    break;
                case Key.Up:
                    MoveUp();
                    break;
                case Key.Down:
                    MoveDown();
                    break;
                case Key.Enter:
                    NovaHra();
                    break;
            }
        }


        public void PrictiBody(int body)
        {
            ScoreCelkem += body;
            Score.Text = ScoreCelkem.ToString();
        }

        
        public void SpojCisla(int hodnota)
        {
            int body = hodnota * 2; 
            PrictiBody(body);
        }

        public void ScoreDisplay()
        {
            Score.Text = ScoreCelkem.ToString();

            int max = 0;
            for (int i = 0; i < HerniPole.GetLength(0); i++)
            {
                for (int j = 0; j < HerniPole.GetLength(1); j++)
                {
                    if (HerniPole[i, j] > max)
                    {
                        max = HerniPole[i, j];
                    }
                }
            }
            NejvetsiCislo = max;
        }
        



        public void Vybarvy()
        {
            for (int i = 0; i < HerniPole.GetLength(0); i++)
            {
                for (int j = 0; j < HerniPole.GetLength(1); j++)
                {
                    TextBox textBox = GetTextBoxByRowAndColumn(i, j);
                    string value = HerniPole[i, j].ToString();
                    switch (value)
                    {
                        case "2":
                            textBox.Background = Brushes.LightBlue;
                            break;
                        case "0":
                            textBox.Background = Brushes.LightGreen;
                            break;
                        case "4":
                            textBox.Background = Brushes.Red;
                            break;
                        case "8":
                            textBox.Background = Brushes.Orange;
                            break;
                        case "16":
                            textBox.Background = Brushes.Pink;
                            break;
                        case "32":
                            textBox.Background = Brushes.Yellow;
                            break;
                        case "64":
                            textBox.Background = Brushes.Purple;
                            break;
                        case "128":
                            textBox.Background = Brushes.Green;
                            break;
                        case "256":
                            textBox.Background = Brushes.Cyan;
                            break;
                        case "512":
                            textBox.Background = Brushes.Magenta;
                            break;
                        case "1024":
                            textBox.Background = Brushes.Magenta;
                            break;
                        case "2048":
                            textBox.Background = Brushes.LightGreen;
                            break;
                        default:
                            textBox.Background = Brushes.White;
                            break;
                    }
                }
            }
        }

        private void MoveLeft()
        {
            if (CanMoveLeft())
            {
                for (int row = 0; row < 4; row++)
                {
                    for (int col = 1; col < 4; col++)
                    {
                        if (HerniPole[row, col] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            int currentNumber = HerniPole[row, col];
                            int prevCol = col - 1;

                            while (prevCol >= 0 && HerniPole[row, prevCol] == 0)
                            {
                                prevCol--;
                            }

                            if (prevCol >= 0 && HerniPole[row, prevCol] == currentNumber)
                            {
                                HerniPole[row, prevCol] += currentNumber;
                                HerniPole[row, col] = 0;
                                SpojCisla(currentNumber); 
                            }
                            else
                            {
                                HerniPole[row, prevCol + 1] = currentNumber;
                                if (prevCol + 1 != col)
                                {
                                    HerniPole[row, col] = 0;
                                }
                            }
                        }
                    }
                }

                int cislo = Vygeneruj();

                int[] Pozice1 = VygenerujSouradnice();
                int PoziceX1 = Pozice1[0];
                int PoziceY1 = Pozice1[1];
                HerniPole[PoziceX1, PoziceY1] += cislo;

                ScoreDisplay();
                ZobrazPole();
                DoslaPole();
                JeVPoli2048();
                Vybarvy();
            }
        }


        public bool CanMoveLeft()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 1; col < 4; col++)
                {
                    if (HerniPole[row, col] != 0)
                    {
                        if (HerniPole[row, col - 1] == 0)
                        {
                            return true;
                        }

                        if (HerniPole[row, col - 1] == HerniPole[row, col])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void MoveUp()
        {
            if (CanMoveUp())
            {
                for (int col = 0; col < 4; col++)
                {
                    for (int row = 1; row < 4; row++)
                    {
                        if (HerniPole[row, col] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            int currentNumber = HerniPole[row, col];
                            int prevRow = row - 1;

                            while (prevRow >= 0 && HerniPole[prevRow, col] == 0)
                            {
                                prevRow--;
                            }

                            if (prevRow >= 0 && HerniPole[prevRow, col] == currentNumber)
                            {
                                HerniPole[prevRow, col] += currentNumber;
                                HerniPole[row, col] = 0;
                                SpojCisla(currentNumber);
                            }
                            else
                            {
                                HerniPole[prevRow + 1, col] = currentNumber;
                                if (prevRow + 1 != row)
                                {
                                    HerniPole[row, col] = 0;
                                }
                            }
                        }
                    }
                }

                int cislo = Vygeneruj();

                int[] Pozice1 = VygenerujSouradnice();
                int PoziceX1 = Pozice1[0];
                int PoziceY1 = Pozice1[1];
                HerniPole[PoziceX1, PoziceY1] += cislo;

                ScoreDisplay();
                ZobrazPole();
                DoslaPole();
                JeVPoli2048();
                Vybarvy();
            }
        }

        public bool CanMoveUp()
        {
            for (int col = 0; col < 4; col++)
            {
                for (int row = 1; row < 4; row++)
                {
                    if (HerniPole[row, col] != 0)
                    {
                        if (HerniPole[row - 1, col] == 0)
                        {
                            return true;
                        }

                        if (HerniPole[row - 1, col] == HerniPole[row, col])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public void MoveRight()
        {
            if (CanMoveRight())
            {
                for (int row = 0; row < 4; row++)
                {
                    for (int col = 2; col >= 0; col--)
                    {
                        if (HerniPole[row, col] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            int currentNumber = HerniPole[row, col];
                            int nextCol = col + 1;

                            while (nextCol < 4 && HerniPole[row, nextCol] == 0)
                            {
                                nextCol++;
                            }

                            if (nextCol < 4 && HerniPole[row, nextCol] == currentNumber)
                            {
                                HerniPole[row, nextCol] += currentNumber;
                                HerniPole[row, col] = 0;
                                SpojCisla(currentNumber);
                            }
                            else
                            {
                                HerniPole[row, nextCol - 1] = currentNumber;
                                if (nextCol - 1 != col)
                                {
                                    HerniPole[row, col] = 0;
                                }
                            }
                        }
                    }
                }

                int cislo = Vygeneruj();

                int[] Pozice1 = VygenerujSouradnice();
                int PoziceX1 = Pozice1[0];
                int PoziceY1 = Pozice1[1];
                HerniPole[PoziceX1, PoziceY1] += cislo;

                ScoreDisplay();
                ZobrazPole();
                DoslaPole();
                JeVPoli2048();
                Vybarvy();
            }
        }

        public bool CanMoveRight()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 2; col >= 0; col--)
                {
                    if (HerniPole[row, col] != 0)
                    {
                        if (HerniPole[row, col + 1] == 0)
                        {
                            return true;
                        }

                        if (HerniPole[row, col + 1] == HerniPole[row, col])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void MoveDown()
        {
            if (CanMoveDown())
            {
                for (int col = 0; col < 4; col++)
                {
                    for (int row = 2; row >= 0; row--)
                    {
                        if (HerniPole[row, col] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            int currentNumber = HerniPole[row, col];
                            int nextRow = row + 1;

                            while (nextRow < 4 && HerniPole[nextRow, col] == 0)
                            {
                                nextRow++;
                            }

                            if (nextRow < 4 && HerniPole[nextRow, col] == currentNumber)
                            {
                                HerniPole[nextRow, col] += currentNumber;
                                HerniPole[row, col] = 0;
                                SpojCisla(currentNumber);
                            }
                            else
                            {
                                HerniPole[nextRow - 1, col] = currentNumber;
                                if (nextRow - 1 != row)
                                {
                                    HerniPole[row, col] = 0;
                                }
                            }
                        }
                    }
                }

                int cislo = Vygeneruj();

                int[] Pozice1 = VygenerujSouradnice();
                int PoziceX1 = Pozice1[0];
                int PoziceY1 = Pozice1[1];
                HerniPole[PoziceX1, PoziceY1] += cislo;

                ScoreDisplay();
                ZobrazPole();
                DoslaPole();
                JeVPoli2048();
                Vybarvy();
            }
        }

        public bool CanMoveDown()
        {
            for (int col = 0; col < 4; col++)
            {
                for (int row = 2; row >= 0; row--)
                {
                    if (HerniPole[row, col] != 0)
                    {
                        if (HerniPole[row + 1, col] == 0)
                        {
                            return true;
                        }

                        if (HerniPole[row + 1, col] == HerniPole[row, col])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void Vyhra()
        {
            Prohra = false;
        }

        public void GameOver2()
        {
            if (JeVPoli == true)
            {
                Vyhra();
            }
            else
            {
                GameOver gameOver = new GameOver(ScoreCelkem, NejvetsiCislo, Prohra);
                this.Visibility = Visibility.Hidden;
                gameOver.Show();
                NovaHra();
            }

        }

        protected void NovaHra()

        {
            NejvetsiCislo = 0;
            ScoreCelkem = 0;
            for (int i = 0; i < HerniPole.GetLength(0); i++)
            {
                for (int j = 0; j < HerniPole.GetLength(1); j++)
                {
                    HerniPole[i, j] = 0;
                }
            }

            VygenerujZacatek();
            ZobrazPole();
            Vybarvy();
            ScoreDisplay();

        }


        public void DoslaPole()
        {
            int PocetNul = 0;
            bool lzeSpojit = false;

            for (int i = 0; i < HerniPole.GetLength(0); i++)
            {
                for (int j = 0; j < HerniPole.GetLength(1); j++)
                {
                    if (HerniPole[i, j] == 0)
                    {
                        PocetNul++;
                    }

                    if (j < HerniPole.GetLength(1) - 1 && HerniPole[i, j] == HerniPole[i, j + 1])
                    {
                        lzeSpojit = true;
                    }

                    if (i < HerniPole.GetLength(0) - 1 && HerniPole[i, j] == HerniPole[i + 1, j])
                    {
                        lzeSpojit = true;
                    }
                }
            }

            if (PocetNul == 0 && !lzeSpojit)
            {
                GameOver2();
            }
        }

        public void JeVPoli2048()
        {
            for (int i = 0; i < HerniPole.GetLength(0); i++)
            {
                for (int j = 0; j < HerniPole.GetLength(1); j++)
                {
                    if (HerniPole[i, j] == 2048)
                    {
                        JeVPoli = true;
                    }
                }
            }
            if (JeVPoli == true)
            {
                GameOver2();
            }
        }
    }
}
    

        

        

        
