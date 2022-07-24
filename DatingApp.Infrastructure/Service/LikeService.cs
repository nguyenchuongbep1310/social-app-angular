using DatingApp.Application.DTO.Likes;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using DatingApp.Core.Interfaces;
using DatingApp.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Service
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IPostRepository _postRepository;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly INotificationRepository _notificationRepository;

        public LikeService(
            IHubContext<BroadcastHub, IHubClient> hubContext,
            INotificationRepository notificationRepository,
            ILikeRepository likeRepository, 
            IPostRepository postRepository)
        {
            _likeRepository = likeRepository;
            _postRepository = postRepository;
            _hubContext = hubContext;
            _notificationRepository = notificationRepository;
        }

        public async Task<AddLikeResponse> CreateNewLike(AddLikeRequest request)
        {
            PostLike newLike = new PostLike();
            newLike.UserId = request.UserId;
            newLike.PostId = request.PostId;
            newLike.CreatedDate = DateTime.Now;
            newLike.UpdatedDate = DateTime.Now;
            newLike.Status = "Actived";

            await _likeRepository.Add(newLike);
            var userReceive = _postRepository.GetById(request.PostId).Result;

            if(userReceive.UserId != request.UserId)
            {
                Notification notification = new Notification()
                {
                    Content = "like on your post",
                    Status = "Actived",
                    Type = "Like",
                    UserSend = request.UserId,
                    UserReceive = userReceive.UserId,
                };

                await _notificationRepository.Add(notification);
                await _hubContext.Clients.All.BroadcastMessage();
            }       

            return new AddLikeResponse
            {
                Id = newLike.Id,
                PostId = newLike.PostId,
                UserId = newLike.UserId,
            };
        }

        public async Task<GetLikeResponse> GetLikeOfCurrentUser(GetLikeRequest request)
        {
            var likes = await _likeRepository.GetAll(request.PostId);
            var like = likes.SingleOrDefault(l => l.UserId == request.UserId);

            if (like == null) return null;

            return new GetLikeResponse {
                Id = like.Id,
                PostId = like.PostId,
                UserId = like.UserId,
                Status = like.Status,
            };
        }

        public async Task DeleteLike(int id, int userCreatedId)
        {
            var likeToDelete = await _likeRepository.GetById(id);
            if (likeToDelete != null)
            {
                if (likeToDelete.UserId != userCreatedId) throw new Exception();
                await _likeRepository.Delete(likeToDelete);
            }
        }
    }
}
