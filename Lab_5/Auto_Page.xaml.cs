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
    public partial class Auto_Page : Page
    {
        AuthorizationsTableAdapter auto = new AuthorizationsTableAdapter();
        RoleTableAdapter roles = new RoleTableAdapter();
        public Auto_Page()
        {
            InitializeComponent();
            AutoGrid.ItemsSource = auto.GetData();
            ComboBox1.ItemsSource = roles.GetData();
            ComboBox1.DisplayMemberPath = "Role_id";
            ComboBox1.SelectedValuePath = "Role_id";
            ComboBox2.ItemsSource = roles.GetData();
            ComboBox2.DisplayMemberPath = "Role_id";
            ComboBox2.SelectedValuePath = "Role_id";
            add_think_hide();
            upload_think_hide();
        }

        private void add_think_hide()
        {
            add_text.Visibility = Visibility.Hidden;
            Add_box.Visibility = Visibility.Hidden;
            Add_box1.Visibility = Visibility.Hidden;
            ComboBox1.Visibility = Visibility.Hidden;
            add_button.Visibility = Visibility.Hidden;
        }

        private void add_think_visible()
        {
            add_text.Visibility = Visibility.Visible;
            Add_box.Visibility = Visibility.Visible;
            Add_box1.Visibility = Visibility.Visible;
            ComboBox1.Visibility = Visibility.Visible;
            add_button.Visibility = Visibility.Visible;
        }
        private void upload_think_hide()
        {
            upload_text.Visibility = Visibility.Hidden;
            Upload_box.Visibility = Visibility.Hidden;
            Upload_box1.Visibility = Visibility.Hidden;
            ComboBox2.Visibility = Visibility.Hidden;
            Upload_button.Visibility = Visibility.Hidden;
            Upload_button1.Visibility = Visibility.Hidden;
        }

        private void upload_think_visible()
        {
            upload_text.Visibility = Visibility.Visible;
            Upload_box.Visibility = Visibility.Visible;
            Upload_box1.Visibility = Visibility.Visible;
            ComboBox2.Visibility = Visibility.Visible;
            Upload_button.Visibility = Visibility.Visible;
            Upload_button1.Visibility = Visibility.Visible;
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox1.SelectedItem as DataRowView).Row[0];
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Add_box.Text) || string.IsNullOrEmpty(Add_box1.Text) || string.IsNullOrEmpty(ComboBox1.Text))
            {
                MessageBox.Show("Заполните все обязательные поля!");
                return;
            }
            auto.InsertQuery(Add_box.Text, Add_box1.Text, Convert.ToInt32(ComboBox1.Text));
            AutoGrid.ItemsSource = auto.GetData();
            Add_box.Text = "";
            Add_box1.Text = "";
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (AutoGrid.SelectedItem != null && AutoGrid.SelectedItems.Count == 1)
            {
                object id = (AutoGrid.SelectedItem as DataRowView).Row[0];
                auto.DeleteQuery(Convert.ToInt32(id));
                AutoGrid.ItemsSource = auto.GetData();
            }
            else
            {
                MessageBox.Show("Выберите поле, которое хотите удалить!");
            }
        }

        private void Upload_button1_Click(object sender, RoutedEventArgs e)
        {
            if (AutoGrid.SelectedItem == null && AutoGrid.SelectedItems.Count != 1)
            {
                MessageBox.Show("Для изменения данных в таблице нажмите на строчку, которую хотите изменить, а затем на кнопку 'Изменить элементы' и только потом нажимайте на 'Внести изменения'!");
                return;
            }
            if (string.IsNullOrEmpty(Upload_box.Text) || string.IsNullOrEmpty(Upload_box1.Text))
            {
                MessageBox.Show("Заполните все обязательные поля!");
                return;
            }
            else
            {
                object id = (AutoGrid.SelectedItem as DataRowView).Row[0];
                auto.UpdateQuery(Upload_box.Text, Upload_box1.Text, Convert.ToInt32(ComboBox2.Text), Convert.ToInt32(id));
                AutoGrid.ItemsSource = auto.GetData();
                Upload_box.Text = "";
                Upload_box1.Text = "";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            upload_think_hide();
            add_think_visible();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            add_think_hide();
            upload_think_visible();
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox2.SelectedItem as DataRowView).Row[0];
        }

        private void Upload_button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView id = AutoGrid.SelectedItem as DataRowView;
            if (id != null && AutoGrid.SelectedItem != null && AutoGrid.SelectedItems.Count == 1)
            {
                string box1 = id[1].ToString();
                string box2 = id[2].ToString();
                var box3 = id[3];

                Upload_box.Text = box1;
                Upload_box1.Text = box2;

                if (box3 != null)
                {
                    ComboBox2.SelectedValue = box3;
                }
            }
            else
            {
                MessageBox.Show("Выберите поле, которое хотите изменить!");
            }
        }
    }
}
