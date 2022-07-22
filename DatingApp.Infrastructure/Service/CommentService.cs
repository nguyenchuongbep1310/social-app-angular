using DatingApp.Application.DTO.Comments;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using DatingApp.Core.Interfaces;
using DatingApp.Infrastructure.Data;
using DatingApp.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Service
{
    public class CommentService : ICommentService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public CommentService(ICommentRepository commentRepository, 
            IHubContext<BroadcastHub, IHubClient> hubContext,
            INotificationRepository notificationRepository,
            IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _hubContext = hubContext;
            _notificationRepository = notificationRepository;
            _postRepository = postRepository;
        }

        public async Task<AddCommentResponse> CreateNewComment(AddCommentRequest request)
        {
            PostComment newComment = new PostComment() {
                UserId = request.UserId,
                PostId = request.PostId,
                Text = request.Text,
            };

            var comment = await _commentRepository.Add(newComment);
            var userReceive = _postRepository.GetById(request.PostId).Result;

            Notification notification = new Notification()
            {
                Content = "comment on your post",
                Type = "Comment",
                Status = "Actived",
                UserSend = request.UserId,
                UserReceive = userReceive.UserId,
            };

            await _notificationRepository.Add(notification);
            await _hubContext.Clients.All.BroadcastMessage();

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
    }
}
