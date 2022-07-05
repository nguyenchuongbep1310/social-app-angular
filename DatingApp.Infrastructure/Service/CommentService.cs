using DatingApp.Application.DTO;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
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

        public async Task<Comment> CreateNewComment(CommentDto commentDto)
        {
            Comment newComment = new Comment();
            newComment.Text = commentDto.Text;
            newComment.UserId = commentDto.UserId;
            newComment.PostId = commentDto.PostId;
            newComment.CreatedDate = DateTime.Now;
            newComment.UpdatedDate = DateTime.Now;

            return await _commentRepository.Insert(newComment);
        }

        public async Task DeleteComment(int commentId)
        {
           await _commentRepository.Delete(commentId);
        }

        public async Task<IEnumerable<Comment>> GetAllCommentOfAPost(int postId)
        {
            return await _commentRepository.GetAllOfAPost(postId);
        }

        public async Task<Comment> GetCommentById(int commentId)
        {
            return await _commentRepository.GetById(commentId);
        }

        public async Task<Comment> UpdateComment(string commentContent, int commentId)
        {
            Comment commentToUpdate = await _commentRepository.GetById(commentId);
            commentToUpdate.Text = commentContent;
            commentToUpdate.UpdatedDate = DateTime.Now;

            return await _commentRepository.Update(commentToUpdate);
        }
    }
}
