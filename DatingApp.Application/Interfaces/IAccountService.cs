using DatingApp.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatingApp.Application.DTO;

namespace DatingApp.Application.Interfaces
{
    public interface IAccountService
    {
        Task <UserDto> Login(LoginDto loginDto);

        Task Register(RegisterDto registerDto);
    }
}
