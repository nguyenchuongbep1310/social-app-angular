using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.DTO
{
    public class RegisterDto
    {
        [Required]
        [StringLength(64, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z_0-9]{5,63}$", ErrorMessage = "Username is not valid.")]
        public string Username { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z])(?!.*[\s]).{2,31}$", ErrorMessage = "Password is not valid.")]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "First name is not valid.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "First name is not valid.")]
        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Avatar { get; set; }

    }
}