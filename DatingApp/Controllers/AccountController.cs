using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Application.Interfaces;
using DatingApp.Core.DTO;
using DatingApp.Core.Entities;
using DatingApp.Core.Interfaces;
using DatingApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountService _accountService;
        public AccountController(IUserRepository userRepository, IAccountService accountService)
        {
            _userRepository = userRepository;
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Resgister(RegisterDto registerDto)
        {
            if (await this._userRepository.CheckUsernameExist(registerDto.Username))
            {
                return BadRequest("This username is already in use. Please use another one");
            } 

            if (await this._userRepository.CheckEmailExist(registerDto.Email)) return BadRequest("This email is already in use. Please use another one");

            await _accountService.Register(registerDto);

            return Ok(new
            {
                success = true,
                message = "Your account has been created",
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {

            var loginResult = await this._accountService.Login(loginDto);
            if (loginResult.IsSuccess)
            {
                return Ok(loginResult);
            }

            else
            {
                return BadRequest(loginResult);
            }
            
        }

        //private async Task<bool> UserExists(string username)
        //{
        //    return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        //}

        //private async Task<bool> EmailExists(string email)
        //{
        //    return await _context.Users.AnyAsync(x => x.Email == email.ToLower());
        //}

        //private async Task<bool> EmailExists(string userEmail)
        //{
        //    return await _userRepository.EmailExist(userEmail);
        //}
    }
}
