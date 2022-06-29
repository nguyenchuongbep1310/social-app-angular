using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using DatingApp.Infrastructure.Data;

namespace DatingApp.Infrastructure.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(int PostId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostUser>> GetAll()
        {
            throw new NotImplementedException();
        }

       
        public void Insert(PostUser postUser)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(PostUser postUser)
        {
            throw new NotImplementedException();
        }
    }
}
