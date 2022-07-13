using DatingApp.Application.DTO.Comments;
using DatingApp.Application.DTO.Likes;
using DatingApp.Application.DTO.Posts;
using DatingApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Application.Interfaces
{
    public interface IPostService
    {
        Task<AddPostResponse> CreateNewPost(AddPostRequest request);
        Task DeletePost(DeletePostRequest request);
        Task<GetPostResponse> GetPostById(GetPostRequest request);
        Task<List<GetUserPostResponse>> GetAllPostOfUser(GetUserPostRequest request);
        Task<GetLikeResponse> CountLikeOfPost(int id);
        Task<List<GetCommentResponse>> GetAllCommentOfAPost(int postId);
    }
}
