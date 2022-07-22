using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Application.DTO;
using DatingApp.Application.Interfaces;
using DatingApp.Core.DTO;
using DatingApp.Core.Entities;
using DatingApp.Core.Interfaces;
using DatingApp.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Resgister([FromForm] RegisterDto registerDto)
        {          
            if (await _userRepository.CheckUsernameExist(registerDto.Username)) return BadRequest("This username is already in use. Please use another one");
            if (await _userRepository.CheckEmailExist(registerDto.Email)) return BadRequest("This email is already in use. Please use another one");

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
            var loginResult = await _accountService.Login(loginDto);

            if (loginResult.IsSuccess)
            {
                return Ok(loginResult);
            }
            else
            {
                return BadRequest(loginResult);
            }   
        }

        [Authorize]
        [HttpPatch("edit-profile")]
        public async Task<IActionResult> EditProfile([FromForm] ProfileDto profileDto)
        {
            try
            {
                await _accountService.EditProfile(profileDto);
                return Ok();
            }
            catch
            {
                return BadRequest("Error");
            }
        }

        [Authorize]
        [HttpPost("user-profile")]
        public async Task<IActionResult> GetUserProfile([FromForm] string username)
        {   
            try
            {
                ProfileInfoDto profileInfoDto = await _accountService.GetUserProfile(username);
                return Ok(profileInfoDto);
            }
            catch
            {
                return BadRequest("Error");
            }
        }
        
        
        [HttpGet("search-user-profile")]
        public async Task<IActionResult> SearchUserProfile([FromQuery] string username)
        {
            ProfileInfoDto profileInfoDto = await _accountService.GetUserProfile(username);
            return Ok(profileInfoDto);
        }
    }
}
