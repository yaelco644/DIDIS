using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseEntity
    {
        private string username;
        private string password;
        private string phoneNumber;
        private string email;
        private string address;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        public User() { }

        public User(string username, string password, string phoneNumber, string email, string address)
        {
            this.username = username;
            this.password = password;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.address = address;
        }
    }
}
