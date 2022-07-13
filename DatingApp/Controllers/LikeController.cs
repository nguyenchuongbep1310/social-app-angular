using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using DatingApp.Core.Extension;
using DatingApp.Core.Helpers;
using DatingApp.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikesRepository _likesRepository;
        private readonly IUserRepository _userRepository;
    

        public LikeController(ILikesRepository likesRepository, IUserRepository userRepository)
        {
            _likesRepository = likesRepository;
            _userRepository = userRepository;
        }
        [HttpPost("{username}")]
        public async Task<ActionResult> AddLike(string username)
        {
            var sourceUserId = User.GetUserId();
            var likedUser = await _userRepository.GetByUsername(username);
            var sourceUser = await _likesRepository.GetUserWithLikes(sourceUserId);

            if (likedUser == null) return NotFound();

            if (sourceUser.UserName == username) return BadRequest("You cannot like yourself");

            var userLike = await _likesRepository.GetUserLike(sourceUserId, likedUser.Id);

            if (userLike != null) return BadRequest("You already like this user");

            userLike = new UserLike
            {
                SourceUserId = sourceUserId,
                LikedUserId = likedUser.Id
            };

            sourceUser.LikedUsers.Add(userLike);

            return Ok();

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUserLikes([FromQuery] LikeParam likesParams, int id)
        {
            likesParams.UserId = User.GetUserId();
            var users = await _likesRepository.GetUserLikes(likesParams);

            return Ok(users);
        }
    }
}
