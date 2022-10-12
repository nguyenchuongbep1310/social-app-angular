using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using DatingApp.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{

    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await _userRepository.GetAll();
        }

        //api/users/3
        [Authorize]
        [HttpGet("{id}")]
        public async Task<AppUser> GetUsersById (int id)
        {
            return await _userRepository.GetById(id);
        }

        
    }
}