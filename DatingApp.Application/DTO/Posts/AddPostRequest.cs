﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.DTO.Posts
{
    public class AddPostRequest
    {
        public int UserId { get; set; }
        public string Text { get; set; }
        public IFormFile Image { get; set; }
    }
}
