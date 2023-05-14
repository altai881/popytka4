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
using popytka4.AplpicationData;
using popytka4.Pages;

namespace popytka4.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            ListViewForest.ItemsSource = bd_flowersEntities.GetContext().Product.ToList();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameClass.Navigate(new NewEditFrorest((sender as Button).DataContext as Product));
        }

        private void ButtonBoz_Click(object sender, RoutedEventArgs e)
        {
            ListViewForest.ItemsSource = bd_flowersEntities.GetContext().Product.OrderBy(p =>p.ProductCost).ToList();
        }

        private void ButtonYb_Click(object sender, RoutedEventArgs e)
        {
            ListViewForest.ItemsSource = bd_flowersEntities.GetContext().Product.OrderByDescending(p => p.ProductCost).ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameClass.Navigate(new NewEditFrorest(null));
        }

        private void Buttondelete_Click(object sender, RoutedEventArgs e)
        {
            var ProductFordel = ListViewForest.SelectedItems.Cast<Product>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следущие элементы {ProductFordel.Count()}", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    bd_flowersEntities.GetContext().Product.RemoveRange(ProductFordel);
                    bd_flowersEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    ListViewForest.ItemsSource = bd_flowersEntities.GetContext().Product.ToList();
                    TextBoxNum.Text = bd_flowersEntities.GetContext().Product.Count().ToString();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
