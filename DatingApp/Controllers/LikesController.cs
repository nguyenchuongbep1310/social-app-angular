using DatingApp.Application.DTO.Likes;
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
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;
        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateNewLike([FromForm] AddLikeRequest request)
        {
            var newLike = await _likeService.CreateNewLike(request);
            return Ok(newLike);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLike(int id)
        {
            int currentLoginUserId = User.GetUserId();
            try
            {
                await _likeService.DeleteLike(id, currentLoginUserId);
                return NoContent();
            }
            catch(Exception)
            {
                return BadRequest("You do not have permisson to do this action.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLikeOfCurrentUser([FromQuery] GetLikeRequest request)
        {
            var likeOfCurrentUser = await _likeService.GetLikeOfCurrentUser(request);
            return Ok(likeOfCurrentUser);
        }
    }
}
