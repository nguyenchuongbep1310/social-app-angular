using DatingApp.Core.Entities;

namespace DatingApp.Core.Interfaces
{
    public interface ITokenService
    {
         string CreateToken(AppUser user);
    }
}