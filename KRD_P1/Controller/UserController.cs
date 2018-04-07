using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KRD_P1
{
    public class UserController
    {
        public void AddUser(int index)
        {
            var AddUserForm = new AddUserForm(null);
            AddUserForm.Show();
        }

        public void EditUser(int index) // todo: po ID
        {
            var usersFromXML = GetUsers(null);
            User selected = usersFromXML[index];
            var AddUserForm = new AddUserForm(selected);
            AddUserForm.Show();
        }

        public List<User> FindUsers(string byName)
        {
            if (!File.Exists("users.xml")) File.Create("users.xml");
            var usersInXml = File.ReadAllText("users.xml");
            var users = new XMLProvider().XMLToUsers(usersInXml);
            return users.Where(f => f.Name.Contains(byName) || f.Surname.Contains(byName)).ToList();
        }

        public List<User> GetUsers(string byName)
        {
            if (byName != null) return FindUsers(byName);
            if (!File.Exists("users.xml")) File.Create("users.xml");
            var usersInXml = File.ReadAllText("users.xml");
            List<User> usersFromXML = new XMLProvider().XMLToUsers(usersInXml);
            return usersFromXML;
        }

        public void AddUser(User user)
        {
            // load users
            if (!File.Exists("users.xml")) File.Create("users.xml");
            var usersInXml = File.ReadAllText("users.xml");
            var usersFromXML = new XMLProvider().XMLToUsers(usersInXml) ?? new List<User>();
            user.ID = usersFromXML.Count == 0 ? 1 : usersFromXML.Max(f => f.ID) + 1;
            usersFromXML.Add(user); // add user
            // new file (include all users)
            var newXML = new XMLProvider().UsersToXML(usersFromXML);
            File.WriteAllText("users.xml", newXML);
        }

    }
}