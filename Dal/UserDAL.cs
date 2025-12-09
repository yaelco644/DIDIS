
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {
        public UserDAL() { }
        public List<User> SelectAllUsers()
        {
            List<User> users = new List<User>();
            DataTable dt = SQLHelper.SelectData("select * from UsersTBL");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // יוצרת משתמש
                string username = dt.Rows[i]["username"].ToString();
                string password = dt.Rows[i]["password"].ToString();
                string phone = dt.Rows[i]["phoneNumber"].ToString();
                string email = dt.Rows[i]["email"].ToString();
                string address = dt.Rows[i]["address"].ToString();

                User user = new User(username, password, phone, email, address);

                // מכניסה אותו לרשימה
                users.Add(user);
            }
            return users;
        }
        public static bool IsExist(string username, string password) 
        {
            string query = $"select * from [UsersTBL] where username='{username}' and password='{password}'";
            DataTable dt = SQLHelper.SelectData(query);

            if (dt.Rows.Count > 0)
                return true;

            return false;



            //   DataTable dtUser = SQLHelper.SelectData("select * from users where username=N'" + username + "' and password=N'" + password + "'");
            //    DataRow row;

            //if (dtUser.Rows.Count >= 1)
            //{
            //    if (username != "")
            //    {
            //        this.Session["login_user"] = userNameForm;
            //        this.Session["login_userPass"] = passwordFrom;
            //        if (Convert.ToBoolean(row["isAdmin"]) == true)
            //        {
            //            this.Session["user_isAdmin"] = true;
            //            Response.Redirect("Admin.aspx");
            //        }
            //        else
            //        {
            //            this.Session["user_isAdmin"] = false;
            //            Response.Redirect("Menu.aspx");
            //        }
            //    }
            //}
            //else
            //{
            //    errorMsg = "Incorrect password or username<br/>";

        }

        // הכנסת משתמש
        public static void InsertToDB(User user)
        {
            string query = $"" +
                        $"INSERT INTO [UsersTBL] (username, password, phoneNumber, email, address) " +
                        $" VALUES " +
                        $"('{user.Username}', '{user.Password}', '{user.PhoneNumber}', '{user.Email}', '{user.Address}')";
            SQLHelper.DoQuery(query);
        }

    }
}
