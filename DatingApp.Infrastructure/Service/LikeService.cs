using DatingApp.Application.DTO.Likes;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
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

        public LikeService(ILikeRepository likeRepository, IPostRepository _postRepository)
        {
            _likeRepository = likeRepository;
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

            return new AddLikeResponse
            {
                Id = newLike.Id,
                PostId = newLike.PostId,
                UserId = newLike.UserId,
            };
        }

        public async Task<UpdateLikeResponse> UpdateLike(UpdateLikeRequest request)
        {
            var updateLike = await _likeRepository.GetById(request.Id);
            switch (updateLike.Status)
            {
                case "Actived":
                    updateLike.Status = "Deleted";
                    break;
                case "Deleted":
                    updateLike.Status = "Actived";
                    break;
                default:
                    break;
            }

            var updatedLike = await _likeRepository.Update(updateLike);

            return new UpdateLikeResponse
            {
                Id = updatedLike.Id,
                PostId = updatedLike.PostId,
                UserId = updatedLike.UserId,
                Status = updatedLike.Status,
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
    }
}
