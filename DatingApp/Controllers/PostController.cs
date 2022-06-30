using DatingApp.Application.DTO;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
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

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllPostsOfAUser(int userId)
        {
            if (userId == 0) return BadRequest();

            var postsUser = await _postService.GetAllPostsOfUser(userId);

            return Ok(postsUser);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById(int postId, int userId)
        {
            var postUser = await _postService.GetById(postId, userId);
            if (postUser == null) return BadRequest();

            return Ok(postUser);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] PostDto postDto)
        {
            if (!await _postService.Create(postDto)) return BadRequest();

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> EditPost([FromForm] PostDto postDto, int postId)
        {
            if (!await _postService.Update(postDto, postId)) return BadRequest();

            return Ok();
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId, int userId)
        {
            if (!await _postService.Delete(postId, userId)) return BadRequest();

            return NoContent();
        }   
    }
}
