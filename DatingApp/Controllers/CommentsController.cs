using DatingApp.Application.DTO;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
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
    public class CommentsController : BaseApiController
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<CommentDto> CreateComment(CommentDto commentDto)
        {
            await _commentService.CreateNewComment(commentDto);

            return commentDto;
        }
    }
}
