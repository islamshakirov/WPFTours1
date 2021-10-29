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

namespace demo
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();

            MainWindow.Navigate(new Tourspage());
            Manager.MainWindow = MainWindow;
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainWindow.GoBack();
        }

        private void MainWindow_ContentRendered(object sender, EventArgs e)
        {
            if (MainWindow.CanGoBack)
            {
                backbtn.Visibility = Visibility.Visible;
            }
            else
            {
                backbtn.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainWindow.Navigate(new Hotelspage());
        }
    }
}
