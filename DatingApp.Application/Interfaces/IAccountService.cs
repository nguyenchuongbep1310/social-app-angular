using DatingApp.Core.DTO;
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
    }
}
