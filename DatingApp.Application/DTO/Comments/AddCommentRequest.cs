﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.DTO.Comments
{
    public class AddCommentRequest
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
