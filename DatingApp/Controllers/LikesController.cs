using DatingApp.Application.DTO.Likes;
using DatingApp.Application.Interfaces;
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
            try
            {
                var newLike = await _likeService.CreateNewLike(request);
                return Ok(newLike);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLike(int id)
        {
            await _likeService.DeleteLike(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetLikeOfCurrentUser([FromQuery] GetLikeRequest request)
        {
            var likeOfCurrentUser = await _likeService.GetLikeOfCurrentUser(request);
            return Ok(likeOfCurrentUser);
        }
    }
}
