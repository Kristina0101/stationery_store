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
    /// <summary>
    /// Логика взаимодействия для ReceiptsPage.xaml
    /// </summary>
    public partial class ReceiptsPage : Page
    {
        ReceiptsTableAdapter receipts = new ReceiptsTableAdapter();
        public ReceiptsPage()
        {
            InitializeComponent();
            ReceptsGrid.ItemsSource = receipts.GetData();
        }
        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(add_box.Text))
            {
                MessageBox.Show("Поля пустые или содержат некорректные значения!");
                return;
            }
            receipts.InsertQuery(add_box.Text);
            ReceptsGrid.ItemsSource = receipts.GetData();
            add_box.Text = "";
        }

        private void upload_button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView id = ReceptsGrid.SelectedItem as DataRowView;
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
            if (ReceptsGrid.SelectedItem != null && ReceptsGrid.SelectedItems.Count == 1)
            {
                object id = (ReceptsGrid.SelectedItem as DataRowView).Row[0];
                receipts.DeleteQuery(Convert.ToInt32(id));
                ReceptsGrid.ItemsSource = receipts.GetData();
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
                if (ReceptsGrid.SelectedItem == null && ReceptsGrid.SelectedItems.Count != 1)
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
                        object id = (ReceptsGrid.SelectedItem as DataRowView).Row[0];
                        receipts.UpdateQuery(upload_box.Text, Convert.ToInt32(id));
                        ReceptsGrid.ItemsSource = receipts.GetData();
                        upload_box.Text = "";
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите правильный формат данных!");
            }
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            var id = (ReceptsGrid.SelectedItem as DataRowView).Row[0];
            var fileName = $"C:\\Users\\krist\\OneDrive\\Рабочий стол\\Чек №{id}.txt";

            var dt1 = (ReceptsGrid.SelectedItem as DataRowView).Row[1];

            File.WriteAllText(fileName, $"\t Чек №{id} \nНомер заказа: " + id + "\nДата: " + dt1 + "");
        }
    }
}
