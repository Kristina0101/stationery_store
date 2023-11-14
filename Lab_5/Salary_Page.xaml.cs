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

    public partial class Salary_Page : Page
    {
        SalaryTableAdapter salary = new SalaryTableAdapter();
        public Salary_Page()
        {
            InitializeComponent();
            SalaryGrid.ItemsSource = salary.GetData();
            add_think_hide();
            upload_think_hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            upload_think_hide();
            add_think_visible();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Add_box.Text) || string.IsNullOrEmpty(Add_box1.Text) || string.IsNullOrEmpty(Add_box2.Text) || string.IsNullOrEmpty(Add_box3.Text) || Add_box.Text.Contains("-") || Add_box1.Text.Contains("-") || Add_box2.Text.Contains("-") || Add_box3.Text.Contains("-"))
                {
                    MessageBox.Show("Поля пустые или содержат некорректные значения!");
                    return;
                }
                salary.InsertQuery(Convert.ToInt16(Add_box.Text), Convert.ToDecimal(Add_box1.Text), Convert.ToDecimal(Add_box2.Text), Convert.ToDecimal(Add_box3.Text));
                SalaryGrid.ItemsSource = salary.GetData();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            add_think_hide();
            upload_think_visible();
        }

        private void add_think_hide()
        {
            add_text.Visibility = Visibility.Hidden;
            Add_box.Visibility = Visibility.Hidden;
            Add_box1.Visibility = Visibility.Hidden;
            Add_box2.Visibility = Visibility.Hidden;
            Add_box3.Visibility = Visibility.Hidden;
            add_button.Visibility = Visibility.Hidden;
        }

        private void add_think_visible()
        {
            add_text.Visibility = Visibility.Visible;
            Add_box.Visibility = Visibility.Visible;
            Add_box1.Visibility = Visibility.Visible;
            Add_box2.Visibility = Visibility.Visible;
            Add_box3.Visibility = Visibility.Visible;
            add_button.Visibility = Visibility.Visible;
        }
        private void upload_think_hide()
        {
            upload_text.Visibility = Visibility.Hidden;
            Upload_box.Visibility = Visibility.Hidden;
            Upload_box1.Visibility = Visibility.Hidden;
            Upload_box2.Visibility = Visibility.Hidden;
            Upload_box3.Visibility = Visibility.Hidden;
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
            Upload_button.Visibility = Visibility.Visible;
            Upload_button1.Visibility = Visibility.Visible;
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (SalaryGrid.SelectedItem != null && SalaryGrid.SelectedItems.Count == 1)
            {
                object id = (SalaryGrid.SelectedItem as DataRowView).Row[0];
                salary.DeleteQuery(Convert.ToInt32(id));
                SalaryGrid.ItemsSource = salary.GetData();
            }
            else
            {
                MessageBox.Show("Выберите поле, которое хотите удалить!");
            }
        }

        private void Upload_button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView id = SalaryGrid.SelectedItem as DataRowView;
            if (id != null)
            {
                string box1 = id[1].ToString();
                string box2 = id[2].ToString();
                string box3 = id[3].ToString();
                string box4 = id[4].ToString();

                Upload_box.Text = box1;
                Upload_box1.Text = box2;
                Upload_box2.Text = box3;
                Upload_box3.Text = box4;
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
                if (SalaryGrid.SelectedItem == null && SalaryGrid.SelectedItems.Count != 1 )
                {
                    MessageBox.Show("Для изменения данных в таблице нажмите на строчку, которую хотите изменить, а затем на кнопку 'Изменить элементы' и только потом нажимайте на 'Внести изменения'!");
                    return;
                }
                else
                {
                    if(string.IsNullOrEmpty(Upload_box.Text) || string.IsNullOrEmpty(Upload_box1.Text) || string.IsNullOrEmpty(Upload_box2.Text) || string.IsNullOrEmpty(Upload_box3.Text) || Upload_box.Text.Contains("-") || Upload_box1.Text.Contains("-") || Upload_box2.Text.Contains("-") || Upload_box3.Text.Contains("-"))
                    {
                        MessageBox.Show("Поля пустые или содержат некорректные значения!");
                        return;
                    }
                    else
                    {
                        object id = (SalaryGrid.SelectedItem as DataRowView).Row[0];
                        salary.UpdateQuery(Convert.ToInt16(Upload_box.Text), Convert.ToDecimal(Upload_box1.Text), Convert.ToDecimal(Upload_box2.Text), Convert.ToDecimal(Upload_box3.Text), Convert.ToInt32(id));
                        SalaryGrid.ItemsSource = salary.GetData();
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
    }
}
