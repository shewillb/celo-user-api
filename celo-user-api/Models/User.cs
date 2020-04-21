using celo_user_api.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace celo_user_api.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LastName  { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
