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
using MaterialDesignThemes;
using MaterialDesignColors;
using Lab_5.laboratory_5DataSet1TableAdapters;

namespace Lab_5
{
    public partial class ProductPage : Page
    {
        ProductTableAdapter product = new ProductTableAdapter();
        ClassificationTableAdapter classs = new ClassificationTableAdapter();
        WarehouseTableAdapter warehouse = new WarehouseTableAdapter();
        public ProductPage()
        {
            InitializeComponent();
            ProductGrid.ItemsSource = product.GetData();
            ComboBox1.ItemsSource = classs.GetData();
            ComboBox2.ItemsSource = warehouse.GetData();
            ComboBox1.DisplayMemberPath = "Classification_id";
            ComboBox1.SelectedValuePath = "Classification_id";
            ComboBox2.DisplayMemberPath = "Warehouse_id";
            ComboBox2.SelectedValuePath = "Warehouse_id";
            ComboBox3.ItemsSource = classs.GetData();
            ComboBox4.ItemsSource = warehouse.GetData();
            ComboBox3.DisplayMemberPath = "Classification_id";
            ComboBox3.SelectedValuePath = "Classification_id";
            ComboBox4.DisplayMemberPath = "Warehouse_id";
            ComboBox4.SelectedValuePath = "Warehouse_id";
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Add_box.Text) || string.IsNullOrEmpty(Add_box1.Text) || string.IsNullOrEmpty(ComboBox1.Text) || string.IsNullOrEmpty(Add_box2.Text) || string.IsNullOrEmpty(Add_box3.Text) || string.IsNullOrEmpty(ComboBox2.Text) || Add_box1.Text.Contains("-"))
                {
                    MessageBox.Show("Поля пустые или содержат некорректные значения!");
                    return;
                }
                product.InsertQuery(Add_box.Text, Convert.ToDecimal(Add_box1.Text), Convert.ToInt32(ComboBox1.Text), Add_box2.Text, Add_box3.Text, Convert.ToInt32(ComboBox2.Text));
                ProductGrid.ItemsSource = product.GetData();
                Add_box.Text = "";
                Add_box1.Text = "";
                Add_box2.Text = "";
                Add_box3.Text = "";
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

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox2.SelectedItem as DataRowView).Row[0];
        }
        private void add_think_hide()
        {
            add_text.Visibility = Visibility.Hidden;
            Add_box.Visibility = Visibility.Hidden;
            Add_box1.Visibility = Visibility.Hidden;
            Add_box2.Visibility = Visibility.Hidden;
            Add_box3.Visibility = Visibility.Hidden;
            ComboBox1.Visibility = Visibility.Hidden;
            ComboBox2.Visibility = Visibility.Hidden;
            add_button.Visibility = Visibility.Hidden;
        }

        private void add_think_visible()
        {
            add_text.Visibility = Visibility.Visible;
            Add_box.Visibility = Visibility.Visible;
            Add_box1.Visibility = Visibility.Visible;
            Add_box2.Visibility = Visibility.Visible;
            Add_box3.Visibility = Visibility.Visible;
            ComboBox1.Visibility = Visibility.Visible;
            ComboBox2.Visibility = Visibility.Visible;
            add_button.Visibility = Visibility.Visible;
        }
        private void upload_think_hide()
        {
            upload_text.Visibility = Visibility.Hidden;
            Upload_box.Visibility = Visibility.Hidden;
            Upload_box1.Visibility = Visibility.Hidden;
            Upload_box2.Visibility = Visibility.Hidden;
            Upload_box3.Visibility = Visibility.Hidden;
            ComboBox3.Visibility = Visibility.Hidden;
            ComboBox4.Visibility = Visibility.Hidden;
            Upload_button.Visibility = Visibility.Hidden;
            Upload_button1.Visibility = Visibility.Hidden;
        }

        private void upload_think_visible()
        {
            upload_text.Visibility = Visibility.Visible;
            Upload_box.Visibility = Visibility.Visible;
            Upload_box1.Visibility = Visibility.Visible;
            Upload_box2.Visibility = Visibility.Visible;
            Upload_box3.Visibility = Visibility.Visible;
            ComboBox3.Visibility = Visibility.Visible;
            ComboBox4.Visibility = Visibility.Visible;
            Upload_button.Visibility = Visibility.Visible;
            Upload_button1.Visibility = Visibility.Visible;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            add_think_hide();
            upload_think_visible();
        }

        private void Upload_button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView id = ProductGrid.SelectedItem as DataRowView;
            if (id != null)
            {
                string box1 = id[1].ToString();
                string box2 = id[2].ToString();
                var box3 = id[3];
                string box4 = id[4].ToString();
                string box5 = id[5].ToString();
                var box6 = id[6];

                Upload_box.Text = box1;
                Upload_box1.Text = box2;
                Upload_box2.Text = box4;
                Upload_box3.Text = box5;

                if (box3 != null)
                {
                    ComboBox3.SelectedValue = box3;
                }
                if (box6 != null)
                {
                    ComboBox4.SelectedValue = box6;
                }
            }
            else
            {
                MessageBox.Show("Выберите поле, которое хотите изменить!");
            }
        }

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox3.SelectedItem as DataRowView).Row[0];
        }

        private void ComboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox4.SelectedItem as DataRowView).Row[0];
        }
        private void Upload_button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProductGrid.SelectedItem == null && ProductGrid.SelectedItems.Count != 1)
                {
                    MessageBox.Show("Для изменения данных в таблице нажмите на строчку, которую хотите изменить, а затем на кнопку 'Изменить элементы' и только потом нажимайте на 'Внести изменения'!");
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(Upload_box.Text) || string.IsNullOrEmpty(Upload_box1.Text) || string.IsNullOrEmpty(ComboBox3.Text) || string.IsNullOrEmpty(Upload_box2.Text) || string.IsNullOrEmpty(Upload_box3.Text) || string.IsNullOrEmpty(ComboBox4.Text) || Upload_box1.Text.Contains("-"))
                    {
                        MessageBox.Show("Поля пустые или содержат некорректные значения!");
                        return;
                    }
                    else
                    {
                        object id = (ProductGrid.SelectedItem as DataRowView).Row[0];
                        product.UpdateQuery(Upload_box.Text, Convert.ToDecimal(Upload_box1.Text), Convert.ToInt32(ComboBox3.Text), Upload_box2.Text, Upload_box3.Text, Convert.ToInt32(ComboBox4.Text), Convert.ToInt32(id));
                        ProductGrid.ItemsSource = product.GetData();
                        Upload_box.Text = "";
                        Upload_box1.Text = "";
                        Upload_box2.Text = "";
                        Upload_box3.Text = "";
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
            if (ProductGrid.SelectedItem != null && ProductGrid.SelectedItems.Count == 1)
            {
                object id = (ProductGrid.SelectedItem as DataRowView).Row[0];
                product.DeleteQuery(Convert.ToInt32(id));
                ProductGrid.ItemsSource = product.GetData();
            }
            else
            {
                MessageBox.Show("Выберите поле, которое хотите удалить!");
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            upload_think_hide();
            add_think_visible();
        }
    }
}
