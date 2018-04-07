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
    public partial class AddUserForm : Form
    {
        public delegate void AddUser(User user);
        public UserController userController = new UserController();
        public AddUserForm(User user)
        {
            InitializeComponent();
            if (user != null) FillTextBoxes(user);
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
                Login = textBoxName.Text,
                Password = "password",
                Role = "user"
            };
            AddUser addUser = userController.AddUser;
            addUser.Invoke(user);
            Close();
        }
    }
}
