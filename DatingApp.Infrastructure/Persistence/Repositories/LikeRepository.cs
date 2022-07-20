using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using DatingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Persistence.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly DataContext _context;
        public LikeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PostLike> Add(PostLike like)
        {
            _context.Likes.Add(like);
            await _context.SaveChangesAsync();
            return like;
        }

        public async Task Delete(PostLike like)
        {
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PostLike>> GetAll(int postId)
        {         
            return await _context.Likes.Where(l => l.PostId == postId).ToListAsync();
        }

        public async Task<PostLike> GetById(int likeId)
        {
            return await _context.Likes.FindAsync(likeId);
        }

        public async Task<PostLike> Update(PostLike like)
        {
            _context.Entry(like).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Likes.FindAsync(like.Id);
        }
    }
}
