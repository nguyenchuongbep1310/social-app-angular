using DatingApp.Application.Interfaces;
using DatingApp.Core.DTO;
using DatingApp.Core.Entities;
using DatingApp.Core.Interfaces;
using DatingApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ISendMailService _sendMailService;
        public AccountService(IUserRepository userRepository, ITokenService tokenService, ISendMailService sendMailService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _sendMailService = sendMailService;
        }
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            //accountService.login(username, password);
            //var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
            var user = await _userRepository.GetByUsername(loginDto.Username);

            if (user == null) return new UserDto { IsSuccess = false };

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) 
                {
                    return new UserDto { IsSuccess = false };
                }              
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
                IsSuccess = true
                
            };
        }

        public async Task Register(RegisterDto registerDto)
        {
            
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
            _userRepository.Insert(user);
            _userRepository.Save();

            MailContent content = new MailContent
            {
                To = user.Email,
                Subject = "Welcome to UNGAP",
                Body = "<p>Your account has been created - now it will be easier than ever to share and connect with your friends and family</p>" +
                        "<br />" +
                        "<p>Here are three ways for you to get the most out of it:</p>" +
                        "<p>+Find the people you know</p>" +
                        "<p>+Upload a Profile Photo</p>" +
                        "<p>+Edit your Profile</p>"
            };
            await _sendMailService.SendMail(content);
        }
    }
}
