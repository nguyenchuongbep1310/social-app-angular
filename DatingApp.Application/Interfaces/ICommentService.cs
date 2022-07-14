using DatingApp.Application.DTO.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Interfaces
{
    public interface ICommentService
    {
        Task<AddCommentResponse> CreateNewComment(AddCommentRequest request);
        Task DeleteComment(DeleteCommentRequest request);
    }
}
