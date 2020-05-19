using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUsersRepository
    {
        Task<IList<User>> GetUsersAsync();
        Task<IList<Role>> GetRolesAsync();
    }
}
