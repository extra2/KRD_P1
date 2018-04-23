using System;
using System.Collections.Generic;
using KRD_P1;
using NUnit;
using NUnit.Framework;

namespace KRD_P1Tests
{
    [TestFixture]
    public class UserControllerTestClass
    {
        private UserController _userController;
        private List<User> _users;
        [SetUp]
        public void SetUp()
        {
            _users = new List<User>()
            {
                new User
                {
                    ID = 1,
                    Login = "login",
                    Password = "password",
                    Name = "Adam",
                    Role = "admin",
                    Street = "jasna",
                    Surname = "Kowalski"
                },
                new User()
                {
                    ID = 2,
                    Login = "login",
                    Password = "password",
                    Name = "Jan",
                    Role = "admin",
                    Street = "jasna",
                    Surname = "Kowalski"
                },
                new User()
                {
                    ID = 3,
                    Login = "login",
                    Password = "password",
                    Name = "Adam",
                    Role = "admin",
                    Street = "jasna",
                    Surname = "Kowalski"
                }
            };

            _userController = new UserController();
        }

        [Test]
        public void FindUser_Adam_TwoUsers()
        {
            // Arrange
            string name = "Adam";
            // Act
            var users = _userController.FindUsers(name);
            // Assert
            Assert.IsTrue(users.Count == 2);
        }
    }
}
