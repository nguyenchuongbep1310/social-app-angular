using DatingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.Interfaces
{
    public interface ICommentRepository
    {
        Task<PostComment> Add(PostComment comment);

        Task<PostComment> Update(PostComment comment);

        Task Delete(PostComment comment);

        Task<PostComment> GetById(int commentId);

        Task<List<PostComment>> GetAll(int postId);
    }
}
