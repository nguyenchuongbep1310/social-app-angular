using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Application.DTO;
using DatingApp.Core.DTO;
using FluentValidation;

namespace DatingApp.Application.Validation
{
    public class PostDtoValidation : AbstractValidator<PostDto>
    {
        public PostDtoValidation()
        {
            // config level for validation
            // when a rule/validation is fails, the validation is stopped for the current rule/validation
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(post => post.UserId)
                .NotEmpty().WithMessage("Please enter userId")
                .NotNull().WithMessage("Please enter userId");

            RuleFor(post => post.Text)
                .MaximumLength(32).WithMessage("The maximum length of uploaded status is 1000 words. Please try again.");
        }
    }
}
