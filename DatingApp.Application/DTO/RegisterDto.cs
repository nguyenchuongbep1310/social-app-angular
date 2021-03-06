using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Core.DTO
{
    public class RegisterDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }
       
        public string Phone { get; set; }

        public IFormFile Avatar { get; set; }
    }
}