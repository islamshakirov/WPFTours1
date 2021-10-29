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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace demo
{
    /// <summary>
    /// Логика взаимодействия для Hotelspage.xaml
    /// </summary>
    public partial class Hotelspage : Page
    {
        public Hotelspage()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainWindow.Navigate(new AddEditPage());
        }

        private void Redacthotel1_Click(object sender, RoutedEventArgs e)
        {
            new AddRedactHotelWindow().Show();
        }

        private void Redacthotel2_Click(object sender, RoutedEventArgs e)
        {
            new AddRedactHotelWindow().Show();
        }

        private void Addhotel_Click(object sender, RoutedEventArgs e)
        {
            new AddRedactHotelWindow().Show();
        }
    }
}
