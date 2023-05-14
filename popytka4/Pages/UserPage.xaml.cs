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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            ListViewForest.ItemsSource = bd_flowersEntities.GetContext().Product.ToList();
        }
        private void ButtonBoz_Click(object sender, RoutedEventArgs e)
        {
            ListViewForest.ItemsSource = bd_flowersEntities.GetContext().Product.OrderBy(p => p.ProductCost).ToList();
        }

        private void ButtonYb_Click(object sender, RoutedEventArgs e)
        {
            ListViewForest.ItemsSource = bd_flowersEntities.GetContext().Product.OrderByDescending(p => p.ProductCost).ToList();
        }
    }
}
