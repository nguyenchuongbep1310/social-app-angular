using DatingApp.Application.Interfaces;
using DatingApp.Core.DTO;
using DatingApp.Core.Interfaces;
using DatingApp.Infrastructure.Data;
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
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly ISendMailService _sendMailService;
        public AccountService(DataContext context, ITokenService tokenService, ISendMailService sendMailService)
        {
            _tokenService = tokenService;
            _context = context;
            _sendMailService = sendMailService;
        }
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            //accountService.login(username, password);
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

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
    }
}
