using celo_user_api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace celo_user_api.Utils
{
    public static class UserDataMock
    {
        public static IEnumerable<User> GetUsersWithAutoIncrement(string usersDataPath)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(usersDataPath));
            return users.Select((u, i) => new User
            {
                Id = i + 1,
                Title = u.Title,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                BirthDate = u.BirthDate,
                CreatedDate = u.CreatedDate,
                ModifiedDate = u.ModifiedDate,
                PhoneNumber = u.PhoneNumber,
            });
        }      
    }
}
