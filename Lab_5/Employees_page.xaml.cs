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
    public partial class Employees_page : Page
    {
        EmployeesTableAdapter employees = new EmployeesTableAdapter();
        SalaryTableAdapter salary = new SalaryTableAdapter();
        AuthorizationsTableAdapter auto = new AuthorizationsTableAdapter();
        public Employees_page()
        {
            InitializeComponent();
            people.ItemsSource = employees.GetData();
            ComboBox1.ItemsSource = salary.GetData();
            ComboBox2.ItemsSource = auto.GetData();
            ComboBox1.DisplayMemberPath = "Salary_id";
            ComboBox1.SelectedValuePath = "Salary_id";
            ComboBox2.DisplayMemberPath = "Authorization_id";
            ComboBox2.SelectedValuePath = "Authorization_id";
            ComboBox3.ItemsSource = salary.GetData();
            ComboBox4.ItemsSource = auto.GetData();
            ComboBox3.DisplayMemberPath = "Salary_id";
            ComboBox3.SelectedValuePath = "Salary_id";
            ComboBox4.DisplayMemberPath = "Authorization_id";
            ComboBox4.SelectedValuePath = "Authorization_id";
            add_think_hide();
            upload_think_hide();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Add_box.Text) || string.IsNullOrEmpty(Add_box1.Text) || string.IsNullOrEmpty(Add_box2.Text) || string.IsNullOrEmpty(ComboBox1.Text) || string.IsNullOrEmpty(ComboBox2.Text))
            {
                MessageBox.Show("Заполните все обязательные поля!");
                return;
            }
            employees.InsertQuery(Add_box.Text, Add_box1.Text, Add_box2.Text, Convert.ToInt32(ComboBox1.Text), Convert.ToInt32(ComboBox2.Text));
            people.ItemsSource = employees.GetData();
            Add_box.Text = "";
            Add_box1.Text = "";
            Add_box2.Text = "";
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (people.SelectedItem != null && people.SelectedItems.Count == 1)
            {
                object id = (people.SelectedItem as DataRowView).Row[0];
                employees.DeleteQuery(Convert.ToInt32(id));
                people.ItemsSource = employees.GetData();
            }
            else
            {
                MessageBox.Show("Выберите поле, которое хотите удалить!");
            }
        }

        private void Upload_button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView id = people.SelectedItem as DataRowView;
            if (id != null)
            {
                string box1 = id[1].ToString();
                string box2 = id[2].ToString();
                string box3 = id[3].ToString();
                var box4 = id[4];
                var box5 = id[5];

                Upload_box.Text = box1;
                Upload_box1.Text = box2;
                Upload_box2.Text = box3;

                if(box4 != null)
                {
                    ComboBox3.SelectedValue = box4;
                }
                if (box5 != null)
                {
                    ComboBox4.SelectedValue = box4;
                }
            }
            else
            {
                MessageBox.Show("Выберите поле, которое хотите изменить!");
            }
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

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox1.SelectedItem as DataRowView).Row[0];
        }

        private void ComboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell1 = (ComboBox2.SelectedItem as DataRowView).Row[0];
        }
        private void add_think_hide()
        {
            add_text.Visibility = Visibility.Hidden;
            Add_box.Visibility = Visibility.Hidden;
            Add_box1.Visibility = Visibility.Hidden;
            Add_box2.Visibility = Visibility.Hidden;
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
            ComboBox3.Visibility = Visibility.Visible;
            ComboBox4.Visibility = Visibility.Visible;
            Upload_button.Visibility = Visibility.Visible;
            Upload_button1.Visibility = Visibility.Visible;
        }

        private void Upload_button1_Click(object sender, RoutedEventArgs e)
        {
            if (people.SelectedItem == null && people.SelectedItems.Count != 1)
            {
                MessageBox.Show("Для изменения данных в таблице нажмите на строчку, которую хотите изменить, а затем на кнопку 'Изменить элементы' и только потом нажимайте на 'Внести изменения'!");
                return;
            }
            if (string.IsNullOrEmpty(Upload_box.Text) || string.IsNullOrEmpty(Upload_box1.Text) || string.IsNullOrEmpty(Upload_box2.Text) || string.IsNullOrEmpty(ComboBox3.Text) || string.IsNullOrEmpty(ComboBox4.Text))
            {
                MessageBox.Show("Заполните все обязательные поля!");
                return;
            }
            else
            {
                object id = (people.SelectedItem as DataRowView).Row[0];
                employees.UpdateQuery(Upload_box.Text, Upload_box1.Text, Upload_box2.Text, Convert.ToInt32(ComboBox3.Text), Convert.ToInt32(ComboBox4.Text), Convert.ToInt32(id));
                people.ItemsSource = employees.GetData();
                Upload_box.Text = "";
                Upload_box1.Text = "";
                Upload_box2.Text = "";
            }
        }

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox3.SelectedItem as DataRowView).Row[0];
        }

        private void ComboBox4_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox4.SelectedItem as DataRowView).Row[0];
        }
    }
}
