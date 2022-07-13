using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.DTO.Comments
{
    public class DeleteCommentRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
