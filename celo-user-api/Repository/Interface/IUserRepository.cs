using celo_user_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace celo_user_api.Repository
{
    public interface IUserRepository : IDataRepository<User>
    {
        IQueryable<User> GetUsersByLimit(int limit);

        IQueryable<User> GetUsersByFirstName(string firstName);

        IQueryable<User> GetUsersByLastName(string lastName);
    }
}
