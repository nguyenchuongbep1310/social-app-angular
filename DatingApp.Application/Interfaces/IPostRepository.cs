using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Core.Entities;

namespace DatingApp.Application.Interfaces
{
    public interface IPostRepository
    {
        Task<PostUser> Insert(PostUser postUser);
        Task Update(PostUser postUser);
        Task Delete(int postId);
        Task<PostUser> GetById(int postId);
        Task<IEnumerable<PostUser>> GetAllOfAUser(int userId);
    }
}
