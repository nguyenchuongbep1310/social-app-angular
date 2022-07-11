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
        private readonly IPostRepository _postRepository;

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

        public Task UpdateLike(UpdateLikeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
