using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Core.Entities;
using DatingApp.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{

    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();

        }

        //api/users/3
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsersById (int id)
        {
            return await _context.Users.FindAsync(id);
        }

        
    }
}