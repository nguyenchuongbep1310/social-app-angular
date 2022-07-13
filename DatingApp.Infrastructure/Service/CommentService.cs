using DatingApp.Application.DTO.Comments;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using DatingApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<AddCommentResponse> CreateNewComment(AddCommentRequest request)
        {
            PostComment newComment = new PostComment() {
                UserId = request.UserId,
                PostId = request.PostId,
                Text = request.Text,
            };

            var comment = await _commentRepository.Add(newComment);

            return new AddCommentResponse
            {
                Id = comment.Id,
                PostId = comment.PostId,
                UserId = comment.UserId,
                Text = comment.Text,
            };
        }

        public async Task DeleteComment(DeleteCommentRequest request)
        {      
            PostComment commentToDelete = await _commentRepository.GetById(request.Id);
            await _commentRepository.Delete(commentToDelete);
        }

        public Task UpdateComment(UpdateCommentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
