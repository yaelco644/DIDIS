using Microsoft.Win32;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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
using DAL;

namespace DIDIS
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            //הערה 1
            int num = 1;//stam
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // לחבר את המשתמש
            if (UserDAL.IsExist(username, password))
            {
                App.user = new User();
                App.user.Username = username;
                App.user.Password = password;
                App.foodList = new List<Food>();


                Window1 window = new Window1();
                window.Show();
            }
            else
                MessageBox.Show("שם המשתמש והסיסמא לא תואמים");

        }
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Password))
            {
                placeholderPassword.Visibility = Visibility.Visible;
            }
            else
            {
                placeholderPassword.Visibility = Visibility.Collapsed;
            }
        }
        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                placeholderUsername.Visibility = Visibility.Visible;
            }
            else
            {
                placeholderUsername.Visibility = Visibility.Collapsed;
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Register());
        }
        
    }
}
