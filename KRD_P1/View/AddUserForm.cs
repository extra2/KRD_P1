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
                Street = textBoxStreet.Text
            };
            // load users
            if (!File.Exists("users.xml")) File.Create("users.xml");
            var usersInXml = File.ReadAllText("users.xml");
            var usersFromXML = new XMLProvider().XMLToUsers(usersInXml) ?? new List<User>();
            user.ID = usersFromXML.Count == 0 ? 1 : usersFromXML.Max(f => f.ID) + 1;
            usersFromXML.Add(user); // add user
            // new file (include all users)
            var newXML = new XMLProvider().UsersToXML(usersFromXML);
            File.WriteAllText("users.xml", newXML);
            Close();
        }
    }
}
