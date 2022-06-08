using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Resgister(RegisterDto registerDto)
        {
            if (!CheckConfirmPassword(registerDto)) return BadRequest("The confirm password is not match with password. Please re-enter your password");
            if (await UserExists(registerDto.Username)) return BadRequest("This username is already in use. Please use another one");
            if (await EmailExists(registerDto.Email)) return BadRequest("This email is already in use. Please use another one");
            if (!CheckValidDOB(registerDto.DateOfBirth)) return BadRequest("Please re-enter your date of birth following format dd/mm/yyyy");
            if(!CheckUserAge(registerDto.DateOfBirth)) return BadRequest("To be eligible to sign up for Ungap, you must be at least 13 years old");

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = registerDto.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,

                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                DateOfBirth = registerDto.DateOfBirth,
                Gender = registerDto.Gender,
                Email = registerDto.Email,
                Phone = registerDto.Phone,
                Avatar = registerDto.Avatar,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok( new
            {
                success = true,
                message = "Your account is created",
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null) return Unauthorized("The username does not exist.");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("The password that you've entered is incorrect. Please re-enter your password");
            }

             return new UserDto{
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
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
