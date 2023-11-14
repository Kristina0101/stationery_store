using System;
using System.Collections.Generic;
using System.Data;
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
    
    public partial class DiscountPage : Page
    {
        DiscountsTableAdapter dicsount = new DiscountsTableAdapter();
        ProductTableAdapter product = new ProductTableAdapter();
        public DiscountPage()
        {
            InitializeComponent();
            DiscountGrid.ItemsSource = dicsount.GetData();
            ComboBox1.ItemsSource = product.GetData();
            ComboBox1.DisplayMemberPath = "Product_id";
            ComboBox1.SelectedValuePath = "Product_id";
            ComboBox2.ItemsSource = product.GetData();
            ComboBox2.DisplayMemberPath = "Product_id";
            ComboBox2.SelectedValuePath = "Product_id";
        }
        
        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ComboBox1.Text) || string.IsNullOrEmpty(Add_box1.Text) || string.IsNullOrEmpty(Add_box2.Text) || Add_box1.Text.Contains("-") || Add_box2.Text.Contains("-"))
                {

                    MessageBox.Show("Поля пустые или содержат некорректные значения!");
                    return;
                }
                dicsount.InsertQuery(Convert.ToInt32(ComboBox1.Text), Convert.ToInt32(Add_box1.Text), Convert.ToInt32(Add_box2.Text));
                DiscountGrid.ItemsSource = dicsount.GetData();
                Add_box1.Text = "";
                Add_box2.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите правильный формат данных!");
            }
            
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox1.SelectedItem as DataRowView).Row[0];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            upload_think_hide();
            add_think_visible();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            add_think_hide();
            upload_think_visible();
        }
        private void add_think_hide()
        {
            add_text.Visibility = Visibility.Hidden;
            Add_box1.Visibility = Visibility.Hidden;
            Add_box2.Visibility = Visibility.Hidden;
            ComboBox1.Visibility = Visibility.Hidden;
            add_button.Visibility = Visibility.Hidden;
        }

        private void add_think_visible()
        {
            add_text.Visibility = Visibility.Visible;
            Add_box1.Visibility = Visibility.Visible;
            Add_box2.Visibility = Visibility.Visible;
            ComboBox1.Visibility = Visibility.Visible;
            add_button.Visibility = Visibility.Visible;
        }
        private void upload_think_hide()
        {
            upload_text.Visibility = Visibility.Hidden;
            Upload_box1.Visibility = Visibility.Hidden;
            Upload_box2.Visibility = Visibility.Hidden;
            ComboBox2.Visibility = Visibility.Hidden;
            Upload_button.Visibility = Visibility.Hidden;
            Upload_button1.Visibility = Visibility.Hidden;
        }

        private void upload_think_visible()
        {
            upload_text.Visibility = Visibility.Visible;
            Upload_box1.Visibility = Visibility.Visible;
            Upload_box2.Visibility = Visibility.Visible;
            ComboBox2.Visibility = Visibility.Visible;
            Upload_button.Visibility = Visibility.Visible;
            Upload_button1.Visibility = Visibility.Visible;
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox2.SelectedItem as DataRowView).Row[0];
        }

        private void Upload_button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView id = DiscountGrid.SelectedItem as DataRowView;
            if (id != null)
            {
                var box1 = id[1];
                string box2 = id[2].ToString();
                string box3 = id[3].ToString();

                Upload_box1.Text = box2;
                Upload_box2.Text = box3;

                if (box1 != null)
                {
                    ComboBox2.SelectedValue = box1;
                }
            }
            else
            {
                MessageBox.Show("Выберите поле, которое хотите изменить!");
            }
        }

        private void Upload_button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DiscountGrid.SelectedItem == null && DiscountGrid.SelectedItems.Count != 1)
                {
                    MessageBox.Show("Для изменения данных в таблице нажмите на строчку, которую хотите изменить, а затем на кнопку 'Изменить элементы' и только потом нажимайте на 'Внести изменения'!");
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(ComboBox2.Text) || string.IsNullOrEmpty(Upload_box1.Text) || string.IsNullOrEmpty(Upload_box2.Text) || Upload_box1.Text.Contains("-") || Upload_box2.Text.Contains("-"))
                    {
                        MessageBox.Show("Поля пустые или содержат некорректные значения!");
                        return;
                    }
                    else
                    {
                        object id = (DiscountGrid.SelectedItem as DataRowView).Row[0];
                        dicsount.UpdateQuery(Convert.ToInt32(ComboBox2.Text), Convert.ToInt32(Upload_box1.Text), Convert.ToDouble(Upload_box2.Text), Convert.ToInt32(id));
                        DiscountGrid.ItemsSource = dicsount.GetData();
                        Upload_box1.Text = "";
                        Upload_box2.Text = "";
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите правильный формат данных!");
            }
        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (DiscountGrid.SelectedItem != null && DiscountGrid.SelectedItems.Count == 1)
            {
                object id = (DiscountGrid.SelectedItem as DataRowView).Row[0];
                dicsount.DeleteQuery(Convert.ToInt32(id));
                DiscountGrid.ItemsSource = dicsount.GetData();
            }
            else
            {
                MessageBox.Show("Выберите поле, которое хотите удалить!");
            }
           
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Discount> import = Deserealize.DeserealizeOdject<List<Discount>>();
                foreach (var item in import)
                {
                    dicsount.InsertQuery(Convert.ToInt32(item.Product_id), Convert.ToInt32(item.Discounts), Convert.ToDouble(item.Final_price));
                }

                DiscountGrid.ItemsSource = null;
                DiscountGrid.ItemsSource = dicsount.GetData();
            }
            catch
            {
                MessageBox.Show("Выбран неверный файл");
            }
        }
    }
}
