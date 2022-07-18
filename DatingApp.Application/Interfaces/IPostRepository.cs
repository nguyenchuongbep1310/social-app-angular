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
        Task<PostUser> Add(PostUser post);

        Task Delete(PostUser post);
        Task DeleteAllComment(int postId);
        Task DeleteAllLike(int postId);

        Task<PostUser> GetById(int postId);

        Task<List<PostUser>> GetAll(int userId);
    }
}
