using DatingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Interfaces
{
    public interface ILikeRepository
    {
        Task<PostLike> Add(PostLike like);

        Task<PostLike> Update(PostLike like);

        Task Delete(PostLike like);

        Task<PostLike> GetById(int likeId);

        Task<List<PostLike>> GetAll(int postId);
    }
}
