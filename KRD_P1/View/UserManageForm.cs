using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KRD_P1
{
    public partial class UserManageForm : Form
    {
        public delegate void UserHandler(int index);

        public delegate List<User> GetUsers(string byName);
        public UserController userController = new UserController();
        public UserManageForm()
        {
            InitializeComponent();
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.MultiSelect = false;
            Reload();
        }

        private void buttonPierwszyBaton_Click(object sender, EventArgs e)
        {
            UserHandler handler = userController.AddUser;
            handler.Invoke(0);
            Reload();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var selectedUser = getSelectedUserIndex();
            if (selectedUser == -1) return;

            UserHandler editUser = userController.EditUser;
            editUser.Invoke(0);
            
            DeleteUser();
            Reload();
        }

        public int getSelectedUserIndex()
        {
            int selectedRow;
            try
            {
                selectedRow = dataGridViewUsers.SelectedRows[0].Index;
            }
            catch (Exception)
            {
                return -1;
            }

            return selectedRow;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void DeleteUser()
        {
            var selectedUser = getSelectedUserIndex();
            if (selectedUser == -1) return;

            GetUsers getUsers = userController.GetUsers;
            var usersFromXML = getUsers.Invoke(null);


            if (selectedUser >= usersFromXML.Count || selectedUser < 0) return;
            var userToRemove = usersFromXML.First(i => i.ID == (int)dataGridViewUsers.Rows[selectedUser].Cells[3].Value);
            usersFromXML.Remove(userToRemove);
            var newXML = new XMLProvider().UsersToXML(usersFromXML);
            File.WriteAllText("users.xml", newXML);
            Reload();
        }
        private void Reload()
        {
            GetUsers getUsers = userController.GetUsers;
            var usersFromXML = getUsers.Invoke(null);

            dataGridViewUsers.Rows.Clear();
            if (usersFromXML != null)
                foreach (var user in usersFromXML)
                {
                    dataGridViewUsers.Rows.Add(user.Name, user.Surname, user.Street, user.ID);
                }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var searchOption = textBoxSearch.Text;
            GetUsers getUsers = userController.GetUsers;
            var usersFromXML = getUsers.Invoke(searchOption);

            dataGridViewUsers.Rows.Clear();
            if (usersFromXML != null)
                foreach (var user in usersFromXML)
                {
                    dataGridViewUsers.Rows.Add(user.Name, user.Surname, user.Street, user.ID);
                }
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            buttonSearch_Click(this, null);
        }
    }
}
