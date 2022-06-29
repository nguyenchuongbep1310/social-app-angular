using DatingApp.Application.DTO;
using DatingApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Interfaces
{
    public interface IPostService
    {
        Task<bool> Create(PostDto postDto);
        Task<bool> Update(PostDto postDto, int postId);
        Task<bool> Delete(int postId, int userId);
        Task<PostUser> GetById(int postId, int userId);
        Task<IEnumerable<PostUser>> GetAllPostsOfUser(int userId);
    }
}
