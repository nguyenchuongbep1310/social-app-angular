using DatingApp.Application.DTO;
using DatingApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Application.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> CreateNewComment(CommentDto commentDto);
        Task<Comment> UpdateComment(string text, int commentId);
        Task DeleteComment(int commentId);
        Task<Comment> GetCommentById(int commentId); 
        Task<IEnumerable<Comment>> GetAllCommentOfAPost(int postId);
    }
}
