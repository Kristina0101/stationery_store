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
    public partial class RolePage : Page
    {
        RoleTableAdapter roles = new RoleTableAdapter();
        public RolePage()
        {
            InitializeComponent();
            Roles.ItemsSource = roles.GetData();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(add_box.Text))
            {
                MessageBox.Show("Заполните все обязательные поля!");
                return;
            }
            roles.InsertQuery(add_box.Text);
            Roles.ItemsSource = roles.GetData();
            add_box.Text = "";
        }

        private void upload_button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView id = Roles.SelectedItem as DataRowView;
            if (id != null)
            {
                string box1 = id[1].ToString();
                upload_box.Text = box1;
            }
            else
            {
                MessageBox.Show("Выберите поле, которое хотите изменить!");
            }
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (Roles.SelectedItem != null && Roles.SelectedItems.Count == 1)
            {
                object id = (Roles.SelectedItem as DataRowView).Row[0];
                roles.DeleteQuery(Convert.ToInt32(id));
                Roles.ItemsSource = roles.GetData();
            }
            else
            {
                MessageBox.Show("Выберите поле, которое хотите удалить!");
            }
            
        }
        private void Upload_button1_Click(object sender, RoutedEventArgs e)
        {
            if (Roles.SelectedItem == null && Roles.SelectedItems.Count != 1)
            {
                MessageBox.Show("Для изменения данных в таблице нажмите на строчку, которую хотите изменить, а затем на кнопку 'Изменить элемент' и только потом нажимайте на 'Внести изменения'!");
                return;
            }
            if (string.IsNullOrEmpty(upload_box.Text))
            {
                MessageBox.Show("Заполните все обязательные поля!");
                return;
            }
            else
            {
                object id = (Roles.SelectedItem as DataRowView).Row[0];
                roles.UpdateQuery(upload_box.Text, Convert.ToInt32(id));
                Roles.ItemsSource = roles.GetData();
                upload_box.Text = "";
            }
        }
    }
}
