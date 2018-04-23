using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using KRD_P1.Wrapper;
using File = System.IO.File;

namespace KRD_P1
{
    public class UserController
    {
        private IFile _file = new Wrapper.File();
        private IUsersProvider _userProvider = new UsersFromDb();
        public void AddUser(int index)
        {
            var AddUserForm = new AddUserForm(null);
            AddUserForm.Show();
        }

        public void EditUser(int index) // todo: po ID
        {
            var users = GetUsers(null);
            User selected = users.FirstOrDefault(u => u.ID == index);
            var AddUserForm = new AddUserForm(selected);
            if (selected != null) _userProvider.DeleteUser(selected.ID);
            AddUserForm.Show();
        }

        public List<User> FindUsers(string byName)
        {
            return _userProvider.FindUsers(byName);
        }

        public List<User> GetUsers(string byName)
        {
            if (byName != null) return FindUsers(byName);
            return _userProvider.GetUsers();
        }

        public void AddUser(User user)
        {
            _userProvider.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            _userProvider.DeleteUser(id);
        }
    }
}