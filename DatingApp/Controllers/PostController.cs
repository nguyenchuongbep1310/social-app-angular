using DatingApp.Application.DTO;
using DatingApp.Application.DTO.Posts;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using DatingApp.Core.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService, ILikeService likeService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostsOfAUser([FromQuery] GetUserPostRequest request)
        {
            var postsUser = await _postService.GetAllPostOfUser(request);
            return Ok(postsUser);
        }

        [HttpGet]
        [Route("FriendPosts")]
        public async Task<IActionResult> GetAllPostsOfAUserAndFriend([FromQuery] GetUserPostRequest request)
        {
            var postsUser = _postService.GetAllPostOfUserAndFriend(request);
            return Ok(postsUser);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById([FromQuery] GetPostRequest request)
        {
            var postUser = await _postService.GetPostById(request);
            return Ok(postUser);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateNewPost([FromForm] AddPostRequest request)
        {
            var newPost = await _postService.CreateNewPost(request);
            return Ok(newPost);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeletePost([FromForm] DeletePostRequest request)
        {
            int currentLoginUserId = User.GetUserId();
            if (currentLoginUserId != request.UserId) return BadRequest("You do not have permisson to do this action.");

            await _postService.DeletePost(request);
            return Ok();
        }

        [HttpGet("{postId}/CountLikes")]
        public async Task<IActionResult> CountLikeOfPost(int postId)
        {
            var updatedLike = await _postService.CountLikeOfPost(postId);
            return Ok(updatedLike);
        }

        [HttpGet("{postId}/GetComments")]
        public async Task<IActionResult> GetAllCommentOfAPost(int postId)
        {
            var commentsOfPost = await _postService.GetAllCommentOfAPost(postId);

            return Ok(commentsOfPost);
        }
    }
}
