using DatingApp.Application.DTO.Comments;
using DatingApp.Application.Interfaces;
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

        [HttpPost]
        public async Task<IActionResult> CreateNewComment([FromBody] AddCommentRequest request)
        {
            var newComment = await _commentService.CreateNewComment(request);

            return Ok(newComment);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment([FromBody] DeleteCommentRequest request)
        {
            await _commentService.DeleteComment(request);

            return NoContent();
        }
    }
}
