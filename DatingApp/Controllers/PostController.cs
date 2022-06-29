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
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<PostUser>> PostUsers()
        {
            return await _postRepository.Post();
        }
    }
}
