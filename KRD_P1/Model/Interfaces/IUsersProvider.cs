using System.Collections.Generic;
using System.Threading.Tasks;

namespace KRD_P1
{
    public interface IUsersProvider
    {
        User GetUser(int id);
        List<User> GetUsers();
        List<User> FindUsers(string Name);
        Task<User> UpdateUser(User user);
        void DeleteUser(int id);

        Task<User> AddUser(User user);
    }
}
