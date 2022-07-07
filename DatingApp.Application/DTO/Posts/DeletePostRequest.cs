using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.DTO.Posts
{
    public class DeletePostRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
