using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KRD_P1
{
    public delegate void AddUser(User user);
    public partial class AddUserForm : Form
    {
        
        public UserController userController = new UserController();
        public AddUserForm(User user)
        {
            InitializeComponent();
            if (user != null) FillTextBoxes(user);
            var roles = new List<string>() {"user", "admin", "postman"};
            comboBoxRole.DataSource = roles;
        }

        public void FillTextBoxes(User user)
        {
            textBoxName.Text = user.Name;
            textBoxSurname.Text = user.Surname;
            textBoxStreet.Text = user.Street;
        }
        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            // create user
            var user = new User
            {
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Street = textBoxStreet.Text,
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text,
                Role = comboBoxRole.Text
            };
            // to delegate
            AddUser addUser = userController.AddUser;
            addUser.Invoke(user);
            Close();
        }
    }
}
