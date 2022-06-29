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

        public async Task<PostUser> Insert(PostUser postUser)
        {
            _context.Posts.Add(postUser);
            await _context.SaveChangesAsync();

            return postUser;
        }

        public async Task Update(PostUser postUser)
        {
            _context.Entry(postUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int postId)
        {
            PostUser postToDelete = await _context.Posts.FindAsync(postId);
            _context.Posts.Remove(postToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<PostUser> GetById(int postId)
        {
            return await _context.Posts.FindAsync(postId);
        }

        public Task<IEnumerable<PostUser>> GetAllOfUser(int userId)
        {
            throw new NotImplementedException();
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
