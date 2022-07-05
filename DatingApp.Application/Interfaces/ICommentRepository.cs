using DatingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> Insert(Comment comment);
        Task<Comment> Update(Comment comment);
        Task Delete(int commentId);
        Task<Comment> GetById(int commentId);
        Task<IEnumerable<Comment>> GetAllOfAPost(int postId);
    }
}
