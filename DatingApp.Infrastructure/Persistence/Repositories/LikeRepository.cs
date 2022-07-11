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

        public Task Delete(PostLike like)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostLike>> GetAll(int likeId)
        {
            throw new NotImplementedException();
        }

        public Task<PostLike> GetById(int likeId)
        {
            throw new NotImplementedException();
        }

        public async Task<PostLike> Update(PostLike like)
        {
            _context.Entry(like).State = EntityState.Modified;
            return await _context.Likes.FindAsync(like.Id);
        }
    }
}
