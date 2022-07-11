using System;
using System.Globalization;

using DatingApp.Core.DTO;
using FluentValidation;

namespace DatingApp.Application.Validation
{
    public class RegisterDtoValidation : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            // config level for validation
            // when a rule/validation is fails, the validation is stopped for the current rule/validation
            RuleLevelCascadeMode = CascadeMode.Stop;

            // validation username
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Please enter your username")
                .NotNull().WithMessage("Please enter your username")
                .MinimumLength(6).WithMessage("The username must be at least 6 characters long. Please use another one")
                .MaximumLength(32).WithMessage("The username is limit on the number of 32 characters. Please use another one")
                .Matches(@"^(?=[a-zA-Z])(?!.*[_]{2})[a-zA-Z0-9_]+(?<![_])$").WithMessage("The username is invalid. Please use another one which not start with a number and not contain special characters, spaces or symbols");

            // validation password
            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Please enter your password")
                .NotNull().WithMessage("Please enter your password")
                .MinimumLength(8).WithMessage("The username must be at least 8 characters long. Please use another one")
                .MaximumLength(32).WithMessage("The username is limit on the number of 32 characters. Please use another one")
                .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z])(?!.*[\s]).{2,31}$").WithMessage("Please enter your password with at least 1 uppercase and 1 number")
                .DependentRules(() =>
                {
                    // validaton confirm password
                    RuleFor(user => user.ConfirmPassword)
                        .NotEmpty().WithMessage("Please enter your confirm password")
                        .NotNull().WithMessage("Please enter your confirm password")
                        .Equal(user => user.Password).WithMessage("The password you entered does not match. Please re-enter your password");
                });
            

            // validation first name
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("Please enter your first name")
                .NotNull().WithMessage("Please enter your first name")
                .MinimumLength(1).WithMessage("The first name must be at least 1 characters long. Please use another one")
                .MaximumLength(50).WithMessage("The first name is limit on the number of 50 characters. Please use another one")
                .Matches(@"^[\p{L}0-9]*$").WithMessage("First name is not valid. Please use another one which does not contain special characters " + @"`~!@#$%^&*()-_+=[]\|;:'<,>.?/");

            // validation last name
            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Please enter your last name")
                .NotNull().WithMessage("Please enter your last name")
                .MinimumLength(1).WithMessage("The last name must be at least 1 characters long. Please use another one")
                .MaximumLength(50).WithMessage("The last name is limit on the number of 50 characters. Please use another one")
                .Matches(@"^[\p{L}\s0-9]*$").WithMessage("Last name is not valid. Please use another one which does not contain special characters " + @"`~!@#$%^&*()-_+=[]\|;:'<,>.?/");

            // validation date of birth
            RuleFor(user => user.DateOfBirth)
                .NotEmpty().WithMessage("Please enter your date of birth")
                .NotNull().WithMessage("Please enter your date of birth")
                .Matches(@"^(0?[1-9]|[12][0-9]|3[01])([ \/\-])(0?[1-9]|1[012])\2([0-9][0-9][0-9][0-9])(([ -])([0-1]?[0-9]|2[0-3]):[0-5]?[0-9]:[0-5]?[0-9])?$").WithMessage("Please re-enter your date of birth following format dd/mm/yyyy")
                .Must(CheckUserAgeValid).WithMessage("To be eligible to sign up for Ungap, you must be at least 13 years old");       

            // validation email
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Please enter your email")
                .NotNull().WithMessage("Please enter your email")
                .Matches(@"^[a-z0-9]*([a-z0-9_.-])(?!.*[_.-]{2})*[a-z0-9]+@gmail\.com$").WithMessage("Must be a valid email which consists of lowercase alphabet letters, numbers, underscores '_', periods '.'. An underscore, period must be followed by one or more letter or number. An email domain format is just only gmail.com");

            // validation phone number
            RuleFor(user => user.Phone)
                .Matches(@"^([0][0-9]{9})*$").WithMessage("Please enter a valid phone number which starts with 0 and must have 10 digits.");

        }

        private bool CheckUserAgeValid(string dateOfBirth)
        {
            try
            {
                DateTime dtDateOfBirth = DateTime.ParseExact(dateOfBirth, "d/M/yyyy", CultureInfo.InvariantCulture);
                if (DateTime.Now.Year - dtDateOfBirth.Year >= 13) return true;
            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}
