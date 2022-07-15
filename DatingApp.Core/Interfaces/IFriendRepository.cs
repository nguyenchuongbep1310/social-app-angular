using DatingApp.Core.Entities;
using DatingApp.Core.Helpers;
using System.Threading.Tasks;

namespace DatingApp.Core.Interfaces
{
    public interface IFriendRepository
    {
        Task<UserFriend> GetUserLike(int sourceUserId, int likedUserId);
        Task<AppUser> GetUserWithLikes(int userId);

        Task<AppUser> GetUserLikes(FriendParam likesParams);

        Task<bool> Complete();

    }
}
