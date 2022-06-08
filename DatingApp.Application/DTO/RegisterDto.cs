using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Core.DTO
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Please enter your username")]
        [MinLength(6, ErrorMessage = "The username must be at least 6 characters long. Please use another one")]
        [MaxLength(32, ErrorMessage = "The username is limit on the number of 32 characters. Please use another one")]
        [RegularExpression(@"^(?=[a-zA-Z])(?!.*[_]{2})[a-zA-Z0-9_]+(?<![_])$", ErrorMessage = "The username is invalid. " +
                                                                            "Please use another one which not start with a number " +
                                                                            "and not contain special characters, spaces or symbols")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long. Please use another one")]
        [MaxLength(32, ErrorMessage = "The password is limit on the number of 32 characters. Please use another one")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z]).{7,31}$",
                            ErrorMessage = "Please enter your password with at least 1 uppercase and 1 number")]
        //[RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z])(?!.*[\s]).{2,31}$", 
        //                    ErrorMessage = "Please enter your password with at least 1 uppercase and 1 number")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Please enter your first name")]
        [MinLength(1, ErrorMessage = "The first name must be at least 1 characters long. Please use another one")]
        [MaxLength(50, ErrorMessage = "The first name is limit on the number of 50 characters. Please use another one")]
        [RegularExpression(@"^[\p{L}0-9]*$", ErrorMessage = "First name is not valid. " +
                                                            "Please use another one which does not contain special characters" +
                                                              @"`~!@#$%^&*()-_+=[]\|;:'<,>.?/")]
        //[RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "First name is not valid. " +
        //                                                    "Please use another one which does not contain special characters" +
        //                                                      @"`~!@#$%^&*()-_+=[]\|;:'<,>.?/")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [MinLength(1, ErrorMessage = "The last name must be at least 1 characters long. Please use another one")]
        [MaxLength(50, ErrorMessage = "The last name is limit on the number of 50 characters. Please use another one")]
        [RegularExpression(@"^[\p{L}\s0-9]*$", ErrorMessage = "Last name is not valid. " +
                                                            "Please use another one which does not contain special characters" +
                                                                @"`~!@#$%^&*()-_+=[]\|;:'<,>.?/")]
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Last name is not valid. " +
        //                                                    "Please use another one which does not contain special characters" +
        //                                                        @"`~!@#$%^&*()-_+=[]\|;:'<,>.?/")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        [RegularExpression("^[a-z0-9]*([a-z0-9_.-])(?!.*[_.-]{2})*[a-z0-9]+@gmail.com$", ErrorMessage = @"Must be a valid email which consists of lowercase alphabet letters, numbers, underscores '_', periods '.'. An underscore, period must be followed by one or more letter or number. An email domain format is just only gmail.com")]
        public string Email { get; set; }


        public string DateOfBirth { get; set; }

        public string Gender { get; set; }

        [RegularExpression(@"^[0][0-9]{9}$", ErrorMessage = "Please enter a valid phone number which starts with 0 and must have 10 digits")]
        public string Phone { get; set; }

        public string Avatar { get; set; }

    }
}