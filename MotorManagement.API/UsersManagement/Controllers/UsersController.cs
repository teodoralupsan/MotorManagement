using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace UsersManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            IList<UserDto> userList = await _usersService.GetUsersWithRolesAsync();
            return Ok(userList);
        }
    }
}