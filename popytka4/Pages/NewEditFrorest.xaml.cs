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
    /// Логика взаимодействия для NewEditFrorest.xaml
    /// </summary>
    public partial class NewEditFrorest : Page
    {
        private static Product _curectProduct = new Product();
        public NewEditFrorest(Product selectedProduct)
        {
            if (_curectProduct != null)
            {
                _curectProduct = selectedProduct;

            }
            DataContext = _curectProduct;
            InitializeComponent();
            ComboBoxMeasure.DisplayMemberPath = "MeasureName";
            ComboBoxMeasure.SelectedValuePath = "MeasureID";
            ComboBoxMeasure.ItemsSource = bd_flowersEntities.GetContext().Measure.ToList();
            ComboBoxSupplier.DisplayMemberPath = "SupplierName";
            ComboBoxSupplier.SelectedValuePath = "SupplierID";
            ComboBoxSupplier.ItemsSource = bd_flowersEntities.GetContext().Supplier.ToList();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (_curectProduct.ProductArticleNumber == "")
            {
                bd_flowersEntities.GetContext().Product.Add(_curectProduct);
                
            }
            try
            {
                bd_flowersEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
