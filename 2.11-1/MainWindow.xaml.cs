using System;
using System.Windows;

namespace _2._11_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new ViewModel();
        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModel)this.DataContext).NewGame();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
