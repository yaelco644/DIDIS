using DAL;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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


namespace DIDIS
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        List<User> users = new List<User>();
        public Register()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            placeholderUsername.Visibility = string.IsNullOrEmpty(txtUsername.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            placeholderPassword.Visibility = string.IsNullOrEmpty(txtPassword.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void txtConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            placeholderConfirmPassword.Visibility = string.IsNullOrEmpty(txtConfirmPassword.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            placeholderPhone.Visibility = string.IsNullOrEmpty(txtPhone.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            placeholderEmail.Visibility = string.IsNullOrEmpty(txtEmail.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            placeholderAddress.Visibility = string.IsNullOrEmpty(txtAddress.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        // כפתור הרשמה
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password; 
            string conPassword = txtConfirmPassword.Password; 
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;

            string isExist = $"select * from UsersTBL where userName=N'{username}'";
            int manyExist = SQLHelper.DoQuery(isExist);

            // אם אחד מהשדות ריק
            if (username == "" || password == "" || conPassword == "" || phone == "" || email == "" || address == "")
                MessageBox.Show("נא למלא את כל השדות");

            // אם הוא קיים כבר
            else if (manyExist > 0)
                MessageBox.Show("שם המשתמש כבר תפוס");

            // אם הסיסמאות לא תואמות
            else if (conPassword != password)
                MessageBox.Show("הסיסמאות לא תואמות");

            // אם עבר את כל הבדיקות
            else
            {
                User user = new User(username, password, phone, email, address);
                UserDAL.InsertToDB(user);
                MessageBox.Show("המשתמש נוסף בהצלחה!");

                users.Add(user);
            }    
        }


        // חזרה לעמוד Login
        private void BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Login()); 
        }
    }
}
