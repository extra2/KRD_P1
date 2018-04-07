using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KRD_P1
{
    public partial class UserManageForm : Form
    {
        public UserManageForm()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            Reload();
        }

        private void buttonPierwszyBaton_Click(object sender, EventArgs e)
        {
            var AddUserForm = new AddUserForm(null);
            AddUserForm.Show();
            Reload();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedRow;
            try
            {
                selectedRow = dataGridView1.SelectedRows[0].Index;
            }
            catch (Exception)
            {
                return;
            }

            if (!File.Exists("users.xml")) File.Create("users.xml");
            var usersInXml = File.ReadAllText("users.xml");
            List<User> usersFromXML = new XMLProvider().XMLToUsers(usersInXml);
            User selected = usersFromXML[selectedRow];
            var AddUserForm = new AddUserForm(selected);
            AddUserForm.Show();
            DeleteUser();
            Reload();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void DeleteUser()
        {
            if (!File.Exists("users.xml")) File.Create("users.xml");
            var usersInXml = File.ReadAllText("users.xml");
            List<User> usersFromXML = new XMLProvider().XMLToUsers(usersInXml);
            int selectedRow;
            try
            {
                selectedRow = dataGridView1.SelectedRows[0].Index;
            }
            catch (Exception)
            {
                return;
            }

            if (selectedRow >= usersFromXML.Count || selectedRow < 0) return;
            var userToRemove = usersFromXML.First(i => i.ID == (int) dataGridView1.Rows[selectedRow].Cells[3].Value);
            usersFromXML.Remove(userToRemove);
            var newXML = new XMLProvider().UsersToXML(usersFromXML);
            File.WriteAllText("users.xml", newXML);
            Reload();
        }
        private void Reload()
        {
            if (!File.Exists("users.xml")) File.Create("users.xml");
            var usersInXml = File.ReadAllText("users.xml");
            List<User> usersFromXML = new XMLProvider().XMLToUsers(usersInXml);
            dataGridView1.Rows.Clear();
            if(usersFromXML != null)
            foreach (var user in usersFromXML)
            {
                dataGridView1.Rows.Add(user.Name, user.Surname, user.Street, user.ID);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var searchOption = textBoxSearch.Text;
            if (!File.Exists("users.xml")) File.Create("users.xml");
            var usersInXml = File.ReadAllText("users.xml");
            List<User> usersFromXML = new XMLProvider().XMLToUsers(usersInXml);
            usersFromXML = usersFromXML.Where(f => f.Name.Contains(searchOption) || f.Surname.Contains(searchOption)).ToList();
            dataGridView1.Rows.Clear();
            if (usersFromXML != null)
                foreach (var user in usersFromXML)
                {
                    dataGridView1.Rows.Add(user.Name, user.Surname, user.Street, user.ID);
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
