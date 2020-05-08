using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Repositories;
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

        public async Task<IList<User>> GetUsersAsync()
        {
            return await _usersRepository.GetUsersAsync();
        }
    }
}
