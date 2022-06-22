using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    public class ImageController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetImage()
        {
            var fstrem = await System.IO.File.ReadAllBytesAsync(@"./Share/Images/test.jpg");
            return File(fstrem, "application/octet-stream");
        }
    }
}
