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
using Lab_5.laboratory_5DataSet1TableAdapters;

namespace Lab_5
{
    /// <summary>
    /// Логика взаимодействия для SellerPage.xaml
    /// </summary>
    public partial class SellerPage : Window
    {
        public SellerPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ProductPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new PurchasesPage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ReceiptsPage();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
