using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUsersService
    {
        Task<IList<UserDto>> GetUsersWithRolesAsync();
    }
}
