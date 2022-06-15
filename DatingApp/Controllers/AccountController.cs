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
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IAccountService _accountService;
        public AccountController(DataContext context, ITokenService tokenService, IAccountService accountService)
        {
            _tokenService = tokenService;
            _context = context;
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Resgister(RegisterDto registerDto)
        {
            if (!CheckConfirmPassword(registerDto)) return BadRequest("The confirm password is not match with password. Please re-enter your password");
            if (await UserExists(registerDto.Username)) return BadRequest("This username is already in use. Please use another one");
            if (await EmailExists(registerDto.Email)) return BadRequest("This email is already in use. Please use another one");
            if (!CheckValidDOB(registerDto.DateOfBirth)) return BadRequest("Please re-enter your date of birth following format dd/mm/yyyy");
            if (!CheckUserAge(registerDto.DateOfBirth)) return BadRequest("To be eligible to sign up for Ungap, you must be at least 13 years old");

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

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

        private async Task<bool> EmailExists(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email.ToLower());
        }

        private bool CheckConfirmPassword(RegisterDto registerDto)
        {
            return registerDto.Password == registerDto.ConfirmPassword;
        }


        //dob = date of birth
        private bool CheckValidDOB(string dob)
        {
            try
            {
                if (dob == null || dob == "") return true;
                DateTime dt = DateTime.ParseExact(dob, "d/M/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool CheckUserAge(string dob)
        {
            try
            {
                DateTime dt = DateTime.ParseExact(dob, "d/M/yyyy", CultureInfo.InvariantCulture);
                if (DateTime.Now.Year - dt.Year >= 13) return true;
            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}
