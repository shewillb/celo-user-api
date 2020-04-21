using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace celo_user_api.Models.Interface
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
