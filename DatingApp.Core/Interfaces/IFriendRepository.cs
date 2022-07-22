﻿using DatingApp.Core.Entities;
using DatingApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.Interfaces
{
    public interface IFriendRepository
    {
        Task<UserFriend> GetUserFriend(int sourceUserId, int likedUserId);
        Task<AppUser> GetUserWithFriends(int userId);
        Task<bool> Complete();

    }
}
