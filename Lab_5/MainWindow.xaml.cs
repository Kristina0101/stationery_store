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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes;
using MaterialDesignColors;
using Lab_5.laboratory_5DataSet1TableAdapters;

namespace Lab_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AuthorizationsTableAdapter adapter = new AuthorizationsTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoTo_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = adapter.GetData().Rows;
            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][1].ToString() != logins.Text || allLogins[i][2].ToString() != passwors.Password)
                {
                    Valid.Text = "Логин или пароль введены неверно! Попробуйте снова или обратитесь к администратору";
                }
                else
                {
                    if (allLogins[i][1].ToString() == logins.Text && allLogins[i][2].ToString() == passwors.Password)
                    {
                        int Role_id = (int)allLogins[i][3];
                        switch (Role_id)
                        {
                            case 1:
                                AdminWindow admin = new AdminWindow();
                                admin.Show();
                                break;
                            case 2:
                                SellerPage Seller = new SellerPage();
                                Seller.Show();
                                break;
                            case 3:
                                SkladWindow sklad = new SkladWindow();
                                sklad.Show();
                                break;
                        }
                        Close();
                    }
                }
            }
        }
    }
}
