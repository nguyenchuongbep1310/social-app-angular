using DatingApp.Application.DTO.Comments;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateNewComment([FromBody] AddCommentRequest request)
        {
            var newComment = await _commentService.CreateNewComment(request);

            return Ok(newComment);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteComment([FromBody] DeleteCommentRequest request)
        {
            await _commentService.DeleteComment(request);

            return NoContent();
        }
    }
}
