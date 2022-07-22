using DatingApp.Core.Entities;
using DatingApp.Core.Helpers;
using DatingApp.Core.Interfaces;
using DatingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Persistence.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly DataContext _context;
        public FriendRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserFriend> GetUserFriend(int sourceUserId, int likedUserId)
        {
            return await _context.Friends.FindAsync(sourceUserId, likedUserId);
        }

        public async Task<AppUser> GetUserWithFriends(int userId)
        {
            return await _context.Users.Include(x => x.FriendUsers).FirstOrDefaultAsync(x => x.Id == userId);
        }
        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }    
    }
}
