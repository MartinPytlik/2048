using System.Windows;

namespace Projekt_2048
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            this.ShowDialog();
        }

        private void HratHru(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void ZavritOknoBtn(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
