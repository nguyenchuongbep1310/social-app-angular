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
        private readonly ISendMailService _sendMailService;

        public AccountController(DataContext context, ITokenService tokenService, ISendMailService sendMailService)
        {
            _tokenService = tokenService;
            _context = context;
            _sendMailService = sendMailService;
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

            MailContent content = new MailContent
            {
                To = "trung.pv194@gmail.com",
                Subject = "Welcome to UNGAP",
                Body = "<p>Your account has been created - now it will be easier than ever to share and connect with your friends and family</p>" +
                        "<br />" +
                        "<p>Here are three ways for you to get the most out of it:</p>" +
                        "<p>+Find the people you know</p>"+ 
                        "<p>+Upload a Profile Photo</p>"+ 
                        "<p>+Edit your Profile</p>"
            };
            await _sendMailService.SendMail(content);

            return Ok( new
            {
                success = true,
                message = "Your account has been created",
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null) return NotFound("The username does not exist.");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("The password that you've entered is incorrect. Please re-enter your password");
            }

            // return new UserDto{
            //    Username = user.UserName,
            //    Token = _tokenService.CreateToken(user)
            //};

            return Ok(new
            {
                success = true,
                message = "Login successfully",
            });
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
