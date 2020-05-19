using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            return await _context.Users.Include(x => x.UserRoles).ToListAsync();
        }

        public async Task<IList<Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
