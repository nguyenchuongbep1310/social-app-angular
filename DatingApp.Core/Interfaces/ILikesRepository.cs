using API.Helpers;
using DatingApp.Core.Entities;
using DatingApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int likedUserId);
        Task<AppUser> GetUserWithLikes(int userId);

        Task<PagedList<AppUser>> GetUserLikes(LikeParam likesParams);

    }
}
