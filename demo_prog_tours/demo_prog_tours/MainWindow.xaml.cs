using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            {
                //ImportTours();
                FrameManager.MainFrame = MainFrame;
                FrameManager.MainFrame.Navigate(new ToursPage());
            }
        
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void BtnHotelsPage_Click(object sender, RoutedEventArgs e)
        {
           FrameManager.MainFrame.Navigate(new HotelsPage());
        }


        private void BtnAddEditPage_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void ImportTours()
        {
            var fileData = File.ReadAllLines(@"D:\Word\4 курс\ОСЕНЬ\Внедрение и поддержка КС\Демо\ДЭ\import\Туры.txt");
            var images = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Resources\Туры фото");

            foreach (var line in fileData)
            {
                var data = line.Split('\t');

                var tempTour = new Tour
                {
                    Name = data[0].Replace("\"",""),
                    TicketCount=int.Parse(data[2]),
                    Price=decimal.Parse(data[3]),
                    IsActual=(data[4]=="0") ? false:true
                };

                foreach(var tourType in data[5].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var currentType = ToursBase.GetContext().Types.ToList().FirstOrDefault(p => p.Name == tourType);
                    if (currentType != null)
                        tempTour.Types.Add(currentType);
                }

                try
                {
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }
    }
}
