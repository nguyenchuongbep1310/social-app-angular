using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.DTO
{
    public class RegisterDto
    {
        [Required]
        [StringLength(64, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string Username { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Avatar { get; set; }

    }
}