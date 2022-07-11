using DatingApp.Application.DTO;
using DatingApp.Core.DTO;
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
