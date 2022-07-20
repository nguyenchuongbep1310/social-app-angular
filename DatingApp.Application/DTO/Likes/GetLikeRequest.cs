using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.DTO.Likes
{
    public class GetLikeRequest
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
