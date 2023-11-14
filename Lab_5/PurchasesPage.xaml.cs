using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using Lab_5.laboratory_5DataSet1TableAdapters;

namespace Lab_5
{
    public partial class PurchasesPage : Page
    {
        ProductTableAdapter product = new ProductTableAdapter();
        PurchasesTableAdapter purchases = new PurchasesTableAdapter();
        ReceiptsTableAdapter receipts = new ReceiptsTableAdapter();
        public PurchasesPage()
        {
            InitializeComponent();
            ProductsDataGrid.ItemsSource = product.GetData();
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            var id = (ProductsDataGrid.SelectedItem as DataRowView).Row[0];
            var fileName = $"C:\\Users\\krist\\OneDrive\\Рабочий стол\\Чек №{id}.txt";

            var dt1 = (ProductsDataGrid.SelectedItem as DataRowView).Row[1];

            var dt2 = (ProductsDataGrid.SelectedItem as DataRowView).Row[2];

            File.WriteAllText(fileName, $"\t Чек №{id} \nНомер заказа: " + id + "\nНазвание: " + dt1 + "\nСумма: " + dt2 + "");
        }
    }
}
