using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KRD_P1.View;

namespace KRD_P1
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //FUCK(); -> create new users
            var login = textBoxLogin.Text;
            var password = textBoxPassword.Text;
            var role = new XMLProvider().Login(login, password);
            IMessageProvider messages = new MessageBoxProvider();
            if (role?.Role == null) return;
            switch (role.Role)
            {
                case "admin":
                    messages.SendMessage("Logged in as admin " + login);
                    new UserManageForm().Show();
                    break;
                case "postman":
                    messages.SendMessage("Logged in as postman " + login);
                    new MainForm().Show();
                    break;
                case "user":
                    messages.SendMessage("Logged in as user " + login);
                    new ClientView(role.ID);
                    break;
                default:
                    messages.SendMessage("User does not exist");
                    break;
            }
        }

        private void FUCK()
        {
            //Fake Users Creator King (FUCK) v1.0
            List<User> userList = new List<User>();
            var xmlProvider = new XMLProvider();
            var newAdmin = new User()
            {
                ID = 1,
                Name = "admin",
                Surname = "admin",
                Login = "admin",
                Password = "admin",
                Role = "admin",
                Street = "admin"
            };
            userList.Add(newAdmin);
            // ===================================
            for (int i = 0; i < 10; i++)
            {
                var newPostman = new User()
                {
                    ID = i + 2,
                    Name = "postman" + i,
                    Surname = "postman" + i,
                    Login = "postman" + i,
                    Password = "postman" + i,
                    Role = "postman",
                    Street = "postman" + i
                };
                userList.Add(newPostman);
            }
            // ===================================
            for (int i = 0; i < 50; i++)
            {
                var newUser = new User()
                {
                    ID = i + 12,
                    Name = "user" + i,
                    Surname = "user" + i,
                    Login = "user" + i,
                    Password = "user" + i,
                    Role = "user",
                    Street = "user" + i
                };
                userList.Add(newUser);
            }

            File.WriteAllText("users.xml", xmlProvider.UsersToXML(userList));
        }
    }
}
