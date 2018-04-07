using System;
using System.ComponentModel.DataAnnotations;

namespace KRD_P1
{
    public class UsersLogin
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}