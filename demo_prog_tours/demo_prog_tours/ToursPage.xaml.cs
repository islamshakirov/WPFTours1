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

namespace TravelInRussia
{
    /// <summary>
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        List<Tour> currentTours;

        public ToursPage()
        {
            InitializeComponent();

            var allTypes = ToursBase.GetContext().Types.ToList();
            allTypes.Insert(0, new Type
            {
                Name = "Все типы"
            });
            ComboType.ItemsSource = allTypes;

            CheckActual.IsChecked = true;
            ComboType.SelectedIndex = 0;

            UpdateTours();
        }

        private void UpdateTours()
        {
            currentTours = ToursBase.GetContext().Tours.ToList();

            if (ComboType.SelectedIndex > 0)
                currentTours = currentTours.Where(p=>p.Types.Contains(ComboType.SelectedItem as Type)).ToList();

            currentTours = currentTours.Where(p=>p.Name.ToLower().Contains(TBoxSearchName.Text.ToLower())).ToList();
            //currentTours = currentTours.Where(p => p.Description.ToLower().Contains(TBoxSearchDescription.Text.ToLower())).ToList();

            if (CheckActual.IsChecked.Value)
                currentTours = currentTours.Where(p => p.IsActual).ToList();

            LViewTours.ItemsSource = currentTours.OrderBy(p => p.TicketCount).ToList();
            var TotalPrice= currentTours.Sum(p => p.TicketCount * p.Price);
            TextTotalPrice.Text = String.Format("Общая стоимость туров: {0:N2} РУБ",TotalPrice);
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }

        private void CheckActual_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }


        private void BtnPriceIncr_Click(object sender, RoutedEventArgs e)
        {
            LViewTours.ItemsSource = currentTours.OrderBy(p=>p.Price);
        }

        private void BtnPriceDecr_Click(object sender, RoutedEventArgs e)
        {
            LViewTours.ItemsSource = currentTours.OrderByDescending(p => p.Price);
        }
    }
}
