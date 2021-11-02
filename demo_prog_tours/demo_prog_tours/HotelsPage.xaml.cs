using System;
using System.Collections;
using System.ComponentModel;
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
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        private PagingCollectionView hotelsListPage;

        public HotelsPage()
        {
            InitializeComponent();
        }

        private void BtnDeleteHotel_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGridHotels.SelectedItems.Cast<Hotel>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {hotelsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ToursBase.GetContext().Hotels.RemoveRange(hotelsForRemoving);
                    ToursBase.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    var hotelsList = ToursBase.GetContext().Hotels.ToList();
                    hotelsListPage = new PagingCollectionView(hotelsList, 10);
                    DGridHotels.ItemsSource = hotelsListPage;
                    InfoUpdate();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Hotel));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ToursBase.GetContext().ChangeTracker.Entries().ToList().ForEach(p=>p.Reload());
                var hotelsList = ToursBase.GetContext().Hotels.ToList();
                hotelsListPage = new PagingCollectionView(hotelsList,10);
                DGridHotels.ItemsSource = hotelsListPage;
                InfoUpdate();
                //TravelInRussiaEntities.GetContext().Hotels.ToList();
            }
        }

        private void InfoUpdate()
        {
            TextCurrentPage.Text = String.Format("Страница: {0}", hotelsListPage.CurrentPage);
            TextPageTotal.Text = String.Format("Всего страниц: {0}", hotelsListPage.PageCount);
            TextStringTotal.Text = String.Format("Всего записей: {0}", hotelsListPage.StringCount);
        }

        private void BtnLastPage_Click(object sender, RoutedEventArgs e)
        {
            hotelsListPage.MoveToLastPage();
            InfoUpdate();
        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            hotelsListPage.MoveToNextPage();
            InfoUpdate();
        }

        private void BtnPrevPage_Click(object sender, RoutedEventArgs e)
        {
            hotelsListPage.MoveToPreviousPage();
            InfoUpdate();
        }

        private void BtnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            hotelsListPage.MoveToFirstPage();
            InfoUpdate();
        }
    }


    public class PagingCollectionView : CollectionView
    {
        private readonly IList _innerList;
        private readonly int _itemsPerPage;

        private int currentPage = 1;

        public PagingCollectionView(IList innerList, int itemsPerPage)
            : base(innerList)
        {
            this._innerList = innerList;
            this._itemsPerPage = itemsPerPage;
        }

        public override int Count
        {
            get
            {
                if (this.currentPage < this.PageCount) // page 1..n-1
                {
                    return this._itemsPerPage;
                }
                else // page n
                {
                    var itemsLeft = this._innerList.Count % this._itemsPerPage;
                    if (0 == itemsLeft)
                    {
                        return this._itemsPerPage; // exactly itemsPerPage left
                    }
                    else
                    {
                        // return the remaining items
                        return itemsLeft;
                    }
                }
            }
        }

        public int CurrentPage
        {
            get { return this.currentPage; }
            set
            {
                this.currentPage = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        public int ItemsPerPage { get { return this._itemsPerPage; } }

        public int PageCount
        {
            get
            {
                return (this._innerList.Count + this._itemsPerPage - 1)
                    / this._itemsPerPage;
            }
        }

        public int StringCount
        {
            get
            {
                return this._innerList.Count;
            }
        }


        private int EndIndex
        {
            get
            {
                var end = this.currentPage * this._itemsPerPage - 1;
                return (end > this._innerList.Count) ? this._innerList.Count : end;
            }
        }

        private int StartIndex
        {
            get { return (this.currentPage - 1) * this._itemsPerPage; }
        }

        public override object GetItemAt(int index)
        {
            var offset = index % (this._itemsPerPage);
            return this._innerList[this.StartIndex + offset];
        }

        public void MoveToNextPage()
        {
            if (this.currentPage < this.PageCount)
            {
                this.CurrentPage += 1;
            }
            this.Refresh();
        }

        public void MoveToPreviousPage()
        {
            if (this.currentPage > 1)
            {
                this.CurrentPage -= 1;
            }
            this.Refresh();
        }

        public void MoveToLastPage()
        {
            this.CurrentPage = PageCount;
            this.Refresh();
        }

        public void MoveToFirstPage()
        {
            this.CurrentPage = 1;
            this.Refresh();
        }
    }
}
