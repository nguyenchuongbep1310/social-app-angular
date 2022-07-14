using DatingApp.Core.Entities;
using DatingApp.Core.Helpers;
using System.Threading.Tasks;

namespace DatingApp.Core.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int likedUserId);
        Task<AppUser> GetUserWithLikes(int userId);

        Task<AppUser> GetUserLikes(LikeParam likesParams);

        Task<bool> Complete();

    }
}
