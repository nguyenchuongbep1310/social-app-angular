using DatingApp.Application.DTO.Posts;
using DatingApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostsOfAUser([FromQuery] GetUserPostRequest request)
        {
            var postsUser = await _postService.GetAllPostOfUser(request);
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
            await _postService.DeletePost(request);
            return Ok();
        }   
    }
}
