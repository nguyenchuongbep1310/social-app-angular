using Microsoft.AspNetCore.Http;

namespace DatingApp.Application.DTO
{
    public class PostDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public IFormFile Images { get; set; }
    }
}
