using DatingApp.Application.DTO.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Interfaces
{
    public interface ILikeService
    {
        Task<AddLikeResponse> CreateNewLike(AddLikeRequest request);
        Task UpdateLike(UpdateLikeRequest request);
    }
}
