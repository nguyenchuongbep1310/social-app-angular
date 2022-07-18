using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using DatingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PostUser> Add(PostUser post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task Delete(PostUser post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllComment(int postId)
        {
            var listComment = _context.Comments.Where(c => c.PostId == postId);
            _context.Comments.RemoveRange(listComment);
            await _context.SaveChangesAsync();
        }

        public async Task<PostUser> GetById(int postId)
        {
            return await _context.Posts.FindAsync(postId);
        }

        public async Task<List<PostUser>> GetAll(int userId)
        {
            return await _context.Posts.Where(p => p.UserId == userId).ToListAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
