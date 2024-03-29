﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.Extension
{
    public static class ClaimsPrincipleExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst("Id")?.Value);
        }
    }
}
