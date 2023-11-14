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
    public partial class ClassificationPage : Page
    {
        ClassificationTableAdapter classification = new ClassificationTableAdapter();
        public ClassificationPage()
        {
            InitializeComponent();
            ClassificationGrid.ItemsSource = classification.GetData();
        }
        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(add_box.Text))
            {
                MessageBox.Show("Поля пустые или содержат некорректные значения!");
                return;
            }
            classification.InsertQuery(add_box.Text);
            ClassificationGrid.ItemsSource = classification.GetData();
            add_box.Text = "";
        }

        private void upload_button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView id = ClassificationGrid.SelectedItem as DataRowView;
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
            if (ClassificationGrid.SelectedItem != null && ClassificationGrid.SelectedItems.Count == 1)
            {
                object id = (ClassificationGrid.SelectedItem as DataRowView).Row[0];
                classification.DeleteQuery(Convert.ToInt32(id));
                ClassificationGrid.ItemsSource = classification.GetData();
            }
            else
            {
                MessageBox.Show("Выберите поле, которое хотите удалить!");
            }
        }

        private void Upload_button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ClassificationGrid.SelectedItem == null && ClassificationGrid.SelectedItems.Count != 1)
                {
                    MessageBox.Show("Для изменения данных в таблице нажмите на строчку, которую хотите изменить, а затем на кнопку 'Изменить элементы' и только потом нажимайте на 'Внести изменения'!");
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(upload_box.Text))
                    {
                        MessageBox.Show("Поля пустые или содержат некорректные значения!");
                        return;
                    }
                    else
                    {
                        object id = (ClassificationGrid.SelectedItem as DataRowView).Row[0];
                        classification.UpdateQuery(upload_box.Text, Convert.ToInt32(id));
                        ClassificationGrid.ItemsSource = classification.GetData();
                        upload_box.Text = "";
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
