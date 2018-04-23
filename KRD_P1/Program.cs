using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KRD_P1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            new UsersFromDb().AddUser(new User()
            {
                Login = "postman",
                Name = "postman",
                Password = "postman",
                Role = "postman",
                Street = "postman",
                Surname = "surname"
            });
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RegisterForm());
        }
    }
}
