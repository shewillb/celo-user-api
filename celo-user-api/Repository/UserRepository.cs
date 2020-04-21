using celo_user_api.Models;
using celo_user_api.Repository;
using System;
using System.Linq;

namespace celo_user_api.Repository
{
    public class UserRepository : DataRepository<User>, IUserRepository
    {
        public IQueryable<User> GetUsersByFirstName(string firstName)
        {
            return GetByCondition(u => u.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));
        }

        public IQueryable<User> GetUsersByLastName(string lastName)
        {
            return GetByCondition(u => u.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        public IQueryable<User> GetUsersByLimit(int limit)
        {
            return GetAll().OrderByDescending(u => u.ModifiedDate).Take(limit);
        }
        public UserRepository(UserDBContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
