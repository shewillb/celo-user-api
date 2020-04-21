using celo_user_api.Models;
using celo_user_api.Repository;
using celo_user_api_test.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace celo_user_api_test.Repository
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private readonly IUserRepository userRepository = null;

        public UserRepositoryTest()
        {
            userRepository = MockConfiguration.MockVehicleRepository.Object;
        }

        [Test, Order(1)]
        public void CheckIfUsersAreAvailableAndMatchingTheTestDataCount()
        {
            var users = userRepository.GetAll();

            Assert.IsNotNull(users);
            Assert.IsTrue(users.Any());
            Assert.IsTrue(users.Count() == 75);
            Assert.IsInstanceOf<IQueryable<User>>(users);
        }

        [Test, Order(2)]
        public void CheckIfAbleToReturnUserById()
        {
            var userId = 1;
            var user = userRepository.Get(userId);

            Assert.IsNotNull(userId);
            Assert.IsInstanceOf<User>(user);
            Assert.AreEqual(DateTime.ParseExact("2020-04-15", "yyyy-MM-dd", new CultureInfo("en-US")), user.CreatedDate.Date);
            Assert.AreEqual(DateTime.ParseExact("2020-04-16", "yyyy-MM-dd", new CultureInfo("en-US")), user.ModifiedDate.Date);
        }

        [Test, Order(3)]
        public void CheckIfAbleToReturnUsersByFirstName()
        {
            var firstName = "Jeffry";
            var users = userRepository.GetUsersByFirstName(firstName);

            Assert.IsNotNull(users);
            Assert.IsTrue(users.Any());
            Assert.IsTrue(users.Count() >= 1);
            Assert.IsInstanceOf<IQueryable<User>>(users);
        }

        [Test, Order(4)]
        public void CheckIfAbleToReturnUsersByLastName()
        {
            var lastName = "Rosenbaum";
            var users = userRepository.GetUsersByLastName(lastName);

            Assert.IsNotNull(users);
            Assert.IsTrue(users.Any());
            Assert.IsTrue(users.Count() >= 1);
            Assert.IsInstanceOf<IQueryable<User>>(users);
        }

        [Test, Order(5)]
        public void CheckIfAbleToReturnUsersByLimit()
        {
            var limit = 3;
            var users = userRepository.GetUsersByLimit(limit);

            Assert.IsNotNull(users);
            Assert.IsTrue(users.Any());
            Assert.IsTrue(users.Count() == limit);
            Assert.IsInstanceOf<IQueryable<User>>(users);
        }

        [Test, Order(6)]
        public void CheckIfAbleToAddNewUser()
        {
            var user = new User
            {
                Title = "Ms",
                FirstName = "Sheryl",
                LastName = "Basbas",
                Email = "none@nowhere.com",
                PhoneNumber = 021343434,
                BirthDate = new DateTime(1990, 3, 2)
            };
            userRepository.Add(user);

            var users = userRepository.GetUsersByFirstName("Sheryl");
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Select(u => u.Email).Any());
            Assert.IsTrue(users.Select(u => u.Email).Any(e => e.Equals("none@nowhere.com", StringComparison.OrdinalIgnoreCase)));
        }

        [Test, Order(7)]
        public void CheckIfAbleToUpdateUser()
        {
            var user = new User
            {
                Id = 4,
                Title = "Mr",
                FirstName = "Harry",
                LastName = "Potter",
                Email = "hp@gmail.com",
                PhoneNumber = 123456,
                BirthDate = new DateTime(1988, 4, 13)
            };
            userRepository.Update(user);

            var users = userRepository.GetUsersByFirstName("Harry");
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Select(u => u.Email).Any());
            Assert.IsTrue(users.Select(u => u.Email).Any(e => e.Equals("hp@gmail.com", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(users.Select(u => u.PhoneNumber).Any(e => e.Equals(123456)));
        }

        [Test, Order(8)]
        public void CheckIfAbleToRemoveUser()
        {
            var userId = 1;
            var user = userRepository.Get(userId);
            userRepository.Delete(user);

            var userIds = userRepository.GetAll().Select(u => u.Id);
            Assert.IsTrue(userIds.Any());
            Assert.IsFalse(userIds.Any(u => u == userId));
        }
    }
}
