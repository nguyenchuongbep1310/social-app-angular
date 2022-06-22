using DatingApp.Application.DTO;
using DatingApp.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Interfaces
{
    public interface IAccountService
    {
        Task <UserDto> Login(LoginDto loginDto);

        Task Register(RegisterDto registerDto);

        Task EditProfile(ProfileDto profileDto);

        Task <ProfileInfoDto> GetUserProfile(string username);
    }
}
