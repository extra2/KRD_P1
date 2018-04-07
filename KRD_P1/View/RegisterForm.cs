using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            //Fake Users Creator King (FUCK) v1.0 
            //var newAdmin = new UsersLogin();
            //newAdmin.Login = "admin";
            //newAdmin.Password = "admin";
            //newAdmin.Role = "admin";
            //new XMLProvider().AddLoginToXML(newAdmin);
            //for (int i = 0; i < 10; i++)
            //{
            //    newAdmin = new UsersLogin();
            //    newAdmin.Login = "postman" + i;
            //    newAdmin.Password = "postman" + i;
            //    newAdmin.Role = "postman";
            //    new XMLProvider().AddLoginToXML(newAdmin);
            //}
            // ===================================

            var login = textBoxLogin.Text;
            var password = textBoxPassword.Text;
            var role = new XMLProvider().Login(login, password);
            IMessageProvider messages = new MessageBoxProvider();
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
                default: // "register" :D
                    var newUser = new UsersLogin();
                    newUser.Login = login;
                    newUser.Password = password;
                    newUser.Role = "user";
                    new XMLProvider().AddLoginToXML(newUser);
                    messages.SendMessage("New user has been created. You can login as this user.");
                    break;
            }
        }
    }
}
