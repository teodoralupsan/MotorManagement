using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repositories;
using Domain.Dtos;
using Domain.Models;

namespace Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IList<UserDto>> GetUsersWithRolesAsync()
        {
            IList<User> dbUsers = await _usersRepository.GetUsersAsync();
            IList<Role> dbRoles = await _usersRepository.GetRolesAsync();
            return dbUsers
                .OrderBy(x => x.Id)
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = (from userRole in user.UserRoles
                             join role in dbRoles
                             on userRole.RoleId
                             equals role.Id
                             select role.Name).ToList()
                }).ToList();
        }
    }
}
